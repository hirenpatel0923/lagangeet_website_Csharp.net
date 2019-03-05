using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds;
	public Class1()
	{
        con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Lagangeet.mdf;Integrated Security=True;User Instance=True");
	}
    public bool login(string emailid, string pwd)
    {

        try
        {
            con.Close();
            cmd = new SqlCommand("select * from login where userid='" + emailid + "' and pwd='" + pwd + "'", con);
            con.Open();
            adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adp.Fill(ds, "0");
            int count = ds.Tables[0].Rows.Count;
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception e)
        {
            return false;
        }
    }

}