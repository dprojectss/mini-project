<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="TeacherList" %>

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
        <li class="selected"><a href="StudentHome.aspx">Home</a></li>
            <li><a href="Test.aspx">Test</a></li>
            <li><a href="Result.aspx">Result</a></li>
            
            

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
       <p>Hallticket</p>
         &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
          </asp:DropDownList>

          <br />
          <br />
          <br />
          <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red" Text="No Records Found" Visible="False"></asp:Label>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged1="GridView1_SelectedIndexChanged1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowCommand="GridView1_RowCommand">
              <Columns>
                  <asp:BoundField HeaderText="Hallticket No" DataField="hallticketno" />
                  <asp:BoundField DataField="subject" HeaderText="Subject" />
                  <asp:BoundField DataField="marks" HeaderText="Marks" />
              </Columns>
          </asp:GridView>
          <br />
          <asp:Button CssClass="submit" ID="Button2" runat="server" Text="Download Result" OnClick="Button2_Click" />
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
