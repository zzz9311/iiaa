using AspNetCore.Unobtrusive.Ajax;
using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Models;
using IvritSchool.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<BotUser> _userRepository;
        private readonly IUserBLL _userBLL;

        public HomeController(ILogger<HomeController> logger,
            IRepository<BotUser> userRepository, IUserBLL userBLL)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userBLL = userBLL;
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

        [HttpGet]
        public ActionResult AddDay()
        {
            return View();
        }
    }
}
