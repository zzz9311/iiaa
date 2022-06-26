using AspNetCore.Unobtrusive.Ajax;
using IvritSchool.BLL.Days;
using IvritSchool.BLL.Messages;
using IvritSchool.BLL.Tariffs;
using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Repository;
using IvritSchool.Senders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IvritSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<BotUser> _userRepository;
        private readonly IRepository<Days> _daysRepository;
        private readonly IRepository<Tariff> _tariffRepository;
        private readonly IRepository<Entities.Message> _messageRepository;
        private readonly IRepository<Entities.PayedUsers> _payedUsersRepository;
        private readonly IUserBLL _userBLL;
        private readonly IDayBLL _dayBLL;
        private readonly ITariffBLL _tariffBLL;
        private readonly IMessageBLL _messageBLL;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ISender _sender;

        public HomeController(IRepository<BotUser> userRepository,
                              IUserBLL userBLL,
                              IDayBLL dayBLL,
                              IRepository<Days> daysRepository,
                              IRepository<Tariff> tariffRepository,
                              ITariffBLL tariffBLL,
                              IMessageBLL messageBLL,
                              IRepository<Entities.Message> messageRepository,
                              IWebHostEnvironment appEnvironment,
                              IRepository<PayedUsers> payedUsersRepository, 
                              ISender sender)
        {
            _userRepository = userRepository;
            _userBLL = userBLL;
            _dayBLL = dayBLL;
            _daysRepository = daysRepository;
            _tariffRepository = tariffRepository;
            _tariffBLL = tariffBLL;
            _messageBLL = messageBLL;
            _messageRepository = messageRepository;
            _appEnvironment = appEnvironment;
            _payedUsersRepository = payedUsersRepository;
            _sender = sender;
        }
        private string BuildResultString((bool, string) tuple)
        {
            string Color = tuple.Item1 ? "Green" : "Red";
            string ResultString = $"<p class=\"font-weight-bold\" style=\"color: {Color}\">{tuple.Item2}</p>";
            return ResultString;
        }

        public IActionResult Index()
        {
            return View(_userRepository.ToArray());
        }

        #region User
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _userBLL.GetByID(id);
            return View(user);
        }

        [AjaxOnly]
        [HttpPost]
        public string EditUser(BotUser user)
        {
            _userBLL.Edit(user);
            return BuildResultString((true, "Пользователь был изменен"));
        }
        #endregion

        #region Day
        [HttpGet]
        public ActionResult AllDays()
        {
            return View(_daysRepository.ToArray());
        }

        public ActionResult AddDay()
        {
            _userRepository.Include(x => x.Name).Include(y => y.Name).Find(x => x.IsBanned);
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        public string AddDay(Days day)
        {
            try
            {
                _dayBLL.Insert(day);
            }
            catch (ArgumentException ex)
            {
                return BuildResultString((false, ex.Message));
            }

            return BuildResultString((true, "День был добавлен"));
        }

        [HttpGet]
        public ActionResult EditDay(int dayID)
        {
            var day = _dayBLL.FindByID(dayID);

            if (day == null)
            {
                return NotFound();
            }

            return View(day);
        }

        [HttpGet]
        public ActionResult DaysMessages(int dayID)
        {
            var daysMessages = _messageRepository.Include(x => x.Day).ToArray(x => x.Day.ID == dayID);

            return View(daysMessages);
        }
        #endregion

        #region Tariffs
        [HttpGet]
        public ActionResult AllTarifs()
        {
            return View(_tariffRepository.ToArray());
        }

        [HttpGet]
        public ActionResult AddTariff()
        {
            return View();
        }

        [HttpPost]
        public string AddTariff(Tariff tariff, string daysPredicate)
        {
            _tariffBLL.Insert(tariff, daysPredicate);
            return BuildResultString((true, "Тариф был добавлен"));
        }
        #endregion

        #region Messages
        [HttpGet]
        public ActionResult AddMessageToDay(int dayID)
        {
            var day = _dayBLL.FindByID(dayID);

            if (day == null)
            {
                return NotFound();
            }

            List<SelectListItem> messageTypes = new()
            {
                new SelectListItem { Value = "1", Text = "Текстовое" },
                new SelectListItem { Value = "2", Text = "Аудио" }
            };

            ViewBag.MessageTypes = messageTypes;

            ViewBag.Day = dayID;
            return View();
        }

        [HttpPost]
        public async Task<string> AddMessageToDayAsync(Entities.Message message, int dayID, IFormFile uploadedFile)
        {
            var day = _dayBLL.FindByID(dayID);

            if (day == null)
            {
                return BuildResultString((false, "День не найден"));
            }

            if (uploadedFile != null)
            {
                message.Path = await AddFileAsync(uploadedFile);
            }

            message.Day = day;
            _messageBLL.Insert(message);
            return BuildResultString((true, "Сообщение было добавлено"));
        }

        public async Task<string> AddFileAsync(IFormFile uploadedFile)
        {
            // путь к папке Files
            string path = "/files/" + Guid.NewGuid() +  "." + uploadedFile.ContentType.Split("/")[1];
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            return path;
        }


        [HttpGet]
        public ActionResult EditMessage(int messageID)
        {
            var message = _messageRepository.Find(x => x.ID == messageID);

            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpPost]
        public async Task<string> EditMessage(Entities.Message message, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                if (System.IO.File.Exists(message.Path))
                {
                    System.IO.File.Delete(message.Path);
                }
                message.Path = await AddFileAsync(uploadedFile);
            }
            _messageBLL.Update(message);
            return BuildResultString((true, "Сообщение было обновлено"));
        }

        #endregion

        #region
        [AllowAnonymous]
        public async Task SendLessons()
        {
            var payedUsers = _payedUsersRepository.Include(x => x.User)
                                                  .Include(x => x.Tariff)
                                                  .Include(x => x.Tariff.Days)
                                                  .Include(x => x.CurrentDay)
                                                  .ToArray(x => x.ClientStatus == Enums.ClientStatus.Studing);
            //var client = await Bot.Bot.Get();

            foreach (var el in payedUsers)
            {

                var dayToSend = el.Tariff.Days.Where(i => i.DayNumber == el.CurrentDay.DayNumber).FirstOrDefault();

                if(dayToSend == null)
                {
                    continue;
                }

                foreach(var lesson in dayToSend.Messages)
                {
                    //await _sender.SendMessage(lesson, el.User.TID, el.Tariff, client);
                }

                var dayIndex = el.Tariff.Days.ToList().FindIndex(a => a == dayToSend);

                if(dayIndex != -1)
                {
                    var nextDay = el.Tariff.Days.ToArray()[dayIndex + 1];
                    if(nextDay != null)
                    {
                        el.CurrentDay = nextDay;
                    }
                    else
                    {
                        el.ClientStatus = Enums.ClientStatus.NotStuding;
                    }
                }
            }
        }
        #endregion
    }
}


//5,6,7,10
//5