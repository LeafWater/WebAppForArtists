using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppForArtists.Views
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            User objUser = new User();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Register(User objUser)
        {
            using (DB_Model_Entities dbModel = new DB_Model_Entities())
            {
                if (dbModel.Users.Any(x => x.Email == objUser.Email))
                {
                    ViewBag.EmailExistsMessage = "User with that email already exists.";
                    return View("Register", objUser);
                }
                dbModel.Users.Add(objUser);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful! Now you can log in and start fully using Art Space!";
            return View("Register", new User());
        }
    }
}