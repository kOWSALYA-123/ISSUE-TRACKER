
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
    public partial class CustomerProduct : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            if (!IsPostBack)
            {
               
                Load_customer();
                Load_product();
                chk_isactive.Visible = false;
                lbl_cust.Visible = false;
                chk_isactive.Checked = true;
                if (Global.GlobalVariables.sCustMode == "Edit")
                {
                    chk_isactive.Visible = true;
                    lbl_cust.Visible = true;
                    btnclear.Visible = false;

                    ddlcustomer.Enabled = false;
                   
                    chkboxlistproduct.Enabled = false;
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select CP.CustomerID,Cm.CustomerName,Cp.ProductID,PM.ProductName,CP.IsActive from tbl_Customer_Product CP inner join tbl_CustomerMaster CM on CP.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on PM.ProductId=CP.ProductId where  CP.CustomerID='" + Session["CustomerID"].ToString() + "' AND PM.ProductName='" + Session["productID"].ToString() + "'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet dg_Customerproduct = new DataSet();
                    dg_Customerproduct.Tables.Add(dbt2);
                    if (dg_Customerproduct != null && dg_Customerproduct.Tables.Count > 0)
                    {

                        for (int i = 0; i < ddlcustomer.Items.Count; i++)
                        {
                            if (ddlcustomer.Items[i].Text.ToString().Trim().ToLower() == dg_Customerproduct.Tables[0].Rows[0]["CustomerName"].ToString().Trim().ToLower())
                            {
                                ddlcustomer.SelectedIndex = i;
                                break;
                            }
                        }
                        

                        

                        for (int i = 0; i < chkboxlistproduct.Items.Count; i++)
                        {
                            string Pname = Session["productID"].ToString();

                            for (int j = 0; j < Pname.Length; j++)
                            {
                                if (chkboxlistproduct.Items[i].Text.ToString() == Pname.ToString())
                                {
                                    chkboxlistproduct.Items[i].Selected = true;
                                    break;
                                }
                            }

                        }
                        if (dg_Customerproduct.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                        {
                            chk_isactive.Checked = true;
                        }
                        else
                        {
                            chk_isactive.Checked = false;
                        }

                        Session["customercodes"] = null;
                    }
                }

            }
        }

        private void Load_customer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select  CustomerName  from tbl_CustomerMaster ", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddlcustomer.DataValueField = "CustomerName";
            ddlcustomer.DataTextField = "CustomerName";
            ddlcustomer.DataSource = dbtl;
            ddlcustomer.DataBind();
            ddlcustomer.Items.Insert(0, "----SELECT----");
            ddlcustomer.SelectedIndex = 0;
        }

        private void Load_product()
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select  ProductName  from tbl_ProductMaster ", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            if (dbtl.Rows.Count > 0)
            {
                chkboxlistproduct.DataSource = dbtl;
                chkboxlistproduct.DataTextField = "ProductName";
                chkboxlistproduct.DataValueField = "ProductName";
                chkboxlistproduct.DataBind();

            }
        }



        protected void chkboxlistproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string text = null;
            string text2 = null;
            int num = 0;
            bool flag = false;
           
            for (int i = 0; i < chkboxlistproduct.Items.Count; i++)
            {
                if (chkboxlistproduct.Items[i].Selected)
                {
                    text2 = chkboxlistproduct.Items[i].Text.ToString();
                    text = text + text2 + ",";
                    num++;
                    flag = true;
                    string text3 = chkboxlistproduct.Items[i].Value.ToString();
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    SqlDataAdapter sqlda = new SqlDataAdapter("select Cm.CustomerName,PM.ProductName,CP.IsActive from tbl_Customer_Product CP inner join tbl_CustomerMaster CM on CP.CustomerID=CM.CustomerID Inner join tbl_ProductMaster PM on  PM.ProductId=CP.ProductId where CP.isactive='0' AND CM.CustomerName='" + ddlcustomer.SelectedValue.ToString() + "' AND PM.PRODUCTNAME='" + text2 + "'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet dg_amcdetails = new DataSet();
                    dg_amcdetails.Tables.Add(dbt2);
                    if (dg_amcdetails != null && dg_amcdetails.Tables[0].Rows.Count > 0)
                    {
                        lbl_msg.Visible = true;
                        return;
                    }
                    else
                    {
                    }
                    lbl_msg.Visible = false;
                }
            }
            if (flag)
            {
                //ddlproduct.Texts.SelectBoxCaption = num.ToString();
                //txtproduct.Text = text.Remove(text.Length - 1);
            }
            else
            {
                // ddlproduct.Texts.SelectBoxCaption = "";
                //txtproduct.Text = "";
            }
            base.ClientScript.RegisterStartupScript(GetType(), "test", "<script>document.getElementById('a2').className = 'active_tab'</script>");
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                char active;
                if (chk_isactive.Checked == true)
                {
                    active = '1';
                }
                else
                {
                    active = '0';
                }
                string text = null;
                string text2 = null;
                int num = 0;
                bool flag = false;

                for (int i = 0; i < chkboxlistproduct.Items.Count; i++)
                {
                    if (chkboxlistproduct.Items[i].Selected)
                    {
                        text2 = chkboxlistproduct.Items[i].Text.ToString();
                        string cmdText;
                        SqlCommand sqlCommand;
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("sp_insert_customerproduct  ", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", ddlcustomer.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ProductID", text2);
                        cmd.Parameters.AddWithValue("@isactive", active);
                        cmd.Parameters.AddWithValue("@createuser", Global.GlobalVariables.susername.ToString());
                        cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                lbl_save.Visible = true;
                return;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('Saved Successfully..!');", addScriptTags: true);
            funclear();
            Response.Redirect("~/customerproduct_grid.aspx");

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            funclear();
        }


        public void funclear()
        {
            if (Global.GlobalVariables.sCustMode == "Edit")
            {

            }
            else
            {

                ddlcustomer.SelectedIndex = 0;
               
              
            }
        }

    }
}