Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnQuery(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("QueriesCategories.aspx")
    End Sub

    Protected Sub btnTrain(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Training.aspx")
    End Sub

    Protected Sub btnRes(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("ViewResults.aspx")
    End Sub

    Protected Sub btnAss(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Assessments.aspx")
    End Sub

    Protected Sub btnMocas(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("MockAs.aspx")
    End Sub


End Class