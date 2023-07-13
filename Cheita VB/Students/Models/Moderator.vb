Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Moderator
inherits Entity

Public Shared Display_Moderator_ID as Boolean=true
Public Shared Display_Moderator_FirstName as Boolean=true
Public Shared Display_Moderator_LastName as Boolean=true
Public Shared Display_Moderator_Email as Boolean=true
Public Shared Display_Moderator_Password as Boolean=true

Private I_Display_Moderator_ID as Boolean=true
Private I_Display_Moderator_FirstName as Boolean=true
Private I_Display_Moderator_LastName as Boolean=true
Private I_Display_Moderator_Email as Boolean=true
Private I_Display_Moderator_Password as Boolean=true

Public previous_Moderator_ID as System.String

Public Moderator_ID as System.String
Public Moderator_FirstName as System.String
Public Moderator_LastName as System.String
Public Moderator_Email as System.String
Public Moderator_Password as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Moderator_ID=display_flag
Display_Moderator_FirstName=display_flag
Display_Moderator_LastName=display_flag
Display_Moderator_Email=display_flag
Display_Moderator_Password=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Moderator (Moderator_ID,Moderator_FirstName,Moderator_LastName,Moderator_Email,Moderator_Password)"
cmd.CommandText = cmd.CommandText & "values(@Moderator_ID,@Moderator_FirstName,@Moderator_LastName,@Moderator_Email,@Moderator_Password)"

cmd.Parameters.Add("@Moderator_ID" , 22 , 255 , "Moderator_ID")
cmd.Parameters("@Moderator_ID").Value = SetNull(Moderator_ID)
cmd.Parameters.Add("@Moderator_FirstName" , 22 , 255 , "Moderator_FirstName")
cmd.Parameters("@Moderator_FirstName").Value = SetNull(Moderator_FirstName)
cmd.Parameters.Add("@Moderator_LastName" , 22 , 255 , "Moderator_LastName")
cmd.Parameters("@Moderator_LastName").Value = SetNull(Moderator_LastName)
cmd.Parameters.Add("@Moderator_Email" , 22 , 255 , "Moderator_Email")
cmd.Parameters("@Moderator_Email").Value = SetNull(Moderator_Email)
cmd.Parameters.Add("@Moderator_Password" , 22 , 255 , "Moderator_Password")
cmd.Parameters("@Moderator_Password").Value = SetNull(Moderator_Password)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Moderator where Moderator_ID=@previous_Moderator_ID"
cmd.Parameters.Add("@previous_Moderator_ID", 22, 255, "previous_Moderator_ID")
cmd.Parameters("@previous_Moderator_ID").Value = Me.previous_Moderator_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Moderator_ID as System.String) As Moderator
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Moderator_ID,"
if Display_Moderator_FirstName=true then cmd.CommandText = cmd.CommandText & "Moderator_FirstName,"
if Display_Moderator_LastName=true then cmd.CommandText = cmd.CommandText & "Moderator_LastName,"
if Display_Moderator_Email=true then cmd.CommandText = cmd.CommandText & "Moderator_Email,"
if Display_Moderator_Password=true then cmd.CommandText = cmd.CommandText & "Moderator_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Moderator where Moderator_ID=@Moderator_ID"
cmd.Parameters.Add("@Moderator_ID", 22, 255, "Moderator_ID")
cmd.Parameters("@Moderator_ID").Value = Moderator_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Moderator
For i = 0 To dt.Rows.Count - 1
p.Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
p.I_Display_Moderator_ID=Display_Moderator_ID
if Display_Moderator_FirstName=true then p.Moderator_FirstName=checknull(dt.Rows(i)("Moderator_FirstName"))
p.I_Display_Moderator_FirstName=Display_Moderator_FirstName
if Display_Moderator_LastName=true then p.Moderator_LastName=checknull(dt.Rows(i)("Moderator_LastName"))
p.I_Display_Moderator_LastName=Display_Moderator_LastName
if Display_Moderator_Email=true then p.Moderator_Email=checknull(dt.Rows(i)("Moderator_Email"))
p.I_Display_Moderator_Email=Display_Moderator_Email
if Display_Moderator_Password=true then p.Moderator_Password=checknull(dt.Rows(i)("Moderator_Password"))
p.I_Display_Moderator_Password=Display_Moderator_Password
p.previous_Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
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
cmd.CommandText = "update Moderator set "
cmd.CommandText =cmd.CommandText & " Moderator_ID=@Moderator_ID,"
if I_Display_Moderator_FirstName=true then cmd.CommandText =cmd.CommandText & " Moderator_FirstName=@Moderator_FirstName,"
if I_Display_Moderator_LastName=true then cmd.CommandText =cmd.CommandText & " Moderator_LastName=@Moderator_LastName,"
if I_Display_Moderator_Email=true then cmd.CommandText =cmd.CommandText & " Moderator_Email=@Moderator_Email,"
if I_Display_Moderator_Password=true then cmd.CommandText =cmd.CommandText & " Moderator_Password=@Moderator_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Moderator_ID=@previous_Moderator_ID"


