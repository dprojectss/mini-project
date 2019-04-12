using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class TeacherList : System.Web.UI.Page
{
    static DateTime start;
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    String hallno;
    int second = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime start = DateTime.Now;
       if (Session["username"] != null)
	{
		 Label1.Text = Session["username"].ToString();
	}

       con.Open();
       SqlDataAdapter da = new SqlDataAdapter("select * from hallticket where username='"+Label1.Text+"'",con);
       DataSet ds = new DataSet();
       da.Fill(ds);
       con.Close();
       if (ds.Tables[0].Rows.Count>0)
       {
           hallno = ds.Tables[0].Rows[0]["hallticketno"].ToString() + "!!";
            Label2.Text= hallno;
       }



    }

   
   
    
    
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Write("<script Language=java script>alert('welcome')</script>");

        DateTime end = DateTime.Now;
        Label5.Text = end.Subtract(start).Seconds.ToString();
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {


    }
   
   
    protected void Timer1_Tick(object sender, EventArgs e)
    {
       
       Label4.Text = DateTime.Now.ToString();
       Timer1.Interval = 1000;
       //Timer1.Start();
        //second = second + 1;
        //if (second >= 10)
        //{
        //    Timer1.Stop();
           
        //}
      
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from question ",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            //string ques=ds.Tables[0].Rows[0]["sem"].ToString();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i==0)
                {
                    Label3.Text = ds.Tables[0].Rows[0]["question"].ToString();
                }
               
               
            }
        }

    }
} 