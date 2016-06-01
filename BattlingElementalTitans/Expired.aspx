<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expired.aspx.cs" Inherits="BattlingElementalTitans.Expired" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/Error.css" /> 
    <title>Session expired</title>
    <style type="text/css">
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            font-size: x-large;
            font-family: Arial;
            height: 118px;
        }
        .auto-style4 {
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="error">Error</div></td>
            </tr>
        </table>
        
        
            <table class="ErrorForm">
                <tr>
                    <td class="auto-style3">
                        <span class="auto-style4">Session Expired</span><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <p class="auto-style2">
                                The pages you are trying to visit had already been expired. </p>
                            <p class="auto-style2">
                                Please do not to click back button on your browser.</p>
                            <p class="auto-style2">
                                &nbsp;</p>
                            <p class="auto-style2">
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/button/btnBackToWelcomePage.png" OnClick="btnBack_Click" />
                            </p>
                        
                    </td>
                </tr>
            </table>
        
        
    </div>
    </form>
</body>
</html>