cmd.Parameters.Add("@Moderator_ID", 22, 255, "Moderator_ID")
cmd.Parameters("@Moderator_ID").Value = SetNull(Moderator_ID)

if I_Display_Moderator_FirstName=true then cmd.Parameters.Add("@Moderator_FirstName", 22, 255, "Moderator_FirstName")
if I_Display_Moderator_FirstName=true then cmd.Parameters("@Moderator_FirstName").Value = SetNull(Moderator_FirstName)

if I_Display_Moderator_LastName=true then cmd.Parameters.Add("@Moderator_LastName", 22, 255, "Moderator_LastName")
if I_Display_Moderator_LastName=true then cmd.Parameters("@Moderator_LastName").Value = SetNull(Moderator_LastName)

if I_Display_Moderator_Email=true then cmd.Parameters.Add("@Moderator_Email", 22, 255, "Moderator_Email")
if I_Display_Moderator_Email=true then cmd.Parameters("@Moderator_Email").Value = SetNull(Moderator_Email)

if I_Display_Moderator_Password=true then cmd.Parameters.Add("@Moderator_Password", 22, 255, "Moderator_Password")
if I_Display_Moderator_Password=true then cmd.Parameters("@Moderator_Password").Value = SetNull(Moderator_Password)



cmd.Parameters.Add("@previous_Moderator_ID", 22, 255, "previous_Moderator_ID")
cmd.Parameters("@previous_Moderator_ID").Value = Me.previous_Moderator_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Moderator)
Dim ps As New Generic.List(Of Moderator)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Moderator_ID,"
if Display_Moderator_FirstName=true then cmd.CommandText = cmd.CommandText & "Moderator_FirstName,"
if Display_Moderator_LastName=true then cmd.CommandText = cmd.CommandText & "Moderator_LastName,"
if Display_Moderator_Email=true then cmd.CommandText = cmd.CommandText & "Moderator_Email,"
if Display_Moderator_Password=true then cmd.CommandText = cmd.CommandText & "Moderator_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Moderator " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Moderator
p.Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
p.I_Display_Moderator_ID=Display_Moderator_ID
if Display_Moderator_FirstName=true then p.Moderator_FirstName=checknull(dt.Rows(i)("Moderator_FirstName"))
p.I_Display_Moderator_FirstName=Display_Moderator_FirstName
if Display_Moderator_LastName=true then p.Moderator_LastName=checknull(dt.Rows(i)("Moderator_LastName"))
p.I_Display_Moderator_LastName=Display_Moderator_LastName
if Display_Moderator_Email=true then p.Moderator_Email=checknull(dt.Rows(i)("Moderator_Email"))
p.I_Display_Moderator_Email=Display_Moderator_Email
if Display_Moderator_Password=true then p.Moderator_Password=checknull(dt.Rows(i)("Moderator_Password"))
p.I_Display_Moderator_Password=Display_Moderator_Password
p.previous_Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Moderator)
Dim ps As New Generic.List(Of Moderator)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Moderator_ID from Moderator" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Moderator
p.Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
p.previous_Moderator_ID=checknull(dt.Rows(i)("Moderator_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class