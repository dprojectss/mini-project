<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherHome.aspx.cs" Inherits="StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Teacher Home Page</title>
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
          <li class="selected"><a href="TeacherHome.aspx">Home</a></li>
            <li class="selected"><a href="Question.aspx">Add Questions</a></li>
          
        </ul>
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
        <!-- insert your sidebar items here -->
        <h4>Logout Here</h4>
         
          <br />
          <asp:Button ID="Button1" CssClass="submit" runat="server" Text="Logout" OnClick="Button1_Click" />
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome Teacher
           <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green"></asp:Label>
          </h1>
        <img src="image/imglogin.jpg"/>
          <br />
          <div style="display:inline;width:200PX;height:200PX">
              <h2>Manual Checking</h2>
              Hallticket No
          <br />
          <asp:DropDownList CssClass="input" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
              <asp:ListItem>----Select----</asp:ListItem>
          </asp:DropDownList>   
             
              
              <br />
              <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
          <br />
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                  <Columns>
                      <asp:BoundField DataField="question" HeaderText="Questions" />
                      <asp:BoundField DataField="answer" HeaderText="Answer" />
                      <asp:TemplateField HeaderText="Marks">
                          <ItemTemplate>
                              <asp:TextBox Text='<%# Eval("marks") %>' ID="TextBox1" runat="server"></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
              </asp:GridView>
              <br />
         </div>
          
          <asp:Button CssClass="submit" ID="Button2" runat="server" Text="Update Marks" OnClick="Button2_Click" />
          
     </div>
    <div id="footer1">
      Copyright &copy; OnlineDescriptiveExamination
    </div>
  </div>
    </div>
       
    </form>
</body>
</html>
