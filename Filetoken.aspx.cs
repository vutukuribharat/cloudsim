using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
public partial class Filetoken : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    DataSet ds = new DataSet();
        //    DataSet ds1 = new DataSet();
        //    upload upload = new upload();
        //    Registration reg=new Registration();
        //    reg.UserID=Session["username"].ToString();
        //    upload.userId = Session["username"].ToString();

        //    ds = obj_service.get_key(upload);
        //    ds1 = obj_service.check(reg);
        //    string str = ds1.Tables[0].Rows[0][0].ToString();
        //    if (ds.Tables[0].Rows.Count == 0 || str=="no")
        //    {
        //        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You are not Activated');", true);
        //    }
        //    else
        //    {
        //        Panel1.Visible = true;
        //    }
        //}
        //catch
        //{
        //}
    }


    protected void btn_token_Click(object sender, EventArgs e)
    {
        try
        {

            upload upload = new upload();
            upload.userId = Session["username"].ToString();
            upload.time = DateTime.Now;
            Random random = new Random();
            int key1 = random.Next(22222222, 88888888);
            int key2 = random.Next(22222222, 88888888);
            string str1 = Convert.ToString(key1);
            string str2 = Convert.ToString(key2);
            string str = Convert.ToString(str1 + str2);
            upload.key = Convert.ToString(str);
            bool i = obj_service.insert_token_request(upload);
            if (i == true)
            {
                Response.Write("<script>alert('Request is sent')</script>");
            }
            else
            {
                Response.Write("<script>alert('sending failed')</script>");
            }



            //DataSet ds = new DataSet();
            //upload upload = new upload();
            //upload.userId = Session["username"].ToString();
            //ds = obj_service.get_key(upload);
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You are not Activated');", true);
            //    Generate.Text = "You are not Activated";
            //}
            //else
            //{
            //    Generate.Text = ds.Tables[0].Rows[0][0].ToString();
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Your convergent key is:'"+ds.Tables[0].Rows[0][0].ToString()+"');", true);
            //}
        }
        catch
        { 
        }
    }
}