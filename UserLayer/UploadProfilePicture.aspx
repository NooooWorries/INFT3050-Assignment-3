<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProfilePicture.aspx.cs" Inherits="BattlingElementalTitans.UploadProfilePicture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Upload profile picture</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
     <style type="text/css">
         .auto-style1 {
             font-size: large;
         }
         .auto-style2 {
             color: #3333FF;
             margin-top: 5px;
             margin-bottom: 5px;
         }
         .auto-style3 {
             font-size: xx-large;
             color: #FF9900;
         }
         .auto-style4 {
             width: 100%;
         }
         .auto-style5 {
             text-align: right;
             font-weight: bold;
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
            <td colspan="2" class="AccountTitle"><strong><span class="auto-style3">Manage Profile</span></strong><br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" class ="description" >
                <div class="pic_image"><asp:Image ID="pic" runat="server" Height="100px" Width="100px" />
                </div>
                <div><asp:FileUpload ID="pic_upload" runat="server" />
                    <br />
                    <span class="auto-style1"><strong></span>
                    <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label> </strong> </div>
                    <div class="auto-style2"><strong>Upload .jpg, jpeg format only, size cannot exceed than 1MB</strong></span><br />
                        <br />
                        <table class="auto-style4">
                            <tr>
                                <td class="auto-style5">Screen name</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="tbxScreenName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Password</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Repeat password</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="tbxRepeatPassword" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                </div>
                   <div>
                       <asp:ImageButton ID="btnUpload" runat="server" ImageUrl="~/images/button/btnUpload.png" OnClick="btnUpload_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/button/btnBackToMainPage.png" OnClick="btnBack_Click" />
                   </div>
               
                <br /></td>
        </tr>
        </table>
    </form>
</body>
</html>
