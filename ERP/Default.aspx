<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ERP._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>Full Name: </td>
            <td><asp:TextBox ID="txtEmpFullNm" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nick Name: </td>
            <td><asp:TextBox ID="txtEmpNickName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Designation: </td>
            <td><asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
    <asp:HiddenField ID="hf_emp_gid" runat="server" />
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="gvEmpInfo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="emp_fullnm" HeaderText="Full Name" />
            <asp:BoundField DataField="emp_nicknm" HeaderText="Nick Name" />
            <asp:BoundField DataField="emp_designation" HeaderText="Designation" />
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CausesValidation="false" RowIndex ='<%# Container.DisplayIndex %>'>
                        <img style="border:none;" src="Images/edit_icon.gif" />
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" Text="Delete" runat="server" CausesValidation="false" RowIndex ='<%# Container.DisplayIndex %>'>
                        <img style="border:none;" src="Images/icon_remove.png" />
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
</asp:Content>
