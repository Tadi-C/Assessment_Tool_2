Public Class UploadMCQs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_submit_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim words As String = Question.Text
        Option1.Text = words
    End Sub

End Class