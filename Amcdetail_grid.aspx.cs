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
    public partial class Amcdetail_grid : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            bindgrid();
        }
        private void bindgrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
           
            SqlDataAdapter sqlda = new SqlDataAdapter(" select AD.CustomerID,Cm.CustomerName,AD.AMC_StartDate,AD.AMC_EndDate,AD.ISPAID,AD.ISACTIVE,AD.CreateUser,AD.CreateDate,AD.ModifyUser,AD.ModifyDate from tbl_AmcDetail AD inner join tbl_CustomerMaster CM on AD.CustomerID=CM.CustomerID", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_amcgrid.DataSource = dbtl;
            dg_amcgrid.DataBind();
        }
        protected void dg_amcdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindgrid();
                dg_amcgrid.PageIndex = e.NewPageIndex;
                dg_amcgrid.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void dg_amcdetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode1 = "Edit";
            Session["customerid"] = dg_amcgrid.SelectedDataKey.Value.ToString();
            Response.Redirect("~/AMCDetails.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
        }
        protected void redirect(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode1 = "New";
            Response.Redirect("~/AMCDetails.aspx");
        }
        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(connectionString);
                ImageButton btn1 = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn1.NamingContainer;
                SqlCommand cmd = new SqlCommand("delete from tbl_AmcDetail where customercode='" + row.Cells[0].Text + "'", sqlCon);

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