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
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string sem;
     
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["username"] != null)
	{
		 Label1.Text = Session["username"].ToString();
	}

       

    }

   
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
       

       string studename = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
      
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from studreg where name = '"+studename+"'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update studreg set account = 'yes' where name='"+studename+"' ",con);
            cmd.ExecuteNonQuery();
            con.Close();
            gridrefresh();                                                                                                                                   


            
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from studreg where name ='"+studename+"' and branch='"+DropDownList1.SelectedItem.Text+"' ",con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count>0)
            {
                Random r = new Random();
                string rnum = r.Next(1234, 8765).ToString();
                string hallticketno = rnum;
               
                sem=ds1.Tables[0].Rows[0]["sem"].ToString();
                
                
                con.Open();
                SqlCommand cmd2 = new SqlCommand("insert into hallticket values('"+studename+"','"+hallticketno+"','"+sem+"');",con);
                cmd2.ExecuteNonQuery();
                con.Close();

                //HtmlGenericControl listItem = H.hide as HtmlGenericControl;

                //if (listItem != null)
                //    this.hide.style.Add("display", "none"); 
            }

        }
        else
        {
            con.Open();
            
            con.Close();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "IT")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("----select----");
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
        gridrefresh();

    }

    private void gridrefresh()
    {
        con.Open(); 
        SqlDataAdapter da = new SqlDataAdapter("select * from studreg where sem = '" + DropDownList2.SelectedItem.Text + "' and branch = '" + DropDownList1.SelectedItem.Text + "' and account ='no'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.Visible = true;
            Label2.Visible = false;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            Label2.Visible = true;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["type"] = null;
        Response.Redirect("Default.aspx");
    }
}