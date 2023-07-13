Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Results
inherits Entity

Public Shared Display_Results_ID as Boolean=true
Public Shared Display_Marker_ID as Boolean=true
Public Shared Display_Assessment_ID as Boolean=true
Public Shared Display_Results as Boolean=true
Public Shared Display_Student_ID as Boolean=true

Private I_Display_Results_ID as Boolean=true
Private I_Display_Marker_ID as Boolean=true
Private I_Display_Assessment_ID as Boolean=true
Private I_Display_Results as Boolean=true
Private I_Display_Student_ID as Boolean=true

Public previous_Results_ID as System.String

Public Results_ID as System.String
Public Marker_ID as System.String
Public Assessment_ID as System.String
Public Results as nullable(of System.Double)
Public Student_ID as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Results_ID=display_flag
Display_Marker_ID=display_flag
Display_Assessment_ID=display_flag
Display_Results=display_flag
Display_Student_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Results (Results_ID,Marker_ID,Assessment_ID,Results,Student_ID)"
cmd.CommandText = cmd.CommandText & "values(@Results_ID,@Marker_ID,@Assessment_ID,@Results,@Student_ID)"

cmd.Parameters.Add("@Results_ID" , 22 , 255 , "Results_ID")
cmd.Parameters("@Results_ID").Value = SetNull(Results_ID)
cmd.Parameters.Add("@Marker_ID" , 22 , 255 , "Marker_ID")
cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)
cmd.Parameters.Add("@Assessment_ID" , 22 , 255 , "Assessment_ID")
cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)
cmd.Parameters.Add("@Results" , 6 , 0 , "Results")
cmd.Parameters("@Results").Value = SetNull(Results)
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
cmd.CommandText = "delete from Results where Results_ID=@previous_Results_ID"
cmd.Parameters.Add("@previous_Results_ID", 22, 255, "previous_Results_ID")
cmd.Parameters("@previous_Results_ID").Value = Me.previous_Results_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Results_ID as System.String) As Results
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Results_ID,"
if Display_Marker_ID=true then cmd.CommandText = cmd.CommandText & "Marker_ID,"
if Display_Assessment_ID=true then cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Results=true then cmd.CommandText = cmd.CommandText & "Results,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Results where Results_ID=@Results_ID"
cmd.Parameters.Add("@Results_ID", 22, 255, "Results_ID")
cmd.Parameters("@Results_ID").Value = Results_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Results
For i = 0 To dt.Rows.Count - 1
p.Results_ID=checknull(dt.Rows(i)("Results_ID"))
p.I_Display_Results_ID=Display_Results_ID
if Display_Marker_ID=true then p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
if Display_Assessment_ID=true then p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Results=true then p.Results=checknull(dt.Rows(i)("Results"))
p.I_Display_Results=Display_Results
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
p.previous_Results_ID=checknull(dt.Rows(i)("Results_ID"))
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
cmd.CommandText = "update Results set "
cmd.CommandText =cmd.CommandText & " Results_ID=@Results_ID,"
if I_Display_Marker_ID=true then cmd.CommandText =cmd.CommandText & " Marker_ID=@Marker_ID,"
if I_Display_Assessment_ID=true then cmd.CommandText =cmd.CommandText & " Assessment_ID=@Assessment_ID,"
if I_Display_Results=true then cmd.CommandText =cmd.CommandText & " Results=@Results,"
if I_Display_Student_ID=true then cmd.CommandText =cmd.CommandText & " Student_ID=@Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Results_ID=@previous_Results_ID"


cmd.Parameters.Add("@Results_ID", 22, 255, "Results_ID")
cmd.Parameters("@Results_ID").Value = SetNull(Results_ID)

if I_Display_Marker_ID=true then cmd.Parameters.Add("@Marker_ID", 22, 255, "Marker_ID")
if I_Display_Marker_ID=true then cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)

if I_Display_Assessment_ID=true then cmd.Parameters.Add("@Assessment_ID", 22, 255, "Assessment_ID")
if I_Display_Assessment_ID=true then cmd.Parameters("@Assessment_ID").Value = SetNull(Assessment_ID)

if I_Display_Results=true then cmd.Parameters.Add("@Results", 6, 0, "Results")
if I_Display_Results=true then cmd.Parameters("@Results").Value = SetNull(Results)

if I_Display_Student_ID=true then cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
if I_Display_Student_ID=true then cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)



cmd.Parameters.Add("@previous_Results_ID", 22, 255, "previous_Results_ID")
cmd.Parameters("@previous_Results_ID").Value = Me.previous_Results_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Results)
Dim ps As New Generic.List(Of Results)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Results_ID,"
if Display_Marker_ID=true then cmd.CommandText = cmd.CommandText & "Marker_ID,"
if Display_Assessment_ID=true then cmd.CommandText = cmd.CommandText & "Assessment_ID,"
if Display_Results=true then cmd.CommandText = cmd.CommandText & "Results,"
if Display_Student_ID=true then cmd.CommandText = cmd.CommandText & "Student_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Results " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Results
p.Results_ID=checknull(dt.Rows(i)("Results_ID"))
p.I_Display_Results_ID=Display_Results_ID
if Display_Marker_ID=true then p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
if Display_Assessment_ID=true then p.Assessment_ID=checknull(dt.Rows(i)("Assessment_ID"))
p.I_Display_Assessment_ID=Display_Assessment_ID
if Display_Results=true then p.Results=checknull(dt.Rows(i)("Results"))
p.I_Display_Results=Display_Results
if Display_Student_ID=true then p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
p.previous_Results_ID=checknull(dt.Rows(i)("Results_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Results)
Dim ps As New Generic.List(Of Results)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Results_ID from Results" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Results
p.Results_ID=checknull(dt.Rows(i)("Results_ID"))
p.previous_Results_ID=checknull(dt.Rows(i)("Results_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class