using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration

namespace Webapitest.Models
{
    
    public class AuthorizationToken
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        public bool checkToken(string token) {
           


            con.Close();
            
            // token = "ab0d80c5-df50-4068-8e28-79adf41f74f7";
           
            SqlCommand cmd = new SqlCommand("select token from login where token='" + token + "'", con);

            con.Close();

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;

            



        }

    }
}