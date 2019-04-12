using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



public partial class StudentHome : System.Web.UI.Page
{
    string dt;
    string brnch, sem, sub, date, time,hall;
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //string halltick;
        if (Session["username"] != null)
        {
            Label1.Text = Session["username"].ToString();
        }
        if (!IsPostBack)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from studreg where username='" + Label1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                brnch = ds.Tables[0].Rows[0]["branch"].ToString();
                sem = ds.Tables[0].Rows[0]["sem"].ToString();
                Label3.Text = brnch;
                Label2.Text = sem;
            }

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from examdates where sem='" + sem + "' and branchname='" + brnch + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                sub = ds1.Tables[0].Rows[0]["subjectname"].ToString();
                date = ds1.Tables[0].Rows[0]["dates"].ToString();
                time = ds1.Tables[0].Rows[0]["time"].ToString();
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
            try
            {

            }
            catch(Exception abbb)
            {
                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("select * from hallticket where username='" + Label1.Text + "'", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hall = ds2.Tables[0].Rows[0]["hallticketno"].ToString();
                    sem = ds2.Tables[0].Rows[0]["sem"].ToString();
                    Label2.Text = sem;
                }
            }
           
        }
        //con.Open();
        //SqlDataAdapter da1 = new SqlDataAdapter("select * from examdates",con);
        //DataSet ds1 = new DataSet();
        //da1.Fill(ds1);
        //con.Close();
        //if (ds1.Tables[0].Rows.Count>0)
        //{
        //     dt = ds1.Tables[0].Rows[0]["dates"].ToString();
        //}

        con.Open();
        SqlDataAdapter da12 = new SqlDataAdapter("select * from studreg where username = '"+Label1.Text+"' and hallticket ='yes' and account='Yes'",con);
        DataSet ds12 = new DataSet();
        da12.Fill(ds12);
        con.Close();
        if (ds12.Tables[0].Rows.Count>0)
        {
            //halltick = ds.Tables[0].Rows[0]["hallticket"].ToString();
            LinkButton1.Visible = true;
            
        }
        else
        {
            LinkButton1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Session["username"] = null;
        Session["type"] = null;
        Response.Redirect("Default.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }  
  
    private void ExportGridToPDF()
    {
        string filename = "HallTicket " + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Second.ToString() + ".pdf";
       // Response.ContentType = "application/pdf";
       // Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
       // Response.Cache.SetCacheability(HttpCacheability.NoCache);
       // StringWriter sw = new StringWriter();
       // HtmlTextWriter hw = new HtmlTextWriter(sw);
       // GridView1.AllowPaging = false;
       // GridView1.DataBind();
       // GridView1.RenderControl(hw);
       // StringReader sr = new StringReader(sw.ToString());
       // Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
       // HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
       // PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
       // pdfDoc.Open();
       //pdfDoc.Add(new Paragraph(DateTime.Now.ToShortDateString()));
       // //pdfDoc.Add(new Paragraph("Hall Ticket!"));
       // //pdfDoc.Add(new Paragraph("Semester: " + sem + " " + " : " + "Branch: " + brnch));
       // //pdfDoc.Add(new Paragraph("Student Name: " + Label1.Text + "\t Hallticket Number:" + hall));
       // ////pdfDoc.Add(new Paragraph("ClassRoom: " + croom));
       // //pdfDoc.Add(new Paragraph("\n"));
       // //pdfDoc.Add(new Paragraph("\n"));
       // //pdfDoc.Add(new Paragraph("Subject :" + sub + "\t Date :" + date + "\tTime :" + time));

       // htmlparser.Parse(sr);
       // pdfDoc.Close();
       // Response.Write(pdfDoc);
       // Response.End();
        //string filename = "HallTicket " + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Minute.ToString() + " " + DateTime.Now.Second.ToString() + ".pdf";
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
        pdfDoc.Add(new Paragraph("Hall Ticket!"));
        pdfDoc.Add(new Paragraph("Semester: " + Label2.Text + " " + " : " + "Branch: " + Label3.Text));
     pdfDoc.Add(new Paragraph("Student Name: " + Label1.Text ));
       
        pdfDoc.Add(new Paragraph("\n"));
        pdfDoc.Add(new Paragraph("\n"));
        pdfDoc.Add(new Paragraph("Subject                                                             Date                                                 Time"));

        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();



       
    }






  
}