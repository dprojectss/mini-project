<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="TeacherList" %>

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
          <h1><a>OnlineDescriptive<span class="logo_colour">Examination</span></a></h1>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li ><a href="Admin.aspx">Home</a></li>
          <li   ><a href="TeacherRegistration.aspx">AddTeacher</a></li>
            <li ><a href="TeacherList.aspx">Teacher List</a></li>
            <li class="selected" ><a href="StudentList.aspx">Student List</a></li>
            <li><a href="ExamDates.aspx">ExamDates</a></li>
            
            

        </ul>
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
        <!-- insert your sidebar items here -->
        <h4>Welcome&nbsp;
          <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green"></asp:Label>
     
          </h4>
     
          <asp:Button CssClass="submit" ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
     
          <br />
     
      </div>
      <div id="content">
        <!-- insert the page content here -->
       <p>Branch</p>
         <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
              <asp:ListItem>----Select----</asp:ListItem>
              <asp:ListItem>IT</asp:ListItem>
              <asp:ListItem>Computers</asp:ListItem>
          </asp:DropDownList>

         <p>Semester</p> <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
          <asp:ListItem>----Select----</asp:ListItem>
          </asp:DropDownList>
          <br />
          <br />
          <br />
          <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red" Text="No Records Found" Visible="False"></asp:Label>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged1="GridView1_SelectedIndexChanged1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowCommand="GridView1_RowCommand">
              <Columns>
                  <asp:BoundField HeaderText="Student Name" DataField="name" />
                  <asp:BoundField DataField="branch" HeaderText="Branch" />
                  <asp:BoundField DataField="sem" HeaderText="Sem" />
                  <asp:BoundField DataField="hallticket" HeaderText="Status" />
                  <asp:CommandField ButtonType="Button" HeaderText="Account" ShowSelectButton="True" SelectText="Verified" >
                  <ControlStyle CssClass="submit" />
                  </asp:CommandField>
              </Columns>
          </asp:GridView>
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
