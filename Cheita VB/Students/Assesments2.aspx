<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Assesments2.aspx.vb" Inherits="Cheita_VB.Students.Assesments2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Joses%20styles.css" rel="stylesheet" />

    <title>Assessments</title>
    <style>
        .wrapper1 {
    margin-top: 8vh;
    display: flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
    align-content: flex-end;
    align-items: center;
}



.access-btn1 {
    /*height: 45vh;*/
    min-height: 35vh;
    box-shadow: 2px 2px 6px grey;
    border-radius: 10px;
    border: none;
    width: 35%;
    min-width: 40vh;
    max-width: 55vh;
    margin: 0.8rem;
    color: #ffffff;
    font-size: 1.5rem;
    font-weight: bold;
    white-space: normal;
    word-wrap: break-word;
    display: flex;
    align-items: flex-end;
    align-content: flex-end;
    justify-content: flex-end;
    flex-wrap: wrap;
    background-repeat: no-repeat;
    background-position: center center;
    background-size: 100% 100%;
    padding: 0.8rem;
    text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
    transition: all 250ms;
}

    .access-btn1:hover {
        transform: scale(1.1);
        z-index: 1;
        transition: all 250ms;
    }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentWrapper" runat="server">  
    <div>
    <div class="wrapper1">
         <asp:Label ID="lblMock" runat="server" Text="Label" CssClass="topTitle">Assessments</asp:Label>
    </div>
    
    <div class="wrapper1">
        
    <asp:Button ID="btn3" runat="server" class="access-btn1" Text="Assessment 1" style="background-image: url('images/chietaImages/ass1.jpg')" OnClick=" btnAssess_Click"/>     
    <asp:Button ID="btn4" runat="server" class="access-btn1" Text="Assessment 2" style="background-image: url('images/chietaImages/ass2.jpg')" OnClick=" btnAssess2_Click"/>   
        <asp:Button ID="Button1" runat="server" class="access-btn1" Text="Assessment 3" style="background-image: url('images/chietaImages/ass3.jpg')" OnClick=" btnAssess3_Click"/>   

    </div>
   

    </div>
    <div id="loader" class="loader">
  <!-- Your SVG loader code goes here -->
        <svg xmlns="http://www.w3.org/2000/svg" height="200px" width="200px" viewBox="0 0 200 200" class="pencil">
	<defs>
		<clipPath id="pencil-eraser">
			<rect height="30" width="30" ry="5" rx="5"></rect>
		</clipPath>
	</defs>
	<circle transform="rotate(-113,100,100)" stroke-linecap="round" stroke-dashoffset="439.82" stroke-dasharray="439.82 439.82" stroke-width="2" stroke="currentColor" fill="none" r="70" class="pencil__stroke"></circle>
	<g transform="translate(100,100)" class="pencil__rotate">
		<g fill="none">
			<circle transform="rotate(-90)" stroke-dashoffset="402" stroke-dasharray="402.12 402.12" stroke-width="30" stroke="hsl(223,90%,50%)" r="64" class="pencil__body1"></circle>
			<circle transform="rotate(-90)" stroke-dashoffset="465" stroke-dasharray="464.96 464.96" stroke-width="10" stroke="hsl(223,90%,60%)" r="74" class="pencil__body2"></circle>
			<circle transform="rotate(-90)" stroke-dashoffset="339" stroke-dasharray="339.29 339.29" stroke-width="10" stroke="hsl(223,90%,40%)" r="54" class="pencil__body3"></circle>
		</g>
		<g transform="rotate(-90) translate(49,0)" class="pencil__eraser">
			<g class="pencil__eraser-skew">
				<rect height="30" width="30" ry="5" rx="5" fill="hsl(223,90%,70%)"></rect>
				<rect clip-path="url(#pencil-eraser)" height="30" width="5" fill="hsl(223,90%,60%)"></rect>
				<rect height="20" width="30" fill="hsl(223,10%,90%)"></rect>
				<rect height="20" width="15" fill="hsl(223,10%,70%)"></rect>
				<rect height="20" width="5" fill="hsl(223,10%,80%)"></rect>
				<rect height="2" width="30" y="6" fill="hsla(223,10%,10%,0.2)"></rect>
				<rect height="2" width="30" y="13" fill="hsla(223,10%,10%,0.2)"></rect>
			</g>
		</g>
		<g transform="rotate(-90) translate(49,-30)" class="pencil__point">
			<polygon points="15 0,30 30,0 30" fill="hsl(33,90%,70%)"></polygon>
			<polygon points="15 0,6 30,0 30" fill="hsl(33,90%,50%)"></polygon>
			<polygon points="15 0,20 10,10 10" fill="hsl(223,10%,10%)"></polygon>
		</g>
	</g>
</svg>
</div>

    <script>
        window.addEventListener('load', function () {
            var loader = document.getElementById('loader');
            loader.classList.add('show'); // Show the loader when the page finishes loading

            // Remove the 'show' class after a certain delay (e.g., 3 seconds)
            setTimeout(function () {
                loader.classList.remove('show');
            }, 500); // Adjust the delay as needed
        });
    </script>
   
</asp:Content>




