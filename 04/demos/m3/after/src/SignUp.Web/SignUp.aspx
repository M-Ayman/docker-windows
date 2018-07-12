<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SignUp.Web.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>There's a webinar coming.</h1>
        <p class="lead">Here are my details. Sign me up.</p>
    </div>

    <div class="form-group row">
        <div class="col-md-6">
            <label for="txtFirstName">First Name</label>
            <asp:TextBox class="form-control" id="txtFirstName" runat="server"/>
        </div>
        <div class="col-md-6">
             <label for="ddlCountry">Country</label>
            <asp:DropDownList class="form-control" id="ddlCountry" runat="server"/>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-md-6">
            <label for="txtLastName">Last Name</label>
            <asp:TextBox class="form-control" id="txtLastName" runat="server"/>
        </div>          
        <div class="col-md-6">
            <label for="ddlRole">Your Main Role</label>
            <asp:DropDownList class="form-control" id="ddlRole" runat="server" />
        </div>
    </div>

    <div class="form-group row">
        <div class="col-md-6">
            <label for="txtEmail">Email Address</label>
            <asp:TextBox class="form-control" id="txtEmail" runat="server" />
        </div>
        <div class="col-md-6">
            <label for="interests">Your Interests</label>
            <fieldset class="form-group" id="interests">		    
                <div class="checkbox checkboxlist col-sm-9">
			        <asp:CheckBoxList ID="chkListInterests" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:CheckBoxList>
                </div>
	        </fieldset>
        </div>
    </div>   

    <asp:Button class="btn btn-lg" runat="server" Text="Go!" ID="btnGo" OnClick="btnGo_Click" />

</asp:Content>
