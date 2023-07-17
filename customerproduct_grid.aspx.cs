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
    public partial class customerproduct_grid : System.Web.UI.Page
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
            SqlDataAdapter sqlda = new SqlDataAdapter("select CP.CustomerID,Cm.CustomerName,Cp.ProductID,PM.ProductName,CP.isactive from tbl_Customer_Product CP inner join tbl_CustomerMaster CM on CP.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.ProductId=CP.ProductId", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_Customerproduct.DataSource = dbtl;
            dg_Customerproduct.DataBind();
            
        }
       
        protected void redirect(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode = "New";
            Response.Redirect("~/CustomerProduct.aspx");
        }
        protected void dg_Customerproduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindgrid();
                dg_Customerproduct.PageIndex = e.NewPageIndex;
                dg_Customerproduct.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void dg_Customerproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode = "Edit";
            Session["CustomerID"] = dg_Customerproduct.SelectedDataKey.Value.ToString();
            Session["productID"] = dg_Customerproduct.SelectedDataKey.Values[2].ToString();
            Response.Redirect("~/CustomerProduct.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
        }
    }
}