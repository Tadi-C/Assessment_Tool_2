<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="QueriesCategories.aspx.vb" Inherits="Cheita_VB.QueriesCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Select Query type</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">
   <div class="flex-col" style="margin-top: 6vh;">
   <div>
     <div class="qform-row">
        <div class="Qcol">  

            <h3 class="colTitle" style="color: #412151">What type of query do you have?</h3> 
            <asp:Button ID="MarkEnq"  class="categorybox" runat="server" Text="Mark enquiries" OnClick="MarkEnq_Click" />           
            <asp:Button ID="TechEnq"  class="categorybox" runat="server" Text="Technical enquiries" OnClick="TechEnq_Click" />           
            <asp:Button ID="GeneralEnq"  class="categorybox" runat="server" Text="General enquiries" OnClick="GeneralEnq_Click" />          
            
        </div>
 
    </div>
     <div style="margin-top:5vh">
          <asp:Button ID="PrevEnq"  class="categorybox" runat="server" Text="Previous enquiries" OnClick="PrevEnq_Click" /> 
       
     </div>
    <%--<div class="rowQ rowEnd">
        <asp:Button ID="backBtn" runat="server" Text="Back" class="btnQ"/> 
    </div>--%>
 </div>
 
</div> 
  <div>     
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
    </div>

</asp:Content>
