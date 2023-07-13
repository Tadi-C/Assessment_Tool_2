Public Class Assesments2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnAssess_Click(sender As Object, e As EventArgs)
        DbMethods.paperNumber = "1A"
        Response.Redirect("Section_A.aspx")
    End Sub

    Protected Sub btnAssess2_Click(sender As Object, e As EventArgs)
        DbMethods.paperNumber = "2A"
        Response.Redirect("Section_A.aspx")
    End Sub

    Protected Sub btnAssess3_Click(sender As Object, e As EventArgs)
        DbMethods.paperNumber = "3A"
        Response.Redirect("Section_A.aspx")
    End Sub

    Protected Sub btnBack_ServerClick(sender As Object, e As EventArgs)

    End Sub

End Class