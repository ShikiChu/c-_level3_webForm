<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="masterPage.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Appointment:</h1>
    <hr />
    <div>
         <asp:Label ID="step1" runat="server" Text="Step 1:" Font-Size ="Medium" Font-Bold="true"></asp:Label>
        <br />
        <br />
        <label for="txtName" >Name: </label>
        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            Display="Dynamic" EnableClientScript="true" ErrorMessage="Name is Required!"  ForeColor="red">

        </asp:RequiredFieldValidator>
    </div>
    <br />
     <div>
        <label for="RblMembership" >Massage Therapist Preference: </label>
        <br />
        <asp:RequiredFieldValidator ID="rfvRadioButton" runat="server" ControlToValidate="rblPreference" 
            Display="Dynamic" EnableClientScript="true"  ErrorMessage="Select member's preference!"  
            ForeColor="red">
        </asp:RequiredFieldValidator>
        <br />
        <asp:RadioButtonList ID="rblPreference" runat="server" RepeatDirection="Vertical">
            <asp:ListItem Value="None">None</asp:ListItem>
            <asp:ListItem Value="Jasper White">Jasper White</asp:ListItem>
            <asp:ListItem Value="Tom Jackso">Tom Jackson</asp:ListItem>
            <asp:ListItem Value="Luffy Haha">Luffy Haha</asp:ListItem>
            <asp:ListItem Value="Christina Brown">Christina Brown</asp:ListItem>
            <asp:ListItem Value="Houston">Houston</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
    <div >
        <label for="drpMembership" >Membership: </label>
        <asp:DropDownList ID="drpMembership" runat="server" CssClass="btn btn-default dropdown-toggle" >
            <asp:ListItem Value="-1" Text="Select a membership"></asp:ListItem>
            <asp:ListItem Value="platinum" Text="Platinum Member"></asp:ListItem>
            <asp:ListItem Value="gold" Text="Gold Member"></asp:ListItem>
            <asp:ListItem Value="bronze" Text="Bronze Member"></asp:ListItem>
         </asp:DropDownList>
        
        <asp:RequiredFieldValidator ID="rfvMembership" runat="server" ControlToValidate="drpMembership" 
            Display="Dynamic" EnableClientScript="true" InitialValue="-1" ErrorMessage="Must select a membership!"  
            ForeColor="red">
        </asp:RequiredFieldValidator>
    </div>
    <br />
    <asp:Button ID="BtnNext" runat="server" Text="Next" OnClick="BtnNext_Click" class="btn btn-default" />

    <div>
        <br />
        <asp:Label ID="step2" runat="server" Text="Step 2:" Visible ="false" Font-Size ="Medium" Font-Bold="true"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbldrpMember" runat="server" Visible="false" Text="Select a member:"></asp:Label>
        <asp:DropDownList ID="drpMember" runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="drpMember_SelectedIndexChanged" CssClass="btn btn-default dropdown-toggle" >
            <asp:ListItem Value="-1" Text="Select ..."></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvDrpMember" runat="server" ControlToValidate="drpMember" 
            Display="Dynamic" EnableClientScript="true" InitialValue="-1" ErrorMessage="Must select a member!"  
            ForeColor="red"></asp:RequiredFieldValidator>

    </div>
    <br />
    <asp:label ID="lblCheckListError" runat="server" Text="You need to select at least one service for the appointment" Visible="false"  ForeColor="red"></asp:label>
    <div>
        <asp:CheckBoxList ID="checkList" runat="server" ></asp:CheckBoxList>
    </div>
    <br />
    <asp:Label ID="lblSummary" runat="server" Visible="false" Font-Bold="true" ForeColor="SlateGray"></asp:Label><br />
    <br />
    <asp:Button ID="BtnSave" runat="server" Text="Save" Visible="false" OnClick="btnSave_Click" class="btn btn-default"/>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    


</asp:Content>
