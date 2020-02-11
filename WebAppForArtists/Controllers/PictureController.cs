using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppForArtists.Models;

namespace WebAppForArtists.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        //[HttpPost] od tego był błąd
        [HttpGet]
        public ActionResult Upload()
        {
            UserStorage us = new UserStorage();
            us.UserID = Int32.Parse(Session["UserID"].ToString());
            us.TagsId = new List<int>();
            us.Pictures = new List<string>();
            us.Tags = new List<Tag>();
            us.TagsNames = new List<string>();
            //us.CurrentTagID = "0";
            us.getTagsAndPicturesFromDB(us);

            ViewBag.tags = us.TagsId;

            return View();
        }

        [HttpPost]
        public ActionResult Upload(Picture pictureModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(pictureModel.PictureFile.FileName);
            string extension = Path.GetExtension(pictureModel.PictureFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            pictureModel.Name = "~/Content/Pictures/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Pictures/"), fileName);
            pictureModel.PictureFile.SaveAs(fileName);
            pictureModel.UserID = Int32.Parse(Session["UserID"].ToString());

            UserStorage us = new UserStorage();
            us.UserID = Int32.Parse(Session["UserID"].ToString());
            us.TagsId = new List<int>();
            us.Pictures = new List<string>();
            us.Tags = new List<Tag>();
            us.TagsNames = new List<string>();
            //us.CurrentTagID = "0";
            us.getTagsAndPicturesFromDB(us);

            ViewBag.tags = us.TagsId/*getTagsNames(us)*/;

            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                db.Pictures.Add(pictureModel);
                db.SaveChanges();
                return RedirectToAction("ShowPicture", new { id = pictureModel.PictureID });
            }
            ModelState.Clear();
            return View();
        }

        //public ActionResult ShowPicture()
        //{
        //    Picture pictureModel = new Picture();
        //    using (DB_Model_Entities db = new DB_Model_Entities())
        //    {
        //        pictureModel = db.Pictures.Where(x => x.PictureID == 2).FirstOrDefault();
        //    }
        //    return View(pictureModel);
        //}

        [HttpGet]
        public ActionResult ShowPicture(int id)
        {
            Picture pictureModel = new Picture();
            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                pictureModel = db.Pictures.Where(x => x.PictureID == id).FirstOrDefault();
            }
            return View(pictureModel);
        }

    }
}