Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Question_Category
inherits Entity

Public Shared Display_Category_ID as Boolean=True
    Public Shared Display_Category_Type As Boolean = True


    Private I_Display_Category_ID as Boolean=True
    Private I_Display_Category_Type As Boolean = True


    Public previous_Category_ID as System.String

Public Category_ID as System.String
    Public Category_Type As System.String

    Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Category_ID=display_flag
        Display_Category_Type = display_flag

    End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Question_Category (Category_ID,Category_Type)"
        cmd.CommandText = cmd.CommandText & "values(@Category_ID,@Category_Type)"

        cmd.Parameters.Add("@Category_ID" , 22 , 255 , "Category_ID")
cmd.Parameters("@Category_ID").Value = SetNull(Category_ID)
        cmd.Parameters.Add("@Category_Type", 22, 255, "Category_Type")
        cmd.Parameters("@Category_Type").Value = setNull(Category_Type)



        cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Question_Category where Category_ID=@previous_Category_ID"
cmd.Parameters.Add("@previous_Category_ID", 22, 255, "previous_Category_ID")
cmd.Parameters("@previous_Category_ID").Value = Me.previous_Category_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Category_ID as System.String) As Question_Category
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Category_Type = True Then cmd.CommandText = cmd.CommandText & "Category_Type,"

        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Category where Category_ID=@Category_ID"
cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
cmd.Parameters("@Category_ID").Value = Category_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Question_Category
For i = 0 To dt.Rows.Count - 1
p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.I_Display_Category_ID=Display_Category_ID
            If Display_Category_Type = True Then p.Category_Type = checkNull(dt.Rows(i)("Category_Type"))
            p.I_Display_Category_Type = Display_Category_Type
            p.previous_Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.newinstance = False
Return p
Next
Return Nothing
End Function


Sub update()
If newinstance = True Then
insert()
Return
End If

Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "update Question_Category set "
cmd.CommandText =cmd.CommandText & " Category_ID=@Category_ID,"
        If I_Display_Category_Type = True Then cmd.CommandText = cmd.CommandText & " Category_Type=@Category_Type,"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Category_ID=@previous_Category_ID"


cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
cmd.Parameters("@Category_ID").Value = SetNull(Category_ID)

        If I_Display_Category_Type = True Then cmd.Parameters.Add("@Category_Type", 22, 255, "Category_Type")
        If I_Display_Category_Type = True Then cmd.Parameters("@Category_Type").Value = setNull(Category_Type)



        cmd.Parameters.Add("@previous_Category_ID", 22, 255, "previous_Category_ID")
cmd.Parameters("@previous_Category_ID").Value = Me.previous_Category_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Category)
Dim ps As New Generic.List(Of Question_Category)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Category_Type = True Then cmd.CommandText = cmd.CommandText & "Category_Type,"

        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Category " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Category
p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.I_Display_Category_ID=Display_Category_ID
            If Display_Category_Type = True Then p.Category_Type = checkNull(dt.Rows(i)("Category_Type"))
            p.I_Display_Category_Type = Display_Category_Type
            p.previous_Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Category)
Dim ps As New Generic.List(Of Question_Category)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Category_ID from Question_Category" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Category
p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.previous_Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class