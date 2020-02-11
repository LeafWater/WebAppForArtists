using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppForArtists.Models;

namespace WebAppForArtists.Controllers
{
    public class DashBoardController : Controller
    {
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                UserStorage us = new UserStorage();
                us.UserID = Int32.Parse(Session["UserID"].ToString());
                us.TagsId = new List<int>();
                us.Pictures = new List<string>();
                us.Tags = new List<Tag>();
                us.TagsNames = new List<string>();
                //us.CurrentTagID = "0";
                us.getTagsAndPicturesFromDB(us);

                ViewBag.tags = us.getTagsNames(us);
                ViewBag.pictures = us.Pictures;
                ViewBag.countedTags = us.Tags.Count;
                ViewBag.countedPictures = us.Pictures.Count;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}