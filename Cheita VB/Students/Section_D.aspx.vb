Imports System.Data.SqlClient

Public Class Section_D
    Inherits System.Web.UI.Page
    Public Shared Questions_1 As New List(Of String)()
    Public Shared Count1 As Integer = 0
    Public Shared lst_long_text_ans As New List(Of String)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Questions_1.Clear()
            DBInterface.SetUpConnection()

            Dim thisQuestion As List(Of Question_Bank) = Question_Bank.listall(" where (Section_ID = 'C' or Section_ID = 'D')")
            For Each dp As Question_Bank In thisQuestion
                Questions_1.Add(dp.Question_Text)
                Count1 = Count1 + 1
            Next

            Dim Count As Integer = Count1
            Dim questions As List(Of Question) = GetQuestions(Count)

            divRepeater.DataSource = questions
            divRepeater.DataBind()
        End If
    End Sub
    Private Shared Function GetQuestions(ByVal count As Integer) As List(Of Question)
        Dim questions As New List(Of Question)()

        For i As Integer = 0 To count - 1
            Dim questionNumber As String = $"Question {i + 1}"
            Dim question As String = Questions_1(i)

            Dim q As New Question() With {
            .questionNumber = questionNumber,
            .QuestionText = question
        }

            questions.Add(q)
        Next

        Return questions
    End Function
    Public Class Question
        Public Property QuestionNumber As String
        Public Property QuestionText As String
    End Class

    Protected Function long_text_ans() As List(Of String)
        For Each item As Repeater In divRepeater.Items
            Dim txt_box As TextBox = DirectCast(item.FindControl("tb_Answer"), TextBox)
            If txt_box.Text Is Nothing Then
                lst_long_text_ans.Add("no answer")
            Else
                lst_long_text_ans.Add(txt_box.Text)
            End If



        Next

        Return lst_long_text_ans
    End Function
End Class