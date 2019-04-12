<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentHome.aspx.cs" Inherits="StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Student Home</title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
  <link rel="stylesheet" type="text/css" href="style/style.css" title="style" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="main">
    <div id="header">
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a>OnlineDescriptive<span class="logo_colour">Examination</span></a></h1>
          
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li class="selected"><a href="StudentHome.aspx">Home</a></li>
              <li><a href="DemoTest.aspx">DemoTest</a></li>
            <li><a href="Test.aspx">Test</a></li>
             <li><a href="Result.aspx">Result</a></li>

          
        </ul>
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
         
        <!-- insert your sidebar items here -->
        <h4>Welcome Student Home Page</h4>
     
          <br />
          <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Logout" />
     
          <br />
          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click Here to Download Hall Ticket</asp:LinkButton>
        
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome Student
          <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green"></asp:Label>
     
            <asp:Label ID="Label2" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label3" Visible="false" runat="server" Text="Label"></asp:Label>
     
          </h1>
        <img src="image/img1.JPG" width="600px" height="300px"/>
          <div style="display:none">
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
              <Columns>
                  <asp:BoundField DataField="subjectname" HeaderText="Subject" />
                  <asp:BoundField DataField="dates" HeaderText="Date" />
                  <asp:BoundField DataField="time" HeaderText="Time" />
              </Columns>
             
          </asp:GridView>
          </div>
         
    </div>
  </div>
    <div id="footer1">
       Copyright &copy; OnlineDescriptiveExamination
    </div>
  </div>
    </div>
    </form>
</body>
</html>
