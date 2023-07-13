Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Assessment_Questions
inherits Entity

Public Shared Display_Assessment_Question_ID as Boolean=true
Public Shared Display_Assessment_ID as Boolean=true
Public Shared Display_Question_ID as Boolean=true

Private I_Display_Assessment_Question_ID as Boolean=true
Private I_Display_Assessment_ID as Boolean=true
Private I_Display_Question_ID as Boolean=true

Public previous_Assessment_Question_ID as System.String

Public Assessment_Question_ID as System.String
Public Assessment_ID as System.String
Public Question_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Assessment_Question_ID=display_flag
Display_Assessment_ID=display_flag
Display_Question_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Assessment_Questions (Assessment_Question_ID,Assessment_ID,Question_ID)"
cmd.CommandText = cmd.CommandText & "values(@Assessment_Question_ID,@Assessment_ID,@Question_ID)"

cmd.Parameters.Add("@Assessment_Question_ID" , 22 , 255 , "Assessment_Question_ID")
cmd.Parameters("@Assessment_Question_ID").Value = SetNull(Assessment_Question_ID)
cmd.Parameters.Add("@Assessment_ID" , 22 , 255 , "Assessment_ID")
cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)
cmd.Parameters.Add("@Question_ID" , 22 , 255 , "Question_ID")
cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Assessment_Questions where Assessment_Question_ID=@previous_Assessment_Question_ID"
cmd.Parameters.Add("@previous_Assessment_Question_ID", 22, 255, "previous_Assessment_Question_ID")
cmd.Parameters("@previous_Assessment_Question_ID").Value = Me.previous_Assessment_Question_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Assessment_Question_ID as System.String) As Assessment_Questions
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Assessment_Question_ID,"
if Display_Assessment_ID=true then cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Assessment_Questions where Assessment_Question_ID=@Assessment_Question_ID"
cmd.Parameters.Add("@Assessment_Question_ID", 22, 255, "Assessment_Question_ID")
cmd.Parameters("@Assessment_Question_ID").Value = Assessment_Question_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Assessment_Questions
For i = 0 To dt.Rows.Count - 1
p.Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
p.I_Display_Assessment_Question_ID=Display_Assessment_Question_ID
if Display_Assessment_ID=true then p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
p.previous_Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
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
cmd.CommandText = "update Assessment_Questions set "
cmd.CommandText =cmd.CommandText & " Assessment_Question_ID=@Assessment_Question_ID,"
if I_Display_Assessment_ID=true then cmd.CommandText =cmd.CommandText & " Assessment_ID=@Assessment_ID,"
if I_Display_Question_ID=true then cmd.CommandText =cmd.CommandText & " Question_ID=@Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Assessment_Question_ID=@previous_Assessment_Question_ID"


cmd.Parameters.Add("@Assessment_Question_ID", 22, 255, "Assessment_Question_ID")
cmd.Parameters("@Assessment_Question_ID").Value = SetNull(Assessment_Question_ID)

if I_Display_Assessment_ID=true then cmd.Parameters.Add("@Assessment_ID", 22, 255, "Assessment_ID")
if I_Display_Assessment_ID=true then cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)

if I_Display_Question_ID=true then cmd.Parameters.Add("@Question_ID", 22, 255, "Question_ID")
if I_Display_Question_ID=true then cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)



cmd.Parameters.Add("@previous_Assessment_Question_ID", 22, 255, "previous_Assessment_Question_ID")
cmd.Parameters("@previous_Assessment_Question_ID").Value = Me.previous_Assessment_Question_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Assessment_Questions)
Dim ps As New Generic.List(Of Assessment_Questions)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Assessment_Question_ID,"
if Display_Assessment_ID=true then cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Assessment_Questions " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Assessment_Questions
p.Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
p.I_Display_Assessment_Question_ID=Display_Assessment_Question_ID
if Display_Assessment_ID=true then p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
p.previous_Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Assessment_Questions)
Dim ps As New Generic.List(Of Assessment_Questions)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Assessment_Question_ID from Assessment_Questions" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Assessment_Questions
p.Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
p.previous_Assessment_Question_ID=checknull(dt.Rows(i)("Assessment_Question_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class