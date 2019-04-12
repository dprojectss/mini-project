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
    string date;
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            Label1.Text = Session["username"].ToString();
        }
    }


    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {



    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "IT")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("----Select----");
            for (int i = 1; i <= 5; i++)
            {
                DropDownList2.Items.Add("Sem " + i);
            }
        }
        if (DropDownList1.SelectedItem.Text == "Computers")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("----Select----");
            for (int i = 1; i <= 6; i++)
            {
                DropDownList2.Items.Add("Sem " + i);
            }
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from subject where branch='" + DropDownList1.SelectedItem.Text + "' and sem = '" + DropDownList2.SelectedItem.Text + "' ", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //con.Open();
        //SqlDataAdapter da = new SqlDataAdapter("select * from examdates where branchname='" + DropDownList1.SelectedItem.Text + "' and sem ='" + DropDownList2.SelectedItem.Text + "'", con);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //con.Close();
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            TextBox Contract = (TextBox)GridView1.Rows[i].Cells[1].FindControl("dt1");
            //TextBox time = (TextBox)GridView1.Rows[i].Cells[2].FindControl("t1");
            //HtmlInputControl Contract = ((HtmlInputControl)GridView1.Rows[i].Cells[1].FindControl("dt1"));
            string str = Contract.Text;
            date = str;
         //   string t = time.Text;
            //check already record of selected subject

            con.Open();
            SqlDataAdapter daa = new SqlDataAdapter("select * from examdates where branchname='" + DropDownList1.SelectedItem.Text + "' and sem='" + DropDownList2.SelectedItem.Text + "' and subjectname='" + GridView1.Rows[i].Cells[0].Text + "'", con);
            DataSet dss = new DataSet();
            daa.Fill(dss);
            con.Close();
            if (dss.Tables[0].Rows.Count > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update examdates set dates='" + date + "' where branchname='" + DropDownList1.SelectedItem.Text + "' and sem='" + DropDownList2.SelectedItem.Text + "' and subjectname='" + GridView1.Rows[i].Cells[0].Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into examdates values('" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + GridView1.Rows[i].Cells[0].Text + "','" + date + "')", con);
                //cmd.Parameters.AddWithValue("@dd",date);
                //cmd.Parameters.AddWithValue("@tt", t);  
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //hallticket is ready 

        }
     
        con.Open();
        SqlCommand cmd1 = new SqlCommand("update studreg set hallticket = 'yes' where branch='" + DropDownList1.SelectedItem.Value + "' and sem='" + DropDownList2.SelectedItem.Text + "'  ", con);
        cmd1.ExecuteNonQuery();
        con.Close();
        Response.Write("<script language=javascript>alert('Date has been updated')</script>");
    }
        //else
        //{


        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {

        //        TextBox Contract = (TextBox)GridView1.Rows[i].Cells[1].FindControl("dt1");
        //        TextBox time = (TextBox)GridView1.Rows[i].Cells[2].FindControl("t1");
        //        //HtmlInputControl Contract = ((HtmlInputControl)GridView1.Rows[i].Cells[1].FindControl("dt1"));
        //        string str = Contract.Text;
        //        date = str;
        //        string t = time.Text;
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("insert into examdates values('" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + GridView1.Rows[i].Cells[0].Text + "','" + date + "','" + t + "')", con);
        //        //cmd.Parameters.AddWithValue("@dd",date);
        //        //cmd.Parameters.AddWithValue("@tt", t);  
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        con.Open();
        //        cmd = new SqlCommand("update studreg set hallticket = 'yes' where branch='" + DropDownList1.SelectedItem.Value + "' and sem='" + DropDownList2.SelectedItem.Text + "'  ", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //}


   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["type"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}