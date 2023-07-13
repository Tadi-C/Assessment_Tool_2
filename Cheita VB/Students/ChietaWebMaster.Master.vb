Public Class ChietaWebMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUsername.InnerText = Session("username").ToUpper()
        txtStuNo.InnerText = Session("StudentNumber")
        txtStuNo.InnerText = 232468435.ToString() + "(Default)"
    End Sub

    Protected Sub Logout_ServerClick(sender As Object, e As EventArgs)
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
End Class