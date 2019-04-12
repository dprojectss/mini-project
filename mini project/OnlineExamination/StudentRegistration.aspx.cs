using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class StudentRegistration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
 
        
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from StudReg where username='"+TextBox2.Text+"'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count>0)
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Students Already Exist!')</script>");
            
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into studreg values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+"','"+DropDownList2.SelectedItem.Text+"','"+DropDownList1.SelectedItem.Text+"','No','No')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Students Register Successfully!')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == "IT")
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("----Select----");
            for (int i = 1; i <= 5; i++)
            {
                DropDownList1.Items.Add("Sem "+i);
            }
        }
        if (DropDownList2.SelectedItem.Text == "Computers")
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("----Select----");
            for (int i = 1; i <= 6; i++)
            {
                DropDownList1.Items.Add("Sem "+i);
            }
        }
        if (DropDownList2.SelectedItem.Text == "----Select----")
        {
            DropDownList1.Items.Clear();
          
        }
    }
}