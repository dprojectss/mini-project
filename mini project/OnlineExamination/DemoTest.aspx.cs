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
using System.IO;
using System.Text.RegularExpressions;

public partial class TeacherList : System.Web.UI.Page
{
    string us;
    static DateTime start, startt, end;
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string hallno;
    int second = 0, interval;
    string count = "";
    int noofquestions = 4;
    string brn, sem, sub, date, answer, halticno;
    Random rnum = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null)
        {
            us = Session["username"].ToString();
            Label1.Text = us;

        }
        string name = "";
        con.Open();
        SqlDataAdapter da12 = new SqlDataAdapter("select *  from studreg where username='" + Label1.Text + "' ", con);
        DataSet ds12 = new DataSet();
        da12.Fill(ds12);
        con.Close();
        if (ds12.Tables[0].Rows.Count > 0)
        {
            name = ds12.Tables[0].Rows[0]["name"].ToString();
        }
        con.Open();
        SqlDataAdapter da11 = new SqlDataAdapter("select s.branch,s.subject,h.hallticketno  from hallticket h, subject s where s.sem=h.sem and username='" + name + "' ", con);
        DataSet ds11 = new DataSet();
        da11.Fill(ds11);
        con.Close();
        if (ds11.Tables[0].Rows.Count > 0)
        {
            halticno = ds11.Tables[0].Rows[0]["hallticketno"].ToString();

            if (!IsPostBack)
            {
                Panel1.Visible = true;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from studreg where username='" + Label1.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    brn = ds.Tables[0].Rows[0]["branch"].ToString();
                    lblnranch.Text = ds.Tables[0].Rows[0]["branch"].ToString();
                    lblsem.Text = ds.Tables[0].Rows[0]["sem"].ToString();
                    con.Open();
                    SqlDataAdapter dasubject = new SqlDataAdapter("select * from subject where branch='"+lblnranch.Text+"' and sem='"+lblsem.Text+"'",con);
                    DataSet dssubject = new DataSet();
                    dasubject.Fill(dssubject);
                    con.Close();
                    if (dssubject.Tables[0].Rows.Count>0)
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Add("---Select---");
                        for (int i = 0; i < dssubject.Tables[0].Rows.Count; i++)
                        {
                            DropDownList1.Items.Add(dssubject.Tables[0].Rows[i]["subject"].ToString());
                        }
                    }
                   
                    sem = ds.Tables[0].Rows[0]["sem"].ToString();
                    //sub=ds.Tables[0].Rows[0]["subjectname"].ToString();
                    //DateTime myDateTime = DateTime.Now;
                    //date = myDateTime.Date.ToString("yyyy-MM-dd");
                    Response.Write("<script language=javascript>alert('" + date + "')</script>");
                    //con.Open();
                    //SqlDataAdapter da1 = new SqlDataAdapter("select * from examdates where branchname='" + brn + "' and sem='" + sem + "'", con);
                    ////string query = "select * from examdates where dates='" + date + "' and branchname='" + brn + "' and sem='" + sem + "' and subjectname='" + sub + "'";
                    //DataSet ds1 = new DataSet();
                    //da1.Fill(ds1);
                    //con.Close();
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    lblnranch.Text = ds1.Tables[0].Rows[0]["branchname"].ToString();
                    //    lblsem.Text = ds1.Tables[0].Rows[0]["sem"].ToString();
                    //    lblsubject.Text = ds1.Tables[0].Rows[0]["subjectname"].ToString();
                    //    //getting hallticket number from database of student
                    //    con.Open();
                    //    SqlDataAdapter dd = new SqlDataAdapter("select * from hallticket where username='" + name + "' and sem='" + lblsem.Text + "'", con);
                    //    DataSet dss = new DataSet();
                    //    dd.Fill(dss);

                    //    con.Close();

                    //    if (dss.Tables[0].Rows.Count > 0)
                    //    {
                    //        lblhallticketno.Text = dss.Tables[0].Rows[0]["hallticketno"].ToString();
                    //        con.Open();
                    //        SqlDataAdapter dd1 = new SqlDataAdapter("select * from demoresult where hallticketno='" + lblhallticketno.Text + "' and subject='" + lblsubject.Text + "'", con);
                    //        DataSet dss1 = new DataSet();
                    //        dd1.Fill(dss1);

                    //        con.Close();

                    //        if (dss1.Tables[0].Rows.Count > 0)
                    //        {
                    //            Response.Write("<script language='javascript'>window.alert('Your Message');window.location='demoresult.aspx';</script>");
                    //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "jkl", "alert('yo man wow');window.location('demoresult.aspx');", true);
                    //            Response.Write("u already given the test");
                    //        }
                    //        else
                    //        {
                    //            Panel2.Visible = true;
                    //        }
                    //        //on panel exam

                    //    }



                    //}
                    //else
                    //{
                    //    // Response.Write("<script language=javascript>alert('There is no exam today')</script>");
                    //    Panel2.Visible = true;
                    //}
                    //date=DateTime.Now;
                }



            }
        }
        else
        {
            // Response.Write("<script language=javascript>alert('Wait for your Hallticket Generate by Admin.')</script>");
            Panel2.Visible = true;
        }

    }










    protected void Button2_Click(object sender, EventArgs e)
    {
        updateendtime();
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = true;
        submitQuestionAnswer();
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = true;
        lblmessage.Text = "Test Submited SuccessFully.";




    }

    private void updateendtime()
    {
        //update end time
        //con.Open();
        //SqlCommand cmd = new SqlCommand("update demo set endtime='" + DateTime.Now + "' where username='" + Session["username"].ToString() + "'", con);
        //cmd.ExecuteNonQuery();
        //con.Close();
        //end
    }


    protected void Timer2_Tick2(object sender, EventArgs e)
    {

       
        int time = 60;
        int time1 = time / 60;
        int time2 = 5;
        string sec1 = "60";
        DateTime end = DateTime.Now;
        string hor1 = (time1 - Convert.ToInt32(end.Subtract(start).Hours.ToString())).ToString();
        string min1 = (time2 - Convert.ToInt32(end.Subtract(start).Minutes.ToString())).ToString();
        sec1 = (Convert.ToInt32(sec1) - Convert.ToInt32(end.Subtract(start).Seconds.ToString())).ToString();

        if (Convert.ToInt32(min1) < 0)
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            submitQuestionAnswer();
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel4.Visible = true;

            lblmessage.Text = "Time Over .<br/>Test Submited SuccessFully.";
            Timer2.Enabled = false;

        }
        else
        {
            if (sec1 == "1")
            {
                if (min1 == "0")
                {
                    //alert 
                    Label5.Text = min1 + ":" + (Convert.ToInt32(sec1) - 1).ToString();
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    submitQuestionAnswer();
                    Panel1.Visible = true;
                    Panel2.Visible = true;
                    Panel4.Visible = true;

                    lblmessage.Text = "Time Over .<br/>Test Submited SuccessFully.";
                    Timer2.Enabled = false;
                }

            }
            Label5.Text = min1 + ":" + (Convert.ToInt32(sec1) - 1).ToString();
        }

    }

    private void submitQuestionAnswer()
    {
        double res = 0;
        for (int i = 0; i < cdcatalog.Items.Count; i++)
        {
            string question = ((Label)cdcatalog.Items[i].FindControl("Label2")).Text;
            string answer = ((TextBox)cdcatalog.Items[i].FindControl("TextBox1")).Text;
            //processing answer
            string wordstoprocess = Regex.Replace(answer, @"\s+", " ").ToLower();
            string ans = wordstoprocess;
            string[] answords = ans.Split(' ');
            string[] stopwords;

            //getting stopword from file to array
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            StreamReader file =
                new StreamReader(Server.MapPath("~/mystopwords.txt"));
            string[] arr = new string[1000];
            while ((line = file.ReadLine()) != null)
            {
                arr[counter] = (line.ToString());
                counter++;
            }
            //remove stopword from actual answer
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != null)
                {
                    for (int j = 0; j < answords.Length; j++)
                    {
                        if (arr[k] == answords[j])
                        {
                            answords[j] = "";
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            //make a string of processingwords
            string processingdemoresult = "";
            for (int p = 0; p < answords.Length; p++)
            {
                if (answords[p] != "")
                {
                    if (!processingdemoresult.Contains(answords[p]))
                    {
                        processingdemoresult = processingdemoresult + answords[p].ToString() + " ";
                    }

                }
            }
            //end proce
            //con.Open();
            //SqlCommand cmd1 = new SqlCommand("insert into demoresult values('" + lblhallticketno.Text + "' ,'" + Label1.Text.ToLower() + "' ,'" + lblsubject.Text + "','" + question.ToLower() + "' , '" + answer.ToLower() + "','','" + processingdemoresult.ToLower() + "','No')", con);
            //cmd1.ExecuteNonQuery();
            //con.Close();

            //calculating marks and update table demoresult
            //get actual processing answer from table question

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from question where question='" + question + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string processinganswer = (ds.Tables[0].Rows[0]["processing"].ToString()).Trim();
                string[] arrpw = processinganswer.Split(' ');
                string[] studanswerprocessing = processingdemoresult.Trim().Split(' ');
                int marks = 0;
                for (int m = 0; m < arrpw.Length; m++)
                {
                    string word = arrpw[m].ToLower();
                    for (int n = 0; n < studanswerprocessing.Length; n++)
                    {
                        if (word == studanswerprocessing[n])
                        {
                            marks = marks + 1;

                        }



                    }
                    //convert marks to actual question mark
                    int actualmarks = 5;
                    double wordsinactualanswer = ((double)marks / (double)arrpw.Length);
                    double studentmarks = actualmarks * wordsinactualanswer;
                    res = studentmarks + res;
                    //update marks for question answer by sttudent
                    //con.Open();
                    //cmd1 = new SqlCommand("update demoresult set marks='" + studentmarks.ToString() + "' where question='" + question + "' and username='" + Session["username"].ToString() + "'", con);
                    //cmd1.ExecuteNonQuery();
                    //con.Close();
                    //end update
                }

                //end calculating

            }
        }
        Response.Write("<script language=javascript>alert('You got " +Math.Round( res,2) + " out of " + (noofquestions *5)+ "')</script>");
        Label3.Text = "You got " +Math.Round(res,2) + " out of " + (noofquestions *5);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Timer2.Enabled = true;
        Panel1.Visible = false;



         con.Open();
        SqlDataAdapter da4 = new SqlDataAdapter("select * from question where sem='" + lblsem.Text + "' and branch='" + lblnranch.Text + "' and sub='" + lblsubject.Text + "'", con);
        DataSet ds4 = new DataSet();
        da4.Fill(ds4);
        con.Close();
        if (ds4.Tables[0].Rows.Count > noofquestions)
        {
            start = DateTime.Now;
            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                ListBox1.Items.Add(ds4.Tables[0].Rows[i]["qid"].ToString());
            }


            for (int i = 0; i < noofquestions; i++)
            {
                int index = rnum.Next(0, ListBox1.Items.Count);
                ListBox2.Items.Add(ListBox1.Items[index]);
                ListBox1.Items.RemoveAt(index);
            }

            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                count = count + ListBox2.Items[i] + ",";
            }
            count = count.Remove(count.Length - 1);
            Label6.Text = count;
            Label6.Visible = false;


            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from question where qid in (" + count + ")", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                answer = ds2.Tables[0].Rows[0]["ans"].ToString();
                cdcatalog.DataSource = ds2;
                cdcatalog.DataBind();
            }
            // start = DateTime.Now;
            ListBox1.Visible = false;
            ListBox2.Visible = false;



            Panel2.Visible = true;
            Timer2.Enabled = true;


            //fetch hallticket no.
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from hallticket where username='" + Label1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string hallticno = ds.Tables[0].Rows[0]["hallticketno"].ToString();
                con.Open();
                SqlDataAdapter daa = new SqlDataAdapter("select * from demo where username='" + Session["username"].ToString() + "'", con);
                DataSet dss = new DataSet();
                daa.Fill(dss);
                con.Close();

                if (dss.Tables[0].Rows.Count > 0)
                {
                    //nothing
                }
                else
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into demo values('" + Session["username"].ToString() + "','" + DateTime.Now + "','','" + lblnranch.Text + "','" + lblsem.Text + "','" + lblsubject.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('Question are not ready')</script>");
        }

        Button4.Enabled = false;

    }


    protected void Timer2_Tick(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblsubject.Text = DropDownList1.SelectedItem.Text;
    }
}