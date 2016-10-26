<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ManageCharacter.aspx.cs" Inherits="BattlingElementalTitans.ManageCharacter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        h3 {text-align: center}
        .align {text-align: center}
        p {text-align: center}
        .auto-style18 {
            color: #FF9900;
        }
        .auto-style19 {
            font-size: xx-large;
        }
        .auto-style20 {
            color: #0000FF;
        }
        .auto-style21 {
            color: #0000FF;
            font-weight: bold;
        }
        .auto-style23 {
            width: 379px;
        }
        .auto-style24 {
            color: #0000FF;
            font-weight: bold;
            width: 274px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
        .auto-style26 {
            color: #000066;
            font-weight: bold;
            text-align: center;
        }
        .auto-style28 {
            margin-left: 0px;
            color: #0000FF;
        }
        .auto-style29 {
            font-size: medium;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="MainForm">
                <tr>
                    <td class="MainTitle">
                        <strong><span class="auto-style18"><span class="auto-style19">Manage Your Titans<br />
                        </span></span></strong>
                        <br />
                        <span class="auto-style29"><em>Once changes are saved, you will be redirected to Home</em></span><br />
                    </td>
                </tr>
                <tr>
                    <td>
                       
                        
                        <table border="1" style="width: 100%">
                            <tr>
                                <td colspan="3">
                                    <h3 class="auto-style18">Please Select A Titan</h3>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div class="align">
                                        &nbsp;<asp:DropDownList ID="dropTitan" runat="server" AutoPostBack="True" Width="364px" OnSelectedIndexChanged="dropTitan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="10" class="auto-style23">
                                    <div class="align">
                                        &nbsp;<asp:Image ID="imgTitan" runat="server" />
                                        <br />
                                    </div>
                                </td>
                                <td class="auto-style24">
                                    <h3 class="auto-style20">Titan Name:</h3>
                                </td>
                                <td>
                                    <p class="auto-style21">
                                        <asp:Label ID="lblTitan" runat="server"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style21" colspan="2">
                                    <div class="align">
                                        &nbsp;<asp:TextBox ID="tbxChangeName" runat="server" Width="298px" CssClass="auto-style20" ></asp:TextBox>
&nbsp;<br class="auto-style20" />
                                        <span class="auto-style20">&nbsp; </span>
                                        <asp:Button ID="btnChangeName" runat="server" CssClass="auto-style28" OnClick="btnChangeName_Click" Text="Change Name" Width="305px" />
                                        <span class="auto-style20">&nbsp;</span></div>
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
                                        <asp:Label ID="lblWins" runat="server"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style24">
                                    <h3 class="auto-style20">Losses:</h3>
                                </td>
                                <td>
                                    <p class="auto-style21">
                                        <asp:Label ID="lblLoses" runat="server"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26" colspan="2">
                                        <asp:Button ID="btnDelete" runat="server" CssClass="auto-style25" OnClick="btnDelete_Click" Text="Delete this Titan" Width="305px" />
                                </td>
                            </tr>
                        </table>
                       
                        
                    </td>
                </tr>
            </table>

</asp:Content>
