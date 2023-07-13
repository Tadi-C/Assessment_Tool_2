<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="MockAs.aspx.vb" Inherits="Cheita_VB.MockAs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/vertical-layout-light/style.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">
    <div class="wrapper flex-column align-items-start "> 
      
       <div class="col" style="margin-left:1vw">      
            <asp:Label ID="lblMock" runat="server" Text="Label" CssClass="Heading" >Mock Assessment</asp:Label>
        <div id="lblEx" class="headertext text-black boldtext">An examination that is taken as practice before and actual official examination.</div>
    </div>

        <%--Button and text inside for Assessment 1--%>
    <div class="col-12 d-flex flex-row flex-wrap p-0 wrapper">
        <asp:Button ID="btnMA1" runat="server" CssClass="access-btn1" style="background-image: url(chieta-imgs/group.jpg);" Text="Mock Assessment 1" OnClick="btnMA1_Click" />       
        <asp:Button ID="btnMA3" runat="server" CssClass="access-btn1" style="background-image: url(chieta-imgs/statslaptop.jpg);" Text="Mock Assessment 2" OnClick="btnMA3_Click" />
        <%--<asp:Button ID="btnTrn" runat="server" CssClass="access-btn" style="background-image: url(chieta-imgs/estee-janssens-RARH8b7N-fw-unsplash.jpg);" Text=" Training" OnClick="btnTrn_Click" />--%>
        <%--  Button and text inside for Assessment 2--%>
    
        <%-- <asp:Button ID="btnMA2" runat="server" CssClass="MA2btn" />
        <asp:Label ID="lblMA2" runat="server" Text="Mock Assessment 2" CssClass="MA2lbl" ></asp:Label>--%>
        <%--  The back button.--%>    
   </div>
         
   </div>
     <div>     
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
    </div>

</asp:Content>
