Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Question_Bank
inherits ENTITY

    Public Shared Display_Question_ID As Boolean = True
    Public Shared Display_Question_Text As Boolean = True
    Public Shared Display_Question_CaseStudy As Boolean = True
    Public Shared Display_Question_Image As Boolean = True
    Public Shared Display_Question_Option1 As Boolean = True
    Public Shared Display_Question_Option2 As Boolean = True
    Public Shared Display_Question_Option3 As Boolean = True
    Public Shared Display_Question_Option4 As Boolean = True
    Public Shared Display_Question_Mark As Boolean = True
    Public Shared Display_Answer_ID As Boolean = True
    Public Shared Display_Category_ID As Boolean = True
    Public Shared Display_Section_ID As Boolean = True

    Private I_Display_Question_ID as Boolean=true
Private I_Display_Question_Text as Boolean=true
Private I_Display_Question_CaseStudy as Boolean=true
Private I_Display_Question_Image as Boolean=true
Private I_Display_Question_Option1 as Boolean=true
Private I_Display_Question_Option2 as Boolean=true
Private I_Display_Question_Option3 as Boolean=true
Private I_Display_Question_Option4 as Boolean=true
Private I_Display_Question_Mark as Boolean=true
Private I_Display_Answer_ID as Boolean=True
    Private I_Display_Category_ID As Boolean = True
    Private I_Display_Section_ID As Boolean = True

    Public previous_Question_ID as System.String

Public Question_ID as System.String
Public Question_Text as System.String
Public Question_CaseStudy as System.String
Public Question_Image as System.String
Public Question_Option1 as System.String
Public Question_Option2 as System.String
Public Question_Option3 as System.String
Public Question_Option4 as System.String
Public Question_Mark as System.String
Public Answer_ID as System.String
    Public Category_ID As System.String
    Public Section_ID
    Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_Question_ID=display_flag
Display_Question_Text=display_flag
Display_Question_CaseStudy=display_flag
Display_Question_Image=display_flag
Display_Question_Option1=display_flag
Display_Question_Option2=display_flag
Display_Question_Option3=display_flag
Display_Question_Option4=display_flag
Display_Question_Mark=display_flag
Display_Answer_ID=display_flag
        Display_Category_ID = display_flag
        Display_Section_ID = display_flag
    End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Question_Bank (Question_ID,Question_Text,Question_CaseStudy,Question_Image,Question_Option1,Question_Option2,Question_Option3,Question_Option4,Question_Mark,Answer_ID,Category_ID, Section_ID)"
        cmd.CommandText = cmd.CommandText & "values(@Question_ID,@Question_Text,@Question_CaseStudy,@Question_Image,@Question_Option1,@Question_Option2,@Question_Option3,@Question_Option4,@Question_Mark,@Answer_ID,@Category_ID, @Section_ID)"

        cmd.Parameters.Add("@Question_ID" , 22 , 255 , "Question_ID")
cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)
        cmd.Parameters.Add("@Question_Text", 22, 65535, "Question_Text")
        cmd.Parameters("@Question_Text").Value = SetNull(Question_Text)
        cmd.Parameters.Add("@Question_CaseStudy", 22, 65535, "Question_CaseStudy")
        cmd.Parameters("@Question_CaseStudy").Value = SetNull(Question_CaseStudy)
