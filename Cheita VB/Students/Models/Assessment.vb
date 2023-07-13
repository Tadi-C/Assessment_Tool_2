Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Assessment
inherits Entity

Public Shared Display_Assessment_ID as Boolean=true
Public Shared Display_Assessment_Title as Boolean=true
Public Shared Display_Assessment_Description as Boolean=true
Public Shared Display_Assessment_Paper as Boolean=true
Public Shared Display_Admin_ID as Boolean=true
Public Shared Display_Student_ID as Boolean=true
Public Shared Display_Marker_ID as Boolean=true

Private I_Display_Assessment_ID as Boolean=true
Private I_Display_Assessment_Title as Boolean=true
Private I_Display_Assessment_Description as Boolean=true
Private I_Display_Assessment_Paper as Boolean=true
Private I_Display_Admin_ID as Boolean=true
Private I_Display_Student_ID as Boolean=true
Private I_Display_Marker_ID as Boolean=true

Public previous_Assessment_ID as System.String

Public Assessment_ID as System.String
Public Assessment_Title as System.String
Public Assessment_Description as System.String
Public Assessment_Paper as System.String
Public Admin_ID as System.String
Public Student_ID as System.String
Public Marker_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Assessment_ID=display_flag
Display_Assessment_Title=display_flag
Display_Assessment_Description=display_flag
Display_Assessment_Paper=display_flag
Display_Admin_ID=display_flag
Display_Student_ID=display_flag
Display_Marker_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Assessment (Assessment_ID,Assessment_Title,Assessment_Description,Assessment_Paper,Admin_ID,Student_ID,Marker_ID)"
cmd.CommandText = cmd.CommandText & "values(@Assessment_ID,@Assessment_Title,@Assessment_Description,@Assessment_Paper,@Admin_ID,@Student_ID,@Marker_ID)"

cmd.Parameters.Add("@Assessment_ID" , 22 , 255 , "Assessment_ID")
cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)
cmd.Parameters.Add("@Assessment_Title" , 22 , 255 , "Assessment_Title")
cmd.Parameters("@Assessment_Title").Value = SetNull(Assessment_Title)
cmd.Parameters.Add("@Assessment_Description" , 22 , 400 , "Assessment_Description")
cmd.Parameters("@Assessment_Description").Value = SetNull(Assessment_Description)
cmd.Parameters.Add("@Assessment_Paper" , 22 , -1 , "Assessment_Paper")
cmd.Parameters("@Assessment_Paper").Value = SetNull(Assessment_Paper)
cmd.Parameters.Add("@Admin_ID" , 22 , 255 , "Admin_ID")
cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)
cmd.Parameters.Add("@Student_ID" , 22 , 255 , "Student_ID")
cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)
cmd.Parameters.Add("@Marker_ID" , 22 , 255 , "Marker_ID")
cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Assessment where Assessment_ID=@previous_Assessment_ID"
cmd.Parameters.Add("@previous_Assessment_ID", 22, 255, "previous_Assessment_ID")
cmd.Parameters("@previous_Assessment_ID").Value = Me.previous_Assessment_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Assessment_ID as System.String) As Assessment
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Assessment_Title=true then cmd.CommandText = cmd.CommandText & "Assessment_Title,"
if Display_Assessment_Description=true then cmd.CommandText = cmd.CommandText & "Assessment_Description,"
if Display_Assessment_Paper=true then cmd.CommandText = cmd.CommandText & "Assessment_Paper,"
if Display_Admin_ID=true then cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Marker_ID=true then cmd.CommandText = cmd.CommandText & "Marker_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Assessment where Assessment_ID=@Assessment_ID"
cmd.Parameters.Add("@Assessment_ID", 22, 255, "Assessment_ID")
cmd.Parameters("@Assessment_ID").Value = Assessment_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Assessment
For i = 0 To dt.Rows.Count - 1
p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Assessment_Title=true then p.Assessment_Title=checknull(dt.Rows(i)("Assessment_Title"))
p.I_Display_Assessment_Title=Display_Assessment_Title
if Display_Assessment_Description=true then p.Assessment_Description=checknull(dt.Rows(i)("Assessment_Description"))
p.I_Display_Assessment_Description=Display_Assessment_Description
if Display_Assessment_Paper=true then p.Assessment_Paper=checknull(dt.Rows(i)("Assessment_Paper"))
p.I_Display_Assessment_Paper=Display_Assessment_Paper
if Display_Admin_ID=true then p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Marker_ID=true then p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
p.previous_Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
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
cmd.CommandText = "update Assessment set "
cmd.CommandText =cmd.CommandText & " Assessment_ID=@Assessment_ID,"
if I_Display_Assessment_Title=true then cmd.CommandText =cmd.CommandText & " Assessment_Title=@Assessment_Title,"
if I_Display_Assessment_Description=true then cmd.CommandText =cmd.CommandText & " Assessment_Description=@Assessment_Description,"
if I_Display_Assessment_Paper=true then cmd.CommandText =cmd.CommandText & " Assessment_Paper=@Assessment_Paper,"
if I_Display_Admin_ID=true then cmd.CommandText =cmd.CommandText & " Admin_ID=@Admin_ID,"
if I_Display_Student_ID=true then cmd.CommandText =cmd.CommandText & " Student_ID=@Student_ID,"
if I_Display_Marker_ID=true then cmd.CommandText =cmd.CommandText & " Marker_ID=@Marker_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Assessment_ID=@previous_Assessment_ID"


