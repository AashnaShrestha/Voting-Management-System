<%@ Page Title="EmployeeofTheMonth" Language="C#" AutoEventWireup="true" MasterPageFile="~/Web_Forms/Site.Master" CodeBehind="EmployeeofTheMonth.aspx.cs" Inherits="VotingSytem.Webforms.EmployeeofTheMonth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container ma-12">
        <div>
            <h2>Employee of The Month
            </h2>
        </div>
        <div style="display: flex; margin-bottom: 10px;">
            <asp:TextBox ID="yearTextbox" runat="server" CssClass="form-control" Width="287px" style="margin-right: 10px"></asp:TextBox>
            <asp:DropDownList ID="monthDropDown" runat="server" style="margin-right: 10px"></asp:DropDownList>
            <asp:Button ID="searchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBtn_Click" class="mr-8"/>
        </div>
        <div>
            <asp:GridView ID="EmployeeofTheMonthGV" runat="server" Width="1020px" CssClass="table" EmptyDataText="No Record Has Been Added!" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Vertical" DataKeyNames="CANDIDATE_ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="CANDIDATE_ID" HeaderText="Candidate Id" ReadOnly="True" SortExpression="CANDIDATE_ID" />
                    <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Employee" ReadOnly="True" SortExpression="EMPLOYEE_NAME" />
                    <asp:BoundField DataField="VOTES_COUNT" HeaderText="No. of Votes" ReadOnly="True" SortExpression="VOTES_COUNT" />
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
