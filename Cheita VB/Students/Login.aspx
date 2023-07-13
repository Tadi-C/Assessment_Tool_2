<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Cheita_VB.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
   <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>    
    <!-- plugins:css -->
    <link rel="stylesheet" href="vendors/feather/feather.css"/>
    <link rel="stylesheet" href="vendors/ti-icons/css/themify-icons.css"/>
    <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css"/>
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <link rel="stylesheet" href="vendors/datatables.net-bs4/dataTables.bootstrap4.css"/>
    <link rel="stylesheet" href="vendors/ti-icons/css/themify-icons.css"/>
    <link rel="stylesheet" type="text/css" href="js/select.dataTables.min.css"/>
    <link rel="stylesheet" href="../../vendors/mdi/css/materialdesignicons.min.css"/>
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="css/vertical-layout-light/style.css"/>
    <link href="Students/css/vertical-layout-light/style.css" rel="stylesheet" />
    <link href="Students/NewStyles/StyleSheet1.css" rel="stylesheet" />
    <link href="css/vertical-layout-light/style1.css" rel="stylesheet" />
    <!-- endinject -->
    <link rel="shortcut icon" href="images/chieta-logo.png"/>
    <!--icons----->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        .login-form {
            max-width: 45vh;
           

        }
        body{
            background:#fff3f3
        }

        .login-form input[type="text"],
        .login-form input[type="password"], select {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
            background-color: #f8f8f8;
            color: #333;
            border-radius:10px;
        }
     
        .login-btn  {
            width: 100%;
            background-color: #411f51;
            color: #fff;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
        }

        

        .flexdiv {
            display: flex;
            flex-direction: column;
            align-content: flex-start;
            align-items: center;
            justify-content: center;
        }

       


    </style>
</head>
<body style="display: flex;" >
                 
    
                        
    <form id="form1" style="margin: 25vh auto;" runat="server">

        <div class="flexdiv">
            <div >
            <img src="images/logo1.png" />
        </div>
          <div  class="login-form">
             
             
                                      
        
        <div  class="login-form">
            
            
            <select class="" id="txtRole" runat="server" name="type" required="required" >                                      
                <option value="" disabled="disabled" selected="selected" class="text-muted" >Login type</option>
                <option value="1" >Admin</option>
                <option value="2" >Student</option>
                <option value="3" >Lecturer</option>
               <%-- <option value="4" >Tutor</option>
                <option value="5" >Moderater</option>--%>
             </select>

             <input type="text" id="txtUsername"  runat="server"  required="required" placeholder="Student/Staff ID"/>
            <input type="password" id="txtPwd"  runat="server"  required="required" placeholder="Password" />
            
                <asp:Button ID="loginBtn" class="login-btn" runat="server" Text="Log In" onclick="loginBtn_Click" />
               
             </div>
            
      </div>
          <a href="#" class="link">Forgot password?</a>
            <asp:Label ID="lblError" runat="server" Text="error..."></asp:Label>
        </div>
    </form>
                       
           
</body>
</html>

