using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Word;

public partial class dedup : System.Web.UI.Page
{

    Application word = new Application();
    Document doc = new Document();
    BAL obj_service = new BAL();
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
    protected void Lnk_delete_Click(object sender, EventArgs e)
    {

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Label lblValue = (Label)gvrow.FindControl("lblName");
        string filename = lblValue.Text;
        string filepath = Server.MapPath("images//" + Session["username"].ToString() + "//" + filename);
        string encriptedfilepath = Server.MapPath("~//Public_cloud//Encriptedfile//" + Session["username"].ToString() + "//" + filename);
        File.Delete(filepath);
        File.Delete(encriptedfilepath);
        Response.Redirect(Request.RawUrl);
    }
    protected void btn_referesh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
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
            lblMsg.Text = listfiles.Length + "";
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No files found";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetFilesFromFolder();
    }
    protected void check1()
    {
        try
        {
            FileUpload1.SaveAs(Server.MapPath("~//upload//" + FileUpload1.FileName));

            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            string[] files = Directory.GetFiles(Server.MapPath(@"~\upload"));
            string[] backnode = Directory.GetFiles(Server.MapPath(@"~\images\" + Session["username"].ToString()));


            for (int orgfile = 0; orgfile < files.Count(); orgfile++)
            {
                try
                {
                    object file = files[orgfile].ToString();
                    object missing = System.Type.Missing;

                    var fileStream = new FileStream(Server.MapPath("~//upload//" + FileUpload1.FileName), FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string text = streamReader.ReadToEnd();
                        str1.Append(text);
                    }

                    string read = string.Empty;



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

                        string read = string.Empty;

                        List<ListItem> arr = new List<ListItem>();
                        var fileStream = new FileStream(file.ToString(), FileMode.Open, FileAccess.Read);
                        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                        {
                            string text = streamReader.ReadToEnd();
                            str2.Append(text);
                        }

                        if (str1.ToString() == str2.ToString())
                        {
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('File Is Aleardy Here....'); window.location='" +
                            //Request.ApplicationPath + "check.aspx';", true);


                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('File Is Aleardy Here....');", true);

                            System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath(@"~\upload"));

                            foreach (FileInfo filek in di.GetFiles())
                            {
                                filek.Delete();
                            }
                            break;

                        }
                        else
                        {
                            // FileUpload1.SaveAs(Server.MapPath(@"~\" + Session["username"].ToString() + "//" + FileUpload1.FileName));
                            //encroption();
                            // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Uploaded successfully');", true);
                            str2.Clear();
                        }


                    }
                    catch
                    {

                    }
                }
                file_move();

            }


        }



        catch (Exception)
        {

        }
        finally
        {

        }

    }
    public void file_move()
    {
        DirectoryInfo dir2 = new DirectoryInfo(Server.MapPath(@"~\upload"));
        FileInfo[] Folder1Files = dir2.GetFiles();
        foreach (FileInfo aFile in Folder1Files)
        {
            try
            {

                aFile.MoveTo(Server.MapPath(@"~\images\" + Session["username"].ToString()+"//"+ aFile.Name));
                string inputfile = Server.MapPath(@"~\images\" + Session["username"].ToString() + "//" + aFile.Name);
                string encriptedfilepath = Server.MapPath("~//Public_cloud//Encriptedfile//" + Session["username"].ToString()+"//"+ aFile.Name + "");
                EncryptFile(inputfile, encriptedfilepath, Session["File_token"].ToString());
                File.Delete(Server.MapPath(@"~\upload\") + aFile.Name);
                bind();
            }
            catch (IOException)
            {
                File.Delete(Server.MapPath(@"~\upload\") + aFile.Name);
                // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('File Name Is Aleardy Here....');", true);
            }

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
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        upload upload = new upload();
        upload.userId = Session["username"].ToString();
        string username = Session["username"].ToString();
        string path = Server.MapPath("~//images//" + username);
        string outputfile = Server.MapPath("~//Public_cloud//Encriptedfile//" + username + "");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        if (!Directory.Exists(outputfile))
        {
            Directory.CreateDirectory(outputfile);
        }
        check1();
    }

    protected void check2()
    {
        try
        {
            FileUpload1.SaveAs(Server.MapPath("~//upload//" + FileUpload1.FileName));

            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            string[] files = Directory.GetFiles(Server.MapPath(@"~\upload"));
            string[] backnode = Directory.GetFiles(Server.MapPath(@"~\" + "compare"));


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
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('File Is Aleardy Here....'); window.location='" +
                            //Request.ApplicationPath + "check.aspx';", true);

                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('File Is Aleardy Here....');", true);


                        }
                        else
                        {
                            // FileUpload1.SaveAs(Server.MapPath(@"~\" + Session["username"].ToString() + "//" + FileUpload1.FileName));
                            //encroption();
                            // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Uploaded successfully');", true);
                            str2.Clear();
                        }

                        ((_Document)doc).Close();
                    }
                    catch
                    {

                    }
                }


            }
            file_move();
            ((_Application)word).Quit();

        }



        catch (Exception)
        {

        }

        finally
        {




        }

    }
    public void bind()
    {
        try
        {
            upload upload = new global::upload();
            upload.userId = Session["username"].ToString();
            upload.filename = FileUpload1.FileName;
            upload.filepath = "~//images//" + Session["username"].ToString() + "//" + FileUpload1.FileName + "";
            upload.time = DateTime.Now;
            upload.filesize = FileUpload1.PostedFile.ContentLength + "kb";
            upload.key = Session["File_token"].ToString();
            bool i = obj_service.upload(upload);
        }
        catch
        { 
        }
    }
   
}