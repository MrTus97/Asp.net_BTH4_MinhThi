<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MatHang.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p> DANH MỤC MẶT HÀNG</p>
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="2">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("mahang") %>' ImageUrl='<%# "~/Images/" +Eval("hinh") %>' OnClick="ImageButton1_Click" Height="30px" Width="30px" />
            </br>
            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("mahang") %>' OnClick="LinkButton2_Click" Text='<%# Eval("tenhang") %>'></asp:LinkButton>
            </br>
            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("mahang") %>' OnClick="LinkButton3_Click">Chi tiết</asp:LinkButton>
            </br>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
