using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppForArtists.Controllers
{
    public class SettingsController : Controller
    {
        public ActionResult Settings()
        {
            ViewBag.Name = Session["FirstName"];
            ViewBag.Email = Session["Email"];
            ViewBag.LastName = Session["LastName"];

            return View();
        }

        [HttpPost]
        public ActionResult Settings(User objUser)
        {
            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                int id = Int32.Parse(Session["UserID"].ToString());
                var user = db.Users.First(a=>a.UserID== id);

                user.FirstName = objUser.FirstName;
                ViewBag.Name = objUser.FirstName;           // to assign default value in view
                user.LastName = objUser.LastName;
                ViewBag.LastName = objUser.LastName;
                user.Email = objUser.Email;
                ViewBag.Email = objUser.Email;
                user.ConfirmedPassword = objUser.ConfirmedPassword;
                user.Password = objUser.Password;

                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Change Successful!";
            return View("Settings", new User());
        }
    }
}