Public Class frmBatchProcess

    Private Sub frmBatchProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        timerBatchProcess.Start()
    End Sub

    Private Sub timerBatchProcess_Tick(sender As Object, e As EventArgs) Handles timerBatchProcess.Tick

        timerBatchProcess.Stop()
        SaveBatch()
        nBatch = nBatch + 1

        TransactionID = "9999999999"
        ReferenceID = TransactionID
        CardApproved = True
        SwipTime = Now()
        frmAuthorize.Show()
        Me.Close()

    End Sub
End Class