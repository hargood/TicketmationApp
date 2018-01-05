Public Class frmTicketStock

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub frmTicketStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Height = cmdReset.Top + cmdReset.Height + 50
        Me.Width = cmdReset.Left + cmdReset.Width + 50
        txtStock.Text = GetTicketStock().ToString

    End Sub

    Private Sub KeyPad_Click(sender As Object, e As EventArgs) Handles KeyPad1.Click, KeyPad2.Click, KeyPad3.Click, KeyPad4.Click, KeyPad5.Click, KeyPad6.Click, KeyPad7.Click, KeyPad8.Click, KeyPad9.Click, KeyPad10.Click
        If Strings.Len(txtStock.Text) < 3 Then
            txtStock.Text = txtStock.Text & sender.text
        End If

    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtStock.Text = ""

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        ResetStock(txtStock.Text)
        TicketStock = CInt(txtStock.Text)
        Me.Close()
    End Sub
End Class