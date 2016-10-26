<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FightOutcome.aspx.cs" Inherits="BattlingElementalTitans.FightOutcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fight Outcome</title>
    <link rel="stylesheet" type="text/css" href="css/Battle.css" /> 
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            font-size: 80pt;
            text-align: center;
            color: #FF0000;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style6 {
            color: #FFFFFF;
        }
        .auto-style12 {
            color: #FFFFFF;
        }
        .auto-style13 {
            font-size: xx-large;
        }
        .auto-style14 {
            color: #FFFFFF;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="background"><img src="images/background/FightBG.jpg" /></div> 
    <table id ="header">
            <tr>
                <td>
                    <img alt="logo" src="images/logo.png" /></td>
                <td><div id ="fight">Elemental Battle Arena</div></td>
            </tr>
    </table>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Image ID="imgTitan" runat="server" Height="382px" />
                    <asp:Image ID="imgElement" runat="server" Width="87px" />
                    <br />
                    <span class="auto-style12"><strong>YOUR TITAN</strong></span><br />
                    <span class="auto-style6"><strong>Titan&#39;s name:</strong></span><strong><asp:Label ID="lblTitan" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Level:</strong></span><strong><asp:Label ID="lblLevel" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Steps:</strong></span><strong><asp:Label ID="lblSteps" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Experience points:</strong></span><strong><asp:Label ID="lblExp" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Wins:</strong></span><strong><asp:Label ID="lblWins" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Loses:</strong></span><strong><asp:Label ID="lblLoses" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Player:</strong></span><strong><asp:Label ID="lblPlayer" runat="server" CssClass="auto-style6"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style3"><strong>You<br />
                    <asp:Label ID="lblRes" runat="server"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style2">
                    <asp:Image ID="imgElementEnemy" runat="server" Width="87px" />
                    <asp:Image ID="imgTitanEnemy" runat="server" Height="382px" />
                    <br />
                    <span class="auto-style6"><strong>RIVAL&#39;S</strong></span> <span class="auto-style6"><strong><span class="auto-style12">TITAN</span><br />
                    Titan&#39;s name:</strong></span><strong><asp:Label ID="lblTitanEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Level:</strong></span><strong><asp:Label ID="lblLevelEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Steps:</strong></span><strong><asp:Label ID="lblStepsEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Experience points:</strong></span><strong><asp:Label ID="lblExpEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Wins:</strong></span><strong><asp:Label ID="lblWinsEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Loses:</strong></span><strong><asp:Label ID="lblLosesEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    <br class="auto-style6" />
                    </strong>
                    <span class="auto-style6"><strong>Player:</strong></span><strong><asp:Label ID="lblPlayerEnemy" runat="server" CssClass="auto-style6"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="3">
                    <span class="auto-style14"><strong>Experience points obtained: </strong> </span>
                    <strong>
                    <asp:Label ID="lblExpObtained" runat="server" CssClass="auto-style14"></asp:Label>
                    <br class="auto-style13" />
                    <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/button/btnBackToMainPage.png" OnClick="btnBack_Click" />
                    </strong>
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
