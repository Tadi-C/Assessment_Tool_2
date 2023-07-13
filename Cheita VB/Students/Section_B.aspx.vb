Imports System.Data.SqlClient
Imports Cheita_VB.Section_A

Public Class Section_B
    Inherits System.Web.UI.Page
    Public Shared Questions_1 As New List(Of String)()
    Public Shared Questions_IDs As New List(Of String)()
    Public Shared Options As New List(Of List(Of String))()
    Public qs As New List(Of Question)()
    Public count As Integer = 0

    ' Select X Questions
    Private selectXcount As Integer = 0
    Public Shared SelectXQuestions_1 As New List(Of String)()
    Public Shared SelectXQuestions_IDs As New List(Of String)()
    Public Shared SelectXOptions As New List(Of List(Of String))()
    Public sXqs As New List(Of SelectXQuestion)()
    Public Shared Trueorfalse As New List(Of String)()
    Public Shared CheckBoxAns_lst As New List(Of String)()
    Public Shared T_r_ans As New List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Clearing all the lists on load
        If Not IsPostBack Then
            DBInterface.SetUpConnection()
            Questions_1.Clear()
            Questions_IDs.Clear()
            Options.Clear()
            SelectXQuestions_1.Clear()
            SelectXQuestions_IDs.Clear()
            SelectXOptions.Clear()
            qs.Clear()
            sXqs.Clear()
            T_r_ans.Clear()

            Dim connection_ans As New SqlConnection(DBInterface.connectstring)
            Dim cmd_ans As String = $"select Answer_Text from Answer join Question_Bank on Answer.Answer_ID = Question_Bank.Answer_ID where Answer.Answer_Text='False' or Answer.Answer_Text='True';"
            Dim reader_ans As SqlDataReader = Nothing
            Using cmd_2 As New SqlCommand(cmd_ans, connection_ans)
                connection_ans.Open()
                reader_ans = cmd_2.ExecuteReader()
                While reader_ans.Read()
                    T_r_ans.Add(reader_ans.GetString(0))
                End While
            End Using

            Dim theseQuestions As List(Of Question_Bank) = Question_Bank.listall(" where Section_ID = 'B' and Question_ID not like '%.%' ")
            For Each q As Question_Bank In theseQuestions
                Questions_1.Add(q.Question_Text)
                Questions_IDs.Add(q.Question_ID)
                count += 1
            Next

            Dim QuestionCount As Integer = 0
            For Each item As String In Questions_IDs
                Dim list As New List(Of String)
                Dim TheseQuestionOptions As List(Of Question_Bank) = Question_Bank.listall($" where Section_ID = 'B' and Question_ID like '{item}.%' ")
                For Each qOpts As Question_Bank In TheseQuestionOptions
                    list.Add(qOpts.Question_Text)
                    QuestionCount += 1
                Next
                Options.Add(list)
            Next

            Dim theseXQuestions As List(Of Question_Bank) = Question_Bank.listall(" where Section_ID = 'F' and Question_ID not like '%.%' ")
            For Each q As Question_Bank In theseXQuestions
                SelectXQuestions_1.Add(q.Question_Text)
                SelectXQuestions_IDs.Add(q.Question_ID)
                selectXcount += 1
            Next

            Dim selectXQuestionCount As Integer = 0
            For Each x As String In SelectXQuestions_IDs
                Dim list As New List(Of String)
                Dim TheseXQuestionOptions As List(Of Question_Bank) = Question_Bank.listall($" where Section_ID = 'F' and Question_ID like '{x}.%' ")
                For Each qXOpts As Question_Bank In TheseXQuestionOptions
                    list.Add(qXOpts.Question_Text)
                    selectXQuestionCount += 1
                Next
                SelectXOptions.Add(list)
            Next

            If selectXcount = 0 AndAlso count = 0 Then
                Response.Redirect("Section C.aspx")
            Else
                qs = GetQuestions(count)
                Repeater1.DataSource = qs
                Repeater1.DataBind()

                sXqs = GetSelectXQuestions(selectXcount, count)
                Repeater2.DataSource = sXqs
                Repeater2.DataBind()
            End If
        End If
    End Sub
    Private Shared Function GetQuestions(count As Integer) As List(Of Question)
        Dim questions As New List(Of Question)()
        For i As Integer = 0 To count - 1
            Dim questionNumber As String = $"Question {i + 1}"
            Dim question As String = Questions_1(i)
            Dim list As List(Of String) = Options(i)
            Dim q As New Question() With {
                .QuestionNumber = questionNumber,
                .QuestionText = question,
                .Options = list
            }
            questions.Add(q)
        Next
        Return questions
    End Function
    Private Shared Function GetSelectXQuestions(xcount As Integer, totalCount As Integer) As List(Of SelectXQuestion)
        Dim selectXQuestions As New List(Of SelectXQuestion)()
        For i As Integer = 0 To xcount - 1
            Dim questionNumber As String = $"Question {i + totalCount + 1}"
            Dim question As String = SelectXQuestions_1(i)
            Dim strings As List(Of String) = SelectXOptions(i)
            Dim sX As New SelectXQuestion() With {
                .questionNumber = questionNumber,
                .QuestionText = question,
                .Options = strings
            }
            selectXQuestions.Add(sX)
        Next
        Return selectXQuestions
    End Function
    Protected Sub ItemBoundX(sender As Object, args As RepeaterItemEventArgs)
        If args.Item.ItemType = ListItemType.Item OrElse args.Item.ItemType = ListItemType.AlternatingItem Then
            Dim childRepeater As Repeater = DirectCast(args.Item.FindControl("OptionsRepeater1"), Repeater)
            Dim inner As List(Of String) = sXqs(args.Item.ItemIndex).Options
            For i As Integer = 0 To selectXcount - 1
                childRepeater.DataSource = inner
                childRepeater.DataBind()
            Next
        End If
    End Sub
    Protected Sub ItemBound(sender As Object, args As RepeaterItemEventArgs)
        If args.Item.ItemType = ListItemType.Item OrElse args.Item.ItemType = ListItemType.AlternatingItem Then

            Dim childRepeater As Repeater = DirectCast(args.Item.FindControl("OptionsRepeater"), Repeater)
            Dim innerList As List(Of String) = qs(args.Item.ItemIndex).Options
            For i As Integer = 0 To count - 1
                childRepeater.DataSource = innerList
                childRepeater.DataBind()
            Next
        End If
    End Sub
    Protected Function TrueOrFalseAns() As List(Of String)
        ' Finds the selected items from RadioButtonList controls and returns a list of answers (strings).
        'Dim trueorfalse As New List(Of String)()

        For Each repeater As RepeaterItem In Repeater1.Items
            Dim rt As Repeater = DirectCast(repeater.FindControl("OptionsRepeater"), Repeater)
            For Each trueOrFalseRepeater As RepeaterItem In rt.Items
                Dim r_list As RadioButtonList = DirectCast(trueOrFalseRepeater.FindControl("RadioButtonList1"), RadioButtonList)

                If r_list IsNot Nothing AndAlso r_list.SelectedItem IsNot Nothing Then
                    'Debug.WriteLine(r_list.SelectedItem.Text)
                    Trueorfalse.Add(r_list.SelectedItem.Text)
                Else
                    Trueorfalse.Add("no selection")

                End If
            Next
        Next

        Return Trueorfalse
    End Function
    Protected Function fetch_ans_T_R() As List(Of String)


        Return T_r_ans
    End Function


    Protected Function checkBoxAns() As List(Of String)
        ' Finds the checked CheckBox controls and returns a list of answers (strings).
        'Dim CheckBoxAns_lst As New List(Of String)()

        For Each repeater As RepeaterItem In Repeater2.Items
            Dim rt As Repeater = DirectCast(repeater.FindControl("OptionsRepeater1"), Repeater)
            For Each trueOrFalseRepeater As RepeaterItem In rt.Items
                Dim r_check As CheckBox = DirectCast(trueOrFalseRepeater.FindControl("CheckBox1"), CheckBox)

                If r_check IsNot Nothing AndAlso r_check.Checked Then
                    Debug.WriteLine(r_check.Text.ToString())
                    CheckBoxAns_lst.Add(r_check.Text.ToString())
                End If
            Next
        Next

        Return CheckBoxAns_lst
    End Function


    Public Class Question
        Public Property QuestionNumber As String
        Public Property QuestionText As String
        Public Property Options As List(Of String)
    End Class

    Public Class SelectXQuestion
        Public Property QuestionNumber As String
        Public Property QuestionText As String
        Public Property Options As List(Of String)
    End Class
End Class