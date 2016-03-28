using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PublicLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_username.Text == "Public" && txt_password.Text=="Public")
            {
                Response.Redirect("Public_user.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Incorrect username or password');", true);
            }
        }
        catch
        {
        }
    }
}