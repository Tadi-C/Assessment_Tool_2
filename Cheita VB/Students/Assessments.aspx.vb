Public Class Assessments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As EventArgs)

        Response.Redirect("LandingPage.aspx")
    End Sub

    Protected Sub btnAssess_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("AssessmentAttempt.aspx")
    End Sub

    Protected Sub btnBack_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("LandingPage.aspx")
    End Sub
End Class