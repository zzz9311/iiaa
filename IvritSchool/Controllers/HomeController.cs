﻿using AspNetCore.Unobtrusive.Ajax;
using IvritSchool.BLL.Days;
using IvritSchool.BLL.Messages;
using IvritSchool.BLL.PayedUsers;
using IvritSchool.BLL.SendersLogic;
using IvritSchool.BLL.Tariffs;
using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Enums;
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
using System.Linq;
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
        private readonly ILessonSenderBLL _lessonSenderBLL;
        private readonly IPayedUser _payedUserBLL;

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
                              ILessonSenderBLL lessonSenderBLL, 
                              IPayedUser payedUserBLL)
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
            _lessonSenderBLL = lessonSenderBLL;
            _payedUserBLL = payedUserBLL;
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
        public ActionResult AllDays(int? id = null)
        {
            if (id == null)
            {
                return View(_daysRepository.ToArray());
            }
            var days = _tariffRepository.Include(i => i.Days).ToArray(i => i.ID == id).FirstOrDefault().Days.ToArray();

            return View(days);
        }

        public ActionResult AddDay()
        {
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
            ViewBag.DayId = dayID;

            return View(daysMessages);
        }


        [HttpPost]
        public ActionResult DeleteDay(int dayID)
        {
            _dayBLL.Delete(dayID);
            return RedirectToAction("AllDays");
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

        [HttpGet]
        public ActionResult EditTariff(int tariffID)
        {
            return View(_tariffBLL.Get(tariffID));
        }

        [HttpPost]
        public string EditTariff(Tariff tariff, string daysPredicate = null)
        {
            try
            {
                _tariffBLL.Edit(tariff, daysPredicate);
            }
            catch (ArgumentException ex)
            {
                return BuildResultString((false, ex.Message));
            }

            return BuildResultString((true, "Тариф был изменен"));
        }

        [HttpPost]
        public ActionResult DeleteTariff(int tariffId)
        {
            try
            {
                _tariffBLL.DeleteTariff(tariffId);
                return RedirectToAction("AllTarifs");
            }
            catch (Exception)
            {
                return Ok("Не удалось удалить тариф, есть пользователи, которые используют его");
            }
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

            List<SelectListItem> messageTypes = GetMessageTypes();

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
            string path = "/files/" + Guid.NewGuid() + "." + uploadedFile.ContentType.Split("/")[1];
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

        [HttpPost]
        public ActionResult DeleteMessage(int messageID)
        {
            _messageBLL.Delete(messageID);
            return RedirectToAction("DaysMessages");
        }

        #endregion

        #region sender
        [AllowAnonymous]
        public async Task SendLessons()
        {
            await _lessonSenderBLL.SendAsync();
        }

        public ActionResult SendMessage()
        {
            List<SelectListItem> messageTypes = GetMessageTypes();

            ViewBag.MessageTypes = messageTypes;

            return View();
        }

        [HttpPost]
        public async Task<string> SendMessage(Message message, IFormFile uploadedFile)
        {
            if (uploadedFile != null) //TODO dry
            {
                message.Path = await AddFileAsync(uploadedFile);
            }

            await _lessonSenderBLL.SendAsync(message);
            return BuildResultString((true, "Сообщения были отправлены"));
        }
        #endregion

        #region PayedUsers

        public ActionResult AllPayedUsers()
        {
            return View(_payedUsersRepository.ToArray());
        }

        [HttpGet]
        public ActionResult EditPayedUser(int id)
        {

            var payedUser = _payedUsersRepository.Find(x => x.ID == id);
            if (payedUser == null)
            {
                return NotFound();
            }

            List<SelectListItem> userStatuses = new()
            {
                new SelectListItem { Value = "0", Text = "На паузе" },
                new SelectListItem { Value = "1", Text = "Закончил обучение" },
                new SelectListItem { Value = "2", Text = "Обучается" },
                new SelectListItem { Value = "3", Text = "Не обучается" },
            };

            ViewBag.UserStatuses = userStatuses;

            return View(payedUser);
        }


        [HttpPost]
        public string EditPayedUser(PayedUsers payesUser)
        {
            try
            {
                _payedUserBLL.Edit(payesUser);
            }
            catch (ArgumentException ex)
            {
                return BuildResultString((false, ex.Message));
            }

            return BuildResultString((true, "Оплаченный пользователь был изменен"));
        }

        [HttpGet]
        public ActionResult AddPayedUser()
        {
            SelectList tariffs = new SelectList(_tariffBLL.GetList(), "ID", "Name");
            ViewBag.Tariffs = tariffs;
            return View();
        }

        [HttpPost]
        public string AddPayedUser(Entities.PayedUsers payedUser, int tariffID)
        {
            payedUser.Tariff = _tariffBLL.Get(tariffID);
            _payedUserBLL.Add(payedUser,tariffID);
            return BuildResultString((true, "Пользователь был добавлен"));
        }
        #endregion

        #region helpers...

        [NonAction]
        public List<SelectListItem> GetMessageTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Текстовое" },
                new SelectListItem { Value = "2", Text = "Аудио" },
                new SelectListItem { Value = "3", Text = "Файл" },
                new SelectListItem { Value = "4", Text = "Видео" },
                new SelectListItem { Value = "5", Text = "Фото" },
                new SelectListItem { Value = "6", Text = "Переслать сообщение" }
            };
        }
        #endregion
    }
}
