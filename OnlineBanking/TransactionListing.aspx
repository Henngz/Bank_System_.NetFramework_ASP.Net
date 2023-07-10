<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionListing.aspx.cs" Inherits="OnlineBanking.TransactionListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;<asp:Label ID="lblClientName" runat="server" Font-Bold="True"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAccountNumberValue" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblBalance" runat="server" Text="Balance:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblBalanceValue" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="gvTransationListing" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="DateCreated" DataFormatString="{0:d}" HeaderText="Date">
                <HeaderStyle Height="20px" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TransactionType.Description" HeaderText="Transaction Type">
                <HeaderStyle Height="20px" Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="Deposit" DataFormatString="{0:c2}" HeaderText="Amount In">
                <HeaderStyle Height="20px" Width="130px" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Withdrawal" DataFormatString="{0:c2}" HeaderText="Amount Out">
                <HeaderStyle Height="20px" Width="130px" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="Details">
                <HeaderStyle Height="20px" Width="400px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
        <asp:LinkButton ID="lbtnTransaction" runat="server" OnClick="lbtnTransaction_Click">Pay Bills and Transfer Funds</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnAccountListing" runat="server" OnClick="lbtnAccountListing_Click">Return to Bank Account Listing</asp:LinkButton>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="lblException" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
