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
using System.Web.Script.Serialization;


namespace IssueRegister
{
    public partial class CustomerMaster : System.Web.UI.Page
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
                chk_isactive.Checked = true;
                Load_country();
            
                txtcustomercode.Focus();
                txtcustomercode.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcustomername.Attributes.Add("onKeyPress", "javascript:return OnEnterKey(event,this)");
                txtaddress1.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                ddlcountry.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtphone.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact1name.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact1phoneno.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact1email.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact2name.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact2phoneno.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtcontact2email.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                txtremarks.Attributes.Add("onKeyDown", "javascript:return OnEnterKeyFunc(event,this)");
                if (Global.GlobalVariables.sCustMode == "Edit")
                {
                    btnclear.Visible = false;
                    txtcustomercode.Attributes.Add("readonly", "readonly");
                    txtcustomerid.Attributes.Add("readonly", "readonly");
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_CustomerMaster where Customercode='" + Session["customercodes"].ToString() + "'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet dg_CustomerMaster = new DataSet();
                    dg_CustomerMaster.Tables.Add(dbt2);
                    if (dg_CustomerMaster != null && dg_CustomerMaster.Tables.Count > 0)
                    {
                        txtcustomerid.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerID"].ToString();
                        txtcustomercode.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerCode"].ToString();
                        txtcustomername.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtaddress1.Text = dg_CustomerMaster.Tables[0].Rows[0]["address"].ToString();
                        for (int i = 0; i < ddlcountry.Items.Count; i++)
                        {
                            if (ddlcountry.Items[i].Text.ToString().Trim().ToLower() == dg_CustomerMaster.Tables[0].Rows[0]["country"].ToString().Trim().ToLower())
                            {
                                ddlcountry.SelectedIndex = i;
                                break;
                            }
                        }
                        if (dg_CustomerMaster.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                        {
                            chk_isactive.Checked = true;
                        }
                        else
                        {
                            chk_isactive.Checked = false;
                        }
                       
                        txtphone.Text = dg_CustomerMaster.Tables[0].Rows[0]["Phone"].ToString();
                        txtemail.Text = dg_CustomerMaster.Tables[0].Rows[0]["Email"].ToString();
                        txtcontact1name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_name"].ToString();
                        txtcontact1phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_phone"].ToString();
                        txtcontact1email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_email"].ToString();
                        txtcontact2name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_name"].ToString();
                        txtcontact2phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_phone"].ToString();
                        txtcontact2email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_email"].ToString();
                        txtremarks.Text = dg_CustomerMaster.Tables[0].Rows[0]["remarks"].ToString();
                        Session["customercodes"] = null;
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

                char active;
                if (chk_isactive.Checked == true)
                {
                    active = '1';
                }
                else
                {
                    active = '0';
                }
                //if (txtcustomercode.Text == "")
                //{

                //    lbl_message.Visible = true;
                //}
              if (txtcustomername.Text == "")
                {
                    lbl_message1.Visible = true;
                }
                
                else if (txtaddress1.Text == "")
                {
                    lbl_message2.Visible = true;
                }
                else if (txtphone.Text == "")
                {
                    lbl_message3.Visible = true;
                }
                else
                {
                    string cmdText;
                    SqlCommand sqlCommand;

                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_customermaster ", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerid", txtcustomerid.Text);
                    cmd.Parameters.AddWithValue("@customercode", txtcustomercode.Text);
                    cmd.Parameters.AddWithValue("@customername", txtcustomername.Text);
                    cmd.Parameters.AddWithValue("@address1", txtaddress1.Text);
                    cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@contact1name", txtcontact1name.Text);
                    cmd.Parameters.AddWithValue("@contact1phone", txtcontact1phoneno.Text);
                    cmd.Parameters.AddWithValue("@contact1email", txtcontact1email.Text);
                    cmd.Parameters.AddWithValue("@contact2name", txtcontact2name.Text);
                    cmd.Parameters.AddWithValue("@contact2phone", txtcontact2phoneno.Text);
                    cmd.Parameters.AddWithValue("@contact2email", txtcontact2email.Text);
                    cmd.Parameters.AddWithValue("@remarks", txtremarks.Text);
                    cmd.Parameters.AddWithValue("@isactive", active);
                    cmd.Parameters.AddWithValue("@createuser", Global.GlobalVariables.susername.ToString());
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('Saved Successfully..!');", addScriptTags: true);
                    funclear();
                    Response.Redirect("~/customermaster_grid.aspx",false);
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
            if (Global.GlobalVariables.sCustMode == "Edit")
            {
               
            }
            else
            {
                txtcustomercode.Text = "";
                txtcustomername.Text = "";
                txtaddress1.Text = "";
                ddlcountry.SelectedIndex = 0;
                txtphone.Text = "";
                txtemail.Text = "";
                txtcontact1name.Text = "";
                txtcontact1phoneno.Text = "";
                txtcontact1email.Text = "";
                txtcontact2name.Text = "";
                txtcontact2phoneno.Text = "";
                txtcontact2email.Text = "";
                chk_isactive.Checked = false;
            }
        }
        private void Load_country()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select countryname from tblcountry ", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddlcountry.DataValueField = "countryname";
            ddlcountry.DataTextField = "countryname";
            ddlcountry.DataSource = dbtl;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, "SINGAPORE");
            ddlcountry.SelectedIndex = 0;
        }