cmd.Parameters.Add("@Question_Image" , 22 , 255 , "Question_Image")
cmd.Parameters("@Question_Image").Value = SetNull(Question_Image)
cmd.Parameters.Add("@Question_Option1" , 22 , 255 , "Question_Option1")
cmd.Parameters("@Question_Option1").Value = SetNull(Question_Option1)
cmd.Parameters.Add("@Question_Option2" , 22 , 255 , "Question_Option2")
cmd.Parameters("@Question_Option2").Value = SetNull(Question_Option2)
cmd.Parameters.Add("@Question_Option3" , 22 , 255 , "Question_Option3")
cmd.Parameters("@Question_Option3").Value = SetNull(Question_Option3)
cmd.Parameters.Add("@Question_Option4" , 22 , 255 , "Question_Option4")
cmd.Parameters("@Question_Option4").Value = SetNull(Question_Option4)
cmd.Parameters.Add("@Question_Mark" , 22 , 255 , "Question_Mark")
cmd.Parameters("@Question_Mark").Value = SetNull(Question_Mark)
cmd.Parameters.Add("@Answer_ID" , 22 , 255 , "Answer_ID")
cmd.Parameters("@Answer_ID").Value = SetNull(Answer_ID)
cmd.Parameters.Add("@Category_ID" , 22 , 255 , "Category_ID")
        cmd.Parameters("@Category_ID").Value = setNull(Category_ID)
        cmd.Parameters.Add("@Section_ID", 22, 255, "Section_ID")
        cmd.Parameters("@Section_ID").Value = setNull(Section_ID)


        cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Question_Bank where Question_ID=@previous_Question_ID"
cmd.Parameters.Add("@previous_Question_ID", 22, 255, "previous_Question_ID")
cmd.Parameters("@previous_Question_ID").Value = Me.previous_Question_ID

cmd.ExecuteNonQuery()
End Sub


Shared Function load(Question_ID as System.String) As Question_Bank
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Question_ID,"
if Display_Question_Text=true then cmd.CommandText = cmd.CommandText & "Question_Text,"
if Display_Question_CaseStudy=true then cmd.CommandText = cmd.CommandText & "Question_CaseStudy,"
if Display_Question_Image=true then cmd.CommandText = cmd.CommandText & "Question_Image,"
if Display_Question_Option1=true then cmd.CommandText = cmd.CommandText & "Question_Option1,"
if Display_Question_Option2=true then cmd.CommandText = cmd.CommandText & "Question_Option2,"
if Display_Question_Option3=true then cmd.CommandText = cmd.CommandText & "Question_Option3,"
if Display_Question_Option4=true then cmd.CommandText = cmd.CommandText & "Question_Option4,"
if Display_Question_Mark=true then cmd.CommandText = cmd.CommandText & "Question_Mark,"
if Display_Answer_ID=true then cmd.CommandText = cmd.CommandText & "Answer_ID,"
        If Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & "Section_ID,"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Bank where Question_ID=@Question_ID"
