Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Track_Assesment
inherits Entity

Public Shared Display_Track_Assesment_ID as Boolean=true
Public Shared Display_Assesment_Completed as Boolean=true
Public Shared Display_Attempts as Boolean=true
Public Shared Display_Assesmet_ID as Boolean=true
Public Shared Display_Student_ID as Boolean=true
Public Shared Display_Students_Answer_ID as Boolean=true

Private I_Display_Track_Assesment_ID as Boolean=true
Private I_Display_Assesment_Completed as Boolean=true
Private I_Display_Attempts as Boolean=true
Private I_Display_Assesmet_ID as Boolean=true
Private I_Display_Student_ID as Boolean=true
Private I_Display_Students_Answer_ID as Boolean=true

Public previous_Track_Assesment_ID as System.String

Public Track_Assesment_ID as System.String
Public Assesment_Completed as System.String
Public Attempts as System.String
Public Assesmet_ID as System.String
Public Student_ID as System.String
Public Students_Answer_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Track_Assesment_ID=display_flag
Display_Assesment_Completed=display_flag
Display_Attempts=display_flag
Display_Assesmet_ID=display_flag
Display_Student_ID=display_flag
Display_Students_Answer_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Track_Assesment (Track_Assesment_ID,Assesment_Completed,Attempts,Assesmet_ID,Student_ID,Students_Answer_ID)"
cmd.CommandText = cmd.CommandText & "values(@Track_Assesment_ID,@Assesment_Completed,@Attempts,@Assesmet_ID,@Student_ID,@Students_Answer_ID)"

cmd.Parameters.Add("@Track_Assesment_ID" , 22 , 255 , "Track_Assesment_ID")
cmd.Parameters("@Track_Assesment_ID").Value = SetNull(Track_Assesment_ID)
cmd.Parameters.Add("@Assesment_Completed" , 22 , 255 , "Assesment_Completed")
cmd.Parameters("@Assesment_Completed").Value = SetNull(Assesment_Completed)
cmd.Parameters.Add("@Attempts" , 22 , 255 , "Attempts")
cmd.Parameters("@Attempts").Value = SetNull(Attempts)
cmd.Parameters.Add("@Assesmet_ID" , 22 , 255 , "Assesmet_ID")
cmd.Parameters("@Assesmet_ID").Value = SetNull(Assesmet_ID)
cmd.Parameters.Add("@Student_ID" , 22 , 255 , "Student_ID")
cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)
cmd.Parameters.Add("@Students_Answer_ID" , 22 , 255 , "Students_Answer_ID")
cmd.Parameters("@Students_Answer_ID").Value = SetNull(Students_Answer_ID)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Track_Assesment where Track_Assesment_ID=@previous_Track_Assesment_ID"
cmd.Parameters.Add("@previous_Track_Assesment_ID", 22, 255, "previous_Track_Assesment_ID")
cmd.Parameters("@previous_Track_Assesment_ID").Value = Me.previous_Track_Assesment_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Track_Assesment_ID as System.String) As Track_Assesment
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Track_Assesment_ID,"
if Display_Assesment_Completed=true then cmd.CommandText = cmd.CommandText & "Assesment_Completed,"
if Display_Attempts=true then cmd.CommandText = cmd.CommandText & "Attempts,"
if Display_Assesmet_ID=true then cmd.CommandText = cmd.CommandText & "Assesmet_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Students_Answer_ID=true then cmd.CommandText = cmd.CommandText & "Students_Answer_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Track_Assesment where Track_Assesment_ID=@Track_Assesment_ID"
cmd.Parameters.Add("@Track_Assesment_ID", 22, 255, "Track_Assesment_ID")
cmd.Parameters("@Track_Assesment_ID").Value = Track_Assesment_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Track_Assesment
For i = 0 To dt.Rows.Count - 1
p.Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
p.I_Display_Track_Assesment_ID=Display_Track_Assesment_ID
if Display_Assesment_Completed=true then p.Assesment_Completed=checknull(dt.Rows(i)("Assesment_Completed"))
p.I_Display_Assesment_Completed=Display_Assesment_Completed
if Display_Attempts=true then p.Attempts=checknull(dt.Rows(i)("Attempts"))
p.I_Display_Attempts=Display_Attempts
if Display_Assesmet_ID=true then p.Assesmet_ID=checknull(dt.Rows(i)("Assesmet_ID"))
p.I_Display_Assesmet_ID=Display_Assesmet_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Students_Answer_ID=true then p.Students_Answer_ID=checknull(dt.Rows(i)("Students_Answer_ID"))
p.I_Display_Students_Answer_ID=Display_Students_Answer_ID
p.previous_Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
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
cmd.CommandText = "update Track_Assesment set "
cmd.CommandText =cmd.CommandText & " Track_Assesment_ID=@Track_Assesment_ID,"
if I_Display_Assesment_Completed=true then cmd.CommandText =cmd.CommandText & " Assesment_Completed=@Assesment_Completed,"
if I_Display_Attempts=true then cmd.CommandText =cmd.CommandText & " Attempts=@Attempts,"
if I_Display_Assesmet_ID=true then cmd.CommandText =cmd.CommandText & " Assesmet_ID=@Assesmet_ID,"
if I_Display_Student_ID=true then cmd.CommandText =cmd.CommandText & " Student_ID=@Student_ID,"
if I_Display_Students_Answer_ID=true then cmd.CommandText =cmd.CommandText & " Students_Answer_ID=@Students_Answer_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Track_Assesment_ID=@previous_Track_Assesment_ID"


