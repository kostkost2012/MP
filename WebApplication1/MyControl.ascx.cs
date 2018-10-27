using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class MyControl : UserControl
    {
        SqlConnection connection = new SqlConnection("Server=localhost;Integrated Security=SSPI;Database=MP;");
        String value = null;
        public event Action OnValid;
        public event Action OnInvalid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                value = ViewState["val"].ToString();
                img.ImageUrl = ViewState["url"].ToString();
                return;
            }

            Fill();
        }

        protected void Fill()
        {
            connection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT TOP 1 * FROM Captcha WHERE ID<=(CAST(RAND()*(SELECT MAX(ID) FROM Captcha) as int)) ORDER BY ID DESC", connection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                value = myReader["Value"].ToString();
                ViewState["val"] = value;
                img.ImageUrl = myReader["URL"].ToString();
                ViewState["url"] = img.ImageUrl;
            }
            connection.Close();
        }

        protected bool isValid()
        {
            return TextBox1.Text == value;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                OnValid?.Invoke();
            }
            else
            {
                OnInvalid?.Invoke();
                Fill();
            }
        }
    }
}