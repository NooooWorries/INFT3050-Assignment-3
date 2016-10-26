<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BattlingElementalTitans.Main" %>
<%@ MasterType VirtualPath="~/Menu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 400px;
            height: 250px;
        }
        .auto-style18 {
            font-size: x-large;
        }
        .auto-style19 {
            width: 354px;
        }
        .auto-style20 {
            color: #000066;
            font-size: large;
        }
        .auto-style21 {
            color: #000066;
            font-weight: bold;
            font-size: large;
        }
        .auto-style22 {
            color: #FF9900;
        }
        .auto-style23 {
            color: #FF9900;
            font-size: xx-large;
            font-family: Arial;
        }
        .auto-style24 {
            color: #000066;
            font-weight: bold;
            font-size: large;
            width: 346px;
        }
        .auto-style25 {
            color: #FF9900;
            font-size: large;
            font-family: Arial;
        }
        .newStyle1 {
            font-family: calibri;
            font-size: medium;
        }
        .auto-style27 {
            color: #FF9900;
            font-family: calibri;
            font-size: large;
        }
    </style>
    <script>
        function hide() {
            popCheckTitans.hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" style="width: 80%" align="center">
        <tr>
            <td style="color: #996600">
                <h3 class="auto-style23">HOME&nbsp;</h3>
                <h3 class="auto-style25">Your Exercise Points Balance</h3>
            </td>
        </tr>
        <tr>
            <td class="align"><strong>
                <asp:Label ID="lblExercisePoints" runat="server" CssClass="auto-style18"></asp:Label>
                <br />
                <br />
                </strong></td>
        </tr>
    </table>

    <table border="1" style="width: 80%" align="center">
        <tr>
            <td colspan="3">
                <h3 class="auto-style27">Your Titan&#39;s Information</h3>
                <h3 class="auto-style22">
                    <asp:DropDownList ID="dropTitan" runat="server" OnSelectedIndexChanged="dropTitan_SelectedIndexChanged" Width="325px" AutoPostBack="True">
                    
                    </asp:DropDownList>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div class="align">
                    &nbsp;</div>
            </td>
        </tr>
        <tr>
            <td rowspan="8" class="auto-style19">
                <div class="align">
                    &nbsp;<asp:Image ID="imgTitan" runat="server" />
                </div>
            </td>
            <td class="auto-style24">
                <h3 class="auto-style20">Character Name:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Elemental Class:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblElement" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Level:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblLevel" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Step:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblStep" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Experience Points:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblExp" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Battles:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblBattle" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Wins:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblWin" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">
                <h3 class="auto-style20">Losses:</h3>
            </td>
            <td>
                <p class="auto-style21">
                                        <asp:Label ID="lblLose" runat="server"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
    </asp:Content>
