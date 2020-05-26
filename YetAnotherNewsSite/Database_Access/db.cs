using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace YetAnotherNewsSite.Database_Access
{

    public class db

    {

       
        public class Articles

        {
            public int Articleid { get; set; }

            public string Headline { get; set; }

            public string TextField { get; set; }

            public string Picture { get; set; }

            public string Author { get; set; }

            public DateTime Date { get; set; }

        }


        public static List<Articles> GetArticles(int pageindex, int pagesize)

        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlCommand com = new SqlCommand("Sp_Articles_LazyLoad", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@PageIndex", pageindex);

            com.Parameters.AddWithValue("@PageSize", pagesize);

            List<Articles> listemp = new List<Articles>();



            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listemp.Add(new Articles

                {

                    Articleid = Convert.ToInt32(dr["ArticleId"]),

                    Headline = dr["Headline"].ToString(),

                    TextField = dr["Textfield"].ToString(),

                    Picture = dr["Picture"].ToString(),

                    Author = dr["Author"].ToString(),

                    Date = DateTime.Parse(dr["Date"].ToString())



            });

            }

            return listemp;

        }

    }
}