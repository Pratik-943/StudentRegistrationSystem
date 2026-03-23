<%@ Page Title="Student Registration"
    Language="C#"
    MasterPageFile="~/Presentation Layer/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StudentRegistration.aspx.cs"
    Inherits="Lab_9.Presentation_Layer.StudentRegistration" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container">

<h3>Student Registration</h3>

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
<td>Phone</td>
<td>

<asp:TextBox ID="txtPhone"
    runat="server"
    CssClass="form-control" />

<asp:RegularExpressionValidator
    ID="revPhone"
    runat="server"
    ControlToValidate="txtPhone"
    ValidationExpression="^[0-9]{10}$"
    ErrorMessage="Enter 10 digit phone"
    ForeColor="Red" />

</td>
</tr>

<tr>
<td>Email</td>
<td>

<asp:TextBox ID="txtEmail"
    runat="server"
    CssClass="form-control" />

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
<td>Address</td>
<td>

<asp:TextBox ID="txtAddress"
    runat="server"
    TextMode="MultiLine"
    CssClass="form-control" />

<asp:RequiredFieldValidator
    ID="rfvAddress"
    runat="server"
    ControlToValidate="txtAddress"
    ErrorMessage="Address Required"
    ForeColor="Red" />

</td>
</tr>

<tr>
<td>Gender</td>
<td>

<asp:RadioButtonList
    ID="rblGender"
    runat="server">

<asp:ListItem Text="Male" Value="Male"/>
<asp:ListItem Text="Female" Value="Female"/>

</asp:RadioButtonList>

</td>
</tr>

<tr>
<td>Language</td>
<td>

<asp:CheckBoxList
    ID="cblLanguage"
    runat="server">

<asp:ListItem>English</asp:ListItem>
<asp:ListItem>Hindi</asp:ListItem>
<asp:ListItem>Tamil</asp:ListItem>

</asp:CheckBoxList>

</td>
</tr>

<tr>
<td>State</td>
<td>

<asp:DropDownList
    ID="ddlState"
    runat="server"
    CssClass="form-control"
    AutoPostBack="true"
    OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
</asp:DropDownList>

</td>
</tr>

<tr>
<td>City</td>
<td>

<asp:DropDownList
    ID="ddlCity"
    runat="server"
    CssClass="form-control">
</asp:DropDownList>

</td>
</tr>

<tr>
<td>Photo</td>
<td>

<asp:FileUpload
    ID="fuPhoto"
    runat="server" />

</td>
</tr>

<tr>
<td></td>
<td>

<asp:HiddenField
    ID="hfStudentId"
    runat="server" />

<asp:Button
    ID="btnSave"
    runat="server"
    Text="Save"
    CssClass="btn btn-primary"
    OnClick="btnSave_Click" />

<asp:Button
    ID="btnCancel"
    runat="server"
    Text="Cancel"
    CssClass="btn btn-secondary ms-2"
    OnClick="btnCancel_Click"
    Visible="false"
    CausesValidation="false" />

</td>
</tr>

</table>

<hr />

<h4>Student List</h4>

<asp:GridView
    ID="gvStudent"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table table-bordered"
    DataKeyNames="StudentId"
    OnRowCommand="gvStudent_RowCommand">

<Columns>

<asp:BoundField
    DataField="StudentId"
    HeaderText="ID" />

<asp:BoundField
    DataField="Name"
    HeaderText="Name" />

<asp:BoundField
    DataField="Email"
    HeaderText="Email" />

<asp:BoundField
    DataField="Phone"
    HeaderText="Phone" />

<asp:TemplateField HeaderText="Action">

<ItemTemplate>

<asp:Button
    ID="btnEdit"
    runat="server"
    Text="Edit"
    CommandName="EditRecord"
    CommandArgument='<%# Eval("StudentId") %>'
    CssClass="btn btn-warning btn-sm"
    CausesValidation="false" />

<asp:Button
    ID="btnDelete"
    runat="server"
    Text="Delete"
    CommandName="DeleteRecord"
    CommandArgument='<%# Eval("StudentId") %>'
    CssClass="btn btn-danger btn-sm"
    OnClientClick="return confirmDelete();"
    CausesValidation="false" />

</ItemTemplate>

</asp:TemplateField>

</Columns>

</asp:GridView>

</div>

</asp:Content>