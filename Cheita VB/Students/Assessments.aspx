<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="Assessments.aspx.vb" Inherits="Cheita_VB.Assessments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Assessments</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">  
    <div>
    <div class="wrapper1">
         <asp:Label ID="lblMock" runat="server" Text="Label" CssClass="topTitle">Assessments</asp:Label>
    </div>
    
    <div class="wrapper1">
        
    <asp:Button ID="btn3" runat="server" class="access-btn1" Text="Assessment 1" style="background-image: url('chieta-imgs/glenn-carstens-peters-npxXWgQ33ZQ-unsplash.jpg')" OnClick=" btnAssess_Click"/>     
    <asp:Button ID="btn4" runat="server" class="access-btn1" Text="Assessment 2" style="background-image: url('chieta-imgs/christin-hume-hBuwVLcYTnA-unsplash.jpg')" OnClick=" btnAssess_Click"/>   
    
    </div>
    <div>     
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
    </div>

    </div>
   
   
</asp:Content>
