Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Section
inherits Entity

Public Shared Display_Section_ID as Boolean=true
Public Shared Display_Section_Type as Boolean=true

Private I_Display_Section_ID as Boolean=true
Private I_Display_Section_Type as Boolean=true

Public previous_Section_ID as System.String

Public Section_ID as System.String
Public Section_Type as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Section_ID=display_flag
Display_Section_Type=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Section (Section_ID,Section_Type)"
cmd.CommandText = cmd.CommandText & "values(@Section_ID,@Section_Type)"

cmd.Parameters.Add("@Section_ID" , 22 , 255 , "Section_ID")
cmd.Parameters("@Section_ID").Value = SetNull(Section_ID)
cmd.Parameters.Add("@Section_Type" , 22 , 255 , "Section_Type")
cmd.Parameters("@Section_Type").Value = SetNull(Section_Type)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Section where Section_ID=@previous_Section_ID"
cmd.Parameters.Add("@previous_Section_ID", 22, 255, "previous_Section_ID")
cmd.Parameters("@previous_Section_ID").Value = Me.previous_Section_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Section_ID as System.String) As Section
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Section_ID,"
if Display_Section_Type=true then cmd.CommandText = cmd.CommandText & "Section_Type,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Section where Section_ID=@Section_ID"
cmd.Parameters.Add("@Section_ID", 22, 255, "Section_ID")
cmd.Parameters("@Section_ID").Value = Section_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Section
For i = 0 To dt.Rows.Count - 1
p.Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.I_Display_Section_ID=Display_Section_ID
if Display_Section_Type=true then p.Section_Type=checknull(dt.Rows(i)("Section_Type"))
p.I_Display_Section_Type=Display_Section_Type
p.previous_Section_ID=checknull(dt.Rows(i)("Section_ID"))
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
cmd.CommandText = "update Section set "
cmd.CommandText =cmd.CommandText & " Section_ID=@Section_ID,"
if I_Display_Section_Type=true then cmd.CommandText =cmd.CommandText & " Section_Type=@Section_Type,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Section_ID=@previous_Section_ID"


cmd.Parameters.Add("@Section_ID", 22, 255, "Section_ID")
cmd.Parameters("@Section_ID").Value = SetNull(Section_ID)

if I_Display_Section_Type=true then cmd.Parameters.Add("@Section_Type", 22, 255, "Section_Type")
if I_Display_Section_Type=true then cmd.Parameters("@Section_Type").Value = SetNull(Section_Type)



cmd.Parameters.Add("@previous_Section_ID", 22, 255, "previous_Section_ID")
cmd.Parameters("@previous_Section_ID").Value = Me.previous_Section_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Section)
Dim ps As New Generic.List(Of Section)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Section_ID,"
if Display_Section_Type=true then cmd.CommandText = cmd.CommandText & "Section_Type,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Section " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Section
p.Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.I_Display_Section_ID=Display_Section_ID
if Display_Section_Type=true then p.Section_Type=checknull(dt.Rows(i)("Section_Type"))
p.I_Display_Section_Type=Display_Section_Type
p.previous_Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Section)
Dim ps As New Generic.List(Of Section)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Section_ID from Section" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Section
p.Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.previous_Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class