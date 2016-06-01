<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ManageExercisePoints.aspx.cs" Inherits="BattlingElementalTitans.ManageExercisePoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style18 {
            text-align: center;
            font-size: large;
        }
        .align {text-align: center}
        p {text-align: center}
        h3 {text-align: center}
        h1 {text-align: center}
        .auto-style20 {
            font-weight: bold;
            color: #000066;
        }
        .auto-style21 {
            color: #FF9900;
        }
        .auto-style22 {
            text-align: center;
            font-size: xx-large;
            font-family: Arial;
        }
        .auto-style23 {
            color: #000066;
        }
        .auto-style24 {
            width: 360px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <table class="MainForm" >
                <tr>
                    <td class="auto-style22">
                        <span class="auto-style21"><strong>
                        Manage Your Exercise Points</strong></span><br />
                        <br />
                    </td>
                </tr>
                </table>
              <table class="MainForm"  border="1">
                <tr>
                    <td class="auto-style18">
                        <strong><span class="auto-style21">&nbsp;Exercise points balance:</span><br />
                        <asp:Label ID="lblExercisePoints" runat="server"></asp:Label>
                        <br />
                        <span class="auto-style21">Select a titan to add exercise points:</span><br />
                        <asp:DropDownList ID="dropTitan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropTitan_SelectedIndexChanged" Width="381px">
                        </asp:DropDownList>
                        </strong>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                        <table border="1" style="width:100%">
                            <tr>
                                <td rowspan="6" class="auto-style24">
                                    <div class="align">
                                        &nbsp;<asp:Image ID="imgTitan" runat="server" />
                                    </div>
                                </td>
                                <td class="auto-style20">
                                    <p class="auto-style23">
                                        Character Name:</p>
                                </td>
                                <td>
                                    <p class="auto-style20">
                        <strong>
                        <asp:Label ID="lblTitan" runat="server"></asp:Label>
                        </strong>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <p class="auto-style23">
                                        Level:</p>
                                </td>
                                <td>
                                    <p class="auto-style20">
                        <strong>
                        <asp:Label ID="lblLevel" runat="server"></asp:Label>
                        </strong>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <p class="auto-style23">
                                        Experience Steps:</p>
                                </td>
                                <td>
                                    <p class="auto-style20">
                        <strong>
                        <asp:Label ID="lblStep" runat="server"></asp:Label>
                        </strong>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <p class="auto-style23">
                                        Experience Points:</p>
                                </td>
                                <td>
                                    <p class="auto-style20">
                        <strong>
                        <asp:Label ID="lblExe" runat="server"></asp:Label>
                        </strong>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <h3 class="auto-style23">Enter the amount of points you would like to add to this titan</h3>
                                </td>
                                <td>
                                    <div class="align">
                                        <asp:TextBox ID="tbxAdd" runat="server" TextMode="Number" CssClass="auto-style20"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="align">
                                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="ADD" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
        </table>
</asp:Content>
