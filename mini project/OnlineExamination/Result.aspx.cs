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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

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
       con.Open();
       SqlDataAdapter da = new SqlDataAdapter("select distinct(hallticketno) from result where studname='"+Label1.Text+"'", con);
       DataSet ds = new DataSet();
       da.Fill(ds);
       con.Close();
       if (ds.Tables[0].Rows.Count>0)
       {
           DropDownList1.Items.Add("----Select---");
           //string hall = ds.Tables[0].Rows[0]["hallticketno"].ToString();
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               DropDownList1.Items.Add(ds.Tables[0].Rows[i]["hallticketno"].ToString());
           }
       }

    }

   
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
       

      
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridrefresh();

        
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    private void gridrefresh()
    {
         con.Open();
        SqlDataAdapter daa = new SqlDataAdapter("select * from result  where  hallticketno = '"+DropDownList1.SelectedItem.Text+"' and verifiedanswer='Yes' ",con);
        DataSet dss = new DataSet();
        daa.Fill(dss);
        con.Close();
        if (dss.Tables[0].Rows.Count > 0)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select sum(cast(marks as float)) as marks ,( sum(cast(marks as float))/(count(question) * 5))*100 as percentage,hallticketno, subject from result  where  hallticketno = '" + DropDownList1.SelectedItem.Text + "' group by hallticketno,subject", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //string mrk = ds.Tables[0].Rows[0]["percentage"].ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    double passingmarks = 35;

                    double per = Convert.ToDouble(ds.Tables[0].Rows[i]["percentage"].ToString());
                    if (per >= passingmarks)
                    {
                        Label2.Visible = true;
                        Label2.Text = per + " %" + "You are Passed";
                    }
                    else
                    {
                        Label2.Visible = true;
                        Label2.Text = per + " %" + " You are Failed";
                    }

                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('Result Not Ready.')</script>");
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        string filename = "Marks Sheet " + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Second.ToString() + ".pdf";
       
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        pdfDoc.Add(new Paragraph(DateTime.Now.ToShortDateString()));
        pdfDoc.Add(new Paragraph("Marksheet!"));
        //pdfDoc.Add(new Paragraph("Semester: " + sem + " " + " : " + "Branch: " + branch));
        //pdfDoc.Add(new Paragraph("Student Name: " + sname + "\t Seat Number:" + hn));
        //pdfDoc.Add(new Paragraph("ClassRoom: " + croom));
        pdfDoc.Add(new Paragraph("\n"));
        pdfDoc.Add(new Paragraph("\n"));
      //  pdfDoc.Add(new Paragraph("Subject        \t Date \tTime"));

        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();


    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}