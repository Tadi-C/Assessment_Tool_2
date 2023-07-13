<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="LandingPage.aspx.vb" Inherits="Cheita_VB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="css/vertical-layout-light/style1.css"/>
    <title>Landing page</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">

<div class="wrapper"> 
    <asp:Button ID="btn3" runat="server" class="access-btn" Text="Mock Assessment" style="background-image: url('chieta-imgs/MockImg.png')" OnClick="btnMocas" />     
    <asp:Button ID="btn4" runat="server" class="access-btn" Text="Assessments" style="background-image: url('chieta-imgs/AssessmentImg.png')" OnClick="btnAss"/>     
    <asp:Button ID="btn5" runat="server" class="access-btn" Text="View Results" style="background-image: url('chieta-imgs/view-results.png')"  OnClick="btnRes"/>
    <asp:Button ID="btn1" runat="server" class="access-btn" Text="Query" style="background-image: url('chieta-imgs/query.jpg')"  OnClick="btnQuery"/>   
    <asp:Button ID="btn2" runat="server" class="access-btn" Text="Training" style="background-image: url('chieta-imgs/training.png')" OnClick="btnTrain"/>        
</div>
    
</asp:Content>
