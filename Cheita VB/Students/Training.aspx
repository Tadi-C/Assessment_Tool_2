<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="Training.aspx.vb" Inherits="Cheita_VB.Training" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Training</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">

    <div style="margin-top:8vh" >
   <asp:Label ID="Heading" runat="server" style="margin-left:3vw" Text="Training" Cssclass="Heading "></asp:Label>
    <div class="wrapper flex-column col-12" >
        
        <div  class="watchbox col-6 d-flex">       
            <div id="player"></div>
        </div>


        
    </div>
</div>
   <div>     
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
    </div>
</asp:Content>
