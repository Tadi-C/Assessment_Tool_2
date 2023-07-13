<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="ViewResults.aspx.vb" Inherits="Cheita_VB.ViewResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/vertical-layout-light/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">
     
    <div class="wrapper flex-column align-items-start "> 
       <div class="col" style="margin-left:1vw">      
 
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="Heading" >View Results</asp:Label>
       
    </div>
        </div>
    <div class="wrapper justify-content-sm-evenly ">


    <%--Header--%>

   <%-- <asp:Label ID="lblMock" runat="server" Text="Label" CssClass="topTitle">View Results</asp:Label>--%>
    <div class="bigCol col-5 p-0" style="height:initial">
     <%--Image diplayed on the page--%>

        <asp:Image ID="Image1" runat="server" CssClass="imgVR"/>
    </div>
    <%--The VR text1--%>
    <div class="smallcol flex-row col-6" style="min-width: 45vh;">
      <div class="d-flex col-12 flex-column justify-content-between">

        <div class="d-flex flex-row justify-content-between borderbtm">
        <asp:Label ID="txt1VR" runat="server" Text="Assessment 1 Results" CssClass="txtVR"></asp:Label>

        <%--The VR text1--%>

        <asp:Label ID="txtVR2" runat="server" Text="Highest Attempt" CssClass="txtVR"></asp:Label>
       </div>
         <%--The Paper 1, 2, 3 link button--%>
        <div class="d-flex flex-row justify-content-between borderbtm">
        <div class="d-flex flex-column">
        <asp:LinkButton ID="linkbp1" runat="server" CssClass="linkbP">Paper 1</asp:LinkButton>

        <asp:LinkButton ID="linkbp2" runat="server" CssClass="linkbP">Paper 2</asp:LinkButton>

        <asp:LinkButton ID="linkbp3" runat="server" CssClass="linkbP">Paper 3</asp:LinkButton>
         </div >
          <div class="d-flex flex-column">
   
         <%--The Paper 1, 2, 3 percentages--%>

         <asp:Label ID="txtMarkp1" runat="server" Text="Paper 1" CssClass="markP bg-good ">61%</asp:Label>

        <asp:Label ID="txtMarkp2" runat="server" Text="Paper 2" CssClass="markP bg-pass">77%</asp:Label>

        <asp:Label ID="txtMarkp3" runat="server" Text="Paper 3" CssClass="markP bg-fail">30%</asp:Label>
          </div>
          </div>
          <%--The VR text2--%>

        <div class="d-flex flex-row justify-content-between borderbtm">
        <asp:Label ID="Label2" runat="server" Text="Assessment 2 Results" CssClass="txtVR"></asp:Label>

        <asp:Label ID="Label3" runat="server" Text="Highest Attempt" CssClass="txtVR"></asp:Label>
       </div>
        <asp:Label ID="txtDefault" runat="server" Text="No results available" CssClass="defaultVR"></asp:Label>
    


   

    </div> 
        </div>
    

    <%--The Paper 1, 2, 3 percentages--%>

    <%--  The back button.--%>
    
    
</div>
 <div>     
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
    </div>

</asp:Content>