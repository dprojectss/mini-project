using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class TimeCounter : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    static DateTime start;
    string brn, sem, sub;
    string hallno;
    string count = "";
    int noofquestions = 5;
    Random rnum = new Random();
    static int min=5;
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            
               
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from question",con);
            DataSet ds = new DataSet();
            da.Fill(ds);            
            con.Close();
            if (ds.Tables[0].Rows.Count>0)
            {
                 brn =ds.Tables[0].Rows[0]["branch"].ToString();
                 sem = ds.Tables[0].Rows[0]["sem"].ToString();
                sub = ds.Tables[0].Rows[0]["sub"].ToString();
            }


            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from question where sub='"+sub+"' and sem='"+sem+"' and branch='"+brn+"'",con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    ListBox1.Items.Add(ds1.Tables[0].Rows[i]["qid"].ToString());
                }


                for (int i = 0; i < noofquestions; i++)
               {
                   int index = rnum.Next(0, ListBox1.Items.Count);
                   ListBox2.Items.Add(ListBox1.Items[index]);
                   ListBox1.Items.RemoveAt(index);
               }
               
               for (int i = 0; i < ListBox2.Items.Count; i++)
               {
                   count = count + ListBox2.Items[i]+ ",";
               }
            }

            count = count.Remove(count.Length - 1);
            Label3.Text = count;
            Label3.Visible = false;
           

            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from question where qid in ("+count+")", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count>0)
            {
            
                cdcatalog.DataSource = ds;
                cdcatalog.DataBind();
            }
            start = DateTime.Now;
            ListBox1.Visible = false;
            ListBox2.Visible = false;
        }
    }
    protected void Unnamed_Tick(object sender, EventArgs e)
    {
       Label1.Text = DateTime.Now.Second.ToString();
       
     }




        protected void cdcatalog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select * from hallticket",con);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows.Count>0)
	{
		 hallno = ds3.Tables[0].Rows[0]["hallticketno"].ToString();
	}
        
        foreach (RepeaterItem item in cdcatalog.Items)
        {
            TextBox box = (TextBox)item.FindControl("TextBox1");
            string b = box.Text;
            
            //Label3.Text += b + " . ";
            //Label3.Visible = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into test values('"+hallno+"','"+ListBox2.Text+"','"+b+"','"+Label1.Text+"')",con);
            con.Close();
        }
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
