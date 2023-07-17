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
    public partial class UserCredential_grid : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            SqlConnection sqlCon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            Boolean temp = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isconsultant"]).FirstOrDefault();
            sqlCon.Close();
            if (temp == true)
            {
                btn_new.Visible = true;
            }
            else
            {
                btn_new.Visible = false;
            }
        
            bindgrid();
        }
        private void bindgrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            Boolean temp = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isconsultant"]).FirstOrDefault();
            if (temp == true)
            {
                SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from tbl_UserMaster", sqlConnection);
                DataTable dbt2 = new DataTable();
                sqlda1.Fill(dbt2);
                dg_usercredential.DataSource = dbt2;
                dg_usercredential.DataBind();
            }
            else
            {
                SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from tbl_UserMaster where username='" + Global.GlobalVariables.susername.ToString() + "'", sqlConnection);
                DataTable dbt2 = new DataTable();
                sqlda1.Fill(dbt2);
                dg_usercredential.DataSource = dbt2;
                dg_usercredential.DataBind();
            }
          
          
        }
        protected void redirect(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode3 = "New";
            Response.Redirect("~/Usercredential.aspx");
        }
        protected void dg_usercredential_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["username"] = dg_usercredential.SelectedDataKey.Values[0].ToString();
            Session["userid"] = dg_usercredential.SelectedDataKey.Values[1].ToString();
            SqlConnection sqlCon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            Boolean temp = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isconsultant"]).FirstOrDefault();
            sqlCon.Close();
            if(temp==true)
            {
                Global.GlobalVariables.sCustMode3 = "Edit";
                Response.Redirect("~/Usercredential.aspx");
                this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
            }
            else
            {
            if (Global.GlobalVariables.susername == Session["username"].ToString().Trim())
            {
                Global.GlobalVariables.sCustMode3 = "Edit";
                Response.Redirect("~/Usercredential.aspx");
                this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
            }
            else
            {
               
                Response.Write("<script>alert('You dont Edit Others Profile')</script>");
                return;
            }
            }
        }
        protected void dg_usercredential_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindgrid();
                dg_usercredential.PageIndex = e.NewPageIndex;
                dg_usercredential.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(connectionString);
                ImageButton btn1 = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn1.NamingContainer;
                SqlCommand cmd = new SqlCommand("delete from tbl_UserMaster where customercode='" + row.Cells[0].Text + "'", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                this.bindgrid();
            }
            catch (Exception ex)
            {
            }
        }
    }
}