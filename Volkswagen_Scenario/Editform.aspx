<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editform.aspx.cs" Inherits="Volkswagen_Scenario.Editform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="HomeLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Create/Update"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" Text="Use This Site To Create Or Update Entries"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="width:400px;" class="auto-style1">  
            <ajaxToolkit:Accordion ID="accEdit" runat="server" HeaderCssClass="headerCssClass" 
                ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="true" 
                TransitionDuration="500" AutoSize="None" SelectedIndex="0">  
            </ajaxToolkit:Accordion>  
        </div>
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return To Home Page" />
    </form>
</body>
</html>
