Public Class frmSaleProcessing
    Public iState As Integer = 0
    Public bDone As Boolean = True

    Private Sub frmSaleProcessing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreditCardProcessing.Sale()
        EventTimer.Interval = 1000
        EventTimer.Start()
    End Sub

    Private Sub EventTimer_Tick(sender As Object, e As EventArgs) Handles EventTimer.Tick
        'If iState < 5 Then
        '    If bDone Then iState = iState + 1
        '    bDone = False
        CreditCardProcessing.Events()
        'Else
        'EventTimer.Stop()
        'timerResult.Enabled = True
        'timerResult.Interval = 3000
        'timerResult.Start()

        ''frmAuthorize.Show()
        ''Me.Close()
        ' ''iState = 0
        ' ''EventTimer.Stop()
        'End If


    End Sub

    Private Sub timerResult_Tick(sender As Object, e As EventArgs) Handles timerResult.Tick
        timerResult.Stop()
        frmAuthorize.Show()
        Me.Close()
    End Sub
End Class