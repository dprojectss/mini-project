using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string tmob,smob;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "Admin" && TextBox2.Text=="Admin")
        {
            Session["username"] = TextBox1.Text;
            Response.Write("<script language='javascript'>window.alert('Verifiied User');window.location='Admin.aspx';</script>");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "jkl", "alert('yo man wow');window.location('Admin.aspx');", true);
            //Response.Redirect("Admin.aspx");
        }
        if (DropDownList1.SelectedItem.Text == "Teacher")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from techreg where username='"+TextBox1.Text+"' and password = '"+TextBox2.Text+"'",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count>0)
            {
                Session["username"] = TextBox1.Text;
                Session["type"] = DropDownList1.SelectedItem.Text;
                tmob=ds.Tables[0].Rows[0]["contact"].ToString();
                Response.Redirect("TeacherHome.aspx");
            }

        }
        if (DropDownList1.SelectedItem.Text == "Student")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from studreg where username='" + TextBox1.Text + "' and password='"+TextBox2.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["username"] = TextBox1.Text;
                Session["type"] = DropDownList1.SelectedItem.Text;
                tmob = ds.Tables[0].Rows[0]["contact"].ToString();
                Response.Redirect("StudentHome.aspx");
            }

        }
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Student")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from studreg where username='" + TextBox1.Text + "' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["username"] = TextBox1.Text;
                Session["type"] = DropDownList1.SelectedItem.Text;
                tmob = ds.Tables[0].Rows[0]["contact"].ToString();
              
           

            Session["type"] = "Student";
           
            #region sms
            Random r = new Random();
            int otp = r.Next(1111, 9999);
            Session["username"] = TextBox1.Text;
            string msg = "Pleease put your otp to unblocked";

            Session["otp"] = otp;
            string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=priyankamusle@gmail.com:7786&senderID=TEST SMS&receipientno=" + tmob + "&msgtxt=" + otp + "&state=4";
            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();

            #endregion
            Response.Write("<script LANGUAGE='JavaScript' >alert('OTP sent to your contact!')</script>");
            Response.Redirect("OTP.aspx");
        }
        }
         if (DropDownList1.SelectedItem.Text == "Teacher")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from techreg where username='" + TextBox1.Text + "' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["username"] = TextBox1.Text;
                Session["type"] = DropDownList1.SelectedItem.Text;
                tmob = ds.Tables[0].Rows[0]["contact"].ToString();
               
           

              Session["type"] = "Teacher";
              #region sms
              Random r = new Random();
              int otp = r.Next(1111, 9999);
              Session["username"] = TextBox1.Text;
              string msg = "Pleease put your otp to unblocked";

              Session["otp"] = otp;
              string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=priyankamusle@gmail.com:7786&senderID=TEST SMS&receipientno=" + tmob + "&msgtxt=" + otp + "&state=4";
              WebRequest request = HttpWebRequest.Create(strUrl);
              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
              Stream s = (Stream)response.GetResponseStream();
              StreamReader readStream = new StreamReader(s);
              string dataString = readStream.ReadToEnd();
              response.Close();
              s.Close();
              readStream.Close();

              #endregion
              Response.Write("<script LANGUAGE='JavaScript' >alert('You r Blocked!')</script>");
              Response.Redirect("OTP.aspx");
            
        }
        }
     
    }
}