<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="SelectRival.aspx.cs" Inherits="BattlingElementalTitans.SelectRival" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style19 {
            text-align: center;
            font-size: medium;
            font-family: Arial;
            height: 172px;
        }
        .auto-style18 {
            color: #FF9900;
            font-size: xx-large;
        }
        .newStyle1 {
            background-color: #FFFFFF;
        }
        .newStyle2 {
            font-family: Calibri;
        }
        .newStyle3 {
            font-family: Calibri;
            font-size: large;
            color: #FF9900;
        }
        .newStyle4 {
            font-family: Calibri;
            font-size: large;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainForm" >
                <tr>
                    <td class="auto-style19">
                        <span class="auto-style18"><strong>Select Your Rival<br />
                        </strong></span></td>
                </tr>
                </table>
    <table style="width:80%" align="center">
        <tr>
            <td class="align" colspan="6">
                <asp:GridView ID="gridViewRival" runat="server" Width="868px" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewRival_PageIndexChanging" OnRowCommand="gridViewRival_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField Text="Select" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <br />
                        <span class="newStyle3"><strong>Select your Titan</strong></span><strong><span class="auto-style18"><br />
                <asp:DropDownList ID="dropTitan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropTitan_SelectedIndexChanged" Width="365px">
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblRival" runat="server" CssClass="newStyle4" Text="Rival: Please select a rival titan"></asp:Label>
                <br />
                </span>
                        </strong>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/button/btnFight.png" OnClick="ImageButton1_Click" />
            </td>
        </tr>
    </table>
    </asp:Content>
