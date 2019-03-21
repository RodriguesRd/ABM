<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="edifactParse.aspx.cs" Inherits="ABM_TEST.edifactParse" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>  <asp:Button ID="BtnFindValueEdi" runat="server" OnClick="SendEdifact_Click" Text="Button" class="btn btn-primary btn-lg"/></p>
        <p>  <asp:TextBox   ID="TxtResult" runat="server" Height="500px" Width="1127px" TextMode="MultiLine" Text=""></asp:TextBox></p>
    
    </div>
     <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    

</asp:Content>
