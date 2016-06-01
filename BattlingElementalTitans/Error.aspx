<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BattlingElementalTitans.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/Error.css" /> 
    <title>Error</title>
    <style type="text/css">
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            font-size: xx-large;
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
                        <span class="auto-style4">Error</span><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <p class="auto-style2">
                                Sorry we have encounter a critical error.</p>
                            <p class="auto-style2">
                                Error occured.</p>
                            <p class="auto-style2">
                                You can send an email to our customer services.</p>
                            <p class="auto-style2">
                                Please check the url,
                                or try again in 5 minutes.</p>
                            <p class="auto-style2">
                                Customer service: c3218124@uon.edu.au</p>
                            <p class="auto-style2">
                                Error message from server:</p>
                            <p class="auto-style2">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </p>
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
