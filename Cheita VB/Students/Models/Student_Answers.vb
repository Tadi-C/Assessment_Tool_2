Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Student_Answers
inherits Entity

Public Shared Display_Student_Answer_ID as Boolean=true
Public Shared Display_Student_Answer as Boolean=true
Public Shared Display_Question_ID as Boolean=true
Public Shared Display_Student_ID as Boolean=true

Private I_Display_Student_Answer_ID as Boolean=true
Private I_Display_Student_Answer as Boolean=true
Private I_Display_Question_ID as Boolean=true
Private I_Display_Student_ID as Boolean=true

Public previous_Student_Answer_ID as System.String

Public Student_Answer_ID as System.String
Public Student_Answer as System.String
Public Question_ID as System.String
Public Student_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Student_Answer_ID=display_flag
Display_Student_Answer=display_flag
Display_Question_ID=display_flag
Display_Student_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Student_Answers (Student_Answer_ID,Student_Answer,Question_ID,Student_ID)"
cmd.CommandText = cmd.CommandText & "values(@Student_Answer_ID,@Student_Answer,@Question_ID,@Student_ID)"

cmd.Parameters.Add("@Student_Answer_ID" , 22 , 255 , "Student_Answer_ID")
cmd.Parameters("@Student_Answer_ID").Value = SetNull(Student_Answer_ID)
cmd.Parameters.Add("@Student_Answer" , 22 , -1 , "Student_Answer")
cmd.Parameters("@Student_Answer").Value = SetNull(Student_Answer)
cmd.Parameters.Add("@Question_ID" , 22 , 255 , "Question_ID")
cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)
cmd.Parameters.Add("@Student_ID" , 22 , 255 , "Student_ID")
cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Student_Answers where Student_Answer_ID=@previous_Student_Answer_ID"
cmd.Parameters.Add("@previous_Student_Answer_ID", 22, 255, "previous_Student_Answer_ID")
cmd.Parameters("@previous_Student_Answer_ID").Value = Me.previous_Student_Answer_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Student_Answer_ID as System.String) As Student_Answers
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Student_Answer_ID,"
if Display_Student_Answer=true then cmd.CommandText = cmd.CommandText & "Student_Answer,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Student_Answers where Student_Answer_ID=@Student_Answer_ID"
cmd.Parameters.Add("@Student_Answer_ID", 22, 255, "Student_Answer_ID")
cmd.Parameters("@Student_Answer_ID").Value = Student_Answer_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Student_Answers
For i = 0 To dt.Rows.Count - 1
p.Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
p.I_Display_Student_Answer_ID=Display_Student_Answer_ID
if Display_Student_Answer=true then p.Student_Answer=checknull(dt.Rows(i)("Student_Answer"))
p.I_Display_Student_Answer=Display_Student_Answer
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
p.previous_Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
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
cmd.CommandText = "update Student_Answers set "
cmd.CommandText =cmd.CommandText & " Student_Answer_ID=@Student_Answer_ID,"
if I_Display_Student_Answer=true then cmd.CommandText =cmd.CommandText & " Student_Answer=@Student_Answer,"
if I_Display_Question_ID=true then cmd.CommandText =cmd.CommandText & " Question_ID=@Question_ID,"
if I_Display_Student_ID=true then cmd.CommandText =cmd.CommandText & " Student_ID=@Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Student_Answer_ID=@previous_Student_Answer_ID"


cmd.Parameters.Add("@Student_Answer_ID", 22, 255, "Student_Answer_ID")
cmd.Parameters("@Student_Answer_ID").Value = SetNull(Student_Answer_ID)

if I_Display_Student_Answer=true then cmd.Parameters.Add("@Student_Answer", 22, -1, "Student_Answer")
if I_Display_Student_Answer=true then cmd.Parameters("@Student_Answer").Value = SetNull(Student_Answer)

if I_Display_Question_ID=true then cmd.Parameters.Add("@Question_ID", 22, 255, "Question_ID")
if I_Display_Question_ID=true then cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)

if I_Display_Student_ID=true then cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
if I_Display_Student_ID=true then cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)



cmd.Parameters.Add("@previous_Student_Answer_ID", 22, 255, "previous_Student_Answer_ID")
cmd.Parameters("@previous_Student_Answer_ID").Value = Me.previous_Student_Answer_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Student_Answers)
Dim ps As New Generic.List(Of Student_Answers)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Student_Answer_ID,"
if Display_Student_Answer=true then cmd.CommandText = cmd.CommandText & "Student_Answer,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Student_Answers " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Student_Answers
p.Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
p.I_Display_Student_Answer_ID=Display_Student_Answer_ID
if Display_Student_Answer=true then p.Student_Answer=checknull(dt.Rows(i)("Student_Answer"))
p.I_Display_Student_Answer=Display_Student_Answer
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
p.previous_Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Student_Answers)
Dim ps As New Generic.List(Of Student_Answers)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Student_Answer_ID from Student_Answers" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Student_Answers
p.Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
p.previous_Student_Answer_ID=checknull(dt.Rows(i)("Student_Answer_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class