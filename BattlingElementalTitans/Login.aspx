<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BattlingElementalTitans.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
    <style type="text/css">
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            font-size: xx-large;
        }
        .auto-style4 {
            color: #FF9900;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
         
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                <table>
                    <tr>
                        <td colspan="2" id="ForgotTitle"> Forgot Password
                            <br />
                            <br />
                            <span class ="description">Enter in your username, an email with your password will send to you.</span>
                        </td> 
                    </tr>
                    <tr>
                        <td>Username:</td>
                        <td>
                            <asp:TextBox ID="tbxForgotUsername" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            <asp:Button ID="btnSend" runat="server" Text="Send password" onclick ="btnSend_Click"/> <br />
            <asp:Button ID="Button2" runat="server" Text="Close" />
        </asp:Panel>
        <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="account">Account</div></td>
            </tr>
        </table>
    
    
    <table class ="AccountForm" >
        <tr>
            <td colspan="2" class="AccountTitle">
                <span class="auto-style3"><span class="auto-style4"><strong>Login</strong></span><strong><br class="auto-style4" />
                </strong></span></td>
        </tr>
        <tr>
            <td class="auto-style2">Username:</td>
            <td class="textbox">
                <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td class="textbox">
                <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="tdForgotPassword" colspan="2">
                <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot password?" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class ="tdSubmit">
                <asp:ImageButton ID="btnLogIn" runat="server" ImageUrl="~/images/button/btnLogin.png" OnClick="btnLogIn_Click1" />
            </td>
        </tr>
    </table>
    </form>    
</body>
</html>
