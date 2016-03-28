using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Update_rights : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
       
       try
        {
             Registration reg = new Registration();
        reg.UserID = Session["username"].ToString();
            reg.UserID = Session["username"].ToString();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ds = obj_service.get_right(reg);
            ds1 = obj_service.check(reg);
            string str = ds1.Tables[0].Rows[0][0].ToString();

            if (ds.Tables[0].Rows.Count > 0 && str == "yes")
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You have No Rights');", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ex.Message + "');", true);

        }
    }
    protected void btn_request_Click(object sender, EventArgs e)
    {
        Registration reg = new Registration();
        reg.UserID = Session["username"].ToString();
        reg.username = "yes";
        bool i = obj_service.update_right_status(reg);
        if (i == true)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Request is sent');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Request sending failed');", true);
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lb = (Label)e.Row.FindControl("label1");
            Button btn = (Button)e.Row.FindControl("btn_request");
            if (lb.Text == "yes")
            {
                btn.Visible = false;

            }
            else
            {

            }
        }
    }
}