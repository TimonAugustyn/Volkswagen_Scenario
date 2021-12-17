<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Volkswagen_Scenario.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="HomeLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Home"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" Text="Here You Can See The Various Features There Are To Offer For Each Model"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="width:400px;" class="auto-style1">  
            <ajaxToolkit:Accordion ID="accCars" runat="server" HeaderCssClass="headerCssClass" 
                ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="true" 
                TransitionDuration="500" AutoSize="None" SelectedIndex="0">  
            </ajaxToolkit:Accordion>  
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Or Update Models" />
    </form>
</body>
</html>
