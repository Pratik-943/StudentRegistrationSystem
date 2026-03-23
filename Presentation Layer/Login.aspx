<%@ Page Title="Login"
    Language="C#"
    MasterPageFile="~/Presentation Layer/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="Lab_9.Presentation_Layer.Login" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container">

<h3>User Login</h3>

<table class="table">

<tr>
<td>Email</td>
<td>

<asp:TextBox ID="txtEmail"
    runat="server"

    CssClass="form-control" />

<asp:RequiredFieldValidator
    ID="rfvEmail"
    runat="server"
    ControlToValidate="txtEmail"
    ErrorMessage="Email Required"
    ForeColor="Red" />

</td>
</tr>

<tr>
<td>Password</td>
<td>

<asp:TextBox ID="txtPassword"
    runat="server"
    TextMode="Password"
    CssClass="form-control" />

<asp:RequiredFieldValidator
    ID="rfvPassword"
    runat="server"
    ControlToValidate="txtPassword"
    ErrorMessage="Password Required"
    ForeColor="Red" />

</td>
</tr>

<tr>
<td></td>
<td>

<asp:Button
    ID="btnLogin"
    runat="server"
    Text="Login"
    CssClass="btn btn-success"
    OnClick="btnLogin_Click" />

</td>
</tr>

</table>

</div>

</asp:Content>