Imports System.Data.SqlClient

Public Class Section_C
    Inherits System.Web.UI.Page


    Public Shared RowsNames As New List(Of String)()
    Public columnNamesCount As Integer = 0
    Public rowNamesCount As Integer = 0
    Public Shared ColumnNames As New List(Of String)()
    Public Shared tables_obj As New List(Of Object)()
    Public Shared answers_lst As New List(Of Answers)()

    Public Shared Rows As New List(Of Integer)()
    Public Shared Columns As New List(Of Integer)()
    Public Shared tbl_ans_lst As New List(Of List(Of String))()



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RowsNames.Clear()
            ColumnNames.Clear()

            If Not IsPostBack Then
                Dim tablesData As New List(Of Object)()

                'For i As Integer = 0 To 0 Step 1
                '    tablesData.Add(New With {
                '        .Rows = Rows(i),
                '        .Columns = Columns(i)
                '    })
                'Next i

                tables_obj.Add(GenerateTableQueries("Question_13"))

                tables_obj.Add(GenerateTableQueries("QUESTION_16"))

                If tables_obj.Count() = 0 Then
                    Response.Redirect("Section D.aspx")
                Else
                    tableRepeater.DataSource = tables_obj
                    tableRepeater.DataBind()
                End If
            End If
        End If
    End Sub
    Public Function GenerateTable(ByVal questionNumber As Integer, ByVal questionText As String, ByVal rows As Integer, ByVal columns As Integer, ByVal NamesOfRows As Object, ByVal NamesOfCloumns As Object) As String
        Dim Rownames As List(Of String) = DirectCast(NamesOfRows, List(Of String))
        Dim ColumnNames As List(Of String) = DirectCast(NamesOfCloumns, List(Of String))
        Dim tableHtml As String = "<tr>"

        ' Generate the table header row with question number
        tableHtml += "<label>Question " & (questionNumber + 1) & "</label><br />"
        tableHtml += "<label>" & questionText & "</label><br />"
        tableHtml += "<table>"

        For j As Integer = 0 To columns - 1 Step 1
            Dim colName As String = ColumnNames(j).Replace("_", " ")
            tableHtml += $"<th>{colName}</th>"
        Next j

        tableHtml += "</tr>"

        For i As Integer = 0 To rows - 1 Step 1
            tableHtml += "<tr>"
            tableHtml += $"<td>{Rownames(i)}</td>"

            For j As Integer = 0 To columns - 2 Step 1
                tableHtml += "<td><input type='text' id='table-" & questionNumber + 1 & "-row-" & (i + 1) & "-col-" & (j + 1) & "' class='table-input' /></td>"
            Next j

            tableHtml += "</tr>"
        Next i

        Return tableHtml
    End Function
    Public Class Tables
        Public Property questionText As String
        Public Property Rows As Integer
        Public Property Columns As Integer
        Public Property RowNames As List(Of String)
        Public Property ColNames As List(Of String)
    End Class
    Public Class Answers
        Public Property TextBoxID As String
        Public Property Answertext As String
    End Class

    Public Function GenerateTableQueries(ByVal tableName As String) As Tables
        Dim table As New Tables()

        Dim columnNames As New List(Of String)()
        Dim rowNames As New List(Of String)()

        Dim conn As New SqlConnection(DbMethods.connectionString)
        Dim cmdText As String = $"Declare @TableName NVARCHAR(128) = '{tableName}'" & vbCrLf &
            $"DECLARE @ColumnsToExclude NVARCHAR(MAX) = 'Question_ID,Section_ID,ANSWER_ID,QUESTION_MARK,ASSESMENT_ID,Question_Text'" & vbCrLf &
            $"DECLARE @SQL NVARCHAR(MAX)" & vbCrLf &
            vbCrLf &
            $"SET @SQL = 'SELECT COUNT(*) AS TotalRecords FROM ' + @TableName" & vbCrLf &
            vbCrLf &
            $"EXEC (@SQL)"
        Dim reader As SqlDataReader = Nothing

        Using cmd As New SqlCommand(cmdText, conn)
            conn.Open()
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim result As Integer = reader.GetInt32(0)
                table.Rows = result
            End While
        End Using
        conn.Close()

        cmdText = $"DECLARE @TableName NVARCHAR(128) = '{tableName}'" & vbCrLf &
            $"DECLARE @ColumnsToExclude NVARCHAR(MAX) = 'Question_ID,Section_ID,ANSWER_ID,QUESTION_MARK,ASSESMENT_ID,Question_Text'" & vbCrLf &
            $"DECLARE @SQL NVARCHAR(MAX)" & vbCrLf &
            vbCrLf &
            $"SET @SQL = '" & vbCrLf & "  SELECT COUNT(COLUMN_NAME) AS TotalColumns " & vbCrLf & "   FROM INFORMATION_SCHEMA.COLUMNS " & vbCrLf & "    WHERE TABLE_NAME = ''' + @TableName + ''' " & vbCrLf & "        AND COLUMN_NAME NOT IN (SELECT value FROM STRING_SPLIT(''' + @ColumnsToExclude + ''', '',''))'" & vbCrLf &
            vbCrLf &
            $"EXEC (@SQL)"
        reader = Nothing

        Using command As New SqlCommand(cmdText, conn)
            conn.Open()
            reader = command.ExecuteReader()

            While reader.Read()
                Dim result As Integer = reader.GetInt32(0)
                table.Columns = result
            End While
        End Using
        conn.Close()

        cmdText = $"DECLARE @TableName NVARCHAR(128) = '{tableName}'" & vbCrLf &
            $"DECLARE @ColumnsToExclude NVARCHAR(MAX) = 'Question_ID,Section_ID,ANSWER_ID,QUESTION_MARK,ASSESMENT_ID,Question_Text'" & vbCrLf &
            $"DECLARE @SQL NVARCHAR(MAX)" & vbCrLf &
            vbCrLf &
            $"SET @SQL = '" & vbCrLf & "    SELECT COLUMN_NAME " & vbCrLf & "    FROM INFORMATION_SCHEMA.COLUMNS " & vbCrLf & "   WHERE TABLE_NAME = ''' + @TableName + ''' " & vbCrLf & "       AND COLUMN_NAME NOT IN (SELECT value FROM STRING_SPLIT(''' + @ColumnsToExclude + ''', '','')) " & vbCrLf & "'" & vbCrLf & " EXEC (@SQL)"
        reader = Nothing

        Using cmd As New SqlCommand(cmdText, conn)
            conn.Open()
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim result As String = reader.GetString(0)
                columnNames.Add(result)
            End While
        End Using
        conn.Close()

        cmdText = $"DECLARE @TableName NVARCHAR(128) = '{tableName}'" & vbCrLf &
            $"DECLARE @ColumnsToExclude NVARCHAR(MAX) = 'Question_ID,Section_ID,ANSWER_ID,QUESTION_MARK,ASSESMENT_ID,Question_Text'" & vbCrLf &
            $"DECLARE @SQLCommand NVARCHAR(MAX)" & vbCrLf &
            vbCrLf &
            $"SET @SQLCommand = 'SELECT '" & vbCrLf &
            vbCrLf &
            $"SELECT @SQLCommand = @SQLCommand + COLUMN_NAME + ', '" & vbCrLf &
            $"FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
            $"WHERE TABLE_NAME = @TableName" & vbCrLf &
            $"  AND COLUMN_NAME NOT IN (SELECT value FROM STRING_SPLIT(@ColumnsToExclude, ','))" & vbCrLf &
            vbCrLf &
            $"SET @SQLCommand = LEFT(@SQLCommand, LEN(@SQLCommand) - 1) + ' FROM ' + @TableName" & vbCrLf &
            vbCrLf &
            $"EXEC (@SQLCommand)"

        reader = Nothing

        Using cmd As New SqlCommand(cmdText, conn)
            conn.Open()
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim result As String = reader.GetString(0)
                rowNames.Add(result)
            End While
        End Using
        conn.Close()

        cmdText = $"select Question_Text from {tableName}"
        reader = Nothing

        Using cmd As New SqlCommand(cmdText, conn)
            conn.Open()
            reader = cmd.ExecuteReader()
            reader.Read()
            Dim result As String = reader.GetString(0)
            table.questionText = result
        End Using
        conn.Close()

        table.RowNames = rowNames
        table.ColNames = columnNames

        Return table
    End Function
    Protected Function TableAns() As List(Of List(Of String))
        'Dim tbl_ans As New List(Of List(Of String))()

        For Each item As Repeater In tableRepeater.Items
            Dim tbl As Table = DirectCast(item.FindControl("tbl_id"), Table)

            If tbl IsNot Nothing Then
                Dim Ans_per_row As New List(Of String)()

                For Each row As TableRow In tbl.Rows
                    For Each cell As TableCell In row.Cells
                        ' Access the cell contents or perform operations
                        Dim cellText As String = cell.Text
                        Ans_per_row.Add(cellText)
                        Debug.Write(cellText & " ::::::")
                    Next

                    tbl_ans_lst.Add(Ans_per_row)
                    Ans_per_row = New List(Of String)()
                Next
            End If
        Next

        Return tbl_ans_lst
    End Function

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        TableAns()
        Response.Redirect("Section_D.aspx")
    End Sub
End Class