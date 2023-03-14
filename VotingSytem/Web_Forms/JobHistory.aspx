<%@ Page Title="JobHistory" Language="C#" AutoEventWireup="true" MasterPageFile="~/Web_Forms/Site.Master" CodeBehind="JobHistory.aspx.cs" Inherits="VotingSytem.Webforms.JobHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container ma-12">
        <div>
            <h2>JobHistory
            </h2>
        </div>
        <div style="display: flex; margin-bottom: 10px;">
            <asp:TextBox ID="searchTextbox" runat="server" CssClass="form-control" style="margin-right: 10px;"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBtn_Click" />
        </div>
        <div>
            <asp:GridView ID="JobHistoryGV" runat="server" Height="148px" Width="1020px" CssClass="table" EmptyDataText="No Record Has Been Added!" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" DataKeyNames="HISTORY_ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="HISTORY_ID" HeaderText="HISTORY_ID" ReadOnly="True" SortExpression="HISTORY_ID" />
                    <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="EMPLOYEE_NAME" SortExpression="EMPLOYEE_NAME" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="JOB_NAME" SortExpression="JOB_NAME" />
                    <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT_NAME" SortExpression="DEPARTMENT_NAME" />
                    <asp:BoundField DataField="START_DATE" HeaderText="START_DATE" SortExpression="START_DATE" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="END_DATE" HeaderText="END_DATE" SortExpression="END_DATE" DataFormatString="{0:dd-MM-yyyy}"/>
                    <asp:BoundField DataField="TIME_DIFFERENCE" HeaderText="Time Period (in Days)" SortExpression="TIME_DIFFERENCE" />
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
