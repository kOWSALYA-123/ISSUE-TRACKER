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
    public partial class TicketRegister_grid : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_message3.Visible = false;
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            SqlConnection sqlCon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            Boolean temp = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isdeveloper"]).FirstOrDefault();
            Boolean temp1 = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["iscustomer"]).FirstOrDefault();

            sqlCon.Close();
            if (temp == true)
            {
                bindgrid_developer();
            }
            else if (temp1 == true)
            {
                bindgrid_customer();
            }
            else
            {
                bindgrid();
            }

        }
        private void bindgrid_developer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT TT.TICKETID,TT.RegisterDate,CM.CustomerCode,PM.PRODUCTNAME,TT.ISSUE,TT.Status from tbl_Ticket TT inner join tbl_CustomerMaster CM  on TT.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.Productname=TT.ProductCD where AssignedtoID='" + Global.GlobalVariables.susername.ToString() + "'", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_ticketregister.DataSource = dbtl;
            dg_ticketregister.DataBind();
        }
        private void bindgrid_customer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT TT.TICKETID,TT.RegisterDate,CM.CustomerCode,PM.PRODUCTNAME,TT.ISSUE,TT.Status from tbl_Ticket TT inner join tbl_CustomerMaster CM  on TT.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.Productname=TT.ProductCD where CM.CUSTOMERNAME='" + Global.GlobalVariables.scustomername.ToString() + "'", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_ticketregister.DataSource = dbtl;
            dg_ticketregister.DataBind();
        }
        private void bindgrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT TT.TICKETID,TT.RegisterDate,CM.CustomerCode,PM.PRODUCTNAME,TT.ISSUE,TT.Status from tbl_Ticket TT inner join tbl_CustomerMaster CM  on TT.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.Productname=TT.ProductCD order by ticketid asc", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_ticketregister.DataSource = dbtl;
            dg_ticketregister.DataBind();
        }
        protected void dg_ticketregister_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode2 = "Edit";
            Session["TICKETID"] = dg_ticketregister.SelectedDataKey.Value.ToString();
            Response.Redirect("~/TicketRegisters.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
        }
        protected void dg_ticketregister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindgrid();
                dg_ticketregister.PageIndex = e.NewPageIndex;
                dg_ticketregister.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void redirect(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode2 = "New";
            Response.Redirect("~/TicketRegisters.aspx");
        }
        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(connectionString);
                ImageButton btn1 = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn1.NamingContainer;
                SqlCommand cmd = new SqlCommand("delete from tbl_Ticket where customercode='" + row.Cells[0].Text + "'", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                this.bindgrid();
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnsearch_Click(object sender, System.EventArgs e)
        {
           
            if (txtsearch.Text.ToString().Length == 0)
            {
                bindgrid();
            }
            else
            {
                fun_load_dgsearchcustomer();
            }
        }
        private void fun_load_dgsearchcustomer()
        {
           
            txtsearch.Text.ToString();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlDataAdapter sqlda1 = new SqlDataAdapter("SELECT TT.TICKETID,TT.RegisterDate,CM.CustomerCode,PM.PRODUCTNAME,TT.ISSUE,TT.Status from tbl_Ticket TT inner join tbl_CustomerMaster CM  on TT.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.Productname=TT.ProductCD where CM.customername LIKE '%" + txtsearch.Text + "%'", sqlConnection);
            DataTable dbt2 = new DataTable();
            sqlda1.Fill(dbt2);
            DataSet ds = new DataSet();
            sqlda1.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dg_ticketregister.DataSource = ds.Tables[0];
                    dg_ticketregister.DataBind();
                }
                else
                {
                    dg_ticketregister.DataSource = ds.Tables[0];
                    dg_ticketregister.DataBind();
                    lbl_message3.Visible = true;
                }

            }
            
            }
            
        
    }
}