<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BattlingElementalTitans.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" type="text/css" href="css/Account.css" /> 
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            text-align: center;
        }
        .auto-style2 {
             font-size: medium;
        }
        .popbox {
    display: none;
    position: absolute;
    z-index: 99999;
    width: 400px;
    padding: 10px;
    background: #EEEFEB;
    color: #000000;
    border: 1px solid #4D4F53;
    margin: 0px;
    -webkit-box-shadow: 0px 0px 5px 0px rgba(164, 164, 164, 1);
    box-shadow: 0px 0px 5px 0px rgba(164, 164, 164, 1);
}
        .auto-style3 {
            font-size: xx-large;
            color: #FF9900;
        }
        .auto-style4 {
            font-size: medium;
            text-align: center;
        }
        .auto-style5 {
            color: #0000FF;
        }
        .auto-style6 {
            font-size: medium;
            height: 46px;
            color: #0000FF;
        }
        .auto-style7 {
            text-align: right;
            height: 46px;
        }
        .auto-style8 {
            font-size: medium;
            color: #0000FF;
        }
    </style>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script>
        /*
         * Ajax: Mouseover screen.
         * Reference source: http://stackoverflow.com/questions/20064226/how-to-create-a-pop-up-div-on-mouse-over-and-stay-when-click 
         */
        $(function () {
            var moveLeft = 0;
            var moveDown = 0;
            $('a.popper').hover(function (e) {

                var target = '#' + ($(this).attr('data-popbox'));

                $(target).show();
                moveLeft = $(this).outerWidth();
                moveDown = ($(target).outerHeight() / 2);
            }, function () {
                var target = '#' + ($(this).attr('data-popbox'));
                $(target).hide();
            });

            $('a.popper').mousemove(function (e) {
                var target = '#' + ($(this).attr('data-popbox'));

                leftD = e.pageX + parseInt(moveLeft);
                maxRight = leftD + $(target).outerWidth();
                windowLeft = $(window).width() - 40;
                windowRight = 0;
                maxLeft = e.pageX - (parseInt(moveLeft) + $(target).outerWidth() + 20);

                if (maxRight > windowLeft && maxLeft > windowRight) {
                    leftD = maxLeft;
                }

                topD = e.pageY - parseInt(moveDown);
                maxBottom = parseInt(e.pageY + parseInt(moveDown) + 20);
                windowBottom = parseInt(parseInt($(document).scrollTop()) + parseInt($(window).height()));
                maxTop = topD;
                windowTop = parseInt($(document).scrollTop());
                if (maxBottom > windowBottom) {
                    topD = windowBottom - $(target).outerHeight() - 20;
                } else if (maxTop < windowTop) {
                    topD = windowTop + 20;
                }
                $(target).css('top', topD).css('left', leftD);
            });
        });
    </script>
    </head>
<body>
    <form id="form1" runat="server">
        <div id="noticeUsername" class="popbox">
            Provide your valid email address here. You need a valid email address to activate your account.
        </div>
        <div id="noticePassword" class="popbox">
            Password is at least 8 alpha numeric characters long. 
        </div>
        <div id="noticeRepeat" class="popbox">
            Repeat your password.
        </div>
        <div id="noticeParent" class="popbox">
            Your parents' email address should not be same as yours.
        </div>
        <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="account">Account</div></td>
            </tr>
        </table>
    <table class="AccountForm">
        <tr>
            <td colspan="2" class="AccountTitle"><span class="auto-style3"><strong>Register</strong></span><br />
                <br />
                <span class ="auto-style1">Register a new account to access the game!</span></td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Username*:</strong></td>
            <td class ="textbox">
                <a href="#" class="popper" data-popbox="noticeUsername"><asp:TextBox ID="tbxUsername" runat="server" CssClass="auto-style2"></asp:TextBox></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Password*:</strong></td>
            <td class ="textbox">
                 <a href="#" class="popper" data-popbox="noticePassword"><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="auto-style2"></asp:TextBox></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Repeat password*:</strong></td>
            <td class ="textbox">
                 <a href="#" class="popper" data-popbox="noticeRepeat"><asp:TextBox ID="tbxRepeatPassword" runat="server" TextMode="Password" CssClass="auto-style2"></asp:TextBox></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Your parents&#39; email*:</strong></td>
            <td class ="textbox">
                <a href="#" class="popper" data-popbox="noticeParent"> <asp:TextBox ID="tbxParentsEmail" runat="server" CssClass="auto-style2"></asp:TextBox></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"><strong>Screen name*:</strong></td>
            <td class ="auto-style7">
                <a href="#" class="popper" data-popbox="noticeParent"> <asp:TextBox ID="tbxScreenName" runat="server" CssClass="auto-style2"></asp:TextBox></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Full name:</strong></td>
            <td class ="textbox">
                <a href="#" class="popper" data-popbox="noticeParent"> <asp:TextBox ID="tbxfirstName" runat="server" CssClass="auto-style2"></asp:TextBox></a>
                <br />
                <strong>
                <asp:CheckBox ID="cbxAnonymous" runat="server" Text="Anonymous" />
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                <strong><span class="auto-style5">* Means compulsory.</span><br class="auto-style5" />
                <span class="auto-style5">If you leave full name as blank, that means you hope to be anonymous.<br />
                Every new user will be givem 100 initial exercise points, you can allocate to any titans. If your titan&#39;s experience points is less than 4, it will not get any experience points in the battle.</span></strong></td>
        </tr>
        <tr>
            <td colspan="2" class ="tdSubmit">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/button/btnRegister.png" OnClick="ImageButton1_Click" />
            </td>
        </tr>
    </table>

    </form>
    </body>
</html>
