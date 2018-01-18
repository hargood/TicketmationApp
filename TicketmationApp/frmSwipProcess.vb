Imports TicketmationApp.C2IT.PaymentProcessors
Public Class frmSwipProcess

    Private Sub frmSwipProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bDEMO Then
            CardNumber = "1234560000"
            CardApproved = True
            TransactionID = "-9999999999"
            ReferenceID = TransactionID
            DeclineMessage = ""
            frmAuthorize.Show()
            Me.Close()
        Else
            'Check is this card was used
            If GetUsedCC(CardNumber) Then
                'card used... decline transaction
                CardApproved = False
                DeclineMessage = "Please use different card"
                frmAuthorize.Show()
                Me.Close()
            Else
                'Check if Zip Required
                If TotTicketCount > iMaxTix Then
                    GetZip = True
                Else
                    GetZip = False
                End If
                TimerProcess.Interval = 1000
                TimerProcess.Start()
            End If
        End If
        ''AUTHORIZE.NET
        'Dim rv As New AuthorizeNetProcess.AuthorizeDotNet.Output
        'Dim Order As New AuthorizeNetProcess.AuthorizeDotNet.OrderInfo
        'Dim Merchant As New AuthorizeNetProcess.AuthorizeDotNet.MerchantInfo
        'Merchant.AuthNetVersion = "3.1" 'Contains CCV support
        'Merchant.AuthNetLoginId = "3fhMNGg372W" 'Set AuthNetLoginId here (or in the calling routine)
        'Merchant.AuthNetTransKey = "6XCvTb6Ru8v96L7n"
        'Order.FirstName = CardFirstName
        'Order.LastName = CardLastName
        'Order.Amount = Decimal.op_Implicit(TotalPrice)
        'Order.Description = ShowName
        'Order.CreditCardNumber = CardNumber
        'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)

        'rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessPayment(Merchant, Order)

        'TransactionID = rv.TransactionId
        'frmAuthorize.Show()
        'Me.Close()
        'TimerTest.Interval = 3000
        'TimerTest.Start()

    End Sub

    'Private Sub TimerTest_Tick(sender As Object, e As EventArgs) Handles TimerProcess.Tick
    '    TimerProcess.Stop()
    '    CardApproved = True
    '    CardNumber = "1234567890"
    '    ReferenceID = "ABCDEFG"
    '    frmAuthorize.Show()
    '    Me.Close()

    'End Sub
    Private Sub ProcessCard()

    End Sub

    Private Sub TimerProcess_Tick(sender As Object, e As EventArgs) Handles TimerProcess.Tick
        'AUTHORIZE.NET
        Dim rv As New AuthorizeNetProcess.AuthorizeDotNet.Output
        Dim Order As New AuthorizeNetProcess.AuthorizeDotNet.OrderInfo
        Dim Merchant As New AuthorizeNetProcess.AuthorizeDotNet.MerchantInfo
        Merchant.AuthNetVersion = "3.1" 'Contains CCV support
        TimerProcess.Stop()
        If GetZip Then
            Dim frmDialogue As New frmZipCode
            'Dim result = My.Forms.frmMessage.ShowDialog(Me)
            Dim result = frmDialogue.ShowDialog()
            'frmZipCode.ShowDialog()
            'If frmZipCode.ShowDialog() = DialogResult.OK Then
            'If frmDialogue.ShowDialog() = DialogResult.OK Then
            If result = DialogResult.OK Then
                frmDialogue.Dispose()
                'MessageBox.Show("OK Button Clicked")
                Merchant.AuthNetLoginId = AuthNetLogIDCNP   '"79v9WU2tzC" 'Set AuthNetLoginId here (or in the calling routine)
                Merchant.AuthNetTransKey = AuthNetKeyCNP    '"93M3JyKpzqWm3833"
                Order.FirstName = CardFirstName
                Order.LastName = CardLastName
                Order.Amount = Decimal.op_Implicit(TotalPrice)
                Order.Description = ShowName
                Order.CreditCardNumber = CardNumber
                Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
                Order.ZipCode = ZipCode
                rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCNPPayment(Merchant, Order)
                TransactionID = rv.TransactionId
                ReferenceID = TransactionID
                DeclineMessage = rv.ErrorMessage
                'frmAuthorize.Show()
                'Me.Close()
            ElseIf result = DialogResult.Cancel Then
                frmDialogue.Dispose()
                frmFirstPage.Show()
                Me.Close()
                'Exit Sub
            End If
            'frmZipCode.MdiParent = Me
            'frmZipCode.Show()
            'Merchant.AuthNetLoginId = "423BMqgLP" 'Set AuthNetLoginId here (or in the calling routine)
            'Merchant.AuthNetTransKey = "2Gu6wN9V63g9S33v"
            'Order.FirstName = CardFirstName
            'Order.LastName = CardLastName
            'Order.Amount = Decimal.op_Implicit(TotalPrice)
            'Order.Description = ShowName
            'Order.CreditCardNumber = CardNumber
            'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
            'Order.ZipCode = ZipCode
            'rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCNPPayment(Merchant, Order)
        Else

            Merchant.AuthNetLoginId = AuthNetLogIDCP     '"3fhMNGg372W" 'Set AuthNetLoginId here (or in the calling routine)
            Merchant.AuthNetTransKey = AuthNetKeyCP      '"6XCvTb6Ru8v96L7n"
            Order.FirstName = CardFirstName
            Order.LastName = CardLastName
            Order.Amount = Decimal.op_Implicit(TotalPrice)
            Order.Description = ShowName
            'Order.CreditCardNumber = CardNumber
            'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
            rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCPPayment(Merchant, Order)
            TransactionID = rv.TransactionId
            DeclineMessage = rv.ErrorMessage
            ReferenceID = TransactionID
        End If
        frmAuthorize.Show()
        Me.Close()
        'Order.FirstName = CardFirstName
        'Order.LastName = CardLastName
        'Order.Amount = Decimal.op_Implicit(TotalPrice)
        'Order.Description = ShowName
        'Order.CreditCardNumber = CardNumber
        'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
        'If GetZip Then
        '    rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCNPPayment(Merchant, Order)
        'Else
        '    rv = AuthorizeNetProcess.AuthorizeDotNet.ProcessCPPayment(Merchant, Order)
        'End If

        'TransactionID = rv.TransactionId
        'ReferenceID = TransactionID
        'frmAuthorize.Show()
        'Me.Close()
    End Sub
End Class