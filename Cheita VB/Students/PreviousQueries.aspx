<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Students/ChietaWebMaster.Master" CodeBehind="PreviousQueries.aspx.vb" Inherits="Cheita_VB.PreviousQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Previous Queries</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">
    <div class="rowQ" >
        <div class="searchbox">        
        <input type="search" class="search-input" id="search-input" placeholder="Search..">
        </div>
        <h3  style="color: #412151; font-size: 3.5vh; font-weight: 700; margin-left: 22vw;">Previous Queries</h3>
        <script>
                const searchInput = document.getElementById('search-input');
                const searchIcon = document.createElement('i');
                searchIcon.className = 'fa fa-search search-icon';

                searchInput.addEventListener('focus', () => {
                    searchIcon.classList.add('hide-icon');
                });

                searchInput.addEventListener('blur', () => {
                    searchIcon.classList.remove('hide-icon');
                });

                searchInput.parentNode.appendChild(searchIcon);
        </script>
    </div>
    <hr style="border: 1px solid #69696987;">
    <div class="rowQ" style="justify-content: space-between; margin:0">
        <h4 class="headertext lblText">Queries:</h4>
        <h4 class="headertext lblText">Total: <span id="totalQ" runat="server">6</span></h4> 
        </div>    
    <hr style="border: 1px solid #69696987;">
   <div class="scrollable">

    <table id="QuerisTable" class="tableQ">
              <thead>
                <tr>
                  <th>No.</th>
                  <th>Subject</th>
                  <th>Type</th>
                  <th>Date and Time</th>
                  <th>Attachments</th>
                  <th>Response</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1</td>
                  <td>Assessmet: Paper 1</td>
                  <td>Mark</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>1</td>
                  <td class="text-success">Answered</td>
                  <td> <input id="viewBtn1" type="button" value="View" class="btnQ" runat="server" onserverclick="viewBtn_ServerClick"/> </td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>Assessmet: Paper 3</td>
                  <td>General</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>0</td>
                  <td class="text-muted">None</td>
                  <td> <input id="viewBtn2" type="button" value="View" class="btnQ" runat="server" onserverclick="viewBtn_ServerClick" /> </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Submission not working</td>
                  <td>Technical</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>2</td>
                  <td class="text-success">Answered</td>
                  <td> <input id="viewBtn4" type="button" value="View" class="btnQ" runat="server" onserverclick="viewBtn_ServerClick" /> </td>
                </tr>
                <tr>
                  <td>4</td>
                  <td>Assessmet working</td>
                  <td>Technical</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>2</td>
                  <td class="text-muted">None</td>
                  <td> <input id="viewBtn41" type="button" value="View" class="btnQ" runat="server" onserverclick="viewBtn_ServerClick" /> </td>
                </tr>
                <tr>
                  <td>5</td>
                  <td>Confused</td>
                  <td>General</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>1</td>
                  <td class="text-muted">None</td>
                  <td> <input id="viewBtn5" type="button" value="View" class="btnQ" onserverclick="viewBtn_ServerClick" /> </td>
                </tr>
                <tr>
                  <td>6</td>
                  <td>Angry Student</td>
                  <td>Mark</td>
                  <td>10/06/2023, 12:39 PM</td>
                  <td>2</td>
                  <td class="text-muted">None</td>
                  <td> <input id="viewBtn6" type="button" value="View" class="btnQ" onserverclick="viewBtn_ServerClick" /> </td>
                </tr>

               
              </tbody>
            </table>
        </div>

     <div>
      
        <button ID="btnBack" runat="server" onserverclick="btnBack_ServerClick" Class="Backbtn">Back</button>
            </div>

</asp:Content>
