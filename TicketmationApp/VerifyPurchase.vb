Imports TicketmationApp.C2IT.PaymentProcessors


Public Class VerifyPurchase

    Private Sub VerifyPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim totalSale As Integer = 0
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then

                Select Case i
                    Case 0
                        lblTix1.Text = CStr(TotalTicketSold(i)) & " " & TicketTypes(5, i) & " ticket(s) @ " & FormatCurrency(TicketTypes(3, i), 0) & " = " & FormatCurrency(TotalTicketSold(i) * TicketTypes(3, i), 0)
                        totalSale = totalSale + TotalTicketSold(i) * TicketTypes(3, i)
                    Case 1
                        lblTix2.Text = CStr(TotalTicketSold(i)) & " " & TicketTypes(5, i) & " ticket(s) @ " & FormatCurrency(TicketTypes(3, i), 0) & " = " & FormatCurrency(TotalTicketSold(i) * TicketTypes(3, i), 0)
                        totalSale = totalSale + TotalTicketSold(i) * TicketTypes(3, i)
                    Case 2
                        lblTix3.Text = CStr(TotalTicketSold(i)) & " " & TicketTypes(5, i) & " ticket(s) @ " & FormatCurrency(TicketTypes(3, i), 0) & " = " & FormatCurrency(TotalTicketSold(i) * TicketTypes(3, i), 0)
                        totalSale = totalSale + TotalTicketSold(i) * TicketTypes(3, i)
                End Select
                lblSum.Text = "Total Purchase: " & FormatCurrency(totalSale, 0)

            End If

        Next
        TotalPrice = totalSale
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        LogClick("VerifyPurchase", "Cancel Tickets")
        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        LogClick("VerifyPurchase", "Change Tickets Selected")
        bChange = True
        frmSpecifyTickets.Show()
        Me.Close()

    End Sub

    Private Sub cmdBuy_Click(sender As Object, e As EventArgs) Handles cmdBuy.Click
        If Not HaveInternetConnection() Then
            'frmStartup.Show()
            bHaveInternet = False
            'frmStartup.lMessage.Text = "*************** NO INTERNET CONNECTION ********************"
            'frmStartup.lMessage.Left = frmStartup.lblWelcome.Width / 2 + frmStartup.lblWelcome.Left - frmStartup.lMessage.Width / 2
            frmBatchProcess.Show()
            Me.Close()
            Exit Sub
        Else
            bHaveInternet = True
        End If
        LogClick("VerifyPurchase", "Authorize Sale")
        If bEMV Then
            frmSaleProcessing.Show()
        Else
            'Dim Order As New AuthorizeNetProcess.AuthorizeDotNet.OrderInfo

            'Order.FirstName = CardFirstName
            'Order.LastName = CardLastName
            'Order.Amount = Decimal.op_Implicit(TotalPrice)
            'Order.Description = ShowName
            'Order.CreditCardNumber = CardNumber
            'Order.ExpireDate = Strings.Right(CardExpire, 2) & "/" & Strings.Left(CardExpire, 2)
            frmSwipProcess.Show()
        End If


        Me.Close()
    End Sub
End Class