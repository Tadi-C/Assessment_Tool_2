<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="AssessmentAttempt.aspx.vb" Inherits="Cheita_VB.AssessmentAttempt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="css/vertical-layout-light/style1.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">

    <div class="wrapper flex-row col-12 align-items-start p-0" >
        <div class="wrapper flex-column col-3 m-0 p-0" style="min-width: 40vh;">
            
           <div class="smallcol">
            <div class="Heading">
       
                <a>Assessment 1</a>
            </div>

            <div class="TxTAssess-active">
                 <a href="#">Paper 1</a>
            </div>

            <div class="TxTAssess">
                <a href="#">Paper 2</a>
            </div>

            <div class="TxTAssess">
                <a href="#" >Paper 3</a>
            </div>

           </div>
        </div>

        <div class="wrapper m-0 flex-column col-8 bigCol b-line">
           <%-- <hr class="access-line"/>
            <%--<asp:Image ID="Img" runat="server" src="css/images/4.jpeg" CssClass="my-img"/>--%>
              

            <asp:Label ID="Txt" runat="server" Text="Paper 1" CssClass="Txt"></asp:Label>

            <asp:Label ID="Txt1" runat="server" Text="Attempts allowed: 3" CssClass="smallTxt"></asp:Label>
            <asp:Label ID="Txt2" runat="server" Text="Time limit: 180 Minutes" CssClass="smallTxt"></asp:Label>
            <asp:Label ID="Txt3" runat="server" Text="ELO 1 - 180 Minutes" CssClass="smallTxt"></asp:Label>
            <asp:Label ID="Txt4" runat="server" Text="Pass Mark: 60%" CssClass="smallTxt"></asp:Label>
            <asp:Label ID="Txt5" runat="server" Text="Question Type: Multiple Choice Questions" CssClass="smallTxt"></asp:Label>
            <asp:Label ID="Txt6" runat="server" Text="Grading method: Automatic" CssClass="smallTxt"></asp:Label>
    
           

        </div>
    </div>
    <div>
      
        <button ID="btnBegin" runat="server" Class="Backbtn" style="left:57%">Begin</button>
            </div>
       <div>
      
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
            </div>

</asp:Content>
