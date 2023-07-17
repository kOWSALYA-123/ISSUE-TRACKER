using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Web.Script.Serialization;
using System.Net.Mail;

namespace IssueRegister
{
    public partial class TicketRegisters : System.Web.UI.Page
    {
        
        
       static string sEmailList = String.Empty;
        string sServer, sFromEmailId, sPassword, sAllowEmailInDayEnd, sReportExportFormat;
         string sToEmailAddress;
         string sReportsToFire, sReportTitle;
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Loc_Con"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString().Length == 0)
            {
                Response.Redirect(string.Format("~/UserLogin.aspx?RedirectUr={0}", Request.UrlReferrer));
            }
            try
            {
                if (!IsPostBack)
                {
                    SqlConnection sqlCon1 = new SqlConnection(connectionString);
                    SqlDataAdapter sqlda2 = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon1);
                    DataTable dbt3 = new DataTable();
                    sqlda2.Fill(dbt3);
                    Boolean temp1 = (from DataRow dr in dbt3.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isconsultant"]).FirstOrDefault();
                    sqlCon1.Close();
                    if (temp1 == true)
                    {

                        txtconsultant.Text = Global.GlobalVariables.susername;
                    }
                    else
                    {

                    }

                    SqlConnection sqlCon = new SqlConnection(connectionString);
                    SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon);
                    DataTable dbtl = new DataTable();
                    sqlda1.Fill(dbtl);
                    Boolean temp = (from DataRow dr in dbtl.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["ISCUSTOMER"]).FirstOrDefault();
                    sqlCon.Close();
                    if (temp == true)
                    {
                        ddlassigned.Visible = false;
                        txtestimate.Visible = false;
                        ddldeveloper.Visible = false;
                        txtfixedbydate.Visible = false;
                        lbl_cust1.Visible = false;
                        //lbl_cust2.Visible = false;
                        lbl_cust3.Visible = false;
                        lbl_cust4.Visible = false;
                    }
                    else
                    {
                        ddlassigned.Visible = true;
                        txtestimate.Visible = true;
                        ddldeveloper.Visible = true;
                        txtfixedbydate.Visible = true;
                        lbl_cust1.Visible = true;
                        //lbl_cust2.Visible = true;
                        lbl_cust3.Visible = true;
                        lbl_cust4.Visible = true;
                    }
                    chk_isactive.Checked = true;
                    txtregisterdate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                  
                    txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
                    CalendarExtender2.Enabled = false;
                    Load_customer();
                    Load_developer();
                    Load_developer1();
                    SqlConnection sqlCon2 = new SqlConnection(connectionString);
                    SqlDataAdapter sqlda3 = new SqlDataAdapter("select * from tbl_UserMaster", sqlCon1);
                    DataTable dbt4 = new DataTable();
                    sqlda3.Fill(dbt4);
                    Boolean temp2 = (from DataRow dr in dbt3.Rows where (string)dr["username"] == Global.GlobalVariables.susername.ToString() select (Boolean)dr["isdeveloper"]).FirstOrDefault();
                    sqlCon1.Close();
                    if (temp2 == true)
                    {
                        for (int i = 0; i < ddlassigned.Items.Count; i++)
                        {
                            if (ddlassigned.Items[i].Text.ToString().Trim().ToLower() == Global.GlobalVariables.susername.ToString().ToLower())
                            {
                                ddlassigned.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                    if (Global.GlobalVariables.sCustMode2 == "Edit")
                    {
                        CalendarExtender2.Enabled = false;
                        txtregisterdate.Attributes.Add("readonly", "readonly");
                        txtTime.Attributes.Add("readonly", "readonly");
                        btnclear.Visible = false;
                        ddlcustomer.Attributes.Add("readonly", "readonly");
                        ddlcustomer.BackColor = Color.Yellow;
                        //lblname.Attributes.Add("readonly", "readonly");
                        //lblname.BackColor = Color.Yellow;
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        SqlDataAdapter sqlda = new SqlDataAdapter("select * from vw_Ticket where TiCKETID='" + Session["TICKETID"].ToString() + "'", sqlConnection);
                        DataTable dbt2 = new DataTable();
                        sqlda.Fill(dbt2);
                        DataSet dg_ticketregister = new DataSet();
                        dg_ticketregister.Tables.Add(dbt2);
                        if (dg_ticketregister != null && dg_ticketregister.Tables.Count > 0)
                        {

                            for (int i = 0; i < ddlcustomer.Items.Count; i++)
                            {
                                if (ddlcustomer.Items[i].Text.ToString().Trim().ToLower() == dg_ticketregister.Tables[0].Rows[0]["Customername"].ToString().Trim().ToLower())
                                {
                                    ddlcustomer.SelectedIndex = i;
                                    break;
                                }
                            }
                            Load_product();
                            txtticket.Text = dg_ticketregister.Tables[0].Rows[0]["ticketid"].ToString();
                            //lblname.Text = dg_ticketregister.Tables[0].Rows[0]["CustomerName"].ToString();
                            txtTime.Text = Convert.ToDateTime(dg_ticketregister.Tables[0].Rows[0]["Registertime"]).Date.ToString("HH:mm:ss");
                            txtmodule.Text = dg_ticketregister.Tables[0].Rows[0]["MODULE"].ToString();
                            txtissue.Text = dg_ticketregister.Tables[0].Rows[0]["ISSUE"].ToString();
                            //ddlpriority.Text = dg_ticketregister.Tables[0].Rows[0]["Priority"].ToString();
                            ddlstatus.Text = dg_ticketregister.Tables[0].Rows[0]["STATUS"].ToString();
                            txtclosedon.Text = Convert.ToDateTime(dg_ticketregister.Tables[0].Rows[0]["CLOSEDATE"]).Date.ToString("dd/MM/yyyy");
                            txtregisterdate.Text = Convert.ToDateTime(dg_ticketregister.Tables[0].Rows[0]["REGISTERDATE"]).Date.ToString("dd/MM/yyyy");
                            txtestimate.Text = dg_ticketregister.Tables[0].Rows[0]["ESTIMATEDAYS"].ToString();
                            txtconsultant.Text = dg_ticketregister.Tables[0].Rows[0]["CONSULTANT"].ToString();
                            //txtfixedbydate.Text = Convert.ToDateTime(dg_ticketregister.Tables[0].Rows[0]["FIXEDBYDATE"]).Date.ToString("dd/MM/yyyy");
                            //txtstartdate.Text = Convert.ToDateTime(dg_ticketregister.Tables[0].Rows[0]["Enddatetime"]).Date.ToString("dd/MM/yyyy");
                            txtfixedbydate.Text = dg_ticketregister.Tables[0].Rows[0]["FIXEDBYDATE"].ToString();
                            //txtstartdate.Text = dg_ticketregister.Tables[0].Rows[0]["Enddatetime"].ToString();
                            //txtremarks.Text = dg_ticketregister.Tables[0].Rows[0]["remarks"].ToString();
                            for (int i = 0; i < ddlproductid.Items.Count; i++)
                            {
                                if (ddlproductid.Items[i].Text.ToString().Trim().ToLower() == dg_ticketregister.Tables[0].Rows[0]["PRODUCTCODE"].ToString().Trim().ToLower())
                                {
                                    ddlproductid.SelectedIndex = i;
                                    break;
                                }
                            }
                            for (int i = 0; i < ddldeveloper.Items.Count; i++)
                            {
                                if (ddldeveloper.Items[i].Text.ToString().Trim().ToLower() == dg_ticketregister.Tables[0].Rows[0]["FIXEDBY"].ToString().Trim().ToLower())
                                {
                                    ddldeveloper.SelectedIndex = i;
                                    break;
                                }
                            }
                            for (int i = 0; i < ddlassigned.Items.Count; i++)
                            {
                                if (ddlassigned.Items[i].Text.ToString().Trim().ToLower() == dg_ticketregister.Tables[0].Rows[0]["ASSIGNEDTO"].ToString().Trim().ToLower())
                                {
                                    ddlassigned.SelectedIndex = i;
                                    break;
                                }
                            }
                            if (dg_ticketregister.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                            {
                                chk_isactive.Checked = true;
                            }
                            else
                            {
                                chk_isactive.Checked = false;
                            }

                            Session["customercodes"] = null;
                        }
                        bindgrid();
                    }

                    else
                    {
                        Session["TICKETID"] = null;
                        dg_image.DataSource = null;
                        dg_image.DataBind();

                        SqlCommand cmd = new SqlCommand("select customerid,customername from tbl_CustomerMaster where CUSTOMERCODE='" + Global.GlobalVariables.susername + "'", sqlConnection);

                        cmd.Connection = sqlConnection;
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ddlcustomer.Text = dr.GetValue(0).ToString();
                            //lblname.Text = dr.GetValue(1).ToString();
                        }

                    }

                }
                else
                {
                }
            }
            catch (System.Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('" + ex.Message.ToString() + "');", addScriptTags: true);
            }
           

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dg_image, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dg_image.SelectedRow.RowIndex;
            Global.GlobalVariables.Filename1 = dg_image.SelectedRow.Cells[0].Text;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('image.aspx','_newtab');", true);
            
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtestimate.Text == "")
                {

                    lbl_message3.Visible = true;
                }
                else if (ddlproductid.Text == "")
                {
                    lbl_msg3.Visible = true;
                }
                else if (ddlcustomer.Text == "")
                {
                    lbl_msg4.Visible = true;
                }
                else if (ddlassigned.Text == "")
                {
                    lbl_msg5.Visible = true;
                }
                else if (txtclosedon.Text == "")
                {
                    lbl_msg1.Visible = true;
                }
                else if (txtfixedbydate.Text == "")
                {
                    lbl_msg2.Visible = true;
                }
                else
                {
                    string cmdText;
                    SqlCommand sqlCommand;
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_Ticketregisters  ", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TICKETID", txtticket.Text);
                    cmd.Parameters.AddWithValue("@registerdate", Convert.ToDateTime(txtregisterdate.Text));
                    cmd.Parameters.AddWithValue("@Registertime", Convert.ToDateTime(txtTime.Text));
                    cmd.Parameters.AddWithValue("@customercode", ddlcustomer.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@productid", ddlproductid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@module", txtmodule.Text);
                    cmd.Parameters.AddWithValue("@issue", txtissue.Text);
                    //cmd.Parameters.AddWithValue("@Priority", ddlpriority.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@status", ddlstatus.Text);
                    cmd.Parameters.AddWithValue("@consultantid", txtconsultant.Text);
                    cmd.Parameters.AddWithValue("@closeddt", Convert.ToDateTime(txtclosedon.Text));
                    cmd.Parameters.AddWithValue("@assignedtoid", ddlassigned.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@estimatemdays", txtestimate.Text);
                    cmd.Parameters.AddWithValue("@fixedbyname", ddldeveloper.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@fixeddate", Convert.ToDateTime(txtfixedbydate.Text));
                    //cmd.Parameters.AddWithValue("@Enddatetime", Convert.ToDateTime(txtstartdate.Text));
                    //cmd.Parameters.AddWithValue("@remarks", txtremarks.Text);
                    cmd.Parameters.AddWithValue("@createuser", Global.GlobalVariables.susername.ToString());
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    
                    if (Global.GlobalVariables.sCustMode2 == "Edit")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('Saved Successfully..!');", addScriptTags: true);
                        funclear();
                        Response.Redirect("~/TicketRegister_grid.aspx", false);
                    }
                    else
                    {
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();
                        SqlDataAdapter sqlda1 = new SqlDataAdapter("select email,password from tbl_company where companyid='c01'", sqlConnection);
                        DataTable dbt2 = new DataTable();
                        sqlda1.Fill(dbt2);
                        DataSet ds1 = new DataSet();
                        sqlda1.Fill(ds1);
                        dg_image.DataSource = ds1;
                        sFromEmailId = ds1.Tables[0].Rows[0]["Email"].ToString();
                        sPassword = ds1.Tables[0].Rows[0]["password"].ToString();
                        sReportTitle = "Unipro software pvt ltd";
                        funGetEmailId();
                        if (sToEmailAddress != "")
                        {
                            subSendEmail(sReportTitle, "Hi", sToEmailAddress, "", "");
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "Alert_CodeBehind('Saved Successfully..!');", addScriptTags: true);
                        funclear();
                        Response.Redirect("~/TicketRegister_grid.aspx", false);
                    }
                    
                }
            }

