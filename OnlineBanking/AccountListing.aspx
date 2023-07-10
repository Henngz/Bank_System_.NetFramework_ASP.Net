<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountListing.aspx.cs" Inherits="OnlineBanking.AccountListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblClientName" runat="server" Font-Bold="True">Label</asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <asp:GridView ID="gvAccount" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="22px" OnSelectedIndexChanged="gvAccount_SelectedIndexChanged" Width="524px">
        <Columns>
            <asp:BoundField DataField="AccountNumber" HeaderText="Account Number">
            <HeaderStyle Width="100px" Height="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Account Notes">
            <HeaderStyle Width="200px" Height="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Balance" DataFormatString="{0:c2}" HeaderText="Balance">
            <HeaderStyle Width="150px" Height="50px" />
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="lblErrorOrException" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
