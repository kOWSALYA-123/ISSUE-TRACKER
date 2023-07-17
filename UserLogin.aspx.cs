using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IssueRegister
{
    public partial class UserLogin : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        String connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {            
            txt_Email.Focus();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {                                
                Session["UserName"] = txt_Email.Text.Trim();
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select email,Password,username,customername from tbl_UserMaster where email='" + txt_Email.Text + "'and password='" + txt_password.Text + "'", sqlConnection);
                cmd.Connection = sqlConnection;
                SqlDataReader dr = cmd.ExecuteReader();
              

                if (dr.Read())
                {
                    Global.GlobalVariables.susername = dr.GetValue(2).ToString();
                    Global.GlobalVariables.scustomername = dr.GetValue(3).ToString();
                    Response.Redirect("~/welcome.aspx",false);
                }
                else
                {
                    lbl_message.Visible = true;
                }
                sqlConnection.Close();
            }

            catch (Exception ex)
            {
                base.ClientScript.RegisterStartupScript(GetType(), "Call my function", "Alert_CodeBehind('ERROR IN SAVE');", addScriptTags: true);
                return;
            }
        }
    }
}