Public Class Training
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnBack_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("LandingPage.aspx")
    End Sub
End Class