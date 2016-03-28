using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Word;
using System.IO;

public partial class tempt : System.Web.UI.Page
{
    BAL obj_service = new BAL();
    Application word = new Application();
    Document doc = new Document();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            ViewState["FileType"] = drop1.SelectedValue;
            GetFilesFromFolder();
        }
        catch
        {
        }

    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            upload upload = new upload();
            upload.userId = Session["username"].ToString();
            DataSet ds = new DataSet();
            ds = obj_service.get_key(upload);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString()== txt_key.Text)
                {
                    check();
                    encroption();
                    //Response.Redirect(Request.RawUrl);
                }
                else
                {
                   // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid convergent Key');", true);
                }
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You are not activated');", true);
            }
           
        }
        catch
        {

        }



    }
    public void encroption()
    {
        try
        {


            if (FileUpload1.HasFile)
            {
              upload upload = new upload();
                string username = Session["username"].ToString();
                string filename = FileUpload1.FileName;
                string path = Server.MapPath("~//" + username);
                string filepath = "~//" + username + "//" + filename + "";
                string outputfile = Server.MapPath("~//Public_cloud//Encriptedfile//" + username + "");


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (Directory.Exists(path))
                {
                    upload.userId = username;
                    upload.filename = FileUpload1.FileName;
                    upload.filepath = filepath;
                    upload.time = DateTime.Now;
                    upload.filesize = FileUpload1.PostedFile.ContentLength + "kb";

                    string filepath1 = "~//" + username + "//" + filename + "";

                    FileUpload1.SaveAs(Server.MapPath(filepath));
                    bool i = obj_service.upload(upload);
                    if (i == true)
                    {
                      //  gridbind();
                       // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Uploaded successfully');", true);
                    }

                    if (!Directory.Exists(outputfile))
                    {
                        Directory.CreateDirectory(outputfile);
                    }
                    if (Directory.Exists(outputfile))
                    {
                        string encriptedfilepath = Server.MapPath("~//Public_cloud//Encriptedfile//" + username + "//" + filename + "");
                        string inputfile = Server.MapPath(filepath);

                        EncryptFile(inputfile, encriptedfilepath, txt_key.Text);
                    }

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('select the file');", true);
            }

        }
        catch
        {

        }

        finally
        {
            File.Delete(Server.MapPath(@"~\TEMP\") + FileUpload1.FileName);

        }
    }

    public void gridbind()
    {
        try
        {

            Registration reg = new Registration();
            reg.username = Session["username"].ToString();
            DataSet ds = new DataSet();
            ds = obj_service.get_uploadetails(reg);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = obj_service.get_uploadetails(reg);
                GridView1.DataBind();
            }

        }
        catch
        {

        }
    }

    protected void delete_link_Click(object sender, EventArgs e)
    {
        try
        {
            upload upload = new upload();
            LinkButton lb = sender as LinkButton;
            GridViewRow row = lb.NamingContainer as GridViewRow;
            string username = Session["username"].ToString();
            upload.username = Session["username"].ToString();
            upload.filename = row.Cells[0].Text;
            obj_service.delete_fileupload(upload);

            string deletepath = Server.MapPath("~//Public_cloud//Encriptedfile//" + username + "//" + row.Cells[0].Text);

            if ((System.IO.File.Exists(deletepath)))
            {
                System.IO.File.Delete(deletepath);
            }
            Response.Redirect(Request.RawUrl);
        }
        catch
        {

        }
    }
    private static void EncryptFile(string inputFile, string encriptedfilepath, string skey)
    {
        try
        {
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                /* This is for demostrating purposes only. 
                 * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                using (FileStream fsCrypt = new FileStream(encriptedfilepath, FileMode.Create))
                {
                    using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                    {
                        using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                            {
                                int data;
                                while ((data = fsIn.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {

        }

    }


    protected void check()
    {
        try
        {
            FileUpload1.SaveAs(Server.MapPath("~//upload//" + FileUpload1.FileName));

            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            string[] files = Directory.GetFiles(Server.MapPath(@"~\upload"));
            string[] backnode = Directory.GetFiles(Server.MapPath(@"~\" + Session["username"].ToString()));


            for (int orgfile = 0; orgfile < files.Count(); orgfile++)
            {
                try
                {
                    object file = files[orgfile].ToString();
                    object missing = System.Type.Missing;
                    doc = word.Documents.Open(ref file,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                    string read = string.Empty;

                    List<ListItem> arr = new List<ListItem>();
                    for (int i = 0; i < doc.Paragraphs.Count; i++)
                    {
                        {
                            string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                            if (temp != string.Empty)
                                str1.Append(temp);
                        }
                    }
                    ((_Document)doc).Close();
                }
                catch (Exception)
                {

                }
                for (int backfile = 0; backfile < backnode.Count(); backfile++)
                {
                    try
                    {
                        object file = backnode[backfile].ToString();
                        object missing = System.Type.Missing;
                        doc = word.Documents.Open(ref file,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                        string read = string.Empty;

                        List<ListItem> arr = new List<ListItem>();
                        for (int i = 0; i < doc.Paragraphs.Count; i++)
                        {
                            {
                                string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                                if (temp != string.Empty)
                                    str2.Append(temp);
                            }
                        }
                        if (str1.ToString() == str2.ToString())
                        {
                            Label2.Text = "File alredy is there";

                        }
                        else
                        {


                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Uploaded successfully');", true);
                        }

                        ((_Document)doc).Close();
                    }
                    catch
                    {

                    }
                }

            }

            ((_Application)word).Quit();
        }



        catch (Exception)
        {

        }
        finally
        {



            Dispose();
            DirectoryInfo dir1 = new DirectoryInfo(@"~\" + Session["username"].ToString());
            DirectoryInfo dir2 = new DirectoryInfo(Server.MapPath(@"~\upload"));

            FileInfo[] Folder1Files = dir2.GetFiles();
            if (Folder1Files.Length > 0)
            {
                foreach (FileInfo aFile in Folder1Files)
                {
                    try
                    {
                        if (File.Exists(@"~\upload" + aFile.Name))
                        {
                            File.Delete(@"~\upload" + aFile.Name);
                        }
                        aFile.MoveTo(Server.MapPath(@"~\TEMP\") + aFile.Name);
                    }
                    catch
                    {
                        File.Delete(Server.MapPath(@"~\upload\") + aFile.Name);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('File Is Aleardy Here....')</script>", false);
                    }
                }
            }



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

        DirectoryInfo objDir = new DirectoryInfo(Server.MapPath(str+"\\"));
        FileInfo[] listfiles = objDir.GetFiles("*." + ((string)ViewState["FileType"] != "All" ?
            ViewState["FileType"] : "*"));

        if (listfiles.Length > 0)
        {
            // BIND THE LIST OF FILES (IF ANY) WITH GRIDVIEW.
            GridView1.Visible = true;
            GridView1.DataSource = listfiles;
            GridView1.DataBind();
            lblMsg.Text = listfiles.Length + " files found";
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No files found";
        }
    }
    protected void Lnk_delete_Click(object sender, EventArgs e)
    {
        
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Label lblValue = (Label)gvrow.FindControl("lblName");
        string filename = lblValue.Text;
         string filepath =Server.MapPath(Session["username"].ToString() + "//" + filename);
         string encriptedfilepath = Server.MapPath("~//Public_cloud//Encriptedfile//" + Session["username"].ToString() + "//" + filename);
         File.Delete(filepath);
         File.Delete(encriptedfilepath);
         Response.Redirect(Request.RawUrl);
    }
}