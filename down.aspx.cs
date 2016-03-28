using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

public partial class down : System.Web.UI.Page
{
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
            lblMsg.Text = listfiles.Length + " ";
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No files found";
        }
    }
    protected void lnk_download_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Label lblValue = (Label)gvrow.FindControl("lblName");
        Label lablsize = (Label)gvrow.FindControl("lblLen");
        string filesize = lablsize.Text;
        string filename = lblValue.Text;
        string filepath = Server.MapPath(Session["username"].ToString() + "//" + filename);
        txt_Filename.Text = filename;
        upload upload = new global::upload();
        upload.filename = filename;
        upload.userId = Session["username"].ToString();
        txt_convergentKey.Text = obj_service.check_get_token(upload);
        txt_filesize.Text = filesize;
        lbl_filepath.Text = filepath;
        this.ModalPopupExtender1.Show();
    }
 /*protected void txt_convergentKey_TextChanged(object sender, EventArgs e)
    {
        try
       {
            ServiceReference1.upload upload = new ServiceReference1.upload();
            upload.userId = Session["username"].ToString();
            DataSet ds = new DataSet();
            ds = obj_service.get_key(upload);
            string key = ds.Tables[0].Rows[0][0].ToString();
            if (key.Trim() == txt_convergentKey.Text)
            {

            }
            else
            {
                lbl_status.Text = "Incorrect Convergent Key";
            }
        }
        catch
        {

        }

    */
    protected void Button1_Click(object sender, EventArgs e)
    {
        upload upload = new upload();
        upload.userId = Session["username"].ToString();
        DataSet ds = new DataSet();
        ds = obj_service.get_key(upload);
        string key = ds.Tables[0].Rows[0][0].ToString();

            try
            {
                upload.userId = Session["username"].ToString();
                upload.filesize = txt_filesize.Text;
                upload.time = DateTime.Now;
                upload.filename = txt_Filename.Text;
                bool i = obj_service.insert_download(upload);
                if (i == true)
                {
                }
                else
                {

                }
                string filePath = lbl_filepath.Text;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
               

            }
            catch
            {

            }
        
       
           // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Incorrect Convergent Key');", true);
        
    }

    private static void DecryptFile(string inputFile, string outputFile, string skey)
    {
        try
        {
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                /* This is for demostrating purposes only. 
                 * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                {
                    using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                            {
                                int data;
                                while ((data = cs.ReadByte()) != -1)
                                {
                                    fsOut.WriteByte((byte)data);
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
}