cmd.Parameters.Add("@Question_ID", 22, 255, "Question_ID")
cmd.Parameters("@Question_ID").Value = Question_ID

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Question_Bank
For i = 0 To dt.Rows.Count - 1
p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
if Display_Question_Text=true then p.Question_Text=checknull(dt.Rows(i)("Question_Text"))
p.I_Display_Question_Text=Display_Question_Text
if Display_Question_CaseStudy=true then p.Question_CaseStudy=checknull(dt.Rows(i)("Question_CaseStudy"))
p.I_Display_Question_CaseStudy=Display_Question_CaseStudy
if Display_Question_Image=true then p.Question_Image=checknull(dt.Rows(i)("Question_Image"))
p.I_Display_Question_Image=Display_Question_Image
if Display_Question_Option1=true then p.Question_Option1=checknull(dt.Rows(i)("Question_Option1"))
p.I_Display_Question_Option1=Display_Question_Option1
if Display_Question_Option2=true then p.Question_Option2=checknull(dt.Rows(i)("Question_Option2"))
p.I_Display_Question_Option2=Display_Question_Option2
if Display_Question_Option3=true then p.Question_Option3=checknull(dt.Rows(i)("Question_Option3"))
p.I_Display_Question_Option3=Display_Question_Option3
if Display_Question_Option4=true then p.Question_Option4=checknull(dt.Rows(i)("Question_Option4"))
p.I_Display_Question_Option4=Display_Question_Option4
if Display_Question_Mark=true then p.Question_Mark=checknull(dt.Rows(i)("Question_Mark"))
p.I_Display_Question_Mark=Display_Question_Mark
if Display_Answer_ID=true then p.Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
p.I_Display_Answer_ID=Display_Answer_ID
if Display_Category_ID=true then p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
            p.I_Display_Category_ID = Display_Category_ID
            If Display_Section_ID = True Then p.Section_ID = checkNull(dt.Rows(i)("Section_ID"))
            p.I_Display_Section_ID = Display_Section_ID
            p.previous_Question_ID=checknull(dt.Rows(i)("Question_ID"))
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
cmd.CommandText = "update Question_Bank set "
cmd.CommandText =cmd.CommandText & " Question_ID=@Question_ID,"
if I_Display_Question_Text=true then cmd.CommandText =cmd.CommandText & " Question_Text=@Question_Text,"
if I_Display_Question_CaseStudy=true then cmd.CommandText =cmd.CommandText & " Question_CaseStudy=@Question_CaseStudy,"
if I_Display_Question_Image=true then cmd.CommandText =cmd.CommandText & " Question_Image=@Question_Image,"
if I_Display_Question_Option1=true then cmd.CommandText =cmd.CommandText & " Question_Option1=@Question_Option1,"
if I_Display_Question_Option2=true then cmd.CommandText =cmd.CommandText & " Question_Option2=@Question_Option2,"
if I_Display_Question_Option3=true then cmd.CommandText =cmd.CommandText & " Question_Option3=@Question_Option3,"
if I_Display_Question_Option4=true then cmd.CommandText =cmd.CommandText & " Question_Option4=@Question_Option4,"
if I_Display_Question_Mark=true then cmd.CommandText =cmd.CommandText & " Question_Mark=@Question_Mark,"
if I_Display_Answer_ID=true then cmd.CommandText =cmd.CommandText & " Answer_ID=@Answer_ID,"
        If I_Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & " Category_ID=@Category_ID,"
        If I_Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & " Section_ID=@Section_ID"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where Question_ID=@previous_Question_ID"


cmd.Parameters.Add("@Question_ID", 22, 255, "Question_ID")
cmd.Parameters("@Question_ID").Value = SetNull(Question_ID)

        If I_Display_Question_Text = True Then cmd.Parameters.Add("@Question_Text", 22, 65535, "Question_Text")
        If I_Display_Question_Text=true then cmd.Parameters("@Question_Text").Value = SetNull(Question_Text)

        If I_Display_Question_CaseStudy = True Then cmd.Parameters.Add("@Question_CaseStudy", 22, 65535, "Question_CaseStudy")
        If I_Display_Question_CaseStudy=true then cmd.Parameters("@Question_CaseStudy").Value = SetNull(Question_CaseStudy)

        If I_Display_Question_Image = True Then cmd.Parameters.Add("@Question_Image", 22, 65535, "Question_Image")
        If I_Display_Question_Image=true then cmd.Parameters("@Question_Image").Value = SetNull(Question_Image)

if I_Display_Question_Option1=true then cmd.Parameters.Add("@Question_Option1", 22, 255, "Question_Option1")
if I_Display_Question_Option1=true then cmd.Parameters("@Question_Option1").Value = SetNull(Question_Option1)

if I_Display_Question_Option2=true then cmd.Parameters.Add("@Question_Option2", 22, 255, "Question_Option2")
if I_Display_Question_Option2=true then cmd.Parameters("@Question_Option2").Value = SetNull(Question_Option2)

if I_Display_Question_Option3=true then cmd.Parameters.Add("@Question_Option3", 22, 255, "Question_Option3")
if I_Display_Question_Option3=true then cmd.Parameters("@Question_Option3").Value = SetNull(Question_Option3)

if I_Display_Question_Option4=true then cmd.Parameters.Add("@Question_Option4", 22, 255, "Question_Option4")
if I_Display_Question_Option4=true then cmd.Parameters("@Question_Option4").Value = SetNull(Question_Option4)

