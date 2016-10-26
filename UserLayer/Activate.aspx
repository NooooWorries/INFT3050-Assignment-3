<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activate.aspx.cs" Inherits="BattlingElementalTitans.Activate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Activate your account</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
    <script>
        function delayURL(url, time)
        {
            setTimeout("top.location.href='" + url + "'", time);
        }
    </script>
    <style>
        body {background:url(/images/background/MainBG.jpg) fixed;}
        .auto-style2 {
            font-size: medium;
            text-align: center;
        }
        .auto-style3 {
            font-size: x-large;
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
            <td class="AccountTitle">Activate your account<br />
                <br />
                <span class ="description">The last step to register your account</span>
            </td>
        </tr>
        <tr>
            <td class ="auto-style2">


                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />
                Jump to login page automatically in <span id="time" style="background: red" class="auto-style3">5</span> seconds. <br />
                If browser has no response, please click <a href="Login.aspx">here</a>
                <script >
                    delayURL("Login.aspx", 5000);
                </script>
            </td>
        </tr>
    </table>

    </form>
    </body>
</html>
