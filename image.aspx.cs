using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace IssueRegister
{
    public partial class image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            if (Global.GlobalVariables.Filename1 != "")
            {
                byte[] bytes = (byte[])GetData("SELECT Image FROM tbl_Images_temp WHERE Filename = '" +Global.GlobalVariables. Filename1 + "'").Rows[0]["Image"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
            }
        }
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Loc_Con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        
    }
}