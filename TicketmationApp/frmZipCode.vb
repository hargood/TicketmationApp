Public Class frmZipCode

    Private Sub frmZipCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Zip5.Left + Zip5.Width + 100
        Me.Height = bSubmit.Top + bSubmit.Height + 10
        'Me.Left = 500
        timerZip.Start()
        lZipCode.Text = ""
        bSubmit.Enabled = False
    End Sub

    Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
        timerZip.Stop()
        lZipCode.Text = ""
        ZipCode = ""
        bRestart = True
        Me.DialogResult = DialogResult.Cancel
        'frmFirstPage.Show()
        'Me.Close()
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        lZipCode.Text = ""
        ZipCode = ""
        bSubmit.Enabled = False
    End Sub

    Private Sub bSubmit_Click(sender As Object, e As EventArgs) Handles bSubmit.Click
        timerZip.Stop()
        Me.DialogResult = DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub Zip_Click(sender As Object, e As EventArgs) Handles Zip1.Click, Zip2.Click, Zip3.Click, Zip4.Click, Zip5.Click, Zip6.Click, Zip7.Click, Zip8.Click, Zip9.Click, Zip0.Click
        If Strings.Len(lZipCode.Text) < 5 Then
            lZipCode.Text = lZipCode.Text & sender.text
            If Strings.Len(lZipCode.Text) = 5 Then
                ZipCode = lZipCode.Text
                bSubmit.Enabled = True
            End If
        End If

    End Sub
End Class