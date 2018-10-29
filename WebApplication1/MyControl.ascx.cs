using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class MyControl : System.Web.UI.UserControl
    {
        SqlConnection connection = new SqlConnection("Server=localhost;Integrated Security=SSPI;Database=MP;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.HttpMethod=="POST")
            {
                TextBox result = new TextBox();
                result.Text = SavePoll(connection).ToString();
                HtmlForm poll = new HtmlForm();
                poll.Controls.Add(result);
                Controls.Add(poll);
                return;
            }

            CreatePoll();
        }

        protected void CreatePoll()
        {
            List<Question> questions = new List<Question>() {
            new Question(2,connection),
            new Question(1,connection),
            new Question(0,connection),
            new Question(3,connection)
            };

            HtmlForm poll = new HtmlForm();
            poll.Action = "";
            poll.Method = "POST";
            foreach (Question q in questions)
            {
                Fill(q, poll);
            }
            Button submit = new Button();
            submit.ID = "submitButton";
            poll.Controls.Add(submit);

            Controls.Add(poll);
        }

        protected int SavePoll(SqlConnection conn)
        {
            Guid user = Guid.NewGuid();
            Dictionary<int, List<String>> answers = new Dictionary<int, List<string>>();
            Regex regex = new Regex(@"^my1\$(\d+)(?:\$\d+)?$");
            foreach (String param in Request.Params)
            {
                Match match = regex.Match(param);

                if (match.Success)
                {
                    int id = Convert.ToInt32(match.Groups[1].Value);
                    if (!answers.ContainsKey(id))
                    {
                        answers.Add(id, new List<string>());
                    }
                    answers[id].Add(Request.Params[param]);
                }
            }

            int result = 0;
            foreach(KeyValuePair<int,List<String>> pair in answers)
            {
                Question q = new Question(pair.Key, conn);
                q.SaveAnswers(user, pair.Value, conn);
                result++;
            }
            return 0;
        }

        protected void Fill(Question q, HtmlForm form)
        {
            HtmlGenericControl buf = new HtmlGenericControl("div");

            Label l = new Label();
            l.Text = q.Text;
            buf.Controls.Add(l);
            switch (q.Type)
            {  
                case 0:
                    TextBox tb = new TextBox();
                    tb.ID = q.ID.ToString();
                    buf.Controls.Add(tb);
                    break;
                case 1:
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.ID = q.ID.ToString();
                    foreach(String a in q.Answers)
                    {
                        ListItem li = new ListItem();
                        li.Text = a;
                        li.Value = a;
                        rbl.Items.Add(li);
                    }
                    buf.Controls.Add(rbl);
                    break;
                case 2:
                    CheckBoxList cbl = new CheckBoxList();
                    cbl.ID = q.ID.ToString();
                    foreach (String a in q.Answers)
                    {
                        ListItem li = new ListItem();
                        li.Text = a;
                        li.Value = a;
                        cbl.Items.Add(li);
                    }
                    buf.Controls.Add(cbl);
                    break;
            }
            form.Controls.Add(buf);
        }
    }

    public class Question
    {
        int id;
        public int ID { get { return id; } }
        int type = 0;
        public int Type
            {
                get
                {
                    return type;
                }
            }
        String text;
        public String Text { get { return text; } }

        List<String> answers;
        public List<String> Answers { get { return answers; } }

        List<String> rightAnswers;


        public Question(int id, SqlConnection conn)
        {
            this.id = id;
            this.answers = new List<string>();
            this.rightAnswers = new List<string>();
            String command = "SELECT q.ID as ID, q.Text as Question, q.Type as Type, a.Text as Answer, a.IsRight as IsRight FROM Question as q inner join Answers as a on q.ID = a.Question_ID WHERE ID="+id.ToString();
            conn.Open();
            SqlCommand myCommand = new SqlCommand(command, conn);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                this.type = Convert.ToInt32(myReader["Type"]);
                this.text = myReader["Question"].ToString();
                if (myReader["IsRight"].ToString()=="True")
                    this.rightAnswers.Add(myReader["Answer"].ToString());
                this.answers.Add(myReader["Answer"].ToString());
            }
            conn.Close();
        }

        public bool SaveAnswers(Guid user, List<String> answ, SqlConnection conn)
        {
            foreach (String a in answ)
            {
                conn.Open();
                String command = "INSERT INTO PollAnswers VALUES ('" + user.ToString() + "'," + this.id.ToString() + ",'"+a+"')";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                if (sqlCommand.ExecuteNonQuery() != 1)
                    throw new Exception("not inserted");
                conn.Close();
            }
            return true;
        }

    }
}