if I_Display_Question_Mark=true then cmd.Parameters.Add("@Question_Mark", 22, 255, "Question_Mark")
if I_Display_Question_Mark=true then cmd.Parameters("@Question_Mark").Value = SetNull(Question_Mark)

        If I_Display_Answer_ID = True Then cmd.Parameters.Add("@Answer_ID", 22, 255, "Answer_ID")
        If I_Display_Answer_ID = True Then cmd.Parameters("@Answer_ID").Value = setNull(Answer_ID)


        If I_Display_Category_ID=true then cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
        If I_Display_Category_ID = True Then cmd.Parameters("@Category_ID").Value = setNull(Category_ID)

        If I_Display_Section_ID = True Then cmd.Parameters.Add("@Section_ID", 22, 65535, "Section_ID")
        If I_Display_Section_ID = True Then cmd.Parameters("@Section_ID").Value = setNull(Section_ID)



        cmd.Parameters.Add("@previous_Question_ID", 22, 255, "previous_Question_ID")
cmd.Parameters("@previous_Question_ID").Value = Me.previous_Question_ID



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Bank)
Dim ps As New Generic.List(Of Question_Bank)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "Question_ID,"
if Display_Question_Text=true then cmd.CommandText = cmd.CommandText & "Question_Text,"
if Display_Question_CaseStudy=true then cmd.CommandText = cmd.CommandText & "Question_CaseStudy,"
if Display_Question_Image=true then cmd.CommandText = cmd.CommandText & "Question_Image,"
if Display_Question_Option1=true then cmd.CommandText = cmd.CommandText & "Question_Option1,"
if Display_Question_Option2=true then cmd.CommandText = cmd.CommandText & "Question_Option2,"
if Display_Question_Option3=true then cmd.CommandText = cmd.CommandText & "Question_Option3,"
if Display_Question_Option4=true then cmd.CommandText = cmd.CommandText & "Question_Option4,"
if Display_Question_Mark=true then cmd.CommandText = cmd.CommandText & "Question_Mark,"
if Display_Answer_ID=true then cmd.CommandText = cmd.CommandText & "Answer_ID,"
        If Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & "Section_ID,"
        cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Bank " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Bank
p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.I_Display_Question_ID=Display_Question_ID
if Display_Question_Text=true then p.Question_Text=checknull(dt.Rows(i)("Question_Text"))
p.I_Display_Question_Text=Display_Question_Text
if Display_Question_CaseStudy=true then p.Question_CaseStudy=checknull(dt.Rows(i)("Question_CaseStudy"))
p.I_Display_Question_CaseStudy=Display_Question_CaseStudy
if Display_Question_Image=true then p.Question_Image=checknull(dt.Rows(i)("Question_Image"))
p.I_Display_Question_Image=Display_Question_Image
if Display_Question_Option1=true then p.Question_Option1=checknull(dt.Rows(i)("Question_Option1"))
p.I_Display_Question_Option1=Display_Question_Option1
if Display_Question_Option2=true then p.Question_Option2=checknull(dt.Rows(i)("Question_Option2"))
p.I_Display_Question_Option2=Display_Question_Option2
if Display_Question_Option3=true then p.Question_Option3=checknull(dt.Rows(i)("Question_Option3"))
p.I_Display_Question_Option3=Display_Question_Option3
if Display_Question_Option4=true then p.Question_Option4=checknull(dt.Rows(i)("Question_Option4"))
p.I_Display_Question_Option4=Display_Question_Option4
if Display_Question_Mark=true then p.Question_Mark=checknull(dt.Rows(i)("Question_Mark"))
p.I_Display_Question_Mark=Display_Question_Mark
if Display_Answer_ID=true then p.Answer_ID=checknull(dt.Rows(i)("Answer_ID"))
p.I_Display_Answer_ID=Display_Answer_ID
if Display_Category_ID=true then p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
            p.I_Display_Category_ID = Display_Category_ID
            If Display_Section_ID = True Then p.Section_ID = checkNull(dt.Rows(i)("Section_ID"))
            p.I_Display_Section_ID = Display_Section_ID
            p.previous_Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Bank)
Dim ps As New Generic.List(Of Question_Bank)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select Question_ID from Question_Bank" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Bank
p.Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.previous_Question_ID=checknull(dt.Rows(i)("Question_ID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class