using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class File_token_requests : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = obj_service.select_token_request();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No records Found')</script>");
            }
        }
        catch
        {
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton link_button = (LinkButton)e.Row.FindControl("LinkButton1");
                Label lb = (Label)e.Row.FindControl("Label1");
                if (lb.Text == "yes")
                {
                    
                    link_button.Text = "Sent";
                    lb.Text = "Sent";
                }
                else
                {
                   
                    link_button.Text = "Send";
                    lb.Text = "Pending";
                }
            }
        }
        catch
        {

        }
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = sender as LinkButton;
            if (lb.Text == "Send")
            {
                upload upload = new upload();

                string[] comnd = lb.CommandArgument.Split(',');

                upload.userId = comnd[0].ToString();
                upload.time = Convert.ToDateTime(lb.CommandName.ToString());
                bool i = obj_service.update_file_token(upload);
                Registration reg = new Registration();
                reg.emailid = comnd[0].ToString();
                string email = obj_service.get_email(reg);
                string key = comnd[1].ToString();
                // sendMail(email, key);
                if (i == true)
                {
                    Response.Redirect("File_token_requests.aspx");
                }
                else
                {

                }

            }
            else
            {
                Response.Write("Already sent");
            }
        }
        catch
        {
        }
    }
    public string sendMail(string tomail, string key)
    {
        MailMessage message = new MailMessage();
        string fromemail = "icloudservice39@gmail.com";
        string frompw = "icloudser";
        message.From = new MailAddress(fromemail);
        message.To.Add(tomail);
        message.Subject = "hello";
        message.Body = "Your File token is: " + key + ".....................Thank you..";
        message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        using (SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587))
        {
            smtpclient.EnableSsl = true;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = new NetworkCredential(fromemail, frompw);
            try
            {
                smtpclient.Send(message.From.ToString(), message.To.ToString(), message.Subject, message.Body);

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        return "send successfully";
    }
}