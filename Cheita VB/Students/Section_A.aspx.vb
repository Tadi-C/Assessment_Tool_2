Imports System.Data.SqlClient

Public Class Section_A
    Inherits System.Web.UI.Page
    Public Shared Questions_1 As New List(Of String)()
    Public Shared Questions_IDs As New List(Of String)()
    Public Shared Option_1 As New List(Of String)()
    Public Shared Option_2 As New List(Of String)()
    Public Shared Option_3 As New List(Of String)()
    Public Shared Option_4 As New List(Of String)()
    Public Shared Count1 As Integer = 0
    Public Shared read_answers As New List(Of String)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            ClientScript.RegisterStartupScript(Me.GetType(), "RadioButtonScript", "SetRadioButtonsFromSession();", True)
            'Dim Count1 As Integer = 0

            If Session("TargetTime") Is Nothing Then
                ' Check if session variable exists
                ' Calculate the target time (60 minutes from now)
                Dim targetTime As DateTime = DateTime.Now.AddMinutes(60)
                ' Store the target time in a session variable
                Session("TargetTime") = targetTime
            End If



            Questions_1.Clear()
            Questions_IDs.Clear()
            Option_1.Clear()
            Option_2.Clear()
            Option_3.Clear()
            Option_4.Clear()
            read_answers.Clear()
            DBInterface.SetUpConnection()
            Dim thisQuestion As List(Of Question_Bank) = Question_Bank.listall(" where Section_ID = 'A' ")
            For Each dp As Question_Bank In thisQuestion
                Questions_1.Add(dp.Question_Text)
                Questions_IDs.Add(dp.Question_ID)
                Option_1.Add(dp.Question_Option1)
                Option_2.Add(dp.Question_Option2)
                Option_3.Add(dp.Question_Option3)
                Option_4.Add(dp.Question_Option4)
                Count1 = Count1 + 1
            Next

            Dim Count2 As Integer = Count1
            If Count1 = 0 Then
                Response.Redirect("Section B.aspx")
            Else
                Dim questions As List(Of Question) = GetQuestions(Count2)

                divRepeater.DataSource = questions
                divRepeater.DataBind()
            End If

            ClientScript.RegisterStartupScript(Me.GetType(), "RadioButtonScript", "SetRadioButtonsFromSession();", True)
        End If

    End Sub
    Private Shared Function GetQuestions(count As Integer) As List(Of Question)

        Dim questions As New List(Of Question)()

        For i As Integer = 0 To count - 1
            Dim questionNumber As String = $"Question {i + 1}"

            Dim question As String = Questions_1(i).ToString

            Dim option1 As String = Option_1(i).ToString
            Dim option2 As String = Option_2(i).ToString
            Dim option3 As String = Option_3(i).ToString
            Dim option4 As String = Option_4(i).ToString

            Dim q As New Question() With {
                .questionNumber = questionNumber,
                .QuestionText = question,
                .option1 = option1,
                .option2 = option2,
                .option3 = option3,
                .option4 = option4
            }

            questions.Add(q)
        Next

        Return questions
    End Function
    Public Class Question
        Public Property QuestionNumber As String
        Public Property QuestionText As String
        Public Property Option1 As String
        Public Property Option2 As String
        Public Property Option3 As String
        Public Property Option4 As String
    End Class
    Protected Function FindControls() As List(Of String)
        ' Finds the checked radio button and adds it to a list. Returns a list of answers (strings).
        'Dim answers As New List(Of String)()

        For Each ri As RepeaterItem In divRepeater.Items
            Dim rd1 As RadioButton = DirectCast(ri.FindControl("RadioButton1"), RadioButton)
            Dim rd2 As RadioButton = DirectCast(ri.FindControl("RadioButton2"), RadioButton)
            Dim rd3 As RadioButton = DirectCast(ri.FindControl("RadioButton3"), RadioButton)
            Dim rd4 As RadioButton = DirectCast(ri.FindControl("RadioButton4"), RadioButton)

            If Not rd1.Checked And Not rd2.Checked And Not rd3.Checked And Not rd4.Checked Then
                read_answers.Add("no check")
            Else
                If rd1 IsNot Nothing Then
                    If rd1.Checked Then
                        read_answers.Add(rd1.Text)
                        Debug.WriteLine(rd1.Text)
                    End If
                End If
                If rd2 IsNot Nothing Then
                    If rd2.Checked Then
                        read_answers.Add(rd2.Text)
                        Debug.WriteLine(rd2.Text)
                    End If
                End If
                If rd3 IsNot Nothing Then
                    If rd3.Checked Then
                        read_answers.Add(rd3.Text)
                        Debug.WriteLine(rd3.Text)
                    End If
                End If
                If rd4 IsNot Nothing Then
                    If rd4.Checked Then
                        read_answers.Add(rd4.Text)
                        Debug.WriteLine(rd4.Text)
                    End If
                End If
            End If

        Next

        Return read_answers
    End Function
End Class