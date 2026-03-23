<%@ Page Title="Home"
    Language="C#"
    MasterPageFile="~/Presentation Layer/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="Lab_9.Presentation_Layer.Home" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container">

<h2>Home Page</h2>

<br />

<asp:Label
    ID="lblWelcome"
    runat="server"
    Font-Size="Large"
    Font-Bold="true"
    ForeColor="Blue">
</asp:Label>

<br /><br />

<p>
Welcome to the Student Registration System.
</p>

</div>

</asp:Content>