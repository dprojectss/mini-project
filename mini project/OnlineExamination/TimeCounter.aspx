<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeCounter.aspx.cs" Inherits="TimeCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" ClientIDMode="AutoID">
              
        </asp:ScriptManager>
                                                                                                        
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <Triggers>
              <asp:AsyncPostBackTrigger ControlID="timer1" EventName ="tick" />
          </Triggers>
       </asp:UpdatePanel>
        
    </div>
         
        <br />
        <asp:Panel ID="Panel1" runat="server">
        <asp:Repeater id="cdcatalog" runat="server" OnItemCommand="cdcatalog_ItemCommand">

<HeaderTemplate>
<table width="50%">
<tr>
    
<th style="float:none">Test Questions</th>


</tr>
</HeaderTemplate>

<ItemTemplate>
 
    <tr>
        <td></td>
      <td> <asp:Label runat="server" ID="Label2"
                 Text='<%# Eval("question") %>' /><br />
          <asp:TextBox TextMode="MultiLine" ID="TextBox1" runat="server"></asp:TextBox>

     </td>
  </tr>
</ItemTemplate>
          

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>
        <asp:Button ID="Button1" runat="server" Text="Submit Test" OnClick="Button1_Click" />
        <asp:Timer ID="Timer1" OnTick="Unnamed_Tick" Interval="1000" runat="server"></asp:Timer>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </asp:Panel>

    </form>
</body>
</html>
