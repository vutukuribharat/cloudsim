using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privatelogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_username.Text == "private" && txt_password.Text == "private")
            {
                Response.Redirect("UserDetails.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid username and password');", true);
            }
        }
        catch
        { 

        }
    }
}