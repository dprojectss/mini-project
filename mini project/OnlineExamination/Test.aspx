<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="TeacherList" %>

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

                            <li><a href="StudentHome.aspx">Home</a></li>
                            <li class="selected"><a href="Test.aspx">Test</a></li>


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




                        <br />
                        <asp:Panel ID="Panel1" Visible="false" runat="server">
                            <p>Your Test is Ready</p>
                            <p>Todays Test Detail:</p>
                            <p>Branch Name : <asp:Label ID="lblnranch" runat="server" Text="Label"></asp:Label></p>
                             <p>Sem:  <asp:Label ID="lblsem" runat="server" Text="Label"></asp:Label></p>
                             <p>Subject Name:<asp:Label ID="lblsubject" runat="server" Text="Label"></asp:Label> </p>
                            
                            
                            <p>
                               <h3>Note :</h3> 
                                <p>
                                </p>
                                <p>
                                    You Have a total Five questions to attemt</p>
                                <p>
                                    Each Questions having 5 marks</p>
                                <p>
                                    Total time for Test Is : 5 minute</p>
                                <p>
                                    Click Below to Start Test Immediately.</p>
                                <asp:Button ID="Button4" runat="server" CssClass="submit" OnClick="Button4_Click" Text="Start Test" />
                            </p>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" Visible="false" runat="server">


                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                </ContentTemplate>
                                <Triggers>

                                    <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                                </Triggers>

                            </asp:UpdatePanel>
                            <asp:Timer ID="Timer2" Interval="1000" Enabled="false" runat="server" OnTick="Timer2_Tick2"></asp:Timer>

                            <asp:Repeater ID="cdcatalog" runat="server" >




                                <HeaderTemplate>


                                    <table width="550px">
                                        <tr>

                                            <th colspan="2" style="float: none">Test Questions
                                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="tick" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </th>
                                            

                                        </tr>
                                </HeaderTemplate>

                                <ItemTemplate>

                                    <tr>

                                        <td colspan="2">
                                            <asp:Label runat="server" ID="Label2"
                                                Text='<%# Eval("question") %>' /><br />
                                            <asp:TextBox TextMode="MultiLine" Height="100px" Width="400px" ID="TextBox1" runat="server"></asp:TextBox>

                                        </td>
                                    </tr>
                                </ItemTemplate>


                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>

                            </asp:Repeater>

                            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                            <asp:ListBox ID="ListBox2" runat="server" ></asp:ListBox>

                            
                            <asp:Label ID="lblhallticketno" runat="server" Text="Label"></asp:Label>

                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>

                            <br />

                            <asp:Button CssClass="submit" ID="Button2" runat="server" Text="Submit Test" OnClick="Button2_Click" />


                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Panel3" Visible="false" runat="server">
                            <p><h1>Time Over<asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
&nbsp;</h1>
                                <p>
                                </p>
                            </p>
                        </asp:Panel>
                        <asp:Panel ID="Panel4" Visible="false" runat="server">
                            <p><h1>Best of Luck </h1></p>
                        </asp:Panel>
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
