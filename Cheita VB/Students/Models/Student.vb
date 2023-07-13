Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Student
inherits Entity

Public Shared Display_Student_ID as Boolean=true
Public Shared Display_Student_FirstName as Boolean=true
Public Shared Display_Student_LastName as Boolean=true
Public Shared Display_Student_Type as Boolean=true
Public Shared Display_Student_Email as Boolean=true
Public Shared Display_Student_Password as Boolean=true
Public Shared Display_Student_IDNumber as Boolean=true

Private I_Display_Student_ID as Boolean=true
Private I_Display_Student_FirstName as Boolean=true
Private I_Display_Student_LastName as Boolean=true
Private I_Display_Student_Type as Boolean=true
Private I_Display_Student_Email as Boolean=true
Private I_Display_Student_Password as Boolean=true
Private I_Display_Student_IDNumber as Boolean=true

Public previous_Student_ID as System.String

Public Student_ID as System.String
Public Student_FirstName as System.String
Public Student_LastName as System.String
Public Student_Type as System.String
Public Student_Email as System.String
Public Student_Password as System.String
Public Student_IDNumber as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Student_ID=display_flag
Display_Student_FirstName=display_flag
Display_Student_LastName=display_flag
Display_Student_Type=display_flag
Display_Student_Email=display_flag
Display_Student_Password=display_flag
Display_Student_IDNumber=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Student (Student_ID,Student_FirstName,Student_LastName,Student_Type,Student_Email,Student_Password,Student_IDNumber)"
cmd.CommandText = cmd.CommandText & "values(@Student_ID,@Student_FirstName,@Student_LastName,@Student_Type,@Student_Email,@Student_Password,@Student_IDNumber)"

cmd.Parameters.Add("@Student_ID" , 22 , 255 , "Student_ID")
cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)
cmd.Parameters.Add("@Student_FirstName" , 22 , 255 , "Student_FirstName")
cmd.Parameters("@Student_FirstName").Value = SetNull(Student_FirstName)
cmd.Parameters.Add("@Student_LastName" , 22 , 255 , "Student_LastName")
cmd.Parameters("@Student_LastName").Value = SetNull(Student_LastName)
cmd.Parameters.Add("@Student_Type" , 22 , 255 , "Student_Type")
cmd.Parameters("@Student_Type").Value = SetNull(Student_Type)
cmd.Parameters.Add("@Student_Email" , 22 , 255 , "Student_Email")
cmd.Parameters("@Student_Email").Value = SetNull(Student_Email)
cmd.Parameters.Add("@Student_Password" , 22 , 255 , "Student_Password")
cmd.Parameters("@Student_Password").Value = SetNull(Student_Password)
cmd.Parameters.Add("@Student_IDNumber" , 22 , 255 , "Student_IDNumber")
cmd.Parameters("@Student_IDNumber").Value = SetNull(Student_IDNumber)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Student where Student_ID=@previous_Student_ID"
cmd.Parameters.Add("@previous_Student_ID", 22, 255, "previous_Student_ID")
cmd.Parameters("@previous_Student_ID").Value = Me.previous_Student_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Student_ID as System.String) As Student
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Student_FirstName=true then cmd.CommandText = cmd.CommandText & "Student_FirstName,"
if Display_Student_LastName=true then cmd.CommandText = cmd.CommandText & "Student_LastName,"
if Display_Student_Type=true then cmd.CommandText = cmd.CommandText & "Student_Type,"
if Display_Student_Email=true then cmd.CommandText = cmd.CommandText & "Student_Email,"
if Display_Student_Password=true then cmd.CommandText = cmd.CommandText & "Student_Password,"
if Display_Student_IDNumber=true then cmd.CommandText = cmd.CommandText & "Student_IDNumber,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Student where Student_ID=@Student_ID"
cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
cmd.Parameters("@Student_ID").Value = Student_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Student
For i = 0 To dt.Rows.Count - 1
p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Student_FirstName=true then p.Student_FirstName=checknull(dt.Rows(i)("Student_FirstName"))
p.I_Display_Student_FirstName=Display_Student_FirstName
if Display_Student_LastName=true then p.Student_LastName=checknull(dt.Rows(i)("Student_LastName"))
p.I_Display_Student_LastName=Display_Student_LastName
if Display_Student_Type=true then p.Student_Type=checknull(dt.Rows(i)("Student_Type"))
p.I_Display_Student_Type=Display_Student_Type
if Display_Student_Email=true then p.Student_Email=checknull(dt.Rows(i)("Student_Email"))
p.I_Display_Student_Email=Display_Student_Email
if Display_Student_Password=true then p.Student_Password=checknull(dt.Rows(i)("Student_Password"))
p.I_Display_Student_Password=Display_Student_Password
if Display_Student_IDNumber=true then p.Student_IDNumber=checknull(dt.Rows(i)("Student_IDNumber"))
p.I_Display_Student_IDNumber=Display_Student_IDNumber
p.previous_Student_ID=checknull(dt.Rows(i)("Student_ID"))
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
cmd.CommandText = "update Student set "
cmd.CommandText =cmd.CommandText & " Student_ID=@Student_ID,"
if I_Display_Student_FirstName=true then cmd.CommandText =cmd.CommandText & " Student_FirstName=@Student_FirstName,"
if I_Display_Student_LastName=true then cmd.CommandText =cmd.CommandText & " Student_LastName=@Student_LastName,"
if I_Display_Student_Type=true then cmd.CommandText =cmd.CommandText & " Student_Type=@Student_Type,"
if I_Display_Student_Email=true then cmd.CommandText =cmd.CommandText & " Student_Email=@Student_Email,"
if I_Display_Student_Password=true then cmd.CommandText =cmd.CommandText & " Student_Password=@Student_Password,"
if I_Display_Student_IDNumber=true then cmd.CommandText =cmd.CommandText & " Student_IDNumber=@Student_IDNumber,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Student_ID=@previous_Student_ID"


