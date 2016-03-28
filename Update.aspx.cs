using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Office.Interop.Word;

public partial class Update : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    Application word = new Application();
    Document doc = new Document();
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["FileType"] = drop1.SelectedValue;


        
   
        try
        {
            DataSet ds = new DataSet();
            Registration reg = new Registration();
            reg.UserID = Session["username"].ToString();
            ds = obj_service.get_right(reg);
            string str = ds.Tables[0].Rows[0][3].ToString();
            if (str == "yes")
            {
                  GetFilesFromFolder();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You have No Rights to update');", true);
            }
        }
        catch
        { 
            
        }
    }
      
    
    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetFilesFromFolder();
    }
    private void GetFilesFromFolder()
    {
        // GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        string str = Session["username"].ToString();

        DirectoryInfo objDir = new DirectoryInfo(Server.MapPath("images\\" + str + "\\"));
        FileInfo[] listfiles = objDir.GetFiles("*." + ((string)ViewState["FileType"] != "All" ?
            ViewState["FileType"] : "*"));

        if (listfiles.Length > 0)
        {
            // BIND THE LIST OF FILES (IF ANY) WITH GRIDVIEW.
            GridView1.Visible = true;
            GridView1.DataSource = listfiles;
            GridView1.DataBind();
            lblMsg.Text = listfiles.Length.ToString();
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "0";
        }
    }
    protected void Lnk_delete_Click(object sender, EventArgs e)
    {

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Label lblValue = (Label)gvrow.FindControl("lblName");
        Label lablsize = (Label)gvrow.FindControl("lblLen");
        StringBuilder str1 = new StringBuilder();

        string filesize = lablsize.Text;
        ViewState["filesize"] = filesize;
        string filename = lblValue.Text;
        ViewState["filename"] = filename;
        //StringBuilder str2 = new StringBuilder();
        string filepath = Server.MapPath(@"~\images\" + Session["username"].ToString() + "//" + filename);
        string files = filepath;
        ViewState["filepath"] = filepath;
        //string[] backnode = Directory.GetFiles(Server.MapPath(@"~\upload"));
        Application word = new Application();
        Document doc = new Document();
        string exet = Path.GetExtension(filename);
        if (exet == ".txt")
        {
            if (!string.IsNullOrEmpty(files))
            {
                string[] readText = File.ReadAllLines(files);
                StringBuilder strbuild = new StringBuilder();
                foreach (string s in readText)
                {
                    strbuild.Append(s);
                    strbuild.AppendLine();
                }
                textBoxContents.InnerText = strbuild.ToString();
                textBoxContents.Visible = true;

            }
            else { }
            //try
            //{
            //    object file = files.ToString();
            //    object missing = System.Type.Missing;
            //    doc = word.Documents.Open(ref file,
            //                ref missing, ref missing, ref missing, ref missing,
            //                ref missing, ref missing, ref missing, ref missing,
            //                ref missing, ref missing, ref missing, ref missing,
            //                ref missing, ref missing, ref missing);
            //    string read = string.Empty;

            //    List<ListItem> arr = new List<ListItem>();
            //    for (int i = 0; i < doc.Paragraphs.Count; i++)
            //    {
            //        {
            //            string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
            //            if (temp != string.Empty)
            //                str1.Append(temp);
            //        }
            //    }
            //    ((_Document)doc).Close();
            //}
            //catch (Exception)
            //{ }
            //textBoxContents.InnerText = str1.ToString();

            //textBoxContents.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
            //LinkButton btndetails = sender as LinkButton;
            //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //Label lblValue = (Label)gvrow.FindControl("lblName");
            //Label lablsize = (Label)gvrow.FindControl("lblLen");
            //string filesize = lablsize.Text;
            //ViewState["filesize"] = filesize;
            //string filename = lblValue.Text;
            //ViewState["filename"] = filename;
            //string filepath = Server.MapPath(Session["username"].ToString() + "//" + filename);
            //ViewState["filepath"] = filepath;
            //string path = filepath;
            //if (!string.IsNullOrEmpty(path))
            //{
            //    string[] readText = File.ReadAllLines(path);
            //    StringBuilder strbuild = new StringBuilder();
            //    foreach (string s in readText)
            //    {
            //        strbuild.Append(s);
            //        strbuild.AppendLine();
            //    }
            //    textBoxContents.InnerText = strbuild.ToString();
            //    textBoxContents.Visible = true;
            //    Button1.Visible = true;
            //    Button2.Visible = true;
            //}
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string filefath = ViewState["filepath"].ToString();

            StreamWriter obj_write = new StreamWriter(ViewState["filepath"].ToString());
            obj_write.Write(textBoxContents.InnerText);
            obj_write.Close();
            textBoxContents.InnerText = "";
            upload upload = new upload();
            upload.userId = Session["username"].ToString().ToString();
            upload.filesize = ViewState["filesize"].ToString();
            upload.filename = ViewState["filename"].ToString();
            upload.time = DateTime.Now;
            bool i = obj_service.insert_update(upload);
            if (i == true)
            { }
            else { }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Updated successfully');", true);
            textBoxContents.Visible = false;
            Button1.Visible = false;

        }
        catch
        {
 
        }
       

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        textBoxContents.Visible = false;
        Button1.Visible = false;
        Button2.Visible = false;
    }


    public void check()
    {
        try
        {
            DataSet ds = new DataSet();
            Registration reg = new Registration();
            reg.UserID = Session["username"].ToString();
            ds = obj_service.get_right(reg);
            string str = ds.Tables[0].Rows[0][3].ToString();
            if (str == "yes")
            {

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
