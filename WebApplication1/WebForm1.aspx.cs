using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection con = new  SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

               // load();

            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
           // lbltext.Text = txt.Text;
            string guid1 = System.Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            lbltext.Text = guid1+"-"+guid2;
           

        }

        public void load()

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Emplyee",con);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();




        }
    }
}