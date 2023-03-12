<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="VotingSytem.Web_Forms.CreateEmployee" MasterPageFile="~/Web_Forms/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div><h3>Add Employee</h3></div>
        <div>
         <%--   <div class="form-group mb-2">
                <asp:Label ID="idLabel" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="idTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="This Field is Required!" ControlToValidate="idTextbox" ForeColor="#FF6666"></asp:RequiredFieldValidator>
            </div>--%>
            
            <div class="form-group mb-2">
                <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="employeeNameTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="This Field is Required!" ControlToValidate="employeeNameTextbox" ForeColor="#FF6666"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <asp:Label ID="dateOfBirthLabel" runat="server" Text="Date of Birth"></asp:Label>
                <asp:TextBox ID="dateOfBirthTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="This Field is Required!" ControlToValidate="dateOfBirthTextbox" ForeColor="#FF6666"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group mb-2">
                <asp:Label ID="contactLabel" runat="server" Text="Contact"></asp:Label>
                <asp:TextBox ID="contactTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="This Field is Required!" ControlToValidate="contactTextbox" ForeColor="#FF6666"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group mb-2">
                <asp:Button ID="createEmployeeButton" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="CreateEmployeeBtn_Click"/>
            </div>
        </div>
</asp:Content>