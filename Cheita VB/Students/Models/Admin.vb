Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Admin
inherits Entity

Public Shared Display_Admin_ID as Boolean=true
Public Shared Display_Admin_FirstName as Boolean=true
Public Shared Display_Admin_LastName as Boolean=true
Public Shared Display_Admin_Type as Boolean=true
Public Shared Display_Admin_Email as Boolean=true
Public Shared Display_Admin_Password as Boolean=true

Private I_Display_Admin_ID as Boolean=true
Private I_Display_Admin_FirstName as Boolean=true
Private I_Display_Admin_LastName as Boolean=true
Private I_Display_Admin_Type as Boolean=true
Private I_Display_Admin_Email as Boolean=true
Private I_Display_Admin_Password as Boolean=true

Public previous_Admin_ID as System.String

Public Admin_ID as System.String
Public Admin_FirstName as System.String
Public Admin_LastName as System.String
Public Admin_Type as System.String
Public Admin_Email as System.String
Public Admin_Password as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Admin_ID=display_flag
Display_Admin_FirstName=display_flag
Display_Admin_LastName=display_flag
Display_Admin_Type=display_flag
Display_Admin_Email=display_flag
Display_Admin_Password=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Admin (Admin_ID,Admin_FirstName,Admin_LastName,Admin_Type,Admin_Email,Admin_Password)"
cmd.CommandText = cmd.CommandText & "values(@Admin_ID,@Admin_FirstName,@Admin_LastName,@Admin_Type,@Admin_Email,@Admin_Password)"

cmd.Parameters.Add("@Admin_ID" , 22 , 255 , "Admin_ID")
cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)
cmd.Parameters.Add("@Admin_FirstName" , 22 , 255 , "Admin_FirstName")
cmd.Parameters("@Admin_FirstName").Value = SetNull(Admin_FirstName)
cmd.Parameters.Add("@Admin_LastName" , 22 , 255 , "Admin_LastName")
cmd.Parameters("@Admin_LastName").Value = SetNull(Admin_LastName)
cmd.Parameters.Add("@Admin_Type" , 22 , 255 , "Admin_Type")
cmd.Parameters("@Admin_Type").Value = SetNull(Admin_Type)
cmd.Parameters.Add("@Admin_Email" , 22 , 255 , "Admin_Email")
cmd.Parameters("@Admin_Email").Value = SetNull(Admin_Email)
cmd.Parameters.Add("@Admin_Password" , 22 , 255 , "Admin_Password")
cmd.Parameters("@Admin_Password").Value = SetNull(Admin_Password)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Admin where Admin_ID=@previous_Admin_ID"
cmd.Parameters.Add("@previous_Admin_ID", 22, 255, "previous_Admin_ID")
cmd.Parameters("@previous_Admin_ID").Value = Me.previous_Admin_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Admin_ID as System.String) As Admin
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Admin_FirstName=true then cmd.CommandText = cmd.CommandText & "Admin_FirstName,"
if Display_Admin_LastName=true then cmd.CommandText = cmd.CommandText & "Admin_LastName,"
if Display_Admin_Type=true then cmd.CommandText = cmd.CommandText & "Admin_Type,"
if Display_Admin_Email=true then cmd.CommandText = cmd.CommandText & "Admin_Email,"
if Display_Admin_Password=true then cmd.CommandText = cmd.CommandText & "Admin_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Admin where Admin_ID=@Admin_ID"
cmd.Parameters.Add("@Admin_ID", 22, 255, "Admin_ID")
cmd.Parameters("@Admin_ID").Value = Admin_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Admin
For i = 0 To dt.Rows.Count - 1
p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Admin_FirstName=true then p.Admin_FirstName=checknull(dt.Rows(i)("Admin_FirstName"))
p.I_Display_Admin_FirstName=Display_Admin_FirstName
if Display_Admin_LastName=true then p.Admin_LastName=checknull(dt.Rows(i)("Admin_LastName"))
p.I_Display_Admin_LastName=Display_Admin_LastName
if Display_Admin_Type=true then p.Admin_Type=checknull(dt.Rows(i)("Admin_Type"))
p.I_Display_Admin_Type=Display_Admin_Type
if Display_Admin_Email=true then p.Admin_Email=checknull(dt.Rows(i)("Admin_Email"))
p.I_Display_Admin_Email=Display_Admin_Email
if Display_Admin_Password=true then p.Admin_Password=checknull(dt.Rows(i)("Admin_Password"))
p.I_Display_Admin_Password=Display_Admin_Password
p.previous_Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
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
cmd.CommandText = "update Admin set "
cmd.CommandText =cmd.CommandText & " Admin_ID=@Admin_ID,"
if I_Display_Admin_FirstName=true then cmd.CommandText =cmd.CommandText & " Admin_FirstName=@Admin_FirstName,"
if I_Display_Admin_LastName=true then cmd.CommandText =cmd.CommandText & " Admin_LastName=@Admin_LastName,"
if I_Display_Admin_Type=true then cmd.CommandText =cmd.CommandText & " Admin_Type=@Admin_Type,"
if I_Display_Admin_Email=true then cmd.CommandText =cmd.CommandText & " Admin_Email=@Admin_Email,"
if I_Display_Admin_Password=true then cmd.CommandText =cmd.CommandText & " Admin_Password=@Admin_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Admin_ID=@previous_Admin_ID"


