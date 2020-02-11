using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppForArtists.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            //objUser.ConfirmedPassword = objUser.Password;
            //ViewBag.password = objUser.Password;
            //if (ModelState.IsValid) //jednak nie jest potrzebne
            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                var obj = db.Users.Where(a => a.FirstName.Equals(objUser.FirstName) && a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.UserID.ToString();
                    Session["FirstName"] = obj.FirstName.ToString();
                    Session["LastName"] = obj.LastName.ToString();
                    Session["Email"] = obj.Email.ToString();
                    return RedirectToAction("UserDashBoard", "DashBoard");
                }
                else
                    ViewBag.LoginMessage = "Incorrect data, try again.";
            }
            return View(objUser);
        }

        
    }
}