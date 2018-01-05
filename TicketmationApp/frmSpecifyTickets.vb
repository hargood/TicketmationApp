
Imports System.IO
Public Class frmSpecifyTickets
    Dim TotalPrice As Double
    Private Sub frmSpecifyTickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i
        Dim ShowFirst As Boolean
        'fTicketmation.Close()
        TotTicketCount = 0
        ShowFirst = False
        bRestart = False
        '**********************
        If bChange Then
            '    '' Put up last selection and allow change
            TotalPrice = 0
            'If EventCity = "NEW YORK" Then
            '    BaseTicket = CDec(TicketTypes(3, i)) / (1.0# + 0.08875)
            '    Tax = FormatCurrency(BaseTicket, 2) & " plus " & FormatCurrency(TicketTypes(3, i) - BaseTicket, 2) & " tax"
            '    imgProgram.Picture = LoadPicture(App.path & "/NYProgram.jpg")
            '    imgProgram.Visible = True
            'Else
            '    Tax = ""
            '    lblTax(i).Visible = False
            '    imgProgram.Visible = False
            'End If
            For i = 0 To UBound(TotalTicketSold, 1)
                PopulateButtons(i)

                If TotalTicketSold(i) > 0 Then
                    Select Case i
                        Case 0
                            lblCategoryAmount1.Text = TotalTicketSold(i) & " tickets @ $" & TicketTypes(3, i) & "=" & Format(TotalTicketSold(i) * TicketTypes(3, i), "$#.00")
                            lblCategoryAmount1.Visible = True
                            FrameTicketSum1.Visible = True
                            TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                            PanelTicketButton1.Enabled = True
                        Case 1
                            lblCategoryAmount2.Text = TotalTicketSold(i) & " tickets @ $" & TicketTypes(3, i) & "=" & Format(TotalTicketSold(i) * TicketTypes(3, i), "$#.00")
                            lblCategoryAmount2.Visible = True
                            FrameTicketSum2.Visible = True
                            TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                            PanelTicketButton2.Enabled = True
                        Case 2
                            lblCategoryAmount3.Text = TotalTicketSold(i) & " tickets @ $" & TicketTypes(3, i) & "=" & Format(TotalTicketSold(i) * TicketTypes(3, i), "$#.00")
                            lblCategoryAmount3.Visible = True
                            FrameTicketSum3.Visible = True
                            TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                            PanelTicketButton3.Enabled = True
                    End Select

                End If
            Next i
            lblTotal.Text = "Ticket Purchase Total: " & Format(TotalPrice, "$#.00")
            If TotalPrice > 0 Then
                cmdPurchase.Visible = True
                lblTotal.Visible = True
            Else
                lblTotal.Visible = False
                cmdPurchase.Visible = False

            End If
            'Turn off change mode
            bChange = False
        Else
            'Reset all TICKETS
            SelectedTicket = 0
            Array.Clear(TicketTypes, 0, TicketTypes.Length)
            Array.Clear(TotalTicketSold, 0, TotalTicketSold.Length)
            TotTicketCount = 0
            TicketCount = "0"
            GetTickets()
            For i = 0 To 2
                PopulateButtons(i)

                'If EventCity = "NEW YORK" Then
                '    BaseTicket = CDec(TicketTypes(3, i)) / (1.0# + 0.08875)
                '    lblTax(i) = Format(BaseTicket, "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & " tax"
                '    'lblTax(i) = Format(CDec(TicketTypes(3, i)) / (1# + 0.08875), "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & " tax"
                '    lblTax(i).Visible = True
                '    imgProgram.Picture = LoadPicture(App.path & "/NYProgram.jpg")
                '    imgProgram.Visible = True
                'Else
                '    lblTax(i).Visible = False
                '    imgProgram.Visible = False
                'End If
                'BottomButton = i
            Next

            ' Visible = False
            '    '        imgProgram.Visible = False
            'End If

            SpecifyTicketTimer.Enabled = True
        End If

        '    If EventCity = "NEW YORK" Then
        '        BaseTicket = CDec(TicketTypes(3, i)) / (1.0# + 0.08875)
        '        lblTax(i) = Format(BaseTicket, "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & " tax"
        '        'lblTax(i) = Format(CDec(TicketTypes(3, i)) / (1# + 0.08875), "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & " tax"
        '        lblTax(i).Visible = True
        '        imgProgram.Picture = LoadPicture(App.path & "/NYProgram.jpg")
        '        imgProgram.Visible = True
        '    Else
        '        lblTax(i).Visible = False
        '        imgProgram.Visible = False
        '    End If
        '    BottomButton = i
        'Next i
        ''

    End Sub
    Private Sub PanelTicketButton_Click(sender As Object, e As EventArgs) Handles PanelTicketButton1.Click, PanelTicketButton2.Click, PanelTicketButton3.Click, lCategory1.Click, lCategory2.Click, lCategory3.Click, lTax1.Click, lTax2.Click, lTax3.Click, lDesc1.Click, lDesc2.Click, lDesc3.Click
        SelectedTicket = CInt(Strings.Right(sender.name, 1))
        CategoryPressed()
    End Sub
    'Private Sub PanelTicketButton1_Click(sender As Object, e As EventArgs) Handles PanelTicketButton1.Click
    '    SelectedTicket = 1
    '    CategoryPressed()
    'End Sub
    'Private Sub PanelTicketButton2_Click(sender As Object, e As EventArgs) Handles PanelTicketButton2.Click
    '    SelectedTicket = 2
    '    CategoryPressed()
    'End Sub
    'Private Sub PanelTicketButton3_Click(sender As Object, e As EventArgs) Handles PanelTicketButton3.Click
    '    SelectedTicket = 3
    '    CategoryPressed()
    'End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()
    End Sub
    'Private Sub lCategory_Click(sender As Object, e As EventArgs) Handles lCategory1.Click, lCategory2.Click, lCategory3.Click
    '    SelectedTicket = CInt(Strings.Right(sender.name, 1))
    '    CategoryPressed()
    'End Sub

    'Private Sub lCategory1_Click(sender As Object, e As EventArgs) Handles lCategory1.Click
    '    SelectedTicket = 1
    '    CategoryPressed()
    'End Sub
    'Private Sub lCategory2_Click(sender As Object, e As EventArgs) Handles lCategory2.Click
    '    SelectedTicket = 2
    '    CategoryPressed()
    'End Sub
    'Private Sub lCategory3_Click(sender As Object, e As EventArgs) Handles lCategory3.Click
    '    SelectedTicket = 3
    '    CategoryPressed()
    'End Sub

    'Private Sub lTax1_Click(sender As Object, e As EventArgs) Handles lTax1.Click
    '    SelectedTicket = 1
    '    CategoryPressed()
    '    'PanelKeyPad.Top = PanelTicketButton1.Top
    '    'PanelKeyPad.Visible = True
    '    'PanelTicketButton1.BackColor = Color.BlanchedAlmond
    '    'SelectedTicket = 1
    '    'FrameTicketSum1.Visible = False

    'End Sub
    'Private Sub lTax2_Click(sender As Object, e As EventArgs) Handles lTax2.Click
    '    SelectedTicket = 2
    '    CategoryPressed()

    'End Sub
    'Private Sub lTax3_Click(sender As Object, e As EventArgs) Handles lTax3.Click
    '    SelectedTicket = 3
    '    CategoryPressed()

    'End Sub

    'Private Sub lDesc1_Click(sender As Object, e As EventArgs) Handles lDesc1.Click
    '    SelectedTicket = 1
    '    CategoryPressed()
    'End Sub
    'Private Sub lDesc2_Click(sender As Object, e As EventArgs) Handles lDesc2.Click
    '    SelectedTicket = 2
    '    CategoryPressed()
    'End Sub
    'Private Sub lDesc3_Click(sender As Object, e As EventArgs) Handles lDesc3.Click
    '    SelectedTicket = 3
    '    CategoryPressed()
    'End Sub
    Private Sub cmdKeyPad_Click(sender As Object, e As EventArgs) Handles cmdKeyPad1.Click, cmdKeyPad2.Click, cmdKeyPad3.Click, cmdKeyPad4.Click, cmdKeyPad5.Click, cmdKeyPad6.Click, cmdKeyPad7.Click, cmdKeyPad8.Click, cmdKeyPad9.Click
        KeyPadPressed(CInt(sender.text))
    End Sub

    'Private Sub cmdKeyPad1_Click(sender As Object, e As EventArgs) Handles cmdKeyPad1.Click
    '    KeyPadPressed(1)
    'End Sub
    'Private Sub cmdKeyPad2_Click(sender As Object, e As EventArgs) Handles cmdKeyPad2.Click
    '    KeyPadPressed(2)
    'End Sub
    'Private Sub cmdKeyPad3_Click(sender As Object, e As EventArgs) Handles cmdKeyPad3.Click
    '    KeyPadPressed(3)
    'End Sub
    'Private Sub cmdKeyPad4_Click(sender As Object, e As EventArgs) Handles cmdKeyPad4.Click
    '    KeyPadPressed(4)
    'End Sub
    'Private Sub cmdKeyPad5_Click(sender As Object, e As EventArgs) Handles cmdKeyPad5.Click
    '    KeyPadPressed(5)
    'End Sub
    'Private Sub cmdKeyPad6_Click(sender As Object, e As EventArgs) Handles cmdKeyPad6.Click
    '    KeyPadPressed(6)
    'End Sub
    'Private Sub cmdKeyPad7_Click(sender As Object, e As EventArgs) Handles cmdKeyPad7.Click
    '    KeyPadPressed(7)
    'End Sub
    'Private Sub cmdKeyPad8_Click(sender As Object, e As EventArgs) Handles cmdKeyPad8.Click
    '    KeyPadPressed(8)
    'End Sub
    'Private Sub cmdKeyPad9_Click(sender As Object, e As EventArgs) Handles cmdKeyPad9.Click
    '    KeyPadPressed(9)
    'End Sub
    Private Sub cmdKeyPad10_Click(sender As Object, e As EventArgs) Handles cmdKeyPad10.Click
        KeyPadPressed(10)
    End Sub
    Private Sub KeyPadPressed(ByVal PadNo As Integer)

        ' Timer_Verify.Enabled = False
        PanelKeyPad.Visible = False
        ' LblPickNumber.Visible = False
        FrameTicketSum1.Enabled = True
        FrameTicketSum2.Enabled = True
        FrameTicketSum3.Enabled = True


        If PadNo < 10 Then
            '1-9 selected
            Select Case SelectedTicket
                Case 1
                    lblCategoryAmount1.Text = CStr(PadNo) & " tickets @ " & FormatCurrency(TicketTypes(3, SelectedTicket - 1), 0) & " = " & FormatCurrency(PadNo * TicketTypes(3, SelectedTicket - 1), 0)
                    lblCategoryAmount1.Visible = True
                    FrameTicketSum1.Visible = True
                Case 2
                    lblCategoryAmount2.Text = CStr(PadNo) & " tickets @ " & FormatCurrency(TicketTypes(3, SelectedTicket - 1), 0) & " = " & FormatCurrency(PadNo * TicketTypes(3, SelectedTicket - 1), 0)
                    lblCategoryAmount2.Visible = True
                    FrameTicketSum2.Visible = True
                Case 3
                    lblCategoryAmount3.Text = CStr(PadNo) & " tickets @ " & FormatCurrency(TicketTypes(3, SelectedTicket - 1), 0) & " = " & FormatCurrency(PadNo * TicketTypes(3, SelectedTicket - 1), 0)
                    lblCategoryAmount3.Visible = True
                    FrameTicketSum3.Visible = True
            End Select

            TotalTicketSold(SelectedTicket - 1) = PadNo
        Else
            TotalTicketSold(SelectedTicket - 1) = 0
        End If
        PanelTicketButton1.BackColor = Color.LightSteelBlue
        PanelTicketButton2.BackColor = Color.LightSteelBlue
        PanelTicketButton3.BackColor = Color.LightSteelBlue
        FrameTicketSum1.Enabled = True
        FrameTicketSum2.Enabled = True
        FrameTicketSum3.Enabled = True
        'Recalculate total price
        TotalPrice = 0
        TotTicketCount = 0
        For i = 0 To UBound(TicketTypes, 2)
            TotalPrice = TotalPrice + TotalTicketSold(i) * CInt(TicketTypes(3, i))
            TotTicketCount = TotTicketCount + TotalTicketSold(i)
        Next i
        lblTotal.Text = "Ticket Purchase Total: " & FormatCurrency(TotalPrice, 0)
        If TotalPrice > 0 Then
            cmdPurchase.Visible = True
            cmdPurchase.Enabled = True
            lblTotal.Visible = True
        Else
            lblTotal.Visible = False
            cmdPurchase.Visible = False
        End If
        ' Timer_Verify.Enabled = True
        'reset everything
        PanelKeyPad.Visible = False
        PanelTicketButton1.Enabled = True
        PanelTicketButton2.Enabled = True
        PanelTicketButton3.Enabled = True


    End Sub

    Private Sub bCancel1_Click(sender As Object, e As EventArgs) Handles bCancel1.Click
        CancelSelected(1)
        FrameTicketSum1.Visible = False

    End Sub
    Private Sub bCancel2_Click(sender As Object, e As EventArgs) Handles bCancel2.Click
        CancelSelected(2)
        FrameTicketSum2.Visible = False
        'TotalTicketSold(SelectedTicket) = 0
        'PanelKeyPad.Visible = False
        'FrameTicketSum2.Visible = True
    End Sub
    Private Sub bCancel3_Click(sender As Object, e As EventArgs) Handles bCancel3.Click
        CancelSelected(3)
        FrameTicketSum3.Visible = False
        'TotalTicketSold(SelectedTicket) = 0
        'PanelKeyPad.Visible = False
        'FrameTicketSum1.Visible = True

    End Sub
    Private Sub CategoryPressed()
        SpecifyTicketTimer.Stop()

        'Ticket Button Selected
        'Set Key Pad Title
        PanelKeyPad.Text = "Select number of " & TicketTypes(5, SelectedTicket - 1) & " tickets (cancel for zero)"
        PanelKeyPad.Visible = True
        PanelKeyPad.BringToFront()
        'Depending on selection...
        '' Set button color
        '' Top of key pad
        '' Hid SumPanel for that selection
        '' Disable other ticket buttons
        Select Case SelectedTicket
            Case 1
                PanelTicketButton1.BackColor = Color.BlanchedAlmond
                PanelKeyPad.Top = PanelTicketButton1.Top
                FrameTicketSum1.Visible = False
                PanelTicketButton2.Enabled = False
                PanelTicketButton3.Enabled = False
                FrameTicketSum2.Enabled = False
                FrameTicketSum3.Enabled = False
            Case 2
                PanelTicketButton2.BackColor = Color.BlanchedAlmond
                PanelKeyPad.Top = PanelTicketButton2.Top
                FrameTicketSum2.Visible = False
                PanelTicketButton1.Enabled = False
                PanelTicketButton3.Enabled = False
                FrameTicketSum1.Enabled = False
                FrameTicketSum3.Enabled = False
            Case 3
                PanelTicketButton3.BackColor = Color.BlanchedAlmond
                PanelKeyPad.Top = PanelTicketButton3.Top
                FrameTicketSum3.Visible = False
                PanelTicketButton2.Enabled = False
                PanelTicketButton1.Enabled = False
                FrameTicketSum2.Enabled = False
                FrameTicketSum1.Enabled = False
        End Select
        SpecifyTicketTimer.Start()
    End Sub
    Private Sub CancelSelected(ByVal CatNo As Integer)
        'FrameTicketSum Cancel 
        'reset all PanelTicketButtons
        PanelTicketButton1.Enabled = True
        PanelTicketButton2.Enabled = True
        PanelTicketButton3.Enabled = True
        FrameTicketSum1.Enabled = True
        FrameTicketSum2.Enabled = True
        FrameTicketSum3.Enabled = True
        PanelTicketButton1.BackColor = Color.LightSteelBlue
        PanelTicketButton2.BackColor = Color.LightSteelBlue
        PanelTicketButton3.BackColor = Color.LightSteelBlue

        TotalTicketSold(CatNo - 1) = 0
        PanelKeyPad.Visible = False
        'Recalculate total
        TotalPrice = 0
        For i = 0 To UBound(TicketTypes, 2)
            TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
            TotTicketCount = TotTicketCount + TotalTicketSold(i)
        Next
        lblTotal.Text = "Ticket Purchase Total: " & FormatCurrency(TotalPrice, 0)
        If TotalPrice > 0 Then
            cmdPurchase.Visible = True
            cmdPurchase.Enabled = True
            lblTotal.Visible = True

            'lblInstructions.Caption = "Please select another category or press PURCHASE THESE TICKETS"
        Else
            lblTotal.Visible = False
            cmdPurchase.Visible = False

            ' lblInstructions.Caption = "Please select a ticket category that you would like to purchase"

        End If
    End Sub

    Private Sub SpecifyTicketTimer_Tick(sender As Object, e As EventArgs) Handles SpecifyTicketTimer.Tick
        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()
    End Sub

    Private Sub cmdPurchase_Click(sender As Object, e As EventArgs) Handles cmdPurchase.Click
        LogClick("SpecifyTickets", TotTicketCount.ToString & " Tickets Selected")
        VerifyPurchase.Show()
        Me.Close()
    End Sub
    Private Sub PopulateButtons(ByVal i As Integer)

        'Dim Index As Integer
        'Dim BottomButton As Integer
        'Dim ShowFirst As Boolean
        Dim BaseTicket As Double
        Dim Tax As String
        If EventCity = "NEW YORK" Then
            BaseTicket = CDec(TicketTypes(3, i)) / (1.0# + 0.08875)
            Tax = FormatCurrency(BaseTicket, 2) & " plus " & FormatCurrency(TicketTypes(3, i) - BaseTicket, 2) & " tax"
            '        imgProgram.Picture = LoadPicture(App.path & "/NYProgram.jpg")
            '        imgProgram.Visible = True
        Else
            Tax = ""
            '        lblTax(i).Visible = False
            '        imgProgram.Visible = False
        End If
        'Populate Buttons
        Select Case i
            Case 0
                lCategory1.Text = TicketTypes(5, i) & "  $" & TicketTypes(3, i)
                If Tax <> "" Then
                    lTax1.Text = Tax
                Else
                    lTax1.Visible = False
                End If
                lDesc1.Text = TicketTypes(4, i)
                PanelTicketButton1.Visible = True
            Case 1
                lCategory2.Text = TicketTypes(5, i) & "  $" & TicketTypes(3, i)
                If Tax <> "" Then
                    lTax2.Text = Tax
                Else
                    lTax2.Visible = False
                End If
                lDesc2.Text = TicketTypes(4, i)
                PanelTicketButton2.Visible = True
            Case 2
                lCategory3.Text = TicketTypes(5, i) & "  $" & TicketTypes(3, i)
                If Tax <> "" Then
                    lTax3.Text = Tax
                Else
                    lTax3.Visible = False
                End If
                lDesc3.Text = TicketTypes(4, i)
                PanelTicketButton3.Visible = True
        End Select
    End Sub


End Class