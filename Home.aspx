<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="masterPage.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>How to use this site:</h1>
    <hr />
    

    <div class="container">
        <div class="row">
            <div class="col-4">
                <div class="text-center">
                    <img src="App_Themes/image/spaHomeIMG.jpg" style="width:30%" class="img-rounded"/>
                </div>
            </div>
        </div>
    </div>
    <h3>Introduction:</h3>
    <p>This is the massage and spa internal appointment site for our membership. Members can reserve their appointment and services according to their membership status.</p>
    <p>Bronze members can enjoy free services for maximum <strong>3</strong> hours and not more than  <strong>2</strong> services.</p>
    <p>Gold members can enjoy free services for maximum  <strong>4</strong> hours and not more than  <strong>3 </strong>services.</p>
    <p>Platinum members can enjoy free services for maximum <strong> 5</strong> hours and not more than  <strong>4 </strong>services.</p>

    
</asp:Content>
