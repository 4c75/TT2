using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using TT2_Gala_darbs.Models;

namespace TT2_Gala_darbs.Models
{
    public class database
    {

        public void addUser(string name)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["TT2data"].ConnectionString;
            using (SqlConnection data = new SqlConnection(ConStr))
            {
                data.Open();
                SqlCommand insert = new SqlCommand("insert into Users values( "+name+" )", data);
                insert.ExecuteNonQuery();
                data.Close();
            }
        }

        public void addStory(StoryModel arg)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["TT2data"].ConnectionString;
            using (SqlConnection data = new SqlConnection(ConStr))
            {
                data.Open();
                SqlCommand insert = new SqlCommand("insert into Stories (title, story, username, likes) values( " +
                    "'"+arg.title +"',"+
                    "'" + arg.text + "'," +
                    "'" + arg.currentUser
                    +"', 0 )", data);
                insert.ExecuteNonQuery();

                SqlCommand sel = new SqlCommand("select id from Stories where"
                +" title = '"+ arg.title +"' and"
                +" username = '"+arg.currentUser +"' and"
                +" likes = "+arg.likes.ToString() + 
                "",data);

                string id = "";

                using (SqlDataReader reader = sel.ExecuteReader() )
                {
                    while (reader.Read())
                    {
                        int i = reader.GetInt32(0);
                        id = i.ToString();
                    }
                }

                SqlCommand insertCords = new SqlCommand("insert into cord (id, xcord, ycord) values "+
                    "( "+id+", "
                    +arg.cord.First().x.ToString() + ", "
                    +arg.cord.First().y.ToString() + " )"
                    ,data);
                insertCords.ExecuteNonQuery();

                data.Close();
            }
        }

        public List<StoryModel> getStory(string user)
        {
            List<StoryModel> result = new List<StoryModel>();
            string ConStr = ConfigurationManager.ConnectionStrings["TT2data"].ConnectionString;
            using (SqlConnection data = new SqlConnection(ConStr))
            {

                data.Open();
                string UserName = user;
                SqlCommand sel = new SqlCommand("select id, title, story, likes from Stories where  username = '" + UserName + "' order by id desc", data);
                using (SqlDataReader reader = sel.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StoryModel d = new StoryModel();
                        d.id = reader.GetInt32(0);
                        d.title = reader.GetString(1);
                        d.text = reader.GetString(2);
                        d.likes = reader.GetInt32(3);
                        d.cord = this.getCords(d.id);
                        result.Add(d);
                    }
                }
                data.Close();
            }
            return result;
        }

        public List<Cords> getCords(int id)
        {
            List<Cords> result = new List<Cords>();
            string ConStr = ConfigurationManager.ConnectionStrings["TT2data"].ConnectionString;

            using (SqlConnection data = new SqlConnection(ConStr))
            {

                data.Open();
                SqlCommand sel2 = new SqlCommand("select id, xcord, ycord from cord where id = " + id.ToString(), data);
                using (SqlDataReader reader = sel2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cords b = new Cords();
                        b.id = reader.GetInt32(0);
                        b.x = reader.GetDecimal(1);
                        b.y = reader.GetDecimal(2); 
                        result.Add(b);
                    }
                }
                data.Close();
            }
            return result;
        }


    }
}