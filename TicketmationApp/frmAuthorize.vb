Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
'Imports System.Data.SqlClient
'Imports System.Configuration
'Imports System.Data.OleDb
'Imports MSCommLib
Public Class frmAuthorize
    ' Private comPort As New SerialPort()
    'Private MSComm As New MSComm
    'Public con As New OleDbConnection(ConfigurationManager.ConnectionStrings(strConnectionString).ConnectionString)
    'Public cmd As New OleDbCommand
    'Public rs As OleDbDataReader

    Private Sub frmAuthorize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'timerProcessing.Interval = 100
        'timerProcessing.Start()
        'timerAuthorize.Start()
        'MsgBox(CardNumber)
        timerRemove.Interval = 100
        timerRemove.Start()
    End Sub
    Sub PrintTickets()
        'Dim strPrint As String
        Dim i As Integer
        Dim j As Integer
        Dim K As Integer
        Dim m As Integer
        Dim n As Integer
        Dim TicketreceiptID As String
        Dim CurrentStock As Integer
        Dim CurrentTicStart As Integer
        Dim bProgram As Boolean
        K = 0
        bProgram = False
        'On Error GoTo PrintProblem
        wait_status = True
        Response = True
        ready = True
        problem = False
        duration = 0.5
        Display_Flag = True

        'MSComm.CommPort = 4
        'MSComm.Settings = "9600,N,8,1"
        'MSComm.OutBufferSize = 2048
        '' Open the port.
        'MSComm.RThreshold = 1
        'MSComm.SThreshold = 1
        ''MSComm.InputMode = comInputModeText
        'MSComm.InputLen = 0
        'MSComm.InBufferCount = 0
        ''MSComm.InputMode = comInputModeText
        ''MSComm.Handshaking = comNone
        'MSComm.PortOpen = True
        Try
            wait_status = True
            Response = True
            ready = True
            problem = False
            duration = 0.5
            Display_Flag = True

            AxMSComm1.CommPort = 4
            AxMSComm1.Settings = "9600,N,8,1"
            AxMSComm1.OutBufferSize = 2048
            '' Open the port.
            AxMSComm1.RThreshold = 1
            AxMSComm1.SThreshold = 1
            AxMSComm1.InputMode = MSCommLib.InputModeConstants.comInputModeText
            AxMSComm1.InputLen = 0
            AxMSComm1.InBufferCount = 0
            ''MSComm.InputMode = comInputModeText
            ''MSComm.Handshaking = comNone
            AxMSComm1.PortOpen = True

        Catch ex As Exception
            'Printer Not Attached
            PrinterError = True
            GoTo PrintProblem
            'frmPrinterError.Show()
            'Me.Close()
            'Exit Sub
        End Try
        Dim totalPrice As Integer = 0
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 And Not PrinterError Then
                totalPrice = totalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                For j = 1 To TotalTicketSold(i)
                    K = K + 1
                    Call PrintTicketsBoca(i, K)
                    If PrinterError Then GoTo PrintProblem
                Next j
            End If
        Next i
        ''Close Print Port
        AxMSComm1.PortOpen = False
        'MSComm.PortOpen = False
        RecordPurchase(totalPrice)

        'With cmd
        '    .Connection = con
        '    .CommandType = CommandType.Text
        '    .CommandText = "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount,SessionID) values(@ShowID,@PurchaseDate,@otalPrice,@SessionID)"
        '    .Parameters.AddWithValue("@ShowID", ShowID.ToString)
        '    .Parameters.AddWithValue("@PurchaseDate", Now().ToString)
        '    .Parameters.AddWithValue("@TotalPrice", totalPrice.ToString)
        '    .Parameters.AddWithValue("@SessionID", SessionID.ToString)
        'End With
        'Try
        '    con.Open()
        '    cmd.ExecuteNonQuery()
        'Catch sqlEx As SqlException
        '    MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        'End Try
        'cmd = New OleDbCommand("Select Max(TicketReceiptID) as TRID from PURCHASE_INFO", con)
        'rs = cmd.ExecuteReader()
        'rs.Read()
        'Dim comd As New OleDbCommand
        'TicketreceiptID = rs(0).ToString
        'For i = 0 To UBound(TicketTypes, 2)
        '    If TotalTicketSold(i) > 0 Then
        '        With comd
        '            .Connection = con
        '            .CommandType = CommandType.Text
        '            .CommandText = "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(@TicketreceiptID,@TicketCategoryID,@NumberTickets)"
        '            .Parameters.AddWithValue("@TicketreceiptID", TicketreceiptID)
        '            .Parameters.AddWithValue("@TicketCategoryID", TicketTypes(1, i))
        '            .Parameters.AddWithValue("@NumberTickets", TotalTicketSold(i).ToString)
        '        End With
        '        Try
        '            'con.Open()
        '            comd.ExecuteNonQuery()
        '        Catch sqlEx As SqlException
        '            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        '        End Try

        '        'db.Execute "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
        '    End If
        'Next i
        'Set rsTicketstock = db.OpenRecordset("Select * from TICKET_STOCK")
        'If bProgram Then K = K + 1
        'db.Execute "Update TICKET_STOCK set TicketStock=" & CStr(rsTicketstock(0) - K) & ",StartingTix=" & CStr(rsTicketstock(1) + K)
        UpdateTicketStock(K)
        'cmd = New OleDbCommand("Select * from TICKET_STOCK", con)
        'rs = cmd.ExecuteReader()
        'rs.Read()
        'CurrentStock = rs(0)
        'CurrentTicStart = rs(1)
        'If bProgram Then K = K + 1
        'With comd
        '    .Connection = con
        '    .CommandType = CommandType.Text
        '    .CommandText = "Update TICKET_STOCK set TicketStock=" & (CurrentStock - K).ToString & ",StartingTix=" & (CurrentTicStart + K).ToString
        'End With
        'Try
        '    'con.Open()
        '    comd.ExecuteNonQuery()
        'Catch sqlEx As SqlException
        '    MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        'End Try

        'con.Close()

        'TotalPrice = 0
        'For i = 0 To UBound(TicketTypes, 2)
        '    If TotalTicketSold(i) > 0 Then
        '        TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
        '    End If
        'Next i

        'Timer1.interval = 1000
        'Timer1.Enabled = True

        'db.Execute "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount,SessionID) values(" & ShowID & ",#" & Now() & "#," & TotalPrice & "," & SessionID & ")"
        'Set rs = db.OpenRecordset("Select Max(TicketReceiptID) as TRID from PURCHASE_INFO")
        'For i = 0 To UBound(TicketTypes, 2)
        '    If TotalTicketSold(i) > 0 Then db.Execute "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
        'Next i

        'Set rsTicketstock = db.OpenRecordset("Select * from TICKET_STOCK")
        'If bProgram Then K = K + 1
        'db.Execute "Update TICKET_STOCK set TicketStock=" & CStr(rsTicketstock(0) - K) & ",StartingTix=" & CStr(rsTicketstock(1) + K)
        Exit Sub
