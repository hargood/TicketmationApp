Imports TicketmationApp.C2IT.PaymentProcessors
Public Class frmBatch

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBatch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Batches(5, 10) As String
        Dim i As Integer
        Dim j As Integer
        Me.Width = cmdSubmit.Left + cmdSubmit.Width + 100
        Me.Height = cmdSubmit.Top + cmdSubmit.Height + 100
        'Batches = Get10Batches()
        'If Not String.IsNullOrEmpty(Batches(1, 1)) Then
        '    For i = 1 To 10
        '        If Not String.IsNullOrEmpty(Batches(1, i)) Then
        '            For j = 1 To 5
        '                GridBatches.Item(j - 1, i - 1).Value = Batches(j, i)
        '            Next
        '        End If
        '    Next
        'End If
        PopulateGrid()

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        Dim selectedRowCount As Integer = GridBatches.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then
            Dim i As Integer

            For i = 0 To selectedRowCount - 1
                'strTrack1 = GridBatches.SelectedRows(i).Cells(1).Value.ToString()
                'strTrack2 = GridBatches.SelectedRows(i).Cells(2).Value.ToString()
                'TotalPrice = CInt(GridBatches.SelectedRows(i).Cells(2).Value.ToString())
                'db.Execute "Delete * from BATCH where BatchID=" & .text
                DataBase.DeleteBatch(GridBatches.SelectedRows(i).Cells(0).Value.ToString())
                nBatch = nBatch - 1
            Next i
            PopulateGrid()
        End If
    End Sub
    Private Sub PopulateGrid()
        Dim Batches(5, 10) As String
        Dim i As Integer
        Dim j As Integer
        GridBatches.Rows.Clear()
        Batches = Get10Batches()
        Dim row As String()
        If Not String.IsNullOrEmpty(Batches(1, 1)) Then

            'DataGridView1.Rows.Add(row)
            'row = New String() {"2", "Product 2", "2000"}
            'DataGridView1.Rows.Add(row)
            For i = 1 To 10
                If Not String.IsNullOrEmpty(Batches(1, i)) Then
                    row = New String() {Batches(1, i), Batches(2, i), Batches(3, i), Batches(4, i), Batches(5, i)}
                    GridBatches.Rows.Add(row)
                    'For j = 1 To 5
                    '    GridBatches.Item(j - 1, i - 1).Value = Batches(j, i)
                    'Next
                End If
            Next
        Else
            row = New String() {"", "No Pending Batches", "", "", ""}
            GridBatches.Rows.Add(row)
        End If
    End Sub
    'Private Sub DeleteBatch(ByVal iBatch As String)
    '    'Dim selectedRowCount As Integer = GridBatches.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '    'Dim 
    '    'If selectedRowCount > 0 Then

    '    '    For i = 0 To selectedRowCount - 1
    '    '        BatchID = GridBatches.SelectedRows(i).Cells(0).Value
    '    DeleteBatch(BatchID)
    '    '    Next
    '    'End If

    'End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Dim rv As New AuthorizeNetProcess.AuthorizeDotNet.Output
        Dim Order As New AuthorizeNetProcess.AuthorizeDotNet.OrderInfo
        Dim Merchant As New AuthorizeNetProcess.AuthorizeDotNet.MerchantInfo
        Dim selectedRowCount As Integer = GridBatches.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim strTrack1 As String
        Dim strAccountNumber As String
        Dim BatchID As String
        Dim i As Integer
        If selectedRowCount > 0 Then

            For i = 0 To selectedRowCount - 1
                BatchID = GridBatches.SelectedRows(i).Cells(0).Value.ToString()
                strTrack1 = GridBatches.SelectedRows(i).Cells(1).Value.ToString()
                strAccountNumber = GridBatches.SelectedRows(i).Cells(2).Value.ToString()
                TotalPrice = CInt(GridBatches.SelectedRows(i).Cells(3).Value.ToString())
                GetBatchDetails(BatchID)
                'CardName = Trim(Mid(strTrack1, InStr(1, strTrack1, "^") + 1, InStr((InStr(1, strTrack1, "^") + 1), strTrack1, "^") - InStr(1, strTrack1, "^") - 1))
                Merchant.AuthNetLoginId = AuthNetLogIDCP   '"3fhMNGg372W" 'Set AuthNetLoginId here (or in the calling routine)
                Merchant.AuthNetTransKey = AuthNetKeyCP    '"6XCvTb6Ru8v96L7n"
                'Order.FirstName = CardFirstName
                'Order.LastName = CardLastName
                Order.Amount = Decimal.op_Implicit(TotalPrice)
                Order.Description = ShowName
                'Order.CreditCardNumber = CardNumber
                'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
                AccountNumber = strAccountNumber
                'Track1 = strTrack1
                rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCPPayment(Merchant, Order)
                TransactionID = rv.TransactionId
                ReferenceID = TransactionID
                If CardApproved Then
                    RecordPurchase(TotalPrice)
                    BarCode = "batch"
                    SwipTime = Now()
                    UpdateSQLPurchase()
                End If
                'Update Batch
                DataBase.UpdateBatch(BatchID)
                nBatch = nBatch - 1
                PopulateGrid()

                'TransactionID = rv.TransactionId
                'ReferenceID = TransactionID

                'RecordPurchase(TotalPrice)
                'frmWebBrowser.Show 1
                ''ANTransactionCode = "0"
                ''Remove from batch
                'If Left(ANTransactionCode, 1) <> "-" Then
                '    db.Execute "UPDATE BATCH set BatchUpload = Yes,Track1='" & ANTransactionCode & "',Track2='" & Now() & "' Where BatchID=" & rsBatch(0)
                '    LabelWebState.Visible = False
                'Else
                '    LabelWebState.Visible = True
                'End If
            Next i
        End If
    End Sub
End Class