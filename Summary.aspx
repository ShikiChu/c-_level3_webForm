<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="masterPage.Content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Summary:
    </h1>
    <hr />
    <asp:Table ID="tblSummary" runat="server" CssClass="table table-hover">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Appointment with</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Number Of Service</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Total Hours</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
</asp:Content>
