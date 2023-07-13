Imports System.Net.Mail
Public Class SendEmail
    Public Sub SendForgotPassword(Email, OTP)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()

        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "localhost"
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network
        Smtp_Server.Credentials = New Net.NetworkCredential("gaming040129@gmail.com", "gbsdctpqqtxzeahj")

        ''


        e_mail = New MailMessage()
        e_mail.From = New MailAddress("gaming040129@gmail.com")
        'e_mail.To.Add("dsaujapp@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = "Reset Password Notification"
        e_mail.IsBodyHtml = False
        e_mail.Body = "You have requested to change the password to your  Account: " + Email + Environment.NewLine + "Your OTP:" + OTP.ToString() + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "DSA Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub

    Public Sub SendOTP(Email)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "localhost"
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network
        Smtp_Server.Credentials = New Net.NetworkCredential("gaming040129@gmail.com", "gbsdctpqqtxzeahj")

        'Smtp_Server.Host = "smtp.gmail.com"'
        'Smtp_Server.Port = 587'


        e_mail = New MailMessage()
        e_mail.From = New MailAddress("gaming040129@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = "Password Reset"
        e_mail.IsBodyHtml = False
        e_mail.Body = "Your password for Account: " + Email + " has been reset successfully" + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "DSA Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub
End Class
