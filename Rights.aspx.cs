using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Rights : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Button lb = sender as Button;
            Registration reg = new Registration();
            reg.UserID = lb.CommandName.ToString();
            bool i = obj_service.accept_request(reg);
            if(i==true)
            {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Request is accepted'); window.location='" +
                Request.ApplicationPath + "Rights.aspx';", true);
            }
        }
        catch
        {
        }
    }
    public void bind()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = obj_service.select_request();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
            }
        }
        catch
        {
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}