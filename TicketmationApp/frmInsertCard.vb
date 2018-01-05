Public Class frmInsertCard

    Private Sub frmInsertCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blinkTimer.Start()
        testTimer.Start()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.close

    End Sub

    Private Sub blinkTimer_Tick(sender As Object, e As EventArgs) Handles blinkTimer.Tick
        If lInsertCard.Visible Then
            lInsertCard.Visible = False
        Else
            lInsertCard.Visible = True
        End If
    End Sub

    Private Sub testTimer_Tick(sender As Object, e As EventArgs) Handles testTimer.Tick
        blinkTimer.Stop()
        testTimer.Stop()
        frmAuthorize.Show()
        Me.Close()

    End Sub
End Class