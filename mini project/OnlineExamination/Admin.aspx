<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Admin</title>
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
          <h1><a href="">OnlineDescriptive<span class="logo_colour">Examination</span></a></h1>
          <h2></h2>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li  class="selected"><a href="Admin.aspx">Home</a></li>
          <li ><a href="TeacherRegistration.aspx">AddTeacher</a></li>
            <li ><a href="TeacherList.aspx">Teacher List</a></li>
            <li ><a href="StudentList.aspx">Student List</a></li>
             <li ><a href="ExamDates.aspx">ExamDates</a></li>

           

        </ul>
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
        <!-- insert your sidebar items here -->
        <h4>Welcome&nbsp;
          <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green"></asp:Label>
     
          </h4>
     
          <br />
          <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Logout" />
     
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1></h1>
        <img src="image/img2.jpg" width="600px" height="300px"/>
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
