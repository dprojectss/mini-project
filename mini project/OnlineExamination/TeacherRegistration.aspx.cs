using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class TeacherRegistration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            Label1.Text = Session["username"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from techreg where username='"+TextBox2.Text+"'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            Response.Write("<script language = java script>alert('Username Already Exists')</script>");
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into techreg values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script language = java script>alert('Registration Successful')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text=="IT")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("----Select----");
            for (int i = 1; i <= 5; i++)
            {
                DropDownList2.Items.Add("Sem "+i);
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
        if (DropDownList1.SelectedItem.Text=="Computers")
        {
            string sem = DropDownList2.SelectedItem.Text;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from subject where branch = '"+DropDownList1.SelectedItem.Text+"' and sem = '"+sem+"'",con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            if (ds.Tables[0].Rows.Count>0)
            {
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("----Select----");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList3.Items.Add(ds.Tables[0].Rows[i]["subject"].ToString());
                }
            }
        }
        if (DropDownList1.SelectedItem.Text == "IT")
        {
            string sem = DropDownList2.SelectedItem.Text;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from subject where branch = '" + DropDownList1.SelectedItem.Text + "' and sem = '" + sem + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("----Select----");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList3.Items.Add(ds.Tables[0].Rows[i]["subject"].ToString());
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["type"] = null;
        Response.Redirect("Default.aspx");
    }
}