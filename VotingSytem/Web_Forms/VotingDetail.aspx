<%@ Page Title="VotingDetail" Language="C#" AutoEventWireup="true" MasterPageFile="~/Web_Forms/Site.Master" CodeBehind="VotingDetail.aspx.cs" Inherits="VotingSytem.Webforms.VotingDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container ma-12">
        <div>
            <h2>VotingDetail
            </h2>
        </div>
        <div style="display: flex; margin-bottom: 10px;">
            <asp:TextBox ID="searchTextbox" runat="server" CssClass="form-control" style="margin-right: 10px;"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBtn_Click" />
        </div>
        <div>
            <asp:GridView ID="VotingDetailGV" runat="server" Height="148px" Width="1020px" CssClass="table" EmptyDataText="No Record Has Been Added!" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" DataKeyNames="VOTER_ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="VOTER_ID" HeaderText="VOTER_ID" ReadOnly="True" SortExpression="VOTER_ID" />
                    <asp:BoundField DataField="VOTER_NAME" HeaderText="VOTER_NAME" SortExpression="VOTER_NAME" />
                    <asp:BoundField DataField="VOTING_YEAR" HeaderText="VOTING_YEAR" SortExpression="VOTING_YEAR" />
                    <asp:BoundField DataField="VOTING_MONTH" HeaderText="VOTING_MONTH" SortExpression="VOTING_MONTH" />
                    <asp:BoundField DataField="CANDIDATE_ID" HeaderText="CANDIDATE_ID" SortExpression="CANDIDATE_ID" />
                    <asp:BoundField DataField="CANDIDATE_NAME" HeaderText="CANDIDATE_NAME" SortExpression="CANDIDATE_NAME" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#f7f7f7" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

        </div>
    </div>
</asp:Content>
