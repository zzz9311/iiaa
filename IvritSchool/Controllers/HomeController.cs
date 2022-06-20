using AspNetCore.Unobtrusive.Ajax;
using IvritSchool.BLL.Days;
using IvritSchool.BLL.Messages;
using IvritSchool.BLL.Tariffs;
using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Models;
using IvritSchool.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace IvritSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<BotUser> _userRepository;
        private readonly IRepository<Days> _daysRepository;
        private readonly IRepository<Tariff> _tariffRepository;
        private readonly IRepository<Entities.Message> _messageRepository;
        private readonly IUserBLL _userBLL;
        private readonly IDayBLL _dayBLL;
        private readonly ITariffBLL _tariffBLL;
        private readonly IMessageBLL _messageBLL;

        public HomeController(IRepository<BotUser> userRepository,
                              IUserBLL userBLL,
                              IDayBLL dayBLL,
                              IRepository<Days> daysRepository,
                              IRepository<Tariff> tariffRepository,
                              ITariffBLL tariffBLL,
                              IMessageBLL messageBLL,
                              IRepository<Entities.Message> messageRepository)
        {
            _userRepository = userRepository;
            _userBLL = userBLL;
            _dayBLL = dayBLL;
            _daysRepository = daysRepository;
            _tariffRepository = tariffRepository;
            _tariffBLL = tariffBLL;
            _messageBLL = messageBLL;
            _messageRepository = messageRepository;
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

            if(day == null)
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

            return View(dayID);
        }

        [HttpPost]
        public string AddMessageToDay(Entities.Message message, int dayID)
        {
            var day = _dayBLL.FindByID(dayID);

            if(day == null)
            {
                return BuildResultString((false, "День не найден"));
            }

            message.Day = day;
            _messageBLL.Insert(message);
            return BuildResultString((true, "Сообщение было добавлено"));
        }


        [HttpGet]
        public ActionResult EditMessage(int messageID)
        {
            var message = _messageRepository.Find(x=>x.ID == messageID);

            if(message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        #endregion
    }
}
