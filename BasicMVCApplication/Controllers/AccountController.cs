using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicMVCApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {
            return View();
        }
    
        
        [HttpPost]
        public IActionResult LoginPost(string userName, string password)
        {
            ViewBag.UserName = userName;
            ViewBag.Password = password;
            return View();
        }

        public IActionResult StronglyTypedLogin()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if (login.Username != null) ViewBag.Username = login.Username;
            if (login.Password != null) ViewBag.Password = login.Password;
            return View();
        }
    }
}