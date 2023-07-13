Imports System.Security.Cryptography

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.Visible = False
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("../Students/LandingPage.aspx")
    End Sub

    Protected Sub loginBtn_Click(sender As Object, e As EventArgs)
        'If IsNothing(Session("conn")) Then
        '    Session("conn") = DBInterface.connect("REPLACE ME")
        'End If

        Dim email, plain_pwd, dePwd As String
        email = txtUsername.Value
        plain_pwd = txtPwd.Value
        dePwd = ComputeSHA1Hash(txtPwd.Value)
        'to be removed
        Session("username") = email
        'Session("role") = txtRole.Value


        ''checking if user exist
        'Dim user_inst As New Tbl_User
        'user_inst = user_inst.load(email)

        'If Not user_inst Is Nothing Then
        '    plain_pwd = CipherGate.DecryptString(user_inst.CUSTOMER_PASSWORD, "blu39")
        '    'user exist, checking password..
        '    If user_inst.CUSTOMER_PASSWORD = dePwd Then
        '        Session("username") = user_inst.User_FNAME & ", " & user_inst.User_LNAME
        '        Session("email") = user_inst.User_EMAIL
        '        Session("role") = user_inst.User_RoleName


        '        lblError.Visible = True
        '        lblError.ForeColor = Color.Green
        '        lblError.Text = "You have successfully logged in."


        '        Response.Redirect("../Students/LandingPage.aspx")

        '    Else
        '        lblError.Visible = True
        '        lblError.ForeColor = Color.Red
        '        lblError.Text = "Login Failed. Please check your username and password."
        '        Session.Clear()
        '    End If
        'Else
        '    lblError.Visible = True
        '    lblError.ForeColor = Color.Red
        '    lblError.Text = "Login Failed. Incorrect username or password."

        'End If
        Response.Redirect("../Students/LandingPage.aspx")
    End Sub

    Public Shared Function ComputeSHA1Hash(ByVal inp As String) As String
        Using sha1 As SHA1Managed = New SHA1Managed()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(inp)
            Dim hashBytes As Byte() = sha1.ComputeHash(bytes)
            Return BitConverter.ToString(hashBytes).Replace("-", String.Empty)
        End Using
    End Function

End Class