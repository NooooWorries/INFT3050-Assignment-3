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
            <td colspan="2" class="AccountTitle"><strong><span class="auto-style3">Upload Profile Picture</span></strong><br />
                <asp:Label ID="lblObject" runat="server"></asp:Label>
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
                    <div class="auto-style2"><strong>Upload .jpg, jpeg format only, size cannot exceed than 1MB</strong></span></div>
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
