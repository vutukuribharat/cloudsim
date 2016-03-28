using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Convergent_Kye : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            upload upload=new upload();
            upload.userId = Session["username"].ToString();
            DataSet ds=new DataSet();
            ds = obj_service.get_key(upload);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string key = txt_key.Text;
                if (key == ds.Tables[0].Rows[0][0].ToString())
                {
                    DataSet ds1 = new DataSet();
                    Registration reg = new Registration();
                    reg.UserID = Session["username"].ToString();
                    ds1 = obj_service.check(reg);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        string str = ds1.Tables[0].Rows[0][0].ToString();
                        if (str == "no")
                        {
                            Response.Write("<script>alert('Still Now..You are not Activated')</script>");
                        }
                        else
                        {
                            Response.Redirect("Filetoken.aspx");
                        }
                    }
                    else
                    {

                    }

                   
                }
                else
                {
                    Response.Write("<script>alert('Invalid Authentication key..Try again..')</script>");
                }
            }
            else
            { 

            }
        }
        catch
        { 
        }
    }
}