cmd.Parameters.Add("@Assessment_ID", 22, 255, "Assessment_ID")
cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)

if I_Display_Assessment_Title=true then cmd.Parameters.Add("@Assessment_Title", 22, 255, "Assessment_Title")
if I_Display_Assessment_Title=true then cmd.Parameters("@Assessment_Title").Value = SetNull(Assessment_Title)

if I_Display_Assessment_Description=true then cmd.Parameters.Add("@Assessment_Description", 22, 400, "Assessment_Description")
if I_Display_Assessment_Description=true then cmd.Parameters("@Assessment_Description").Value = SetNull(Assessment_Description)

if I_Display_Assessment_Paper=true then cmd.Parameters.Add("@Assessment_Paper", 22, -1, "Assessment_Paper")
if I_Display_Assessment_Paper=true then cmd.Parameters("@Assessment_Paper").Value = SetNull(Assessment_Paper)

if I_Display_Admin_ID=true then cmd.Parameters.Add("@Admin_ID", 22, 255, "Admin_ID")
if I_Display_Admin_ID=true then cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)

if I_Display_Student_ID=true then cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
if I_Display_Student_ID=true then cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)

if I_Display_Marker_ID=true then cmd.Parameters.Add("@Marker_ID", 22, 255, "Marker_ID")
if I_Display_Marker_ID=true then cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)



cmd.Parameters.Add("@previous_Assessment_ID", 22, 255, "previous_Assessment_ID")
cmd.Parameters("@previous_Assessment_ID").Value = Me.previous_Assessment_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Assessment)
Dim ps As New Generic.List(Of Assessment)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Assessment_Title=true then cmd.CommandText = cmd.CommandText & "Assessment_Title,"
if Display_Assessment_Description=true then cmd.CommandText = cmd.CommandText & "Assessment_Description,"
if Display_Assessment_Paper=true then cmd.CommandText = cmd.CommandText & "Assessment_Paper,"
if Display_Admin_ID=true then cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Marker_ID=true then cmd.CommandText = cmd.CommandText & "Marker_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Assessment " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Assessment
p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Assessment_Title=true then p.Assessment_Title=checknull(dt.Rows(i)("Assessment_Title"))
p.I_Display_Assessment_Title=Display_Assessment_Title
if Display_Assessment_Description=true then p.Assessment_Description=checknull(dt.Rows(i)("Assessment_Description"))
p.I_Display_Assessment_Description=Display_Assessment_Description
if Display_Assessment_Paper=true then p.Assessment_Paper=checknull(dt.Rows(i)("Assessment_Paper"))
p.I_Display_Assessment_Paper=Display_Assessment_Paper
if Display_Admin_ID=true then p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Marker_ID=true then p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
p.previous_Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Assessment)
Dim ps As New Generic.List(Of Assessment)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Assessment_ID from Assessment" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Assessment
p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.previous_Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class