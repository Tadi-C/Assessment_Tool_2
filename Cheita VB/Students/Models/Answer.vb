Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Answer
inherits ENTITY

    Public Shared Display_Answer_ID As Boolean = True
    Public Shared Display_Answer_Text As Boolean = True
    Public Shared Display_Answer_Mark As Boolean = True
    Public Shared Display_Answer_Image As Boolean = True

    Private I_Display_Answer_ID As Boolean = True
    Private I_Display_Answer_Text As Boolean = True
    Private I_Display_Answer_Mark As Boolean = True
    Private I_Display_Answer_Image As Boolean = True

    Public previous_Answer_ID As System.String

    Public Answer_ID As System.String
    Public Answer_Text As System.String
    Public Answer_Mark As System.String
    Public Answer_Image As System.String
    Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
        Display_Answer_ID = display_flag
        Display_Answer_Text = display_flag
        Display_Answer_Mark = display_flag
        Display_Answer_Image = display_flag
    End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Answer (Answer_ID,Answer_Text,Answer_Mark)"
cmd.CommandText = cmd.CommandText & "values(@Answer_ID,@Answer_Text,@Answer_Mark)"

cmd.Parameters.Add("@Answer_ID" , 22 , 255 , "Answer_ID")
cmd.Parameters("@Answer_ID").Value = SetNull(Answer_ID)
        cmd.Parameters.Add("@Answer_Text", 22, 65535, "Answer_Text")
        cmd.Parameters("@Answer_Text").Value = SetNull(Answer_Text)
cmd.Parameters.Add("@Answer_Mark" , 22 , 255 , "Answer_Mark")
        cmd.Parameters("@Answer_Mark").Value = setNull(Answer_Mark)
        cmd.Parameters.Add("@Answer_Image", 22, 65535, "Answer_Image")
        cmd.Parameters("@Answer_Image").Value = setNull(Answer_Image)


        cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Answer where Answer_ID=@previous_Answer_ID"
cmd.Parameters.Add("@previous_Answer_ID", 22, 255, "previous_Answer_ID")
cmd.Parameters("@previous_Answer_ID").Value = Me.previous_Answer_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Answer_ID as System.String) As Answer
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Answer_ID,"
        If Display_Answer_Text = True Then cmd.CommandText = cmd.CommandText & "Answer_Text,"
        If Display_Answer_Mark = True Then cmd.CommandText = cmd.CommandText & "Answer_Mark,"
        If Display_Answer_Image = True Then cmd.CommandText = cmd.CommandText & "Answer_Image,"

        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Answer where Answer_ID=@Answer_ID"
cmd.Parameters.Add("@Answer_ID", 22, 255, "Answer_ID")
cmd.Parameters("@Answer_ID").Value = Answer_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Answer
For i = 0 To dt.Rows.Count - 1
p.Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
p.I_Display_Answer_ID=Display_Answer_ID
if Display_Answer_Text=true then p.Answer_Text=checknull(dt.Rows(i)("Answer_Text"))
p.I_Display_Answer_Text=Display_Answer_Text
if Display_Answer_Mark=true then p.Answer_Mark=checknull(dt.Rows(i)("Answer_Mark"))
            p.I_Display_Answer_Mark = Display_Answer_Mark
            If Display_Answer_Image = True Then p.Answer_Image = checkNull(dt.Rows(i)("Answer_Image"))
            p.I_Display_Answer_Image = Display_Answer_Image
            p.previous_Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
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
cmd.CommandText = "update Answer set "
        cmd.CommandText = cmd.CommandText & " Answer_ID=@Answer_ID,"
        If I_Display_Answer_Text = True Then cmd.CommandText = cmd.CommandText & " Answer_Text=@Answer_Text,"
        If I_Display_Answer_Mark = True Then cmd.CommandText = cmd.CommandText & " Answer_Mark=@Answer_Mark,"
        If I_Display_Answer_Image = True Then cmd.CommandText = cmd.CommandText & " Answer_Image=@Answer_Image"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
        cmd.CommandText = cmd.CommandText & " where Answer_ID=@previous_Answer_ID"



        cmd.Parameters.Add("@Answer_ID", 22, 255, "Answer_ID")
        cmd.Parameters("@Answer_ID").Value = setNull(Answer_ID)


        If I_Display_Answer_Text = True Then cmd.Parameters.Add("@Answer_Text", 22, 65535, "Answer_Text")
        If I_Display_Answer_Text = True Then cmd.Parameters("@Answer_Text").Value = setNull(Answer_Text)


        If I_Display_Answer_Mark = True Then cmd.Parameters.Add("@Answer_Mark", 22, 255, "Answer_Mark")
        If I_Display_Answer_Mark = True Then cmd.Parameters("@Answer_Mark").Value = setNull(Answer_Mark)

        If I_Display_Answer_Image = True Then cmd.Parameters.Add("@Answer_Image", 22, 65535, "Answer_Image")
        If I_Display_Answer_Image = True Then cmd.Parameters("@Answer_Image").Value = setNull(Answer_Image)

        cmd.Parameters.Add("@previous_Answer_ID", 22, 255, "previous_Answer_ID")
        cmd.Parameters("@previous_Answer_ID").Value = Me.previous_Answer_ID




        cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Answer)
Dim ps As New Generic.List(Of Answer)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Answer_ID,"
        If Display_Answer_Text = True Then cmd.CommandText = cmd.CommandText & "Answer_Text,"
        If Display_Answer_Mark = True Then cmd.CommandText = cmd.CommandText & "Answer_Mark,"
        If Display_Answer_Image = True Then cmd.CommandText = cmd.CommandText & "Answer_Image"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Answer " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Answer
            p.Answer_ID = checkNull(dt.Rows(i)("Answer_ID"))
            p.I_Display_Answer_ID = Display_Answer_ID
            If Display_Answer_Text = True Then p.Answer_Text = checkNull(dt.Rows(i)("Answer_Text"))
            p.I_Display_Answer_Text = Display_Answer_Text
            If Display_Answer_Mark=true then p.Answer_Mark=checknull(dt.Rows(i)("Answer_Mark"))
            p.I_Display_Answer_Mark = Display_Answer_Mark
            If Display_Answer_Image = True Then p.Answer_Image = checkNull(dt.Rows(i)("Answer_Image"))
            p.I_Display_Answer_Image = Display_Answer_Image
            p.previous_Answer_ID = checkNull(dt.Rows(i)("Answer_ID"))
            p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Answer)
Dim ps As New Generic.List(Of Answer)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Answer_ID from Answer" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Answer
p.Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
p.previous_Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class