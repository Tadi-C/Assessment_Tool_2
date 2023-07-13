Public Class PreviousQueries
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnBack_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("LandingPage.aspx")
    End Sub

    Protected Sub viewBtn_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("ViewQuery.aspx")
    End Sub
End Class