        protected void txtcustomercode_TextChanged(object sender, System.EventArgs e)
        {
            //btnclear.Visible = false;
            //txtcustomercode.Attributes.Add("readonly", "readonly");
            //txtcustomerid.Attributes.Add("readonly", "readonly");
            //sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();
            //SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_CustomerMaster where Customercode='" + txtcustomercode.Text + "'", sqlConnection);
            //DataTable dbt2 = new DataTable();
            //sqlda.Fill(dbt2);
            //DataSet dg_CustomerMaster = new DataSet();
            //dg_CustomerMaster.Tables.Add(dbt2);

            //if (dg_CustomerMaster != null && dg_CustomerMaster.Tables.Count > 0)
            //{
            //    if (dg_CustomerMaster.Tables[0].Rows.Count > 0)
            //    {
            //        txtcustomerid.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerID"].ToString();
            //        txtcustomercode.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerCode"].ToString();
            //        txtcustomername.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerName"].ToString();
            //        txtaddress1.Text = dg_CustomerMaster.Tables[0].Rows[0]["address"].ToString();
            //        for (int i = 0; i < ddlcountry.Items.Count; i++)
            //        {
            //            if (ddlcountry.Items[i].Text.ToString().Trim().ToLower() == dg_CustomerMaster.Tables[0].Rows[0]["country"].ToString().Trim().ToLower())
            //            {
            //                ddlcountry.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //        if (dg_CustomerMaster.Tables[0].Rows[0]["IsActive"].ToString() == "True")
            //        {
            //            chk_isactive.Checked = true;
            //        }
            //        else
            //        {
            //            chk_isactive.Checked = false;
            //        }

            //        txtphone.Text = dg_CustomerMaster.Tables[0].Rows[0]["Phone"].ToString();
            //        txtemail.Text = dg_CustomerMaster.Tables[0].Rows[0]["Email"].ToString();
            //        txtcontact1name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_name"].ToString();
            //        txtcontact1phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_phone"].ToString();
            //        txtcontact1email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_email"].ToString();
            //        txtcontact2name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_name"].ToString();
            //        txtcontact2phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_phone"].ToString();
            //        txtcontact2email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_email"].ToString();
            //        txtremarks.Text = dg_CustomerMaster.Tables[0].Rows[0]["remarks"].ToString();
            //        Session["customercodes"] = null;
            //    }
            //}
        }

        protected void txtcustomername_TextChanged(object sender, System.EventArgs e)
        {
            btnclear.Visible = false;
            txtcustomercode.Attributes.Add("readonly", "readonly");
            txtcustomerid.Attributes.Add("readonly", "readonly");
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_CustomerMaster where Customercode='" + txtcustomercode.Text + "'", sqlConnection);
            DataTable dbt2 = new DataTable();
            sqlda.Fill(dbt2);
            DataSet dg_CustomerMaster = new DataSet();
            dg_CustomerMaster.Tables.Add(dbt2);
            if (dg_CustomerMaster.Tables[0].Rows.Count > 0)
                {
                    txtcustomerid.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerID"].ToString();
                    txtcustomercode.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerCode"].ToString();
                    txtcustomername.Text = dg_CustomerMaster.Tables[0].Rows[0]["CustomerName"].ToString();
                    txtaddress1.Text = dg_CustomerMaster.Tables[0].Rows[0]["address"].ToString();
                    for (int i = 0; i < ddlcountry.Items.Count; i++)
                    {
                        if (ddlcountry.Items[i].Text.ToString().Trim().ToLower() == dg_CustomerMaster.Tables[0].Rows[0]["country"].ToString().Trim().ToLower())
                        {
                            ddlcountry.SelectedIndex = i;
                            break;
                        }
                    }
                    if (dg_CustomerMaster.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                    {
                        chk_isactive.Checked = true;
                    }
                    else
                    {
                        chk_isactive.Checked = false;
                    }

                    txtphone.Text = dg_CustomerMaster.Tables[0].Rows[0]["Phone"].ToString();
                    txtemail.Text = dg_CustomerMaster.Tables[0].Rows[0]["Email"].ToString();
                    txtcontact1name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_name"].ToString();
                    txtcontact1phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_phone"].ToString();
                    txtcontact1email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact1_email"].ToString();
                    txtcontact2name.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_name"].ToString();
                    txtcontact2phoneno.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_phone"].ToString();
                    txtcontact2email.Text = dg_CustomerMaster.Tables[0].Rows[0]["contact2_email"].ToString();
                    txtremarks.Text = dg_CustomerMaster.Tables[0].Rows[0]["remarks"].ToString();
                    Session["customercodes"] = null;
                }
            }
        }

                                                                                       }


