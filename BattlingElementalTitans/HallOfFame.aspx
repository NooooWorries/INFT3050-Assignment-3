<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="HallOfFame.aspx.cs" Inherits="BattlingElementalTitans.HallOfFame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style18 {
            color: #FF9900;
            font-size: xx-large;
        }
        .auto-style19 {
            text-align: center;
            font-size: medium;
            font-family: Arial;
            height: 172px;
        }
        .newStyle1 {
            background-color: #FFFFFF;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainForm" >
                <tr>
                    <td class="auto-style19">
                        <span class="auto-style18"><strong>~ Hall Of Fame ~</strong></span><br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="align">
                        
                        <asp:GridView ID="gridViewHOF" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" AllowPaging="True" OnPageIndexChanging="gridViewHOF_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
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
                        
                    </td>
                </tr>
                </table>
</asp:Content>
