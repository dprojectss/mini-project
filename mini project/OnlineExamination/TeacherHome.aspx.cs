using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class StudentHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

    string halltick,sem,tmrk,omrk;
       static string branch;
       string[] strmarks;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        
        if (Session["username"]!=null)
        {
            Label1.Text = Session["username"].ToString();
        }
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from techreg where username='"+Label1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        string subject="";
        if (ds.Tables[0].Rows.Count > 0)
        {

            branch = ds.Tables[0].Rows[0]["branch"].ToString();
             subject = ds.Tables[0].Rows[0]["subject"].ToString();


        }


        // fetch hallticketno to add in dropdownlist
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select distinct(hallticketno) from result where subject='"+subject+"' and verifiedanswer='No'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {

            
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                halltick = ds1.Tables[0].Rows[i]["hallticketno"].ToString();
                DropDownList1.Items.Add(halltick);
            }
           
        }
        }
          
            
           
            
           
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["type"] = null;
        Response.Redirect("Default.aspx");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DropDownList1.SelectedItem.Text=="IT")
        //{
        //    DropDownList2.Items.Clear();
        //    DropDownList2.Items.Add("---select---");
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        DropDownList2.Items.Add("Sem "+i);
        //    }

        //}
        //if (DropDownList1.SelectedItem.Text=="Computers")
        //{
        //    DropDownList2.Items.Clear();
        //    DropDownList2.Items.Add("---Select---");
        //    for (int i = 1; i <= 6; i++)
        //    {
        //        DropDownList2.Items.Add("Sem " + i);
        //    }
        //}

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from result r,studreg sr where r.studname=sr.username and sr.branch='"+branch+"' and r.hallticketno='"+DropDownList1.SelectedItem.Text+"';", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            GridView1.DataSource=ds;
            GridView1.DataBind();
            strmarks=new string[GridView1.Rows.Count];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                 TextBox mrk = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBox1");
                 strmarks[i] = mrk.Text;
            }
            Session["marks"] = strmarks;
        }


    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //gridrefresh();
    }

    //private void gridrefresh()
    //{
    //    con.Open();
    //    SqlDataAdapter da = new SqlDataAdapter("select * from result r,studreg sr where r.studname=sr.username and sr.branch='" + branch + "';", con);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    con.Close();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {

    //        GridView1.DataSource = ds;
    //    }

    //}
    protected void Button2_Click(object sender, EventArgs e)
    {
        string[] old = (string[])Session["marks"];
        string hallTicketNumber = DropDownList1.SelectedItem.Text;
		 for (int i = 0; i < GridView1.Rows.Count; i++)
			{
			 TextBox mrk = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBox1");
             string question = GridView1.Rows[i].Cells[0].Text;
             string ans = GridView1.Rows[i].Cells[1].Text;
             string tmrk = mrk.Text;
             double m1 = Convert.ToDouble(old[i]);
             double m2 = Convert.ToDouble(tmrk);
             double avg = Convert.ToDouble((m1 + m2) / 2);
             omrk = System.Math.Round(avg, 2).ToString(); 

              con.Open();
              SqlCommand cmd = new SqlCommand("update result set verifiedanswer='Yes',marks='" + omrk + "' where hallticketno='" + hallTicketNumber + "' and question='" + question + "' and answer='" + ans + "'", con);
              cmd.ExecuteNonQuery();
              con.Close();

			}
        


        
    }
}