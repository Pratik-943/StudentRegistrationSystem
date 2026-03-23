<%@ Page Title="Signup"
    Language="C#"
    MasterPageFile="~/Presentation Layer/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Signup.aspx.cs"
    Inherits="StudentRegistrationSystem.Presentation_Layer.Signup" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container">

<h3>User Signup</h3>

<table class="table">

<tr>
<td>Name</td>
<td>

<asp:TextBox ID="txtName"
    runat="server"
    CssClass="form-control" />

<asp:RequiredFieldValidator
    ID="rfvName"
    runat="server"
    ControlToValidate="txtName"
    ErrorMessage="Name Required"
    ForeColor="Red" />

</td>
</tr>

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

<asp:RegularExpressionValidator
    ID="revEmail"
    runat="server"
    ControlToValidate="txtEmail"
    ErrorMessage="Invalid Email"
    ForeColor="Red"
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

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
<td>Confirm Password</td>
<td>

<asp:TextBox ID="txtConfirmPassword"
    runat="server"
    TextMode="Password"
    CssClass="form-control" />

<asp:CompareValidator
    ID="cvPassword"
    runat="server"
    ControlToValidate="txtConfirmPassword"
    ControlToCompare="txtPassword"
    ErrorMessage="Passwords do not match"
    ForeColor="Red" />

</td>
</tr>

<tr>
<td></td>
<td>

<asp:Button
    ID="btnSignup"
    runat="server"
    Text="Signup"
    CssClass="btn btn-primary"
    OnClick="btnSignup_Click" />

</td>
</tr>

</table>

</div>

</asp:Content>