<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistration.aspx.cs" Inherits="StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>colour_blue</title>
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
          <h1><a href=" ">OnlineDescriptive<span class="logo_colour">Examination</span></a></h1>
          <h2></h2>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li class="selected"><a href="StudentRegistration.aspx">Registration</a></li>
             <li><a href="Default.aspx">Login</a></li>
          
         
        </ul>
      </div>
    </div>
    <div id="site_content">
      
       
      <div class="sidebar">
        <!-- insert your sidebar items here -->
        <h3>Welcome Students</h3>
       
        
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
        
            <h1>Welcome To Registration Form</h1>
       <p>Name</p>    <asp:TextBox CssClass="inputt" ID="TextBox1" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Invalid Name" ValidationExpression="^[a-zA-Z'.\s]{1,50}"></asp:RegularExpressionValidator>
        <br />
          <p>User Name </p>
        <asp:TextBox CssClass="inputt" ID="TextBox2" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
         <br />
            <p>Password</p>
          <asp:TextBox CssClass="inputt" ID="TextBox3" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
           
          <p>Email_Id </p>
          <asp:TextBox CssClass="inputt" ID="TextBox4" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
         
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         
           <p>Contact</p> 
          <asp:TextBox CssClass="inputt" ID="TextBox5" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
        
           <p>Branch</p>
             
              
          <asp:DropDownList CssClass="input" ID="DropDownList2" runat="server" Width="172px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
              <asp:ListItem>----Select----</asp:ListItem>
              <asp:ListItem>IT</asp:ListItem>
              <asp:ListItem>Computers</asp:ListItem>
          </asp:DropDownList>
          <br />
          <p>Sem</p>
              <br />
          <asp:DropDownList CssClass="inputt" ID="DropDownList1" runat="server" Width="179px">
          </asp:DropDownList><br /><br />
          
          <asp:Button CssClass="submit" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />

    
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
