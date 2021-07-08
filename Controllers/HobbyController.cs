using System;
using System.Collections.Generic;
using System.Linq;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class HobbyController : Controller
    {
        private MyContext _context;

        public HobbyController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("Hobby/New")]
        public ActionResult AddHobby()
        {
            if(HttpContext.Session.GetInt32("uid") != null)
                return View();
            return Redirect("/");
        }
        [HttpPost("hobby/create")]
        public IActionResult CreateHobby(Hobby newHobby)
        {
            if(ModelState.IsValid)
            {
                if(!_context.Hobbies.Any(h => h.Name == newHobby.Name))
                {
                    int uid = (int)HttpContext.Session.GetInt32("uid");
                    newHobby.UserId = uid;
                    _context.Hobbies.Add(newHobby);
                    _context.SaveChanges();
                    
                    UserHobby AddUserToHobby = new UserHobby();
                    AddUserToHobby.HobbyId = newHobby.HobbyId;
                    AddUserToHobby.UserId = uid;
                    _context.UserHobbies.Add(AddUserToHobby);
                    _context.SaveChanges();
                    return Redirect("/Hobby");
                }

                ModelState.AddModelError("Name", "Hobby is already Added!");
                return View("AddHobby");
            }
            return View("AddHobby");
        }

        [HttpGet("Hobby/{hobId}")]
        public ViewResult HobbyDetail(int hobId)
        {
            Hobby thisHobby = _context.Hobbies
            .Include(h => h.AllUsers)
            .ThenInclude(uh => uh.UserOnHobby)
            .FirstOrDefault( h => h.HobbyId == hobId);
            return View(thisHobby);
        }

        [HttpGet("addHobbyToUser/{hobId}")]

        public ActionResult AddHobbyToUser( int hobId)
        {
            int uid = (int)HttpContext.Session.GetInt32("uid");
            UserHobby newHobby = new UserHobby();
            newHobby.HobbyId = hobId;
            newHobby.UserId = uid;
            _context.UserHobbies.Add(newHobby);
            _context.SaveChanges();

            return Redirect($"/Hobby/{hobId}");
        }

        [HttpGet("Hobby/Edit/{hobId}")]

        public ViewResult EditHobby(int hobId)
        {
            Hobby thisHobby = _context.Hobbies.FirstOrDefault( h => h.HobbyId == hobId);

            return View("EditHobby", thisHobby);
        }

        [HttpPost("Hobby/processedit/{hobId}")]
        public ActionResult ProcessEditHobby(int hobId, Hobby editedHobby)
        {
            Hobby thisHobby = _context.Hobbies.FirstOrDefault( h => h.HobbyId == hobId);
            if(ModelState.IsValid)
            {
                thisHobby.Name = editedHobby.Name;
                thisHobby.Description = editedHobby.Description;
                thisHobby.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/Hobby/{thisHobby.HobbyId}");
            }

            return View("EditHobby", thisHobby);
        }
    }
}