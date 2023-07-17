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
    public partial class customermaster_grid : System.Web.UI.Page
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
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_CustomerMaster", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            dg_CustomerMaster.DataSource = dbtl;
            dg_CustomerMaster.DataBind();
        }
        protected void dg_CustomerMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindgrid();
                dg_CustomerMaster.PageIndex = e.NewPageIndex;
                dg_CustomerMaster.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void redirect(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode = "New";
            Response.Redirect("~/CustomerMaster.aspx");
        }
        protected void dg_CustomerMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.GlobalVariables.sCustMode = "Edit";
            Session["customercodes"] = dg_CustomerMaster.SelectedDataKey.Value.ToString();
            Response.Redirect("~/CustomerMaster.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "<script>document.getElementById('btn_new').className = 'active_tab'</script>");
        }

       
    }
}