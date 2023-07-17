using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Web.Script.Serialization;
using System.Net.Mail;


namespace IssueRegister
{
    public partial class Email : System.Web.UI.Page
    {
        static string sEmailList = String.Empty;
        string sServer, sFromEmailId, ssubject, sPassword, scontent;
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
            lbl_msg.Visible = false;
            lbl_save.Visible = false;
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text == "")
                {

                    lbl_msg4.Visible = true;
                }
                else if (txtsubject.Text == "")
                {
                    lbl_msg5.Visible = true;
                }
                else
                {
                    sToEmailAddress = txtemail.Text;
                    ssubject = txtsubject.Text;
                    scontent = txtcontent.Text;


                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select email,password from tbl_company where companyid='c01'", sqlConnection);
                    DataTable dbt2 = new DataTable();
                    sqlda.Fill(dbt2);
                    DataSet ds1 = new DataSet();
                    sqlda.Fill(ds1);
                    sFromEmailId = ds1.Tables[0].Rows[0]["Email"].ToString();
                    sPassword = ds1.Tables[0].Rows[0]["password"].ToString();

                    if (sToEmailAddress != "")
                    {
                        subSendEmail(ssubject, scontent, sToEmailAddress, "", "");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                lbl_save.Visible = true;
            }


        }
        


        private void subSendEmail(string sSubject, string scontent, string sToEmailId, string sCC, string sBCC)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //SmtpClient SmtpServer = new SmtpClient("smtp.mail.yahoo.com");
                SmtpClient SmtpServer1 = new SmtpClient(sServer);
                mail.From = new MailAddress(sFromEmailId);
                mail.To.Add(sToEmailId);
                mail.Subject = sSubject;
                mail.Body = scontent;
                
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sFromEmailId, sPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                funclear();
                lbl_msg.Visible = true;


            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "dim('ERROR in Email Sending: " + message + "');", true);
                return;
            }
        }
        public void funclear()
        {
                txtemail.Text = "";
                txtsubject.Text = "";
                txtcontent.Text = "";
               
            }

        protected void btnexport_Click(object sender, System.EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tbl_usermaster", sqlConnection);
            DataTable dbt2 = new DataTable();
            sqlda.Fill(dbt2);
            DataSet ds1 = new DataSet();
            sqlda.Fill(ds1);

        var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
        var worksheet = workbook.CreateSheet("Sheet1");

        // Create a header row in the worksheet
        var headerRow = worksheet.CreateRow(0);
        for (int i = 0; i < ds1.Tables[0].Columns.Count; i++)
        {
            headerRow.CreateCell(i).SetCellValue(ds1.Tables[0].Columns[i].ColumnName);
        }

        // Create data rows in the worksheet
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            var dataRow = worksheet.CreateRow(i + 1);
            for (int j = 0; j < ds1.Tables[0].Columns.Count; j++)
            {
                dataRow.CreateCell(j).SetCellValue(ds1.Tables[0].Rows[i][j].ToString());
            }
        }

        // Save the workbook to a memory stream
        var stream = new MemoryStream();
        workbook.Write(stream);

        // Set the response headers to force download the Excel file
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=ExportedData.xlsx");
        Response.BinaryWrite(stream.ToArray());
        Response.End();
    }

}
}
    
