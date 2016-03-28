using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UserLogin : System.Web.UI.Page
{
    BAL obj_service = new BAL();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txt_userId.Text ="CU00"+Convert.ToString(obj_service.UserId());
        }
        catch
        {
 
        }

    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        try
        {
            Registration reg = new Registration();
            reg.UserID = txt_userId.Text;
            reg.username = txt_user.Text;
            reg.password = txt_userpass.Text;
            reg.emailid = txt_emailid.Text;
            reg.gender = RadioButtonList1.SelectedItem.Text;
            reg.phone = Convert.ToInt64(txt_phone.Text);
            reg.city = txt_city.Text;
            bool i = obj_service.register(reg);
            if (i == true)
            {
                string str = RandomString(6);
                upload upload = new upload();
                upload.userId = txt_userId.Text;
                upload.key = str;
                obj_service.insert_key(upload);
                //sendMail(txt_emailid.Text, str);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Register Successfully...Your Authentication key is: " + str + "');", true);
                clear();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Register failed');", true);
            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ex.Message + "');", true);
        }
               
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            Registration reg = new Registration();
            reg.username = txt_username.Text;
            Session["username"] = txt_username.Text;
            reg.password = txt_password.Text;
            bool i = obj_service.login(reg);
            if (i == true)
            {
                Response.Redirect("Convergent Key.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid emailid and password');", true);
            }

        }
        catch
        { 

        }
      
    }
    public void clear()
    {
        try
        {
            txt_userId.Text = "";
            txt_user.Text = "";
            txt_city.Text = "";
            txt_emailid.Text = "";
            txt_phone.Text = "";
            RadioButtonList1.Items.Clear();
        }
        catch
        {
 
        }
       
    }
    public static string RandomString(int length)
    {
         const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
         var random = new Random();
         return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public string sendMail(string tomail, string key)
    {
        MailMessage message = new MailMessage();
        string fromemail = "icloudservice39@gmail.com";
        string frompw = "icloudser";
        message.From = new MailAddress(fromemail);
        message.To.Add(tomail);
        message.Subject = "hello";
        message.Body = "Your Authendication  Key is: " + key;
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
    public void bind(string rec_no, string msg)
    {

        string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=madhanece55@gmail.com:madhan&senderID=TEST SMS&receipientno=" + rec_no + "&msgtxt=" + msg + "&state=4";
        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind("8220236525", "Your are Terminatd from Spiro solution Pvt. Ltd.,");
    }
   
}