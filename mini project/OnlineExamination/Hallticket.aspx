<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hallticket.aspx.cs" Inherits="TeacherList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Hall Ticket</title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
  <link rel="stylesheet" type="text/css" href="style/style.css" title="style" />
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager2" runat="server" ClientIDMode="AutoID">
              
        </asp:ScriptManager>
                                                                                                        
          <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                
        &nbsp;<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
          <Triggers>
              <asp:AsyncPostBackTrigger ControlID="timer1" EventName ="tick" />
          </Triggers>
       </asp:UpdatePanel>
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
          
             <li class="selected" id="hide"><a href="Hallticket.aspx" >Hallticket</a></li>
            

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
        <!-- insert the page content here -->
          <asp:Panel ID="Panel2" runat="server"> 
   &nbsp;<br /></asp:Panel>  
          <br />
          
         

          <asp:Panel ID="Panel1" runat="server">
             <p>&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 &nbsp;is your Hallticket Numer Please enter in Text Box&nbsp;&nbsp; 
                 <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
                 <asp:Button ID="Button4" runat="server" Text="Button" />
              </p> 
              <asp:TextBox CssClass="input" ID="TextBox1" runat="server"></asp:TextBox>
              <br />
               <asp:Button CssClass="submit" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /> 
              <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
          </asp:Panel>
              <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="391px">   
                  <Columns>
                      <asp:BoundField DataField="username" HeaderText="UserName" />
                      <asp:BoundField DataField="branch" HeaderText="Branch" />
                      <asp:BoundField DataField="sem" HeaderText="Semester" />
                      <asp:BoundField DataField="hallticketno" HeaderText="Hallticket No" />
                      <asp:BoundField DataField="subject" HeaderText="Subject" />
                      <asp:BoundField DataField="dates" HeaderText="Date" />
                      <asp:BoundField DataField="time" HeaderText="Time" />
                  </Columns>
              
              </asp:GridView>--%>
          

          <asp:Panel ID="Panel3" runat="server">
          <p>Q1   <asp:Label ID="Label3" runat="server" Text="Label" Font-Names="Times New Roman" Font-Size="12pt"></asp:Label></p> 
          </asp:Panel>
          <asp:TextBox CssClass="inputt" ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />
          <p>Q2  <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></p>
          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          <p>Q3</p>
          <br />
          
          <asp:Button CssClass="submit" ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
          
      
		<br /><br />
		<asp:ScriptManager ID="ScriptManager1" runat="server"/>
		
          <%--<script>
              var myVar;

              function myFunction() {
                  myVar = setTimeout(alertFunc, 3000);
              }

              function alertFunc() {
                  alert("Hello!");
              }
</script>--%>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
               <%-- <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>--%>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
			<Triggers>

				<asp:AsyncPostBackTrigger controlid="Timer1" eventname="Tick" />
			</Triggers>
               
		</asp:UpdatePanel>    
      </div>
     </div>
    <div id="footer1">
      Copyright &copy; OnlineDescriptiveExamination
    </div>
  </div>
    </div>
      
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
        </asp:Timer>
      
    </form>
</body>
</html>
