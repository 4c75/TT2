using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TT2_Gala_darbs.Models
{
    public class StoryModel
    {
        string ConStr = ConfigurationManager.ConnectionStrings["TT2data"].ConnectionString;

        public ApplicationUser currentUser { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public int likes { get; set; }
        public int id { get; set; }
        public List<Cords> cord { get; set; }
        public List<string> following { get; set; }

        public StoryModel()
        {
            currentUser = new ApplicationUser();

        }
    }


    public class Cords
    {
        public decimal x { get; set; }
        public decimal y { get; set; }
        public int id { get; set; }
    }

}