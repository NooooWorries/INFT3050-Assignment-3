<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="BattlingElementalTitans.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="account">Account</div></td>
            </tr>
        </table>
        <table class="AccountForm">
        <tr>
            <td colspan="2" class="AccountTitle">Logout<br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" class ="auto-style1" >Logout successful<br />
                <br />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/button/btnBackToWelcomePage.png" OnClick="ImageButton1_Click" />
                <br /> </td>
        </tr>
        </table>
    </form>
</body>
</html>
