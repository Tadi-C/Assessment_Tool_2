<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="ViewQuery.aspx.vb" Inherits="Cheita_VB.ViewQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Query</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">
       
<div class="flex-col">
    <div class="rowQ" style="justify-content: space-evenly;">
        <h4 class="headertext">From Student: <span id="StudentNo" runat="server"> 232468435</span></h4>
        <h4 class="headertext" id="time" runat="server">At: 10/06/2023, 12:39 PM</h4>
        <h4 class="headertext">To: <span id="deptType"  runat="server">CHIETA Technical Department</span></h4>
    </div>     
   <div class="form-box">
        <div class="qform-row"><span class="lblText">Subject:</span><input name="ctl00$maincontentWrapper$txtSubjext" type="text" id="maincontentWrapper_txtSubjext" class="qtext-box"> </div>       
        <div class="qform-col">
            <span class="lblText">Question:</span>
            <asp:TextBox ID="txt_question" TextMode="MultiLine" Rows="4" Columns="50"  class="qtext-box" runat="server"></asp:TextBox>
        </div>
        <div class="qform-col">
             <div class="qform-row" style="justify-content:space-between; margin:0vh">
            <span class="lblText">ATTACHMENTS:</span><a href="#" class="lblText" style="font-size:1rem">Add Attachments</a>
                </div>
           <div class="scrollable-y" style="height: 33vh;">
            <table class="tableQ">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Type</th>
                  <th>Size</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>File 1</td>
                  <td>Text</td>
                  <td>10 KB</td>
                </tr>
                <tr>
                  <td>File 2</td>
                  <td>Image</td>
                  <td>2 MB</td>
                </tr>
                <tr>
                  <td>File 3</td>
                  <td>PDF</td>
                  <td>500 KB</td>
                </tr>
                   <tr>
                  <td>File 4</td>
                  <td>DOCX</td>
                  <td>500 KB</td>
                </tr> <tr>
                  <td>File 5</td>
                  <td>Image</td>
                  <td>2 MB</td>
                </tr> <tr>
                  <td>File 6</td>
                  <td>PDF</td>
                  <td>500 KB</td>
                </tr> <tr>
                  <td>File 7</td>
                  <td>PDF</td>
                  <td>500 KB</td>
                </tr>
              </tbody>
            </table>
           </div>
        </div>
       <div class="qform-col">
            <span class="lblText">Response:</span>
            <asp:TextBox ID="txt_response" TextMode="MultiLine" Rows="4" Columns="50"  class="qtext-box" runat="server"></asp:TextBox>
        </div>

       
   </div>
    <div class="rowQ rowEnd" style="margin: 0;">
        <asp:Button ID="backBtn" runat="server" Text="Send" class="btnQ"/> 
    </div>
</div>


</asp:Content>
