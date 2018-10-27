using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            my1.OnValid += () => Label1.Text = "RIGHT";
            my1.OnInvalid += () => Label1.Text = "WRONG";
        }

    }
}