<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTransaction.aspx.cs" Inherits="OnlineBanking.CreateTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAccountNumberValue" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblBalance" runat="server" Text="Balance:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblBalanceValue" runat="server" Text="Label"></asp:Label>
    </p>
    <p id="ddlTransactionType">
        <asp:Label ID="lblTransactionType" runat="server" Text="Transaction Type:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlTransactionType" runat="server" Width="120px" AutoPostBack="True" DataTextField="Description" DataValueField="TransactionTypeId" OnSelectedIndexChanged="ddlTransactionType_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblAmount" runat="server" Text="Amount:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAmountValue" runat="server" style="text-align: right"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmountValue" ErrorMessage="Amount is required." Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAmountValue" ErrorMessage="RangeValidator" MaximumValue="10000" MinimumValue="0.01" Type="Double" Display="Dynamic">The amount entered in must be a numeric value between 0.01 and 10,000.00.</asp:RangeValidator>
    </p>
    <p id="ddlCompanyName">
        <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlpayee" runat="server" Width="200px" DataTextField="Description" DataValueField="PayeeId" OnSelectedIndexChanged="ddlpayee_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:LinkButton ID="lbtnCompleteTransaction" runat="server" OnClick="lbtnCompleteTransaction_Click">Complete Transaction</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnReturntoBankAccountListing" runat="server" CausesValidation="False" OnClick="lbtnReturntoBankAccountListing_Click">Return to Bank Account Listing</asp:LinkButton>
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
</asp:Content>