cmd.Parameters.Add("@Track_Assesment_ID", 22, 255, "Track_Assesment_ID")
cmd.Parameters("@Track_Assesment_ID").Value = SetNull(Track_Assesment_ID)

if I_Display_Assesment_Completed=true then cmd.Parameters.Add("@Assesment_Completed", 22, 255, "Assesment_Completed")
if I_Display_Assesment_Completed=true then cmd.Parameters("@Assesment_Completed").Value = SetNull(Assesment_Completed)

if I_Display_Attempts=true then cmd.Parameters.Add("@Attempts", 22, 255, "Attempts")
if I_Display_Attempts=true then cmd.Parameters("@Attempts").Value = SetNull(Attempts)

if I_Display_Assesmet_ID=true then cmd.Parameters.Add("@Assesmet_ID", 22, 255, "Assesmet_ID")
if I_Display_Assesmet_ID=true then cmd.Parameters("@Assesmet_ID").Value = SetNull(Assesmet_ID)

if I_Display_Student_ID=true then cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
if I_Display_Student_ID=true then cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)

if I_Display_Students_Answer_ID=true then cmd.Parameters.Add("@Students_Answer_ID", 22, 255, "Students_Answer_ID")
if I_Display_Students_Answer_ID=true then cmd.Parameters("@Students_Answer_ID").Value = SetNull(Students_Answer_ID)



cmd.Parameters.Add("@previous_Track_Assesment_ID", 22, 255, "previous_Track_Assesment_ID")
cmd.Parameters("@previous_Track_Assesment_ID").Value = Me.previous_Track_Assesment_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Track_Assesment)
Dim ps As New Generic.List(Of Track_Assesment)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Track_Assesment_ID,"
if Display_Assesment_Completed=true then cmd.CommandText = cmd.CommandText & "Assesment_Completed,"
if Display_Attempts=true then cmd.CommandText = cmd.CommandText & "Attempts,"
if Display_Assesmet_ID=true then cmd.CommandText = cmd.CommandText & "Assesmet_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Students_Answer_ID=true then cmd.CommandText = cmd.CommandText & "Students_Answer_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Track_Assesment " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Track_Assesment
p.Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
p.I_Display_Track_Assesment_ID=Display_Track_Assesment_ID
if Display_Assesment_Completed=true then p.Assesment_Completed=checknull(dt.Rows(i)("Assesment_Completed"))
p.I_Display_Assesment_Completed=Display_Assesment_Completed
if Display_Attempts=true then p.Attempts=checknull(dt.Rows(i)("Attempts"))
p.I_Display_Attempts=Display_Attempts
if Display_Assesmet_ID=true then p.Assesmet_ID=checknull(dt.Rows(i)("Assesmet_ID"))
p.I_Display_Assesmet_ID=Display_Assesmet_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Students_Answer_ID=true then p.Students_Answer_ID=checknull(dt.Rows(i)("Students_Answer_ID"))
p.I_Display_Students_Answer_ID=Display_Students_Answer_ID
p.previous_Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Track_Assesment)
Dim ps As New Generic.List(Of Track_Assesment)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Track_Assesment_ID from Track_Assesment" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Track_Assesment
p.Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
p.previous_Track_Assesment_ID=checknull(dt.Rows(i)("Track_Assesment_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class