cmd.Parameters.Add("@Admin_ID", 22, 255, "Admin_ID")
cmd.Parameters("@Admin_ID").Value = SetNull(Admin_ID)

if I_Display_Admin_FirstName=true then cmd.Parameters.Add("@Admin_FirstName", 22, 255, "Admin_FirstName")
if I_Display_Admin_FirstName=true then cmd.Parameters("@Admin_FirstName").Value = SetNull(Admin_FirstName)

if I_Display_Admin_LastName=true then cmd.Parameters.Add("@Admin_LastName", 22, 255, "Admin_LastName")
if I_Display_Admin_LastName=true then cmd.Parameters("@Admin_LastName").Value = SetNull(Admin_LastName)

if I_Display_Admin_Type=true then cmd.Parameters.Add("@Admin_Type", 22, 255, "Admin_Type")
if I_Display_Admin_Type=true then cmd.Parameters("@Admin_Type").Value = SetNull(Admin_Type)

if I_Display_Admin_Email=true then cmd.Parameters.Add("@Admin_Email", 22, 255, "Admin_Email")
if I_Display_Admin_Email=true then cmd.Parameters("@Admin_Email").Value = SetNull(Admin_Email)

if I_Display_Admin_Password=true then cmd.Parameters.Add("@Admin_Password", 22, 255, "Admin_Password")
if I_Display_Admin_Password=true then cmd.Parameters("@Admin_Password").Value = SetNull(Admin_Password)



cmd.Parameters.Add("@previous_Admin_ID", 22, 255, "previous_Admin_ID")
cmd.Parameters("@previous_Admin_ID").Value = Me.previous_Admin_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Admin)
Dim ps As New Generic.List(Of Admin)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Admin_ID,"
if Display_Admin_FirstName=true then cmd.CommandText = cmd.CommandText & "Admin_FirstName,"
if Display_Admin_LastName=true then cmd.CommandText = cmd.CommandText & "Admin_LastName,"
if Display_Admin_Type=true then cmd.CommandText = cmd.CommandText & "Admin_Type,"
if Display_Admin_Email=true then cmd.CommandText = cmd.CommandText & "Admin_Email,"
if Display_Admin_Password=true then cmd.CommandText = cmd.CommandText & "Admin_Password,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Admin " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Admin
p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.I_Display_Admin_ID=Display_Admin_ID
if Display_Admin_FirstName=true then p.Admin_FirstName=checknull(dt.Rows(i)("Admin_FirstName"))
p.I_Display_Admin_FirstName=Display_Admin_FirstName
if Display_Admin_LastName=true then p.Admin_LastName=checknull(dt.Rows(i)("Admin_LastName"))
p.I_Display_Admin_LastName=Display_Admin_LastName
if Display_Admin_Type=true then p.Admin_Type=checknull(dt.Rows(i)("Admin_Type"))
p.I_Display_Admin_Type=Display_Admin_Type
if Display_Admin_Email=true then p.Admin_Email=checknull(dt.Rows(i)("Admin_Email"))
p.I_Display_Admin_Email=Display_Admin_Email
if Display_Admin_Password=true then p.Admin_Password=checknull(dt.Rows(i)("Admin_Password"))
p.I_Display_Admin_Password=Display_Admin_Password
p.previous_Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Admin)
Dim ps As New Generic.List(Of Admin)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Admin_ID from Admin" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Admin
p.Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.previous_Admin_ID=checknull(dt.Rows(i)("Admin_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class