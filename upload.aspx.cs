using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
public partial class upload : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Lagangeet.mdf;Integrated Security=True;User Instance=True");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            try
            {
                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("download/Audio")+"\\"+ DropDownList2.SelectedItem + "\\" +
                          Path.GetFileName(hpf.FileName));
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Audio(fname,catagory,url) values(@name,@catagory,@url)", con);
                        cmd.Parameters.AddWithValue("@name", hpf.FileName);
                        cmd.Parameters.AddWithValue("@url", "download/" + DropDownList1.SelectedValue + "/" + DropDownList2.SelectedValue + "/" + hpf.FileName);
                        cmd.Parameters.AddWithValue("@catagory", DropDownList2.SelectedValue);
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle your exception here
            }
               
    }
}