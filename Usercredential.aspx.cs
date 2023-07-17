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
    public partial class Usercredential : System.Web.UI.Page
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
                rbtConsultant.Checked = true;
                chk_isactive.Checked = true;
                
                ddlcustomer.Enabled = false;
                lbl_cust.Enabled = false;
                 txtuserid.Attributes.Add("readonly", "readonly");
                if (Global.GlobalVariables.sCustMode3 == "Edit")
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqldaa = new SqlDataAdapter("select * from tbl_UserMaster where userid='" + Session["userid"].ToString() + "'", sqlConnection);
                    DataTable dbtt = new DataTable();
                    sqldaa.Fill(dbtt);
                    DataSet dscust = new DataSet();
                    dscust.Tables.Add(dbtt);
                    if (dscust != null && dscust.Tables.Count > 0)
                    {
                        if (dscust.Tables[0].Rows[0]["iscustomer"].ToString() == "True")
                        {
                          
                            ddlcustomer.Enabled = true;
                        }
                        else
                        {
                            ddlcustomer.Enabled = false;
                        }

                    }
                   
                    btnclear.Visible = false;
                    txtuserid.Attributes.Add("readonly", "readonly");
                    txtuserid.BackColor = Color.Yellow;
                    txtemail.Attributes.Add("readonly", "readonly");
                    txtemail.BackColor = Color.Yellow;
                    rbtConsultant.Attributes["onclick"] = "return false";
                    rbtDeveloper.Attributes["onclick"] = "return false";
                    rbtCustomer.Attributes["onclick"] = "return false";
                    ddlcustomer.Attributes.Add("readonly", "readonly");
                    chk_isactive.Enabled = false;
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster where userid='" + Session["userid"].ToString() + "'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet dg_usercredential = new DataSet();
                    dg_usercredential.Tables.Add(dbt2);
                    if (dg_usercredential != null && dg_usercredential.Tables.Count > 0)
                    {
                        txtuserid.Text = dg_usercredential.Tables[0].Rows[0]["userID"].ToString();
                        TXTUSERNAME.Text = dg_usercredential.Tables[0].Rows[0]["username"].ToString();
                        Global.GlobalVariables.scustomername = dg_usercredential.Tables[0].Rows[0]["customername"].ToString();
                        txtpassword.Text = dg_usercredential.Tables[0].Rows[0]["password"].ToString();
                        txtdepartment.Text = dg_usercredential.Tables[0].Rows[0]["Department"].ToString();
                        if (dg_usercredential.Tables[0].Rows[0]["iscustomer"].ToString() == "True")
                        {
                            rbtCustomer.Checked = true;
                        }
                        else
                        {
                            rbtCustomer.Checked = false;
                        }
                       
                        if (dg_usercredential.Tables[0].Rows[0]["isconsultant"].ToString() == "True")
                        {
                            rbtConsultant.Checked = true;
                        }
                        else
                        {
                            rbtConsultant.Checked = false;
                        }
                        if (dg_usercredential.Tables[0].Rows[0]["isdeveloper"].ToString() == "True")
                        {
                            rbtDeveloper.Checked = true;
                        }
                        else
                        {
                            rbtDeveloper.Checked = false;
                        }
                        if (dg_usercredential.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                        {
                            chk_isactive.Checked = true;
                        }
                        else
                        {
                            chk_isactive.Checked = false;
                        }

                        txtemail.Text = dg_usercredential.Tables[0].Rows[0]["email"].ToString();
                        txtwhatsppno.Text = dg_usercredential.Tables[0].Rows[0]["Mobile"].ToString();
                        for (int i = 0; i < ddlcustomer.Items.Count; i++)
                        {
                            if (ddlcustomer.Items[i].Text.ToString().Trim().ToLower() == dg_usercredential.Tables[0].Rows[0]["CUSTOMERNAME"].ToString().Trim().ToLower())
                            {
                                ddlcustomer.SelectedIndex = i;
                                break;
                            }
                        }

                        Session["username"] = null;
                    }
                }
            }
            else
            {
            }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                

                char customer;
                if (rbtCustomer.Checked == true)
                {
                    customer = '1';
                }
                else
                {
                    customer = '0';
                }

                
                char consultant;
                if (rbtConsultant.Checked == true)
                {
                    consultant = '1';
                }
                else
                {
                    consultant = '0';
                }
                char developer;
                if (rbtDeveloper.Checked == true)
                {
                    developer = '1';
                }
                else
                {
                    developer = '0';
                }
                char active;
                    if(chk_isactive.Checked==true)
                    {
                        active = '1';
                    }
                    else
                    {
                        active = '0';
                    }
                    if (txtemail.Text == "")
                    {

                        lbl_msg1.Visible = true;
                    }
                    else if (txtpassword.Text == "")
                    {
                        lbl_msg2.Visible = true;
                    }
                    else if (TXTUSERNAME.Text == "")
                    {
                        lbl_msg3.Visible = true;
                    }
                    else if (txtwhatsppno.Text == "")
                    {
                        lbl_msg4.Visible = true;
                    }
                    else
                    {
                        string cmdText;
                        SqlCommand sqlCommand;

                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("sp_insert_usermaster", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", txtuserid.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("@username", TXTUSERNAME.Text);
                        cmd.Parameters.AddWithValue("@departmentname", txtdepartment.Text);
                        cmd.Parameters.AddWithValue("@ISCONSULTANT", consultant);
                        cmd.Parameters.AddWithValue("@ISDEVELOPER", developer);
                        cmd.Parameters.AddWithValue("@ISCUSTOMER ", customer);
                        cmd.Parameters.AddWithValue("@whatsappno", txtwhatsppno.Text);
                        cmd.Parameters.AddWithValue("@CUSTOMERNAME", ddlcustomer.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@IsActive", active);
                        cmd.Parameters.AddWithValue("@createuser", Global.GlobalVariables.susername.ToString());
                        cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('Saved Successfully..!');", addScriptTags: true);
                        funclear();

                        Response.Redirect("~/UserCredential_grid.aspx",false);
                    }

            }
            catch (Exception ex)
            {
                lbl_save.Visible = true;
            }
            

        }
        protected void btnclear_Click(object sender, System.EventArgs e)
        {
            funclear();
        }

        public void funclear()
        {
            if (Global.GlobalVariables.sCustMode3 == "Edit")
            {

            }
            else
            {
                TXTUSERNAME.Text = "";
                txtpassword.Text = "";
                rbtCustomer.Checked = false;
                rbtConsultant.Checked = false;
                rbtDeveloper.Checked = false;
                txtemail.Text = "";
                txtwhatsppno.Text = "";
                chk_isactive.Checked = false;
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
            ddlcustomer.Items.Insert(0, "");
            ddlcustomer.SelectedIndex = 0;
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCustomer.Checked == true)
            {
                lbl_cust.Enabled = true;
                ddlcustomer.Enabled = true;

            }
            else
            {
                lbl_cust.Enabled = false;
                ddlcustomer.Enabled = false;
            }
        }
             protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDeveloper.Checked == true)
            {
                lbl_cust.Enabled = false;
                ddlcustomer.Enabled = false;

            }
          
        }
         protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtConsultant.Checked == true)
            {
                lbl_cust.Enabled = false;
                ddlcustomer.Enabled = false;

           }

        }
    }
}