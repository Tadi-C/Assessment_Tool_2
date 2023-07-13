Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Log
inherits Entity

Public Shared Display_Log_ID as Boolean=true
Public Shared Display_Admin_ID as Boolean=true
Public Shared Display_Question_ID as Boolean=true

Private I_Display_Log_ID as Boolean=true
Private I_Display_Admin_ID as Boolean=true
Private I_Display_Question_ID as Boolean=true

Public previous_Log_ID as System.String

Public Log_ID as System.String
Public Admin_ID as System.String
Public Question_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Log_ID=display_flag
Display_Admin_ID=display_flag
Display_Question_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Log (Log_ID,Admin_ID,Question_ID)"
cmd.CommandText = cmd.CommandText & "values(@Log_ID,@Admin_ID,@Question_ID)"

cmd.Parameters.Add("@Log_ID" , 22 , 255 , "Log_ID")
cmd.Parameters("@Log_ID").Value = SetNull(Log_ID)
cmd.Parameters.Add("@Admin_ID" , 22 , 255 , "Admin_ID")
cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)
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
cmd.CommandText = "delete from Log where Log_ID=@previous_Log_ID"
cmd.Parameters.Add("@previous_Log_ID", 22, 255, "previous_Log_ID")
cmd.Parameters("@previous_Log_ID").Value = Me.previous_Log_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Log_ID as System.String) As Log
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Log_ID,"
if Display_Admin_ID=true then cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Log where Log_ID=@Log_ID"
cmd.Parameters.Add("@Log_ID", 22, 255, "Log_ID")
cmd.Parameters("@Log_ID").Value = Log_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Log
For i = 0 To dt.Rows.Count - 1
p.Log_ID=checknull(dt.Rows(i)("Log_ID"))
p.I_Display_Log_ID=Display_Log_ID
if Display_Admin_ID=true then p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
p.previous_Log_ID=checknull(dt.Rows(i)("Log_ID"))
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
cmd.CommandText = "update Log set "
cmd.CommandText =cmd.CommandText & " Log_ID=@Log_ID,"
if I_Display_Admin_ID=true then cmd.CommandText =cmd.CommandText & " Admin_ID=@Admin_ID,"
if I_Display_Question_ID=true then cmd.CommandText =cmd.CommandText & " Question_ID=@Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Log_ID=@previous_Log_ID"


cmd.Parameters.Add("@Log_ID", 22, 255, "Log_ID")
cmd.Parameters("@Log_ID").Value = SetNull(Log_ID)

if I_Display_Admin_ID=true then cmd.Parameters.Add("@Admin_ID", 22, 255, "Admin_ID")
if I_Display_Admin_ID=true then cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)

if I_Display_Question_ID=true then cmd.Parameters.Add("@Question_ID", 22, 255, "Question_ID")
if I_Display_Question_ID=true then cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)



cmd.Parameters.Add("@previous_Log_ID", 22, 255, "previous_Log_ID")
cmd.Parameters("@previous_Log_ID").Value = Me.previous_Log_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Log)
Dim ps As New Generic.List(Of Log)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Log_ID,"
if Display_Admin_ID=true then cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Question_ID=true then cmd.CommandText = cmd.CommandText & "Question_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Log " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Log
p.Log_ID=checknull(dt.Rows(i)("Log_ID"))
p.I_Display_Log_ID=Display_Log_ID
if Display_Admin_ID=true then p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Question_ID=true then p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
p.previous_Log_ID=checknull(dt.Rows(i)("Log_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Log)
Dim ps As New Generic.List(Of Log)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Log_ID from Log" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Log
p.Log_ID=checknull(dt.Rows(i)("Log_ID"))
p.previous_Log_ID=checknull(dt.Rows(i)("Log_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class