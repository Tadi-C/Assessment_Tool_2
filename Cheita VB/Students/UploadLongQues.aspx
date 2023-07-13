<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadLongQues.aspx.vb" Inherits="Cheita_VB.UploadLongQues" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link href="css/Joses%20styles.css" rel="stylesheet" />
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- plugins:css -->
    <link rel="stylesheet" href="vendors/feather/feather.css" />
    <link rel="stylesheet" href="vendors/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css" />
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <link rel="stylesheet" href="vendors/datatables.net-bs4/dataTables.bootstrap4.css" />
    <link rel="stylesheet" href="vendors/ti-icons/css/themify-icons.css">
    <link rel="stylesheet" type="text/css" href="js/select.dataTables.min.css" />
    <link rel="stylesheet" href="../../vendors/mdi/css/materialdesignicons.min.css" />
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="css/vertical-layout-light/style.css">
    <link href="Students/css/vertical-layout-light/style.css" rel="stylesheet" />
    <link href="Students/NewStyles/StyleSheet1.css" rel="stylesheet" />
    <!-- endinject -->
    <link rel="shortcut icon" href="images/favicon.png" />
    <style>
        .button1 {
            padding: 15px 25px;
            border: unset;
            border-radius: 15px;
            color: #212121;
            z-index: 1;
            background-color: darkgoldenrod;
            position: relative;
            font-weight: 1000;
            font-size: 17px;
            -webkit-box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
            box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
            transition: all 250ms;
            overflow: hidden;
        }

            .button1::before {
                content: "";
                position: absolute;
                top: 0;
                left: 0;
                height: 100%;
                width: 0;
                border-radius: 15px;
                background-color: #412151;
                z-index: -1;
                -webkit-box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
                box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
                transition: all 250ms;
            }

            .button1:hover {
                color: #e8e8e8;
            }

                .button1:hover::before {
                    width: 100%;
                }

        .card {
            display: flex;
            flex-direction: column;
            width: 45%;
            height: fit-content;
            border: 1px solid black;
            margin: 10px;
            padding: 10px;
            display: inline-block;
        }

        .question-header {
            font-weight: bold;
        }

        .question {
            font-size: 14px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .option {
            display: block;
        }

        .radio-button-group label {
            display: flex;
            margin-left: 1rem;
            align-items: center;
            margin-top: 0.5rem;
        }

        .ques_cont {
            display: flex;
            justify-content: flex-start;
            padding-top: 35px;
        }

        .cont {
            background-color: #F8F8F8;
            font-weight: 700;
            width: 100%;
           
          /*  display: flex;*/
            padding: 20px 20px;
            border-radius: 10px;
            justify-content: center;
            align-content: center;
            flex-wrap: wrap;
            flex-direction: column;
            height:fit-content;
        }

        .timer {
            position: absolute;
            border: unset;
            border-radius: 15px;
            font-weight: 1000;
            font-size: 17px;
            width: 95px;
            height: 32px;
            left: 90%;
            top: 10%;
            background: #412151;
            text-align: center;
            color: #FFFFFF;
        }

        /* Hide the default radio button */
        input[type="radio"] {
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            display: inline-block;
            width: 16px;
            height: 16px;
            border: 2px solid #ccc;
            border-radius: 50%;
            outline: none;
            cursor: pointer;
        }

            /* Style the custom radio button */
            input[type="radio"]:before {
                content: "";
                display: block;
                width: 10px;
                height: 10px;
                margin: 1.5px;
                border-radius: 50%;
                background-color: #fff;
            }

            /* Style the custom radio button when selected */
            input[type="radio"]:checked:before {
                background-color: #411f51;
            }

            /* Style the custom radio button on hover */
            input[type="radio"]:hover:before {
                background-color: #650c8f;
            }

        .loading-bar {
            margin-top: 20px;
            width: 60%;
            height: 20px;
            border: 1px solid #ccc;
            position: relative;
            border-radius: 20px 20px;
            border-color: white;
            background-color: #c2c2c2;
        }

        .progress {
            width: 1%;
            height: 100%;
            background-color: #411f51;
            position: absolute;
            top: 0;
            left: 0;
            background: repeating-linear-gradient(-45deg, #411f51 0 30px, #0000 0 40px) left/200% 100%;
            animation: i3 10s infinite linear;
            border-radius: 10px;
            border: 1px solid #766DF4;
        }

        @keyframes i3 {
            100% {
                background-position: right;
            }
        }

        /* Media Queries */

        /* Adjust styles for screens smaller than 768px */
        @media (max-width: 768px) {
            .card {
                width: 100%;
            }

            .cont {
                width: 100%;
            }
        }

        /* Adjust styles for screens smaller than 576px */
        @media (max-width: 576px) {
            .button1 {
                font-size: 14px;
            }

            .timer {
                font-size: 14px;
                width: 80px;
                height: 28px;
            }

            .loading-bar {
                width: 80%;
            }
        }

        nav {
            background-color: #f2f2f2;
        }

            nav ul {
                list-style-type: none;
                margin: 0;
                padding: 0;
                display: flex;
                justify-content: center;
            }

            nav li {
                display: inline;
                padding: 10px;
            }

            nav a {
                text-decoration: none;
                color: #333;
            }

        section {
            padding: 20px;
        }

        /loader/
        .pencil {
            display: block;
            width: 7em;
            height: 7em;
        }

        .pencil__body1,
        .pencil__body2,
        .pencil__body3,
        .pencil__eraser,
        .pencil__eraser-skew,
        .pencil__point,
        .pencil__rotate,
        .pencil__stroke {
            -webkit-animation-duration: 3s;
            animation-duration: 3s;
            -webkit-animation-timing-function: linear;
            animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            animation-iteration-count: infinite;
        }

        .pencil__body1,
        .pencil__body2,
        .pencil__body3 {
            -webkit-transform: rotate(-90deg);
            -ms-transform: rotate(-90deg);
            transform: rotate(-90deg);
        }

        .pencil__body1 {
            -webkit-animation-name: pencilBody1;
            animation-name: pencilBody1;
        }

        .pencil__body2 {
            -webkit-animation-name: pencilBody2;
            animation-name: pencilBody2;
        }

        .pencil__body3 {
            -webkit-animation-name: pencilBody3;
            animation-name: pencilBody3;
        }

        .pencil__eraser {
            -webkit-animation-name: pencilEraser;
            animation-name: pencilEraser;
            -webkit-transform: rotate(-90deg) translate(49px,0);
            -ms-transform: rotate(-90deg) translate(49px,0);
            transform: rotate(-90deg) translate(49px,0);
        }

        .pencil__eraser-skew {
            -webkit-animation-name: pencilEraserSkew;
            animation-name: pencilEraserSkew;
            -webkit-animation-timing-function: ease-in-out;
            animation-timing-function: ease-in-out;
        }

        .pencil__point {
            -webkit-animation-name: pencilPoint;
            animation-name: pencilPoint;
            -webkit-transform: rotate(-90deg) translate(49px,-30px);
            -ms-transform: rotate(-90deg) translate(49px,-30px);
            transform: rotate(-90deg) translate(49px,-30px);
        }

        .pencil__rotate {
            -webkit-animation-name: pencilRotate;
            animation-name: pencilRotate;
        }

        .pencil__stroke {
            -webkit-animation-name: pencilStroke;
            animation-name: pencilStroke;
            -webkit-transform: translate(100px,100px) rotate(-113deg);
            -ms-transform: translate(100px,100px) rotate(-113deg);
            transform: translate(100px,100px) rotate(-113deg);
        }

        /* Animations */
        @-webkit-keyframes pencilBody1 {
            from, to {
                stroke-dashoffset: 351.86;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 150.8;
                /* 3/8 of diameter */
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @keyframes pencilBody1 {
            from, to {
                stroke-dashoffset: 351.86;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 150.8;
                /* 3/8 of diameter */
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @-webkit-keyframes pencilBody2 {
            from, to {
                stroke-dashoffset: 406.84;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 174.36;
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @keyframes pencilBody2 {
            from, to {
                stroke-dashoffset: 406.84;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 174.36;
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @-webkit-keyframes pencilBody3 {
            from, to {
                stroke-dashoffset: 296.88;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 127.23;
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @keyframes pencilBody3 {
            from, to {
                stroke-dashoffset: 296.88;
                -webkit-transform: rotate(-90deg);
                transform: rotate(-90deg);
            }

            50% {
                stroke-dashoffset: 127.23;
                -webkit-transform: rotate(-225deg);
                transform: rotate(-225deg);
            }
        }

        @-webkit-keyframes pencilEraser {
            from, to {
                -webkit-transform: rotate(-45deg) translate(49px,0);
                transform: rotate(-45deg) translate(49px,0);
            }

            50% {
                -webkit-transform: rotate(0deg) translate(49px,0);
                transform: rotate(0deg) translate(49px,0);
            }
        }

        @keyframes pencilEraser {
            from, to {
                -webkit-transform: rotate(-45deg) translate(49px,0);
                transform: rotate(-45deg) translate(49px,0);
            }

            50% {
                -webkit-transform: rotate(0deg) translate(49px,0);
                transform: rotate(0deg) translate(49px,0);
            }
        }

        @-webkit-keyframes pencilEraserSkew {
            from, 32.5%, 67.5%, to {
                -webkit-transform: skewX(0);
                transform: skewX(0);
            }

            35%, 65% {
                -webkit-transform: skewX(-4deg);
                transform: skewX(-4deg);
            }

            37.5%, 62.5% {
                -webkit-transform: skewX(8deg);
                transform: skewX(8deg);
            }

            40%, 45%, 50%, 55%, 60% {
                -webkit-transform: skewX(-15deg);
                transform: skewX(-15deg);
            }

            42.5%, 47.5%, 52.5%, 57.5% {
                -webkit-transform: skewX(15deg);
                transform: skewX(15deg);
            }
        }

        @keyframes pencilEraserSkew {
            from, 32.5%, 67.5%, to {
                -webkit-transform: skewX(0);
                transform: skewX(0);
            }

            35%, 65% {
                -webkit-transform: skewX(-4deg);
                transform: skewX(-4deg);
            }

            37.5%, 62.5% {
                -webkit-transform: skewX(8deg);
                transform: skewX(8deg);
            }

            40%, 45%, 50%, 55%, 60% {
                -webkit-transform: skewX(-15deg);
                transform: skewX(-15deg);
            }

            42.5%, 47.5%, 52.5%, 57.5% {
                -webkit-transform: skewX(15deg);
                transform: skewX(15deg);
            }
        }

        @-webkit-keyframes pencilPoint {
            from, to {
                -webkit-transform: rotate(-90deg) translate(49px,-30px);
                transform: rotate(-90deg) translate(49px,-30px);
            }

            50% {
                -webkit-transform: rotate(-225deg) translate(49px,-30px);
                transform: rotate(-225deg) translate(49px,-30px);
            }
        }

        @keyframes pencilPoint {
            from, to {
                -webkit-transform: rotate(-90deg) translate(49px,-30px);
                transform: rotate(-90deg) translate(49px,-30px);
            }

            50% {
                -webkit-transform: rotate(-225deg) translate(49px,-30px);
                transform: rotate(-225deg) translate(49px,-30px);
            }
        }

        @-webkit-keyframes pencilRotate {
            from {
                -webkit-transform: translate(100px,100px) rotate(0);
                transform: translate(100px,100px) rotate(0);
            }

            to {
                -webkit-transform: translate(100px,100px) rotate(720deg);
                transform: translate(100px,100px) rotate(720deg);
            }
        }

        @keyframes pencilRotate {
            from {
                -webkit-transform: translate(100px,100px) rotate(0);
                transform: translate(100px,100px) rotate(0);
            }

            to {
                -webkit-transform: translate(100px,100px) rotate(720deg);
                transform: translate(100px,100px) rotate(720deg);
            }
        }

        @-webkit-keyframes pencilStroke {
            from {
                stroke-dashoffset: 439.82;
                -webkit-transform: translate(100px,100px) rotate(-113deg);
                transform: translate(100px,100px) rotate(-113deg);
            }

            50% {
                stroke-dashoffset: 164.93;
                -webkit-transform: translate(100px,100px) rotate(-113deg);
                transform: translate(100px,100px) rotate(-113deg);
            }

            75%, to {
                stroke-dashoffset: 439.82;
                -webkit-transform: translate(100px,100px) rotate(112deg);
                transform: translate(100px,100px) rotate(112deg);
            }
        }

        @keyframes pencilStroke {
            from {
                stroke-dashoffset: 439.82;
                -webkit-transform: translate(100px,100px) rotate(-113deg);
                transform: translate(100px,100px) rotate(-113deg);
            }

            50% {
                stroke-dashoffset: 164.93;
                -webkit-transform: translate(100px,100px) rotate(-113deg);
                transform: translate(100px,100px) rotate(-113deg);
            }

            75%, to {
                stroke-dashoffset: 439.82;
                -webkit-transform: translate(100px,100px) rotate(112deg);
                transform: translate(100px,100px) rotate(112deg);
            }
        }

        .loader {
            display: none; /* Hide the loader by default */
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(255, 255, 255, 0.8);
            /* Add a semi-transparent background */
            z-index: 9999;
        }

            .loader.show {
                display: flex; /* Show the loader when the 'show' class is added */
                justify-content: center;
                align-items: center;
            }



        .hover-gold {
            color: black; /* Default text color */
            transition: color 0.3s ease; /* Smooth transition effect */
        }

            .hover-gold:hover {
                color: darkgoldenrod; /* Text color on hover */
            }
    label{
        display:block;
    }
    .selected {
  background-color: rgba(184, 134, 11, 0.5);
    }
    .remove-button {
  background-color: red;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 4px;
  cursor: pointer;
}

.trash-icon {
  display: inline-block;
  width: 16px;
  height: 16px;
  background-image: url('chieta-imgs/trashcan.png');
  background-size: contain;
  background-repeat: no-repeat;
}
.button3 {
  border: none;
  outline: none;
  background-color: #ca1f1f;
  padding: 5px 8px;
  font-size: 12px;
  font-weight: 700;
  color: #fff;
  border-radius: 5px;
  -webkit-transition: all ease 0.1s;
  transition: all ease 0.1s;
  -webkit-box-shadow: 0px 5px 0px 0px #ff7474;
          box-shadow: 0px 5px 0px 0px #ff7474;
}

.button3:active {
  -webkit-transform: translateY(5px);
      -ms-transform: translateY(5px);
          transform: translateY(5px);
  -webkit-box-shadow: 0px 0px 0px 0px #ff7474;
          box-shadow: 0px 0px 0px 0px #ff7474;
}


    </style>



</head>
<body>
    <form runat="server">
        <div class="container-scroller">
            <!-- partial:partials/_navbar.html -->
            <nav class="navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
                <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">

                    <a class="navbar-brand brand-logo mr-5" href="index.html">
                        <img src="images/logo1.png" class="mr-2" alt="logo" /></a>
                    <a class="navbar-brand brand-logo-mini" href="index.html">
                        <img src="images/logo-mini.svg" alt="logo" /></a>
                </div>
                <div class="navbar-menu-wrapper d-flex align-items-center justify-content-end">
                    <button class="navbar-toggler navbar-toggler align-self-center" type="button" data-toggle="minimize">
                        <span class="icon-menu"></span>
                    </button>
                    <ul class="navbar-nav navbar-nav-right">
                        <li class="nav-item btn-border">
                            <button class="dropdown-item">
                                <i class="ti-power-off text-primary"></i>
                                Logout
                            </button>
                        </li>

                        <li class="nav-item nav-profile dropdown">
                            <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" id="profileDropdown">
                                <img src="images/faces/face28.jpg" alt="profile" />
                            </a>
                            <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="profileDropdown">
                                <a class="dropdown-item">
                                    <i class="ti-settings text-primary"></i>
                                    Settings
                                </a>
                                <a class="dropdown-item">
                                    <i class="ti-power-off text-primary"></i>
                                    Logout
                                </a>
                            </div>
                        </li>

                        <li style="width: 180px; height: 100%">
                            <div style="width: 100%; align-items: start; height: 100%; display: flex; justify-content: center; align-content: center; flex-direction: column; padding-left: 20px">
                                <label style="margin-bottom: 0px; font-weight: bold">9902286678087</label>
                                <label style="margin-bottom: 0px; text-align: left; font-weight: 500">Student</label>
                            </div>
                        </li>
                        <!--<li class="nav-item nav-settings d-none d-lg-flex">
                      <a class="nav-link" href="#">
                        <i class="icon-ellipsis"></i>
                      </a>
                    </li>-->

                    </ul>
                    <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="offcanvas">
                        <span class="icon-menu"></span>
                    </button>
                </div>
            </nav>
        </div>
        <!-- partial -->

        <!-- partial -->
        <div class="main-panel">
            <div class="content-wrapper">

              
                        <div style="padding-top: 7%; color: #412151;">
                            <h2>Upload Questions</h2>
                            <h4>Paper 1</h4>
                            <div style="display:flex;justify-content:center;">
                                <select style="border-radius:8px;width:30%;">
                                <option value="option1">Section A</option>
                                <option value="option2">Section B</option>
                                <option value="option3" selected>Section C</option>
                                <option value="option4">Section D</option>
                                </select>
                            </div>
                            
                        </div>
              
                <div style="display: flex;flex-direction: row; justify-content:space-between">

                    
<div class="ques_cont">

    <div class="cont" id="questionContainer">
        <div>
  <asp:TextBox TextMode="MultiLine" Rows="4" Wrap="true" style="border-color: black; width: 600px; height: 300px; margin-bottom: 5%; border-radius: 20px; padding: 10px; resize: none; text-align: left;" ID="Question" runat="server" placeholder="Enter your question here"></asp:TextBox>
</div>
        <div style="display:flex; justify-content:center;">
            <a class="button1" ID="Button1">Insert</a>
        </div>
    </div>
</div>
 
                
                <div class="ques_cont">

                        <div class="cont" id="questionContainer2">

                            <h3> Section C(Long Questions)</h3>
                                <div style="display:flex;justify-content:flex-end;margin-bottom:10px;">
                                <button class="button3">
                                 <span class="trash-icon"></span>
                                </button>
                            </div>
                            <label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label>                           
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label>                          
                            </label><label for="myCheckbox">
                            <input type="checkbox" id="myCheckbox"/>
                                    Text for Checkbox jhefgygvdshbwehewyuvfcfbsdhjcvwhcfbwevbcecfhvyweweyucvde
                            </label>
                           

                        </div>

                    </div>
                </div>


                
                

                        <div style="display: flex; justify-content: flex-end; padding: 25px 25px;">
                            <a class="button1" href="Section B.aspx">Next!
                            </a>

                        </div>
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
    // Get all the radio buttons
    var radioButtons = document.querySelectorAll('input[type="radio"][name="radioButtonGroup"]');

    // Add event listener to each radio button
    radioButtons.forEach(function (radioButton) {
        radioButton.addEventListener('change', function () {
            // Remove the 'selected' class from all div containers
            var divContainers = document.querySelectorAll('.cont > div');
            divContainers.forEach(function (divContainer) {
                divContainer.classList.remove('selected');
            });

            // Get the parent div of the radio button
            var radioButtonParent = this.parentNode;

            // Add the 'selected' class to the parent div of the radio button
            radioButtonParent.classList.add('selected');
        });
    });
</script>
                

                <script>
                    // Attach event listeners to radio buttons
                    var radioButtons = document.querySelectorAll('input[type="radio"]');
                    radioButtons.forEach(function (radioButton) {
                        radioButton.addEventListener('click', function () {
                            var selectedValue = this.value;
                            var groupName = this.getAttribute('name'); // Get the name attribute instead of data-group
                            sessionStorage.setItem(groupName, selectedValue);
                        });
                    });

                    // On page load, retrieve and set the previously selected values
                    function SetRadioButtonsFromSession() {
                        radioButtons.forEach(function (radioButton) {
                            var groupName = radioButton.getAttribute('name'); // Get the name attribute instead of data-group
                            var storedValue = sessionStorage.getItem(groupName);
                            if (storedValue && storedValue === radioButton.value) {
                                radioButton.checked = true;
                            }
                        });
                    }

                    SetRadioButtonsFromSession(); // Call the function to set the values on page load
                </script>





                <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
                <script>
                    $(document).ready(function () {
                        $('input[type="radio"]').click(function () {
                            var radioGroup = $(this).attr('name');
                            $('input[name="' + radioGroup + '"]').not(this).prop('checked', false);
                        });
                    });
                </script>



            </div>





            <!-- content-wrapper ends -->

        </div>
        <!-- main-panel ends -->
        </div>
            <!-- page-body-wrapper ends -->

        <!-- container-scroller -->
        <!-- plugins:js -->
        <script src="vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page -->
        <script src="vendors/chart.js/Chart.min.js"></script>
        <script src="vendors/datatables.net/jquery.dataTables.js"></script>
        <script src="vendors/datatables.net-bs4/dataTables.bootstrap4.js"></script>
        <script src="js/dataTables.select.min.js"></script>

        <!-- End plugin js for this page -->
        <!-- inject:js -->
        <script src="js/off-canvas.js"></script>
        <script src="js/hoverable-collapse.js"></script>
        <script src="js/template.js"></script>
        <script src="js/settings.js"></script>
        <script src="js/todolist.js"></script>
        <!-- endinject -->
        <!-- Custom js for this page-->
        <script src="js/dashboard.js"></script>
        <script src="js/Chart.roundedBarCharts.js"></script>
        <!-- End custom js for this page-->
    </form>
    <!-- partial:partials/_footer.html -->
    <footer style="background: #411f51" class="footer">
        <div style="display: flex; justify-content: center">
            <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">Premium  Tel: 087 357 6608 | 011 628 7000 | Anti-Fraud Line: 0800 333 120</span>

        </div>

    </footer>

</body>
</html>