PrintProblem:
        'Printer Not Attached
        'frmPrinterError.Show()
        'Me.Close()
        'PrinterError = True
    End Sub

    Private Sub timerProcessing_Tick(sender As Object, e As EventArgs) Handles timerProcessing.Tick
        Select Case Len(lblProcessing.Text)
            Case 0
                lblProcessing.Text = "P"
            Case 1
                lblProcessing.Text = "PR"

            Case 2
                lblProcessing.Text = "PRO"

            Case 3
                lblProcessing.Text = "PROC"

            Case 4
                lblProcessing.Text = "PROCE"

            Case 5
                lblProcessing.Text = "PROCES"

            Case 6
                lblProcessing.Text = "PROCESS"

            Case 7
                lblProcessing.Text = "PROCESSI"

            Case 8
                lblProcessing.Text = "PROCESSIN"

            Case 9
                lblProcessing.Text = "PROCESSING"

            Case 10
                lblProcessing.Text = "PROCESSING."

            Case 11
                lblProcessing.Text = "PROCESSING.."

            Case 12
                lblProcessing.Text = "PROCESSING..."
            Case 13
                lblProcessing.Text = ""

        End Select
    End Sub

    Private Sub timerAuthorize_Tick(sender As Object, e As EventArgs) Handles timerAuthorize.Tick
        timerAuthorize.Stop()
        timerProcessing.Stop()
        lblProcessing.Text = "APPROVED"
        lblDoNotRemove.Text = "PLEASE REMOVE CARD"
        timerRemove.Start()

    End Sub

    Private Sub timerRemove_Tick(sender As Object, e As EventArgs) Handles timerRemove.Tick
        timerRemove.Stop()
        If CardApproved Then

            lblProcessing.Text = "APPROVED...TICKETS PRINTING"
            lblDoNotRemove.Text = ""
            LogClick("Authorize", "Approved for " & CardNumber)

            PrintTickets()
            If PrinterError Then GoTo PrintError



            ''
            'BarCode = "9999999999"

            ''
            lblProcessing.Text = "TAKE TICKETS FROM SLOT BELOW"
            timerTakeTix.Start()

        Else

            lblProcessing.Text = "CARD DECLINED "
            lblDoNotRemove.Text = ""
            'lSubText.Text = Strings.Left(DeclineMessage, 90)
            lSubText.Text = DeclineMessage
            LogClick("Authorize", "DECLINED for " & CardNumber)
            timerDecline.Interval = 4000
            timerDecline.Start()

        End If
        Exit Sub
