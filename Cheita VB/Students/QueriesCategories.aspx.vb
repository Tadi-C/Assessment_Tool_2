Public Class QueriesCategories
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub MarkEnq_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Query.aspx")
    End Sub

    Protected Sub TechEnq_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Query.aspx")
    End Sub

    Protected Sub GeneralEnq_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Query.aspx")
    End Sub

    Protected Sub PrevEnq_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("PreviousQueries.aspx")
    End Sub

    Protected Sub btnBack_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("LandingPage.aspx")
    End Sub
End Class