<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Login Page</title>
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
         <%-- <h2>Simple. Contemporary. Website Template.</h2>--%>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li class="selected"><a href="Login.aspx">Home</a></li>
          <li><a href="StudentRegistration.aspx">Register</a></li>
         
        </ul>
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
        <!-- insert your sidebar items here -->
        
       <h3>Welcome To Login Form</h3>
          <asp:DropDownList CssClass="input" ID="DropDownList1" runat="server">
              <asp:ListItem>----Select----</asp:ListItem>
              <asp:ListItem>Student</asp:ListItem>
              <asp:ListItem>Teacher</asp:ListItem>
          </asp:DropDownList>
          <p>UserName</p>
           
          <asp:TextBox CssClass="input" ID="TextBox1" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="s" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
          <p>Password</p>
          <asp:TextBox CssClass="input" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
          <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
         
          <br/>
          <asp:Button CssClass="submit" ID="Button1" ValidationGroup="s" runat="server" Text="Submit" OnClick="Button1_Click" />
        
      <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forget Password</asp:LinkButton>--%>
          <br />
          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forget Password</asp:LinkButton>
      </div>
      <div id="content">
        <!-- insert the page content here -->
          <img src="image/imgadmin.jpg" width="600px"/>
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