PrintError:
        frmPrinterError.Show()
        Me.Close()
    End Sub
    Sub PrintTicketsBoca(i As Integer, K As Integer)
        Dim strPrint As String
        Dim printLocation As String
        Dim iPrintLocation As Integer
        Dim printShow As String
        Dim iPrintShow As Integer
        Dim printPrice As String
        Dim iTicketType As String
        'Dim oledbAdapter As OleDbDataAdapter
        Dim rsHeaders As New DataSet
        Dim rsBarCodes As New DataSet
        Dim thisType As Integer
        Dim iCycles As Integer
        Dim strBarCode As String
        Dim strBarCodeTXT As String
        Dim strEventType As String
        Dim printTax1 As String
        Dim strToday As String
        Dim BaseTicket As Double
        Dim Headers(7) As String
        'On Error GoTo PrintErr
        '***TEST
        'ANTransactionCode = "333333333333"
        '****
        iCycles = 0
        'Get Show information
        ''If (con.State <> ConnectionState.Open) Then con.Open()
        ''cmd.Connection = con

        ''oledbAdapter = New OleDbDataAdapter("Select * from TICKET_HEADERS where ShowID=" & ShowID, con)
        ''oledbAdapter.Fill(rsHeaders, "Headers")
        Headers = GetHeaders()

        'If rsHeaders.Tables("Batch").Rows(0).Item(0) = 0 Then
        '    nBatch = 0
        '    '    'lOffLine.Caption = "0"
        'Else
        '    nBatch = ds.Tables("Batch").Rows(0).Item(0)
        'End If
        'rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
        problem = False
        EventType = "AUTO SHOW"
        printTax1 = ""
        '''''
        Select Case TicketTypes(1, i)
            Case 1
                iTicketType = "81"
                ' printTax1 = Format(BaseTicket, "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & " tax"
            Case 2
                iTicketType = "84"
            Case 3
                iTicketType = "82"
            Case 16
                iTicketType = "83"
            Case Else
                iTicketType = "85"
        End Select
        If EventCity = "NEW YORK" Then
            BaseTicket = CDec(TicketTypes(3, i)) / (1.0# + 0.08875)
            printTax1 = Format(BaseTicket, "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & "tax"
        Else
            printTax1 = ""
        End If


        'strBarCode = iTicketType & IP.ToString("00") & Trim(SessionCounter) & Trim(Str(SessionID)) & Format(K, "0#")
        strBarCode = iTicketType & IP.PadLeft(2, "00") & Trim(SessionCounter) & Trim(Str(SessionID)) & K.ToString("D2")
        'Saves last Barcode
        BarCode = strBarCode
        strBarCodeTXT = strBarCode
        If bDEMO And bDEMOP Then
            strBarCode = ""
        End If
        'Show Location
        'printLocation = rsHeaders("Location")
        'printLocation = rsHeaders.Tables("Headers").Rows(0).Item(7)
        printLocation = Headers(7)
        'printShow = rsHeaders("Header2")
        'printShow = rsHeaders.Tables("Headers").Rows(0).Item(2)
        printShow = Headers(2)
        printPrice = "$" & TicketTypes(3, i) & ".00"
        'Calculate print locations for SHOW and VENUE
        iPrintShow = 395 - CInt((Len(printShow) * 25) / 2)
        iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

        'TODAY
        strToday = DateTime.Now.ToString("DD/MM/yyyy")

        'BOCA PRINTER
        strPrint = "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
        'Move price up to same level as Location
        strPrint = strPrint & "<NR><RC80,15><F7><HW1,1>" & printPrice
        'Add tax
        strPrint = strPrint & "<NR><RC105,15><F2><HW1,1>" & printTax1
        ' was strPrint = strPrint & "<NR><RC90,15><F7><HW1,1>" & printPrice
        strPrint = strPrint & "<RC80,700><F7>" & printPrice
        'Add tax
        strPrint = strPrint & "<NR><RC105,700><F2><HW1,1>" & printTax1
        'strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
        'strPrint = strPrint & "<RC130,15><F7>" & rsHeaders.Tables("Headers").Rows(0).Item(5)
        strPrint = strPrint & "<RC130,15><F7>" & Headers(5)
        strPrint = strPrint & "<RC120,150><LT3><HX525>"
        strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
        'strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
        ' strPrint = strPrint & "<RC130,700><F7>" & rsHeaders.Tables("Headers").Rows(0).Item(5)
        strPrint = strPrint & "<RC130,700><F7>" & Headers(5)
        strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
        strPrint = strPrint & "<RC180,150><F10><HW1,1>**** " & EventType & " ****"
        strPrint = strPrint & "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
        strPrint = strPrint & "<RC220,150><LT3><HX525>"
        strPrint = strPrint & "<RC270,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
        '
        'strPrint = strPrint & "<RC230,200><F3>" & rsHeaders("Header4")
        'strPrint = strPrint & "<RC230,200><F3>" & rsHeaders.Tables("Headers").Rows(0).Item(4)
        strPrint = strPrint & "<RC230,200><F3>" & Headers(4)
        'strPrint = strPrint & "<RC230,200><F3>GOOD " & strToday & " ONLY"
        strPrint = strPrint & "<RC270,700><F3>" & CStr(K) & " of " & TotTicketCount
        strPrint = strPrint & "<RC270,250><F9>" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
        strPrint = strPrint & "<RC290,200><F13><HW2,1>NO REFUNDS OR EXCHANGES"
        strPrint = strPrint & "<RC320,15><F9><HW1,1>" & DateTime.Now.ToString("MM/dd/yyyy")
        strPrint = strPrint & "<RC320,700><F9><HW1,1>" & DateTime.Now.ToString("MM/dd/yyyy")
        strPrint = strPrint & "<RC0,850><LT5><HY370>"
        strPrint = strPrint & "<RC40,1005><LT5><VX330>"
        strPrint = strPrint & "<RC40,1035><LT5><VX330>"
        strPrint = strPrint & "<RL><RC300,870><F3><HW1,1>" & strBarCodeTXT

        strPrint = strPrint & "<RC60,990><FL10><X3>:" & strBarCode & ":"

        'Disclaimer
        iPrintShow = 200 + CInt((Len(printShow & " " & EventType) * 13) / 2)
        strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
        strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
        strPrint = strPrint & "<RC270,1060><F2><HW1,1>" & TransactionID
        'If bDebug Then MsgBox "Send Print Command"
        strPrint = strPrint & "<p>"
        con.Close()
        'MSComm.Output = strPrint
        AxMSComm1.Output = strPrint
        ack_found = False
        If wait_status = True Then
            wait_for_ack()                 'Wait for the ACK
        End If
        'problem = True
        'Do
        '    iCycles = iCycles + 1
        '    Application.DoEvents()
        'Loop Until iCycles > 100
        If problem = True Then GoTo PrintErr
        'Dim PrintBuffer As String
        '' Wait for data to come back to the serial port.
        'iCycles = 0
        'Do
        '    PrintBuffer = CStr(Me.AxMSComm1.Input())
        '    iCycles = iCycles + 1
        '    Application.DoEvents()
        'Loop Until Len(PrintBuffer) > 0 Or iCycles > 100
        'PrinterError = False
        'If Len(PrintBuffer) = 0 Then GoTo PrintErr
        '        MsgBox(PrintBuffer)
        'Close Port
        'Me.AxMSComm1.PortOpen = False



        'AxMSComm1.CommEvent
        'ack_found = False
        'If wait_status = True Then
        '    wait_for_ack()                 'Wait for the ACK
        'End If
        'If problem = True Then GoTo PrintErr

        ''''REPLACE WITH ACK
        '    Sleep 700
        '   Do
        '        DoEvents
        '        Buffer = Buffer & SerialPortPrinter.Input
        '        iCycles = iCycles + 1
        '        If iCycles > 10 Then
        '        'If iCycles > 30 Then
        '           PrinterError = True
        '           If bDebug Then MsgBox "PrinterError Set, iCycles=" & CStr(iCycles)
        '
        '            Buffer = "XX"
        '        End If
        '    Loop Until Len(Buffer) > 0
        ''''''''''''''''''''''
        Call LogClick("Print BarCode", strBarCode)
        Exit Sub
PrintErr:
        'If bDebug Then MsgBox Err.Description
        'Printer Not Attached
        PrinterError = True
        'frmPrinterError.Show()
        'Me.Close()
        ''       Exit Sub
    End Sub

    Private Sub timerACK_Tick(sender As Object, e As EventArgs) Handles timerACK.Tick
        timer_flag = True
        timerACK.Stop()
    End Sub
    Private Sub PrintTestTicket()
        'Dim strPrint As String
        'Dim printLocation As String
        'Dim iPrintLocation As Integer
        'Dim printShow As String
        'Dim iPrintShow As Integer
        'Dim TestBarCode As String
        'Dim TestCodes(10) As String

        'Dim testJournalID As Long
        'Dim testDeviceID As String
        'Dim testTicketType As String
        'Dim testNumTix As Integer
        'Dim i As Integer

        ' '''''''''''''
        'ShowID = 70
        'ReDim TicketTypes(6, 1)

        'TicketTypes(1, 1) = 1
        'TicketTypes(3, 1) = 10.0#
        'TicketTypes(5, 1) = "ADULT"
        'TotTicketCount = 1
        'ANTransactionCode = "333333333"

        'wait_status = True
        'Response = True
        'ready = True
        'problem = False
        'duration = 0.5
        'Display_Flag = True



        'MSComm.CommPort = 4
        'MSComm.Settings = "9600,N,8,1"
        'MSComm.OutBufferSize = 2048
        'MSComm.InputLen = 0
        'MSComm.PortOpen = True
        'MSComm.RThreshold = 1
        'MSComm.SThreshold = 1
        ''MSComm.InputMode = comInputModeText
        'MSComm.InputLen = 0
        'MSComm.InBufferCount = 0
        ''MSComm.InputMode = comInputModeText
        ''MSComm.Handshaking = comNone
        ''Call PrintTicketsBocaT(1, 1)
        ''Call PrintTicketsHSG(1, 1)

        'printLocation = "LOS ANGELES CONV CENTER"
        ''printLocation = "JACOB K JAVITS CONV CENTER"
        'printShow = "2009 LA INTL"
        ''printShow = "2009 NY INTL"
        'testJournalID = 123456
        'testDeviceID = "19"
        'testTicketType = "811"
        'testNumTix = 1
        'TestCodes(1) = "SWlw72TSywzZ"
        'TestCodes(2) = "TTGhkQV8ZY9c"
        'TestCodes(3) = "D6XkJDF2wYMc"
        'TestCodes(4) = "lXRxVDm8WMMp"
        'TestCodes(5) = "K5lxVDL8YlmZ"
        'TestCodes(6) = "d17wJQf5M9mc"
        'TestCodes(7) = "R6WwJQS8398N"


        'TestBarCode = "SWlw72TSywzZ"
        'iPrintShow = 410 - CInt((Len(printShow) * 25) / 2)
        'iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

        'For i = 1 To testNumTix
        '    TestBarCode = TestCodes(i)
        '    strPrint = "<NR><RC50," & CStr(iPrintLocation) & "><F8>" & printLocation
        '    strPrint = strPrint & "<NR><RC90,10><F7>$10.00"
        '    strPrint = strPrint & "<RC90,700><F7>$10.00"
        '    'strPrint = strPrint & "<RC130,10><F7>2008NY"
        '    strPrint = strPrint & "<RC130,10><F7>2008LA"
        '    strPrint = strPrint & "<RC120,150><LT3><HX525>"
        '    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
        '    'strPrint = strPrint & "<RC130,700><F7>2008NY"
        '    strPrint = strPrint & "<RC130,700><F7>2008LA"
        '    strPrint = strPrint & "<RC180,10><F3><HW2,1>ADULT"
        '    strPrint = strPrint & "<RC180,150><F10><HW1,1>**** AUTO SHOW****"
        '    strPrint = strPrint & "<RC180,700><F3><HW2,1>ADULT"
        '    strPrint = strPrint & "<RC220,150><LT3><HX525>"
        '    strPrint = strPrint & "<RC270,10><F3><HW1,1>" & CStr(i) & " of " & testNumTix
        '    strPrint = strPrint & "<RC230,200><F3>Dec 4 to 13, 2009"
        '    strPrint = strPrint & "<RC270,700><F3>" & CStr(i) & " of " & testNumTix
        '    strPrint = strPrint & "<RC270,250><F9>" & Now()

        '    strPrint = strPrint & "<RC300,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
        '    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
        '    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
        '    'ABOVE BAR CODE
        '    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & testTicketType & testDeviceID & CStr(testJournalID) & CStr(i)
        '    strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & TestBarCode
        '    'BAR CODE
        '    'strPrint = strPrint & "<RC20,990><NL10><X2>*" & testTicketType & testDeviceID & CStr(testJournalID) & CStr(i) & "*"
        '    strPrint = strPrint & "<RC20,990><OL10><X2>^" & TestBarCode & "^"
        '    'Disclaimer
        '    'strPrint = strPrint & "<RC360,1015><F9><HW1,1>2009 NY INTL AUTO SHOW"
        '    strPrint = strPrint & "<RC360,1015><F9><HW1,1>2009 LA INTL AUTO SHOW"
        '    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
        '    strPrint = strPrint & "<RC340,1060><F2><HW1,1>No Refunds  No Exchanges"
        '    'strPrint = strPrint & "<RC380,1075><F2><HW1,1>Holder releases SHOW for any liability"

        '    strPrint = strPrint & "<p>"
        '    MSComm.Output = strPrint

        '    'Sleep 700

        '    '   Do
        '    '      DoEvents
        '    '   Buffer$ = Buffer$ & MSComm.Input
        '    '   Loop Until Len(Buffer$) > 0
        'Next i
        ''
        'MSComm.PortOpen = False

    End Sub

    Private Sub timerTakeTix_Tick(sender As Object, e As EventArgs) Handles timerTakeTix.Tick
        timerTakeTix.Stop()
        If bHaveInternet And Not bDEMO Then
            UpdateSQLPurchase()

        Else
            'Write to Batch

        End If
        LogClick("Authorize", "Tickets Printed")
        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()


    End Sub

    Private Sub timerDecline_Tick(sender As Object, e As EventArgs) Handles timerDecline.Tick
        timerDecline.Stop()
        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()
    End Sub

    'Private Sub AxMSComm1_OnComm(sender As Object, e As EventArgs) Handles AxMSComm1.OnComm

    'End Sub

    'Private Sub lSubText_Click(sender As Object, e As EventArgs) Handles lSubText.Click

    'End Sub

    Private Sub AxMSComm1_OnComm(sender As Object, e As EventArgs) Handles AxMSComm1.OnComm

        Dim SReply(48) As Byte
        Dim Replied As Boolean
        Dim Rx As String
        Dim RxNumeric As String
        Dim i As Short
        'MsgBox(AxMSComm1.CommEvent)
        Rx = AxMSComm1.Input
        RxNumeric = ""
        For i = 1 To Len(Rx)
            SReply(i - 1) = Asc(Mid(Rx, i, 1))
            RxNumeric = RxNumeric & " " & Hex(SReply(i - 1))
        Next i
        If RxNumeric = " 6" Then
            ack_found = True
            'problem = False
        End If

        'txtWindow.Text = RxNumeric
        'Replied = True
    End Sub
End Class