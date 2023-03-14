<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Web_Forms/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VotingSytem._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Dashboard</h3>
    </div>

    <div class="container" style="padding: 10px"></div>
    <div class="row">
        <div class="col-md-3">
            <div style="text-align: center; background-color:white; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2); transition: 0.3s;">
                <div style="padding: 2px 16px;">
                    <h2>Employees</h2>
                    <asp:Label ID="employeeLabel" runat="server" Style="font-size: 44px"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div style="text-align: center; background-color:white; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2); transition: 0.3s;">
                <div style="padding: 2px 16px;">
                    <h2>Departments</h2>
                    <asp:Label ID="departmentLabel" runat="server" Style="font-size: 44px"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div style="text-align: center; background-color:white; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2); transition: 0.3s;">
                <div style="padding: 2px 16px;">
                    <h2>Roles</h2>
                    <asp:Label ID="roleLabel" runat="server" Style="font-size: 44px"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div style="text-align: center; background-color:white; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2); transition: 0.3s;">
                <div style="padding: 2px 16px;">
                    <h2>Job</h2>
                    <asp:Label ID="jobLabel" runat="server" Style="font-size: 44px"></asp:Label>
                </div>
            </div>
        </div>

    </div>

    <br />

    <div class="row" style="align-content: center">
        <div class="col-md-12" style="text-align:center; background-color:white; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2); transition: 0.3s;">
            <div>
                <h3>Number of employees in each department</h3>
            </div>
            <div>
                <asp:Chart ID="dashboardChart" runat="server" Width="830px" DataSourceID="ChartDataSource">
                <Series>
                    <asp:Series ChartArea="ChartArea1" Name="Series1" XValueMember="DEPARTMENT_NAME" YValueMembers="No. of employees">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="ChartDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT d.department_name, COUNT(*) AS &quot;No. of employees&quot;
FROM department d
JOIN job_history jh ON d.department_id = jh.department_id
WHERE jh.end_date IS NULL
GROUP BY d.department_name"></asp:SqlDataSource>
            </div>
        </div>
    </div>


    <br />

</asp:Content>