            catch (Exception ex)
            {
                lbl_save.Visible = true;
            }


        }
        public void funGetEmailId()
        {
                   sEmailList = string.Empty;
                   sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select email from tbl_UserMaster where username='" + ddlassigned.SelectedValue.ToString() + "'", sqlConnection);
                    DataTable dbtl = new DataTable();
                    sqlda.Fill(dbtl);
                    DataSet ds = new DataSet();
                    sqlda.Fill(ds);
                    dg_image.DataSource = ds;
                   
                          
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sEmailList = sEmailList += ds.Tables[0].Rows[0]["Email"].ToString().Trim() + ",";
                                }
                            }
                            if (sEmailList.Substring(0, 1) == ",")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "dim('Invalid EmailID');", true);
                                return;
                            }
                            else
                            {
                                sToEmailAddress = sEmailList.Remove(sEmailList.Length - 1, 1);
                            }
           
                        
           }

            
        
        private void subSendEmail(string sSubject, string sMessage,  string sToEmailId, string sCC, string sBCC)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpClient SmtpServer1 = new SmtpClient(sServer);
                mail.From = new MailAddress(sFromEmailId);
                mail.To.Add(sToEmailId);
                mail.Subject = sSubject;
                mail.Body = sMessage;
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(sAttachmentPath);
                //mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sFromEmailId, sPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                //mail.Attachments.Dispose();
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "dim('Email Sent Successfully..!');", true);
               


            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "dim('ERROR in Email Sending: " + message + "');", true);
                return;
            }
        }
        protected void btnclear_Click(object sender, System.EventArgs e)
        {
            funclear();
        }

        public void funclear()
        {
            if (Global.GlobalVariables.sCustMode2 == "Edit")
            {

            }
            else
            {
                ddlcustomer.SelectedIndex = 0;

                //lblname.Text = "";
                txtmodule.Text = "";
                txtissue.Text = "";
                ddlproductid.SelectedIndex = 0;
                txtclosedon.Text = "";
                txtregisterdate.Text = "";
                txtconsultant.Text = "";
                txtestimate.Text = "";
                txtfixedbydate.Text = "";
                ddldeveloper.SelectedIndex = 0;
                ddlcustomer.SelectedIndex = 0;
                ddlassigned.SelectedIndex = 0;
                Session["TICKETID"] = "";
                dg_image.DataSource = null;
                dg_image.DataBind();
            }
        }
        public void funvalidation()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_UserMaster where username='" + Global.GlobalVariables.susername.ToString() + "'", sqlConnection);
            DataTable dbt3 = new DataTable();
            sqlda.Fill(dbt3);
            DataSet dg_ticketregister = new DataSet();
            dg_ticketregister.Tables.Add(dbt3);
            if (dg_ticketregister != null)
            {
                if (dg_ticketregister.Tables[0].Rows.Count > 0)
                {
                    if (dg_ticketregister.Tables[0].Rows[0]["iscustomer"].ToString() == "True")
                    {
                        txtconsultant.Attributes.Add("readonly", "readonly");
                        ddldeveloper.Attributes.Add("readonly", "readonly");


                    }
                    if (dg_ticketregister.Tables[0].Rows[0]["iscoordinator"].ToString() == "True")
                    {

                    }
                    if (dg_ticketregister.Tables[0].Rows[0]["isconsultant"].ToString() == "True")
                    {
                        ddldeveloper.Attributes.Add("readonly", "readonly");

                    }
                    if (dg_ticketregister.Tables[0].Rows[0]["isdeveloper"].ToString() == "True")
                    {
                        ddlcustomer.Attributes.Add("readonly", "readonly");
                        //lblname.Attributes.Add("readonly", "readonly");
                        txtmodule.Attributes.Add("readonly", "readonly");
                        txtissue.Attributes.Add("readonly", "readonly");
                        txtregisterdate.Attributes.Add("readonly", "readonly");
                        txtconsultant.Attributes.Add("readonly", "readonly");

                    }

                }


            }


        }

        
        protected void ddlcustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            if (ddlcustomer.Text != "")
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("select AD.CustomerID,Cm.CustomerName,AD.AMC_StartDate,AD.AMC_EndDate,AD.ISPAID,AD.ISACTIVE,AD.CreateUser,AD.CreateDate,AD.ModifyUser,AD.ModifyDate from tbl_AmcDetail AD inner join tbl_CustomerMaster CM on AD.CustomerID=CM.CustomerID WHERE CM.CUSTOMERNAME='" + ddlcustomer.SelectedValue.ToString() + "'", sqlConnection);
                DataTable dbt2 = new DataTable();
                sqlda.Fill(dbt2);
                DataSet dg_amcdetails = new DataSet();
                dg_amcdetails.Tables.Add(dbt2);
                if (dg_amcdetails.Tables[0].Rows.Count == 0)
                {

                    lbl_msg.Visible = true;
                    ddlproductid.Enabled = false;

                }
                else
                {

                    lbl_msg.Visible = false;
                    ddlproductid.Enabled = true;
                }

                Load_product();
                sqlConnection.Close();
                Global.GlobalVariables.supdate = "Edit";

            }
        }



        private void Load_developer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select username from tbl_UserMaster where isdeveloper=1", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddldeveloper.DataValueField = "username";
            ddldeveloper.DataTextField = "username";
            ddldeveloper.DataSource = dbtl;
            ddldeveloper.DataBind();
            ddldeveloper.Items.Insert(0, "----SELECT----");
            ddldeveloper.SelectedIndex = 0;
        }
        private void Load_customer()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select  CustomerName  from tbl_CustomerMaster where IsActive=1", sqlConnection);
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

            SqlDataAdapter sqlda = new SqlDataAdapter("select PM.ProductName AS PRODUCTNAME from tbl_Customer_Product CP inner join tbl_CustomerMaster CM on CP.CustomerID=CM.CustomerID  Inner join tbl_ProductMaster PM on PM.ProductId=CP.ProductId  WHERE CM.CUSTOMERNAME='" + ddlcustomer.SelectedValue.ToString() + "' AND CP.ISACTIVE='1'", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddlproductid.DataValueField = "PRODUCTNAME";
            ddlproductid.DataTextField = "PRODUCTNAME";
            ddlproductid.DataSource = dbtl;
            ddlproductid.DataBind();
            ddlproductid.Items.Insert(0, "----SELECT----");
            ddlproductid.SelectedIndex = 0;
        }
        private void Load_developer1()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select username from tbl_UserMaster where isdeveloper=1", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            ddlassigned.DataValueField = "username";
            ddlassigned.DataTextField = "username";
            ddlassigned.DataSource = dbtl;
            ddlassigned.DataBind();
            ddlassigned.Items.Insert(0, "----SELECT----");
            ddlassigned.SelectedIndex = 0;
        }


        protected void btnaddimage_Click(object sender, System.EventArgs e)
        {
            byte[] array = null;
            int Imgnumber = 0;

            List<HttpPostedFile> files = new List<HttpPostedFile>();
            dynamic fileUploadControlDynamic = btnfileupload;
            foreach (HttpPostedFile file in fileUploadControlDynamic.PostedFiles)
            {
                files.Add(file);
            }

            if (Session["TICKETID"] == "" || Session["TICKETID"] == null)
            {
                Session["TICKETID"] = "";
            }

            int fileSize = btnfileupload.PostedFile.ContentLength;
            //Limit size to approx 2mb for image
            if ((fileSize > 0 & fileSize < 2097152))
            {
               
            }
            else
            {
                lbl_image.Visible = true;
                return;
            }

            for (int i = 0; i < files.Count; i++)
            {
                if (btnfileupload.HasFile)
                {
                    if (checkFileType(btnfileupload.FileName))
                    {
                        HttpPostedFile postedFile = btnfileupload.PostedFile;
                        array = new byte[postedFile.ContentLength];
                        postedFile.InputStream.Read(array, 0, postedFile.ContentLength);
                        sqlConnection = new SqlConnection(connectionString);
                        sqlConnection.Open();

                        string cmdText = "Insert into tbl_Images_temp values (@ImgNumber,@img,getdate(),@FileName)";
                        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@ImgNumber", Session["TICKETID"]);
                        sqlCommand.Parameters.AddWithValue("@img", array);
                        sqlCommand.Parameters.AddWithValue("@FileName", btnfileupload.FileName);
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                    }
                    bindgrid();
                }
            }
        }
        

        bool checkFileType(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;

                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            try
            {
                string Ses1 = Session["TICKETID"].ToString();
                SqlConnection sqlCon = new SqlConnection(connectionString);
                ImageButton btn1 = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn1.NamingContainer;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("delete from tbl_Images_temp where TICKETID=@Imgnumber and FileName = @FileName", sqlCon);
                cmd.Parameters.AddWithValue("@ImgNumber", Session["TICKETID"]);
                cmd.Parameters.AddWithValue("@FileName", row.Cells[0].Text);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                this.bindgrid();
            }
            catch (Exception ex)
            {
            }
        }
        private void bindgrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select FileName from tbl_Images_temp where TicketId = '" + Session["TICKETID"] + "'", sqlConnection);
            DataTable dbtl = new DataTable();
            sqlda.Fill(dbtl);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            dg_image.DataSource = ds;
            dg_image.DataBind();
        }

        protected void ddlcustomer1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string cmdText;
            SqlCommand sqlCommand;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            if (ddlcustomer.SelectedIndex != 0)
            {
                string Pname = "";
                string[] pdemo = new string[0];
                Pname = ddlcustomer.SelectedValue.ToString();
                pdemo = Pname.Split('-');
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_AmcDetail where CustomerID=(select customerid from tbl_customerMASTER WHERE CUSTOMERCODE= '" + pdemo[0] + "') and amc_enddate>getdate()", sqlConnection);
                DataTable dbtl = new DataTable();
                sqlda.Fill(dbtl);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                sqlConnection.Close();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        lbl_msg.Visible = false;
                    }
                }
                Global.GlobalVariables.supdate = "Edit";
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

        

        protected void txtclosedon_TextChanged(object sender, System.EventArgs e)
        {
            DateTime date1 = DateTime.Parse(txtclosedon.Text);
            DateTime date2 = DateTime.Parse(txtregisterdate.Text);
            if (date1 > date2)
            {
                lbl_date.Visible = false;

            }
            else
            {
                lbl_date.Visible = true;
                txtclosedon.Text = "";
            }
        }

        protected void txtfixedbydate_TextChanged(object sender, System.EventArgs e)
        {
            DateTime date3 = DateTime.Parse(txtfixedbydate.Text);
            DateTime date4 = DateTime.Parse(txtregisterdate.Text);
            if (date3 > date4)
            {
                lb_date.Visible = false;
            }
            else
            {
                lb_date.Visible = true;
                txtfixedbydate.Text = "";
            }
        }

        



    }
}

