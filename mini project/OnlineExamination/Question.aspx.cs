using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

public partial class TeacherList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
   
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["username"] != null)
	{
		 Label1.Text = Session["username"].ToString();
	}

       con.Open();
       SqlDataAdapter da = new SqlDataAdapter("select * from subject",con);
       DataSet ds = new DataSet();
       da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            //DropDownList2.Items.Clear();
            //DropDownList2.Items.Add("----Select----");
           
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        String br, semester, subject;
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from techreg where username='"+Label1.Text+"'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            br = ds.Tables[0].Rows[0]["branch"].ToString();
            semester = ds.Tables[0].Rows[0]["sem"].ToString();
            subject = ds.Tables[0].Rows[0]["subject"].ToString();

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from question where question = '"+TextBox1.Text+"' and branch='"+br+"' and sem='"+semester+"' and sub='"+subject+"'",con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script language = javascript>alert('Question allready inserted')</script>");
            }
            else
            {
               
                //processing answer
                string wordstoprocess = Regex.Replace(TextBox8.Text,@"\s+"," ").ToLower();
                string ans = wordstoprocess;
                string[] answords = ans.Split(' ');
                string[] stopwords;
              
                    //getting stopword from file to array
                    int counter = 0;
                    string line;

                    // Read the file and display it line by line.
                   StreamReader file =
                       new StreamReader(Server.MapPath("~/mystopwords.txt"));
                    string[] arr=new string[1000];
                    while ((line = file.ReadLine()) != null)
                    {
                        arr[counter]=(line.ToString());
                        counter++;
                    }
                    //remove stopword from actual answer
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] != null)
                        {
                            for (int j = 0; j < answords.Length; j++)
                            {
                                if (arr[i] == answords[j])
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
                    string processingresult="";
                    for (int i = 0; i < answords.Length; i++)
                    {
                        if (answords[i]!="")
                        {
                            if (!processingresult.Contains(answords[i]))
                            {
                                processingresult = processingresult + answords[i].ToString() + " ";
                            }
                           
                        }
                    }
                    //end proce
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into question(question,ans,weightage,branch,sub,sem,processing) values('" + TextBox1.Text + "','" + TextBox8.Text + "','" + DropDownList1.SelectedItem.Text + "','" + br + "','" + subject + "','" + semester + "','"+processingresult+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //end
                    file.Close();

                    // Suspend the screen.
                  
              
                //End processing
                Response.Write("<script language = javascript>alert('Question Successfully Added')</script>");
                 TextBox1.Text="";
                      TextBox8.Text="";
                        
            }

        }
        
        
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}