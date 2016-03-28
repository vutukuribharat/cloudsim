using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class File_upload : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        upload upload = new upload();
        upload.userId = Session["username"].ToString();
        upload.key = txt_token.Text;
        bool i = obj_service.check_file_token(upload);
        if (i == true)
        {
            bool j = obj_service.check_file_token_upload(upload);
            if (j == false)
            {
                Session["File_token"] = txt_token.Text;
                Response.Redirect("dedup.aspx");
            }
            else
            {
                Response.Write("<script>alert('File Token is Already used...')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('File token is not valid...')</script>");
        }

        

    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_file_token.aspx");
    }
}