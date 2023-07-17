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
    public partial class AMCDetails : System.Web.UI.Page
    {
        DataSet dsA = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            if (!IsPostBack)
            {
                txtvalidateupto.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                txtcustomerid.Attributes.Add("readonly", "readonly");
                chk_isactive.Checked = true;
                Load_customer();
                if (Global.GlobalVariables.sCustMode1 == "Edit")
                {
                    btnclear.Visible = false;
                    txtcustomerid.Attributes.Add("readonly", "readonly");
                    
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    SqlDataAdapter sqlda = new SqlDataAdapter("select * from vw_AMCMaster where customerid='" + Session["customerid"].ToString() + "'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet dg_amcdetails = new DataSet();
                    dg_amcdetails.Tables.Add(dbt2);

                    if (dg_amcdetails != null && dg_amcdetails.Tables.Count > 0)
                    {
                        txtcustomerid.Text = dg_amcdetails.Tables[0].Rows[0]["customerid"].ToString();
                       
                        for (int i = 0; i < ddlcustomer.Items.Count; i++)
                        {
                            if (ddlcustomer.Items[i].Text.ToString().Trim().ToLower() == dg_amcdetails.Tables[0].Rows[0]["Customername"].ToString().Trim().ToLower())
                            {
                                ddlcustomer.SelectedIndex = i;
                                break;
                            }
                        }


                        txtvalidateupto.Text = Convert.ToDateTime(dg_amcdetails.Tables[0].Rows[0]["AMCStartDate"]).Date.ToString("dd/MM/yyyy");
                 
                        txtenddate.Text = Convert.ToDateTime(dg_amcdetails.Tables[0].Rows[0]["AMCEndDate"]).Date.ToString("dd/MM/yyyy");
                
                        if (dg_amcdetails.Tables[0].Rows[0]["ISPAID"].ToString() == "True")
                        {
                            chkpayment.Checked = true;
                        }
                        else
                        {
                            chkpayment.Checked = false;
                        }
                        if (dg_amcdetails.Tables[0].Rows[0]["IsActive"].ToString() == "True")
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
            else
            {
            }

        }

        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcustomerid.Text != "" || ddlcustomer.Text != "" || txtenddate.Text != "" || txtvalidateupto.Text != "")
            {
                Global.GlobalVariables.supdate = "";
            }
            if (Global.GlobalVariables.supdate != "Edit")
            {
                try
                {
                    char Paid;
                    if (chkpayment.Checked == true)
                    {
                        Paid = '1';
                    }
                    else
                    {
                        Paid = '0';
                    }
                    char active;
                    if (chk_isactive.Checked == true)
                    {
                        active = '1';
                    }
                    else
                    {
                        active = '0';
                    }
                    if (ddlcustomer.Text == "")
                    {

                        lbl_msg1.Visible = true;
                    }
                    else if (txtvalidateupto.Text == "")
                    {
                        lbl_msg2.Visible = true;
                    }
                    else if (txtenddate.Text == "")
                    {
                        lbl_msg3.Visible = true;
                    }
                    else
                    {
                        string cmdText;
                        SqlCommand sqlCommand;
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("sp_insert_amcdetails   ", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customerid", txtcustomerid.Text);
                        cmd.Parameters.AddWithValue("@amc_startdate", Convert.ToDateTime(txtvalidateupto.Text));
                        cmd.Parameters.AddWithValue("@amcenddate", Convert.ToDateTime(txtenddate.Text));
                        cmd.Parameters.AddWithValue("@ispaid", Paid);
                        cmd.Parameters.AddWithValue("@isactive", active);
                        cmd.Parameters.AddWithValue("@createuser", Global.GlobalVariables.susername.ToString());
                        cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        ScriptManager.RegisterStartupScript(this, GetType(), "CallMy", "Alert_CodeBehind('Saved Succesfully');", addScriptTags: true);
                        funclear();
                        Response.Redirect("~/AMCDetail_grid.aspx",false);
                    }
                }
                catch (Exception ex)
                {
                    lbl_save.Visible = true;
                }
               

            }
            Global.GlobalVariables.supdate = "";

        }

        protected void btnclear_Click(object sender, System.EventArgs e)
        {
            funclear();
        }
        public void funclear()
        {
            if (Global.GlobalVariables.sCustMode1 == "Edit")
            {

            }
            else
            {
                ddlcustomer.SelectedIndex = 0;
                txtvalidateupto.Text = "";
                txtenddate.Text = "";
                chkpayment.Checked = false;
                chk_isactive.Checked = false;
            }

        }


        private void Load_customer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select CustomerName   from tbl_CustomerMaster ", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddlcustomer.DataValueField = "CustomerName";
            ddlcustomer.DataTextField = "CustomerName";
            ddlcustomer.DataSource = dbtl;
            ddlcustomer.DataBind();
            ddlcustomer.Items.Insert(0, "----SELECT----");
            ddlcustomer.SelectedIndex = 0;
        }
        protected void ddlcustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
           
            if (ddlcustomer.Text != "")
            sqlConnection.Open();
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("select AD.CustomerID,Cm.CustomerName,AD.AMC_StartDate,AD.AMC_EndDate,AD.ISPAID,AD.ISACTIVE,AD.CreateUser,AD.CreateDate,AD.ModifyUser,AD.ModifyDate from tbl_AmcDetail AD inner join tbl_CustomerMaster CM on AD.CustomerID=CM.CustomerID where CM.CUSTOMERNAME='" + ddlcustomer.SelectedValue.ToString() + "'", sqlConnection);
                DataTable dbt2 = new DataTable();
                sqlda.Fill(dbt2);
                DataSet dg_amcdetails = new DataSet();
                dg_amcdetails.Tables.Add(dbt2);
                if (dg_amcdetails != null)
                {
                    if (dg_amcdetails.Tables[0].Rows.Count > 0)
                    {
                        txtcustomerid.Text = dg_amcdetails.Tables[0].Rows[0]["CustomerID"].ToString();
                        txtvalidateupto.Text = dg_amcdetails.Tables[0].Rows[0]["AMC_StartDate"].ToString();
                        txtenddate.Text = dg_amcdetails.Tables[0].Rows[0]["AMC_EndDate"].ToString();
                        if (dg_amcdetails.Tables[0].Rows[0]["ISPAID"].ToString() == "True")
                        {
                            chkpayment.Checked = true;
                        }
                        else
                        {
                            chkpayment.Checked = false;
                        }
                        if (dg_amcdetails.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                        {
                            chk_isactive.Checked = true;
                        }
                        else
                        {
                            chk_isactive.Checked = false;
                        }
                    }
                    sqlConnection.Close();
                    Global.GlobalVariables.supdate = "Edit";
                }
                sqlConnection.Open();
                {
                    SqlDataAdapter sqlda1 = new SqlDataAdapter("select customerid from tbl_customermaster where customername='" + ddlcustomer.SelectedValue.ToString() + "'", sqlConnection);
                    DataTable dbt3 = new DataTable();
                    sqlda1.Fill(dbt3);
                    DataSet dg_amcdetailss = new DataSet();
                    dg_amcdetailss.Tables.Add(dbt3);
                    if (dg_amcdetailss != null)
                    {
                        if (dg_amcdetailss.Tables[0].Rows.Count > 0)
                        {
                            txtcustomerid.Text = dg_amcdetailss.Tables[0].Rows[0]["CustomerID"].ToString();

                        }
                        sqlConnection.Close();
                        Global.GlobalVariables.supdate = "Edit";
                    }
                }


            }

        }

        

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> Getcustomer(string prefixText)
        {
            List<string> Loc = new List<string>();
            DataSet ds = new DataSet();
            ds = Load_customer(prefixText);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Loc.Add(ds.Tables[0].Rows[i]["customer"].ToString().Trim());
               
            }

            return Loc;
        }
        public static DataSet Load_customer(string prefixText)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Loc_Con"].ToString());
            DataSet ds = new DataSet();
            if (con == null)
            {
                con.Open();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select CustomerCode +'-'+ CustomerName as customer from tbl_CustomerMaster where customercode like '%" + prefixText + "%' or customerName like '%" + prefixText + "%'", con);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds;
        }

        protected void txtvalidateupto_TextChanged(object sender, System.EventArgs e)
        {
           
            DateTime date1 = DateTime.Parse(System.DateTime.Now.ToString("dd-MM-yyyy"));
            DateTime date2 = DateTime.Parse(txtvalidateupto.Text);
            if (date2 < date1)
            {
                lbl_date.Visible = true;
                txtvalidateupto.Text = "";

            }
            else
            {
                lbl_date.Visible = false;
                
            }
        }

        protected void txtenddate_TextChanged(object sender, System.EventArgs e)
        {
            DateTime date3 = DateTime.Parse(txtvalidateupto.Text);
            DateTime date4 = DateTime.Parse(txtenddate.Text);
            if (date3 >= date4)
            {
                lb_date.Visible = true;
                txtenddate.Text = "";
            }
            else
            {
                lb_date.Visible = false;
               
            }
        }
      

       
        
    }
}
