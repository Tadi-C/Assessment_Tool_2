Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Marker
inherits Entity

Public Shared Display_Marker_ID as Boolean=true
Public Shared Display_Marker_FirstName as Boolean=true
Public Shared Display_Marker_LastName as Boolean=true
Public Shared Display_Marker_Email as Boolean=true
Public Shared Display_Marker_Password as Boolean=true

Private I_Display_Marker_ID as Boolean=true
Private I_Display_Marker_FirstName as Boolean=true
Private I_Display_Marker_LastName as Boolean=true
Private I_Display_Marker_Email as Boolean=true
Private I_Display_Marker_Password as Boolean=true

Public previous_Marker_ID as System.String

Public Marker_ID as System.String
Public Marker_FirstName as System.String
Public Marker_LastName as System.String
Public Marker_Email as System.String
Public Marker_Password as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Marker_ID=display_flag
Display_Marker_FirstName=display_flag
Display_Marker_LastName=display_flag
Display_Marker_Email=display_flag
Display_Marker_Password=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Marker (Marker_ID,Marker_FirstName,Marker_LastName,Marker_Email,Marker_Password)"
cmd.CommandText = cmd.CommandText & "values(@Marker_ID,@Marker_FirstName,@Marker_LastName,@Marker_Email,@Marker_Password)"

cmd.Parameters.Add("@Marker_ID" , 22 , 255 , "Marker_ID")
cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)
cmd.Parameters.Add("@Marker_FirstName" , 22 , 255 , "Marker_FirstName")
cmd.Parameters("@Marker_FirstName").Value = SetNull(Marker_FirstName)
cmd.Parameters.Add("@Marker_LastName" , 22 , 255 , "Marker_LastName")
cmd.Parameters("@Marker_LastName").Value = SetNull(Marker_LastName)
cmd.Parameters.Add("@Marker_Email" , 22 , 255 , "Marker_Email")
cmd.Parameters("@Marker_Email").Value = SetNull(Marker_Email)
cmd.Parameters.Add("@Marker_Password" , 22 , 255 , "Marker_Password")
cmd.Parameters("@Marker_Password").Value = SetNull(Marker_Password)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Marker where Marker_ID=@previous_Marker_ID"
cmd.Parameters.Add("@previous_Marker_ID", 22, 255, "previous_Marker_ID")
cmd.Parameters("@previous_Marker_ID").Value = Me.previous_Marker_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Marker_ID as System.String) As Marker
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Marker_ID,"
if Display_Marker_FirstName=true then cmd.CommandText = cmd.CommandText & "Marker_FirstName,"
if Display_Marker_LastName=true then cmd.CommandText = cmd.CommandText & "Marker_LastName,"
if Display_Marker_Email=true then cmd.CommandText = cmd.CommandText & "Marker_Email,"
if Display_Marker_Password=true then cmd.CommandText = cmd.CommandText & "Marker_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Marker where Marker_ID=@Marker_ID"
cmd.Parameters.Add("@Marker_ID", 22, 255, "Marker_ID")
cmd.Parameters("@Marker_ID").Value = Marker_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Marker
For i = 0 To dt.Rows.Count - 1
p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
if Display_Marker_FirstName=true then p.Marker_FirstName=checknull(dt.Rows(i)("Marker_FirstName"))
p.I_Display_Marker_FirstName=Display_Marker_FirstName
if Display_Marker_LastName=true then p.Marker_LastName=checknull(dt.Rows(i)("Marker_LastName"))
p.I_Display_Marker_LastName=Display_Marker_LastName
if Display_Marker_Email=true then p.Marker_Email=checknull(dt.Rows(i)("Marker_Email"))
p.I_Display_Marker_Email=Display_Marker_Email
if Display_Marker_Password=true then p.Marker_Password=checknull(dt.Rows(i)("Marker_Password"))
p.I_Display_Marker_Password=Display_Marker_Password
p.previous_Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
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
cmd.CommandText = "update Marker set "
cmd.CommandText =cmd.CommandText & " Marker_ID=@Marker_ID,"
if I_Display_Marker_FirstName=true then cmd.CommandText =cmd.CommandText & " Marker_FirstName=@Marker_FirstName,"
if I_Display_Marker_LastName=true then cmd.CommandText =cmd.CommandText & " Marker_LastName=@Marker_LastName,"
if I_Display_Marker_Email=true then cmd.CommandText =cmd.CommandText & " Marker_Email=@Marker_Email,"
if I_Display_Marker_Password=true then cmd.CommandText =cmd.CommandText & " Marker_Password=@Marker_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Marker_ID=@previous_Marker_ID"


cmd.Parameters.Add("@Marker_ID", 22, 255, "Marker_ID")
cmd.Parameters("@Marker_ID").Value = SetNull(Marker_ID)

if I_Display_Marker_FirstName=true then cmd.Parameters.Add("@Marker_FirstName", 22, 255, "Marker_FirstName")
if I_Display_Marker_FirstName=true then cmd.Parameters("@Marker_FirstName").Value = SetNull(Marker_FirstName)

if I_Display_Marker_LastName=true then cmd.Parameters.Add("@Marker_LastName", 22, 255, "Marker_LastName")
if I_Display_Marker_LastName=true then cmd.Parameters("@Marker_LastName").Value = SetNull(Marker_LastName)

if I_Display_Marker_Email=true then cmd.Parameters.Add("@Marker_Email", 22, 255, "Marker_Email")
if I_Display_Marker_Email=true then cmd.Parameters("@Marker_Email").Value = SetNull(Marker_Email)

if I_Display_Marker_Password=true then cmd.Parameters.Add("@Marker_Password", 22, 255, "Marker_Password")
if I_Display_Marker_Password=true then cmd.Parameters("@Marker_Password").Value = SetNull(Marker_Password)



cmd.Parameters.Add("@previous_Marker_ID", 22, 255, "previous_Marker_ID")
cmd.Parameters("@previous_Marker_ID").Value = Me.previous_Marker_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Marker)
Dim ps As New Generic.List(Of Marker)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Marker_ID,"
if Display_Marker_FirstName=true then cmd.CommandText = cmd.CommandText & "Marker_FirstName,"
if Display_Marker_LastName=true then cmd.CommandText = cmd.CommandText & "Marker_LastName,"
if Display_Marker_Email=true then cmd.CommandText = cmd.CommandText & "Marker_Email,"
if Display_Marker_Password=true then cmd.CommandText = cmd.CommandText & "Marker_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Marker " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Marker
p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.I_Display_Marker_ID=Display_Marker_ID
if Display_Marker_FirstName=true then p.Marker_FirstName=checknull(dt.Rows(i)("Marker_FirstName"))
p.I_Display_Marker_FirstName=Display_Marker_FirstName
if Display_Marker_LastName=true then p.Marker_LastName=checknull(dt.Rows(i)("Marker_LastName"))
p.I_Display_Marker_LastName=Display_Marker_LastName
if Display_Marker_Email=true then p.Marker_Email=checknull(dt.Rows(i)("Marker_Email"))
p.I_Display_Marker_Email=Display_Marker_Email
if Display_Marker_Password=true then p.Marker_Password=checknull(dt.Rows(i)("Marker_Password"))
p.I_Display_Marker_Password=Display_Marker_Password
p.previous_Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Marker)
Dim ps As New Generic.List(Of Marker)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Marker_ID from Marker" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Marker
p.Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.previous_Marker_ID=checknull(dt.Rows(i)("Marker_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class