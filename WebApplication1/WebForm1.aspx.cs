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
            //button1.Text = "ass";
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST" && Request.Params.AllKeys.Contains("theme"))
                Page.Theme = Request.Params["theme"]=="null" ? null : Request.Params["theme"];
        }
    }
}