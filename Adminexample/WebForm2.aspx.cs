using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Adminexample
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
         string val=   txtstring.Text;

            lbl.Text = GenerateSHA512String(val);

            if (GenerateSHA512String(val).ToString().Equals("FFCDBF04FA5BEEFDCC2DD476C18BC410F02B3968E7F4F54E8F43F1E1A310BB32E3B4DEC9305232BB89DB5B1D0C009A53BCACE6F4BD8EC2F695BAF3D43BA730CE")) 

            {
                lblcom.Text = "data matched";
            }

          else
            {

                lblcom.Text = "data not matched";
            }



    }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
             return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}