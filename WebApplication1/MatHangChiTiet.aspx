<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MatHangChiTiet.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p> 
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Giỏ hàng</asp:LinkButton>
    </p>
    <p> 
        <asp:Label ID="lbtest" runat="server" Text="Label"></asp:Label>
    </p>
    <asp:DataList ID="DataList2" runat="server">
        
        <ItemTemplate>
            
            <table class="auto-style1">
                <tr>
                    <td rowspan="4">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("hinh") %>' Height="30px" Width="30px" />
                    </td>
                    <td>Tên hàng</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Mô tả</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("mota") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Đơn giá</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Số lượng</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Mua" OnClick="Button1_Click" CommandArgument='<%# Eval("mahang") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
