<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fight.aspx.cs" Inherits="BattlingElementalTitans.Fight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fight!!</title>
    <link rel="stylesheet" type="text/css" href="css/Battle.css" /> 
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style8 {
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }
        .auto-style3 {
            font-size: 50pt;
            text-align: center;
            color: #FF0000;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style9 {
            text-align: left;
        }
        .auto-style10 {
            width: 152px;
            height: 62px;
            color: #FFFFFF;
        }
        .auto-style11 {
            font-size: 80pt;
        }
        .auto-style12 {
            color: #FFFFFF;
        }
        .auto-style13 {
            color: #FEFFFF;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="background" class="auto-style8"><img src="images/background/FightBG.jpg" /></div> 
    <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="fight">Elemental Battle Arena</div></td>
            </tr>
    </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">
        <table class="auto-style1">
            <tr>
                <td class="auto-style9">
                    <asp:Image ID="imgTitan" runat="server" Height="382px" />
                    <asp:Image ID="imgElement" runat="server" Width="87px" />
                    <br />
                    <span class="auto-style12"><strong>YOUR TITAN</strong></span><br />
                    <span class="auto-style10"><strong>Titan&#39;s name:</strong></span><strong><asp:Label ID="lblTitan" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Level:</strong></span><strong><asp:Label ID="lblLevel" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Steps:</strong></span><strong><asp:Label ID="lblSteps" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Experience points:</strong></span><strong><asp:Label ID="lblExp" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Wins:</strong></span><strong><asp:Label ID="lblWins" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Loses:</strong></span><strong><asp:Label ID="lblLoses" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Player:</strong></span><strong><asp:Label ID="lblPlayer" runat="server" CssClass="auto-style10"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style3"><strong><span class="auto-style11">Vs</span></strong><br />
                </td>
                <td class="auto-style2">
                    <asp:Image ID="imgElementEnemy" runat="server" Width="87px" />
                    <asp:Image ID="imgTitanEnemy" runat="server" Height="382px" />
                    <br />
                    <span class="auto-style13"><strong>RIVAL&#39;</strong></span><span class="auto-style10"><strong><span class="auto-style13">S TITAN</span><br />
                    Titan&#39;s name:</strong></span><strong><asp:Label ID="lblTitanEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Level:</strong></span><strong><asp:Label ID="lblLevelEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Steps:</strong></span><strong><asp:Label ID="lblStepsEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Experience points:</strong></span><strong><asp:Label ID="lblExpEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Wins:</strong></span><strong><asp:Label ID="lblWinsEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Loses:</strong></span><strong><asp:Label ID="lblLosesEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    <br class="auto-style10" />
                    </strong>
                    <span class="auto-style10"><strong>Player:</strong></span><strong><asp:Label ID="lblPlayerEnemy" runat="server" CssClass="auto-style10"></asp:Label>
                    </strong>
                </td>
            </tr>
            </table>
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnBattle" runat="server" ImageUrl="~/images/button/btnBeginFight.png" OnClick="btnBattle_Click" />
&nbsp;&nbsp;
                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/button/btnCancelFight.png" OnClick="btnCancel_Click1" />
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
