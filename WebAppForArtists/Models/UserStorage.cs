using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppForArtists.Models
{
    public class UserStorage
    {
        public int UserID { get; set; }
        public string CurrentTagID { get; set; }
        public List<Tag> Tags { get; set; }
        public List<string> TagsNames { get; set; }
        public List<string> Pictures { get; set; }
        public List<int> TagsId { get; set; }                       //to select only User's tags, not all

        public string userNote1 { get; set; }
        public string userNote2 { get; set; }

        public void getPictures(UserStorage us)
        {
            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                foreach(var row in db.Pictures)
                {
                    if(row.UserID==us.UserID)
                    {
                        us.Pictures.Add(row.Name.ToString());          //Name is a path (to get picture from a folder later)
                        if(row.TagID!=null && !us.TagsId.Contains((int)row.TagID))
                        {
                            us.TagsId.Add((int)row.TagID);
                        }
                    }
                }
            }
        }

        public void getTagsAndPicturesFromDB(UserStorage us)
        {
            getPictures(us);                                          //to have a current list of TagsId
            using (DB_Model_Entities db = new DB_Model_Entities())
            {
                foreach (var row in db.Tags)
                {
                    if(us.TagsId.Contains((int)row.TagID) && !us.Tags.Contains(row/*.TagName.ToString()*/))
                    {
                        us.Tags.Add(row/*.TagName.ToString()*/);
                    }
                    
                } 
            }
        }

        public List<string> getTagsNames(UserStorage us)
        {
            foreach(Tag tag in us.Tags)
            {
                us.TagsNames.Add(tag.TagName.ToString());
            }
            return us.TagsNames;
        }
    }
}