using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    Class1 cs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cs = new Class1();
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool aut = false;
        aut = cs.login(Login1.UserName, Login1.Password);
        e.Authenticated = aut;
        if (aut)
        {
            Response.Redirect("upload.aspx");
        }
    }
}