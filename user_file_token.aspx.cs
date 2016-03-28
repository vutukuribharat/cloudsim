using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_file_token : System.Web.UI.Page
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
            upload upload = new upload();
            upload.userId = Session["username"].ToString();
            DataSet ds = new DataSet();
            ds = obj_service.user_token_request(upload);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            { 
                Response.Write("<script>alert('No records found')</script>");
            }
            
        }
        catch
        { 
        }
        finally
        {

        }
    }
}