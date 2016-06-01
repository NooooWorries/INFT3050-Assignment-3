<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CreateCharacter.aspx.cs" Inherits="BattlingElementalTitans.CreateCharacter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        h1 {text-align: center}
        h3 {text-align: center}
        p {text-align: center}
        .align {text-align: center}
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
        }
        .auto-style9 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
            text-align: center;
        }
        .auto-style18 {
            text-align: center;
            font-size: xx-large;
            font-family: Arial;
            color: #FF9900;
        }
        .auto-style19 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
            text-align: center;
            color: #FF9900;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainForm">
        <tr>
            <td class="auto-style18"> <strong>Create A New Titan</strong></td>
        </tr>
        <tr>
            <td> 
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style19" colspan="4">
                            <br />
                            Step 1: Select an elemental class<br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="align">
                            <asp:ImageButton ID="btnAir" runat="server" ImageUrl="~/images/element/air.jpg" OnClick="btnAir_Click" />
                            <br />
                            Air</td>
                        <td class="align">
                            <asp:ImageButton ID="btnEarth" runat="server" ImageUrl="~/images/element/earth.jpg" OnClick="btnEarth_Click"  />
                            <br />
                            Earth</td>
                        <td class="align">
                            <asp:ImageButton ID="btnFire" runat="server" ImageUrl="~/images/element/fire.jpg" OnClick="btnFire_Click" />
                            <br />
                            Fire</td>
                        <td class="align">
                            <asp:ImageButton ID="btnWater" runat="server" ImageUrl="~/images/element/water.jpg" OnClick="btnWater_Click" />
                            <br />
                            Water</td>
                    </tr>
                    </table>
                <table style="width:100%">
                    <tr>
                        <td colspan="3" class="auto-style9">
                            <br />
                            <asp:Label ID="lblStepTwo" runat="server" Text="Step 2: Select a titan" Visible="False" style="color: #FF9900; font-weight: 700"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="align">
                            <asp:ImageButton ID="btnTitanOne" runat="server" Visible="False" OnClick="btnTitanOne_Click" Width="180px" />
                            <br />
                            <strong>
                            <asp:Label ID="lblCharacterNameOne" runat="server"></asp:Label>
                            </strong>
                        </td>
                        <td class="align">
                            <asp:ImageButton ID="btnTitanTwo" runat="server" Visible="False" OnClick="btnTitanTwo_Click" Width="180px" />
                            <br />
                            <strong>
                            <asp:Label ID="lblCharacterNameTwo" runat="server"></asp:Label>
                            </strong>
                        </td>
                        <td class="align">
                            <asp:ImageButton ID="btnTitanThree" runat="server" Visible="False" OnClick="btnTitanThree_Click" Width="180px" />
                            <br />
                            <strong>
                            <asp:Label ID="lblCharacterNameThree" runat="server"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table> 
    <table class="MainForm">
        <tr>
            <td class="auto-style9">
                <asp:Label ID="lblChoice" runat="server" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblStepThree" runat="server" Text="Step 3: Give a name" Visible="False" style="color: #FF9900; font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="align">
                <asp:TextBox ID="tbxName" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="align">
                <asp:ImageButton ID="btnCreate" runat="server" Visible="False" ImageUrl="~/images/button/btnCreate.png" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
