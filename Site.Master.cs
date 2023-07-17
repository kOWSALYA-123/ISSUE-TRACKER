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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();

        protected void btn_Exit_click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/UserLogin.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Global.GlobalVariables.susername == "")
                {
                    base.Response.Redirect("~/UserLogin.aspx");
                }
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string customer = string.Empty;
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_usermaster where username='" + Global.GlobalVariables.susername.ToString() + "'", sqlConnection);
                DataTable dbtl = new DataTable();
                sqlda.Fill(dbtl);
                DataSet dscustomer = new DataSet();
                dscustomer.Tables.Add(dbtl);
                if (dscustomer.Tables[0].Rows.Count > 0)
                {
                    customer = dscustomer.Tables[0].Rows[0]["customername"].ToString();

                }
                if (customer != null && customer != "")
                {


                    lbluser.Text = Global.GlobalVariables.scustomername;
                }

                else
                {
                    lbluser.Text = Global.GlobalVariables.susername;
                }
            }
            catch (System.Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('" + ex.Message.ToString() + "');", addScriptTags: true);
            }


        }


    }
}
