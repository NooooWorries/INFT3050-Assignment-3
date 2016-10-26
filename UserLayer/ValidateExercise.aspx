<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateExercise.aspx.cs" Inherits="BattlingElementalTitans.ValidateExercise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validate exercise record</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="account">Parents control</div></td>
            </tr>
        </table>
        <table class="AccountForm">
        <tr>
            <td colspan="2" class="AccountTitle">Validate exercise record<br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" class ="tdSubmit" >


                <asp:Label ID="lblMsg" runat="server" CssClass="auto-style1"></asp:Label>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
