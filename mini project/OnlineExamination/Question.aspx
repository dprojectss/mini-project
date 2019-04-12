<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question.aspx.cs" Inherits="TeacherList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Teacher List</title>
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
          <h1>Online Descriptive<span class="logo_colour">Examination</span></h1>
          <h2></h2>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li ><a href="TeacherHome.aspx">Home</a></li>
          
            <li class="selected"><a href="Question.aspx">Add Question</a></li>
            

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
     
      </div>
      <div id="content">
          <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <!-- insert the page content here -->
       <p>Add Questions</p>
          <br />
          <p>Question :</p> <asp:TextBox CssClass="inputt" ID="TextBox1" TextMode="MultiLine" runat="server"></asp:TextBox>
                <p>Answer :</p><asp:TextBox CssClass="inputt" ID="TextBox8" TextMode="MultiLine" runat="server"></asp:TextBox>
        <p>Marks</p>
              <asp:DropDownList CssClass="inputt" ID="DropDownList1" runat="server">
                  <asp:ListItem>----Select----</asp:ListItem>
                  <asp:ListItem>5</asp:ListItem>
                  <asp:ListItem>10</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
          
         <%-- <p>Answer</p>
              <p>A:&nbsp; <asp:TextBox CssClass="inputt" ID="TextBox2" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;</p>
          <p>B:&nbsp;
              <asp:TextBox CssClass="inputt" ID="TextBox3" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
          <p>C:&nbsp;
              <asp:TextBox CssClass="inputt" ID="TextBox5" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;&nbsp;</p>
          <p>D:&nbsp;
              <asp:TextBox CssClass="inputt" ID="TextBox4" runat="server"></asp:TextBox></p>
          <p>Correct :
              <asp:TextBox CssClass="inputt" ID="TextBox7" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox7" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
          </p>--%>
          <p>
             
              <asp:Button CssClass="submit" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
          </p>

          </div>
     </div>
    <div id="footer1">
      Copyright &copy; OnlineDescriptiveExamination
    div>
    </div>
      
    </form>
</body>
</html>
