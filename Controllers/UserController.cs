using System.Collections.Generic;
using System.Linq;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class UserController : Controller
    {
        private MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult ProcessReg(User regUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Username == regUser.Username))
                {
                    ModelState.AddModelError("Username", "The Username is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                _context.Users.Add(regUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("uid", regUser.UserId);
                return RedirectToAction("Hobby");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult ProcessLogin(LoginUser thisUser)
        {
            if (ModelState.IsValid)
            {
                User LoggedUser = _context.Users.FirstOrDefault(u => u.Username == thisUser.LoginUsername);
                if (LoggedUser != null)
                {
                    PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                    if (Hasher.VerifyHashedPassword(thisUser, LoggedUser.Password, thisUser.LoginPassword) != 0)
                    {
                        HttpContext.Session.SetInt32("uid", LoggedUser.UserId);
                        return RedirectToAction("Hobby");
                    }
                }

                ModelState.AddModelError("LoginUsername", "Invalid login credentials!");
                return View("Index");
            }
            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("Hobby")]

        public IActionResult Hobby()
        {
            if(HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("Index");

            List<Hobby> AllHobies = _context.Hobbies
            .Include(h => h.AllUsers)
            .ThenInclude(uh => uh.UserOnHobby)
            .ToList();
            return View(AllHobies);
        }
    }
}