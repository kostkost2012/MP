using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class MyControl : System.Web.UI.UserControl
    {
        TextBox text1 = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            text1.ID = "text1";
            this.Controls.Add(text1);
        }
    }

    public class Question
    {
        int ID;
        int type = 0;
        String text;
        List<String> answers;


        public Question(int id, SqlConnection conn)
        {
            this.ID = id;

        }



        public bool Validate(List<String> answ)
        {
            if (answ.Intersect(answers).Count() == answers.Intersect(answ).Count())
                return true;
            return false;
        }
    }
}