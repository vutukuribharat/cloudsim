using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserDetails : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        grid_bind();
    }
    public void grid_bind()
    {
        try
        {
            gv_userdetails.DataSource = obj_service.user_details();
            gv_userdetails.DataBind();
        }
        catch
        {

        }
    }

    
    protected void gv_userdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton link_button = (LinkButton)e.Row.FindControl("active_link");
                link_button.Attributes.Add("onclick", "return conform('Are You want to active this user')");
                Label lb = (Label)e.Row.FindControl("label1");
                if (link_button.CommandArgument == "yes")
                {
                    string str = link_button.CommandArgument;
                    link_button.Text = "Deactive";
                }
                else
                {
                    string str = link_button.CommandArgument;
                    link_button.Text = "Active";

                }
            }
        }
        catch
        {
 
        }
       
    }
    protected void active_link_Click(object sender, EventArgs e)
    {
       
        try
        {
            upload upload = new upload();
            LinkButton lb = sender as LinkButton;

            if (lb.Text == "Active")
            {
                GridViewRow row = lb.NamingContainer as GridViewRow;
                string userId = row.Cells[0].Text;
                Registration reg = new Registration();
                reg.UserID = userId;

                obj_service.insert_right(reg);
                obj_service.update_status(reg);
                upload.userId = userId;
                DataSet ds = new DataSet();
                ds = obj_service.get_key(upload);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Random random = new Random();
                    int key1 = random.Next(22222222, 88888888);
                    int key2 = random.Next(22222222, 88888888);
                    string str1 = Convert.ToString(key1);
                    string str2 = Convert.ToString(key2);
                    string str = Convert.ToString(str1 + str2);

                    upload.userId = userId;
                    upload.key = Convert.ToString(str);
                    bool i = obj_service.insert_key(upload);
                }
                else
                {

                }
            }
            else
            {

                GridViewRow row = lb.NamingContainer as GridViewRow;
                string userId = row.Cells[0].Text;
                Registration reg = new Registration();
                reg.UserID = userId;
                bool i = obj_service.deactive(reg);
                if(i==true)
                {

                }
                else
                {

                }

            }
            
        }
        catch
        { 
        }

        Response.Redirect(Request.RawUrl);
    }
   
   
   
}