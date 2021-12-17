<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayForm.aspx.cs" Inherits="Volkswagen_Scenario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="HomeLayout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style0">
                    <asp:Label ID="Label1" runat="server" Text="Please Select Your Model:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpModel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpModel_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style0">
                    <asp:Label ID="lblModel" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style0">
                    <asp:Label ID="lblCount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:GridView ID="grdModels" runat="server">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Please Select The Car ID Of The Car You'd Like To Purchase:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
                </td>
                <td>
                    <asp:Label ID="lblPurchase" runat="server" Text="Car Successfully Purchased!"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return To Home Page" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