cmd.Parameters.Add("@Student_ID", 22, 255, "Student_ID")
cmd.Parameters("@Student_ID").Value = SetNull(Student_ID)

if I_Display_Student_FirstName=true then cmd.Parameters.Add("@Student_FirstName", 22, 255, "Student_FirstName")
if I_Display_Student_FirstName=true then cmd.Parameters("@Student_FirstName").Value = SetNull(Student_FirstName)

if I_Display_Student_LastName=true then cmd.Parameters.Add("@Student_LastName", 22, 255, "Student_LastName")
if I_Display_Student_LastName=true then cmd.Parameters("@Student_LastName").Value = SetNull(Student_LastName)

if I_Display_Student_Type=true then cmd.Parameters.Add("@Student_Type", 22, 255, "Student_Type")
if I_Display_Student_Type=true then cmd.Parameters("@Student_Type").Value = SetNull(Student_Type)

if I_Display_Student_Email=true then cmd.Parameters.Add("@Student_Email", 22, 255, "Student_Email")
if I_Display_Student_Email=true then cmd.Parameters("@Student_Email").Value = SetNull(Student_Email)

if I_Display_Student_Password=true then cmd.Parameters.Add("@Student_Password", 22, 255, "Student_Password")
if I_Display_Student_Password=true then cmd.Parameters("@Student_Password").Value = SetNull(Student_Password)

if I_Display_Student_IDNumber=true then cmd.Parameters.Add("@Student_IDNumber", 22, 255, "Student_IDNumber")
if I_Display_Student_IDNumber=true then cmd.Parameters("@Student_IDNumber").Value = SetNull(Student_IDNumber)



cmd.Parameters.Add("@previous_Student_ID", 22, 255, "previous_Student_ID")
cmd.Parameters("@previous_Student_ID").Value = Me.previous_Student_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Student)
Dim ps As New Generic.List(Of Student)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Student_ID,"
if Display_Student_FirstName=true then cmd.CommandText = cmd.CommandText & "Student_FirstName,"
if Display_Student_LastName=true then cmd.CommandText = cmd.CommandText & "Student_LastName,"
if Display_Student_Type=true then cmd.CommandText = cmd.CommandText & "Student_Type,"
if Display_Student_Email=true then cmd.CommandText = cmd.CommandText & "Student_Email,"
if Display_Student_Password=true then cmd.CommandText = cmd.CommandText & "Student_Password,"
if Display_Student_IDNumber=true then cmd.CommandText = cmd.CommandText & "Student_IDNumber,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Student " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Student
p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.I_Display_Student_ID=Display_Student_ID
if Display_Student_FirstName=true then p.Student_FirstName=checknull(dt.Rows(i)("Student_FirstName"))
p.I_Display_Student_FirstName=Display_Student_FirstName
if Display_Student_LastName=true then p.Student_LastName=checknull(dt.Rows(i)("Student_LastName"))
p.I_Display_Student_LastName=Display_Student_LastName
if Display_Student_Type=true then p.Student_Type=checknull(dt.Rows(i)("Student_Type"))
p.I_Display_Student_Type=Display_Student_Type
if Display_Student_Email=true then p.Student_Email=checknull(dt.Rows(i)("Student_Email"))
p.I_Display_Student_Email=Display_Student_Email
if Display_Student_Password=true then p.Student_Password=checknull(dt.Rows(i)("Student_Password"))
p.I_Display_Student_Password=Display_Student_Password
if Display_Student_IDNumber=true then p.Student_IDNumber=checknull(dt.Rows(i)("Student_IDNumber"))
p.I_Display_Student_IDNumber=Display_Student_IDNumber
p.previous_Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Student)
Dim ps As New Generic.List(Of Student)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Student_ID from Student" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Student
p.Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.previous_Student_ID=checknull(dt.Rows(i)("Student_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class