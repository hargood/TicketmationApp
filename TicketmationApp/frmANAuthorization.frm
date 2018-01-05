VERSION 5.00
Object = "{648A5603-2C6E-101B-82B6-000000000014}#1.1#0"; "MSCOMM32.OCX"
Begin VB.Form frmANAuthorization 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   ClientHeight    =   9615
   ClientLeft      =   1545
   ClientTop       =   1830
   ClientWidth     =   13470
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   Moveable        =   0   'False
   Picture         =   "frmANAuthorization.frx":0000
   ScaleHeight     =   9615
   ScaleWidth      =   13470
   ShowInTaskbar   =   0   'False
   WindowState     =   2  'Maximized
   Begin VB.Timer TimerACK 
      Enabled         =   0   'False
      Left            =   240
      Top             =   1560
   End
   Begin VB.Timer Timer4 
      Enabled         =   0   'False
      Left            =   150
      Top             =   3945
   End
   Begin VB.Timer Timer3 
      Enabled         =   0   'False
      Left            =   180
      Top             =   3240
   End
   Begin VB.TextBox Text1 
      Height          =   1020
      Left            =   1620
      MultiLine       =   -1  'True
      TabIndex        =   1
      Top             =   6015
      Visible         =   0   'False
      Width           =   645
   End
   Begin VB.Timer Timer2 
      Enabled         =   0   'False
      Left            =   195
      Top             =   2670
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Left            =   195
      Top             =   2130
   End
   Begin MSCommLib.MSComm SerialPortPrinter 
      Left            =   0
      Top             =   0
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      DTREnable       =   -1  'True
   End
   Begin VB.Image ImFinger 
      Height          =   945
      Left            =   11250
      Picture         =   "frmANAuthorization.frx":2176
      Stretch         =   -1  'True
      Top             =   8415
      Visible         =   0   'False
      Width           =   2145
   End
   Begin VB.Label lblDebit 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Please enter requested information here"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   24
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   750
      Left            =   1905
      TabIndex        =   2
      Top             =   7575
      Visible         =   0   'False
      Width           =   9255
   End
   Begin VB.Image Image1 
      Height          =   1515
      Left            =   2445
      Top             =   0
      Width           =   1455
   End
   Begin VB.Label lblMessage 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Please wait for bank authorization"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   24
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1725
      Left            =   1650
      TabIndex        =   0
      Top             =   4080
      Width           =   11475
   End
End
Attribute VB_Name = "frmANAuthorization"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim strCommand As String

Sub PrintTicketsBoca(i As Integer, K As Integer)
Dim strPrint As String
Dim printLocation As String
Dim iPrintLocation As Integer
Dim printShow As String
Dim iPrintShow As Integer
Dim printPrice As String
'Dim testJournalID As Long
'Dim testDeviceID As String
Dim iTicketType As String
Dim rsHeaders As Recordset
Dim rsBarCodes As Recordset
Dim thisType As Integer
Dim iCycles As Integer
Dim strBarCode As String
Dim strBarCodeTXT As String
Dim strEventType As String
Dim printTax1 As String
Dim strToday As String
Dim BaseTicket As Double

'printTax1 = "$12.86+1.14tax"
On Error GoTo PrintErr

If bDebug Then MsgBox "ENTER HSG PRINT"
iCycles = 0
'Get Show information
Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
'Set EVENT TYPE for ticket
    EventType = "AUTO SHOW"
'Create appropriate Barcode
'IF NOT NY
printTax1 = ""
'''''
'IF NY
Select Case TicketTypes(1, i)
    Case 1
        iTicketType = "81"
'        BaseTicket = CDec(TicketTypes(3, i)) / (1# + 0.08875)
'        'printTax1 = Format(CDec(TicketTypes(3, i)) * (1# - 0.08875), "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & "tax"
'        printTax1 = Format(BaseTicket, "$#.00") & " plus " & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & " tax"
    Case 2
        iTicketType = "84"
    Case 3
        iTicketType = "82"
        'printTax1 = "$4.49+$0.41tax"
'        printTax1 = Format(CDec(TicketTypes(3, i)) * (1# - 0.08875), "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & "tax"
    Case 16
        iTicketType = "83"
        'printTax1 = "$4.59+$0.41tax"
'        printTax1 = Format(CDec(TicketTypes(3, i)) * (1# - 0.08875), "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & "tax"
    Case Else
        iTicketType = "85"
End Select
BaseTicket = CDec(TicketTypes(3, i)) / (1# + 0.08875)
'printTax1 = Format(CDec(TicketTypes(3, i)) * (1# - 0.08875), "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) * 0.08875, "$#.00") & "tax"
printTax1 = Format(BaseTicket, "$#.00") & "+" & Format(CDec(TicketTypes(3, i)) - BaseTicket, "$#.00") & "tax"

strBarCode = iTicketType & Format(IP, "0#") & Trim(SessionCounter) & Trim(str(SessionID)) & Format(K, "0#")
strBarCodeTXT = strBarCode
If bDEMO And bDEMOP Then
    strBarCode = ""
End If
'Show Location
printLocation = rsHeaders("Location")
printShow = rsHeaders("Header2")
printPrice = Format(TicketTypes(3, i), "$#.00")
'Calculate print locations for SHOW and VENUE
iPrintShow = 395 - CInt((Len(printShow) * 25) / 2)
iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

'TODAY
strToday = Format(Now(), "MMM DD, YYYY")

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
    strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC120,150><LT3><HX525>"
    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
    strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC180,150><F10><HW1,1>**** " & EventType & " ****"
    strPrint = strPrint & "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC220,150><LT3><HX525>"
    strPrint = strPrint & "<RC270,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    '''
    strPrint = strPrint & "<RC230,200><F3>" & rsHeaders("Header4")
    'strPrint = strPrint & "<RC230,200><F3>GOOD " & strToday & " ONLY"
    strPrint = strPrint & "<RC270,700><F3>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC270,250><F9>" & Now()
    strPrint = strPrint & "<RC290,200><F13><HW2,1>NO REFUNDS OR EXCHANGES"
    strPrint = strPrint & "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC320,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC0,850><LT5><HY370>"
    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
    strPrint = strPrint & "<RL><RC300,870><F3><HW1,1>" & strBarCodeTXT

    strPrint = strPrint & "<RC60,990><FL10><X3>:" & strBarCode & ":"
  
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " " & EventType) * 13) / 2)
    strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    strPrint = strPrint & "<RC270,1060><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    strPrint = strPrint & "<p>"

    SerialPortPrinter.output = strPrint
    ack_found = False
    If wait_status = True Then
        wait_for_ack                 'Wait for the ACK
    End If
    If problem = True Then GoTo PrintErr

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
If bDebug Then MsgBox "End Buffer Loop"
''''''''''''''''''''''
Call LogClick("Print BarCode", strBarCode)
Exit Sub
PrintErr:
If bDebug Then MsgBox Err.Description

End Sub


Sub PrintTicketsHSG(i As Integer, K As Integer)
Dim strPrint As String
Dim printLocation As String
Dim iPrintLocation As Integer
Dim printShow As String
Dim iPrintShow As Integer
Dim printPrice As String
Dim testJournalID As Long
Dim testDeviceID As String
Dim iTicketType As String
Dim rsHeaders As Recordset
Dim rsBarCodes As Recordset
Dim thisType As Integer
Dim iCycles As Integer
Dim strBarCode As String
Dim strBarCodeTXT As String
Dim strEventType As String
On Error GoTo PrintErr

If bDebug Then MsgBox "ENTER HSG PRINT"
iCycles = 0
'Get Show information
Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
'Set EVENT TYPE for ticket
Select Case EventType
Case "AUTOSHOW"
    EventType = "AUTO SHOW"
Case "SKISHOW"
    EventType = "SKI SHOW"
Case "FAIR"
    EventType = "FAIR"
Case "AOP"
    EventType = "** 866-236-4817 **"
End Select

'Create appropriate Barcode
If AOPBarcode Then
    'Get next AOP barcode
    'REMOVE FOR TEST
'    Set rsBarCodes = db.OpenRecordset("Select top 1 ID, Barcode from BARCODES where ShowID=" & ShowID & " and UsedDateTime is null ORDER BY ID")
'    db.Execute "UPDATE BARCODES set UsedDateTime=#" & Now() & "# where ID =" & rsBarCodes(0) & " and ShowID=" & ShowID
    Set rsBarCodes = db.OpenRecordset("Select top 1 ID, Barcode from BC2" & Format(IP, "0#") & " where UsedDataTime is null ORDER BY ID")
    db.Execute "UPDATE BC2" & Format(IP, "0#") & " set UsedDataTime=#" & Now() & "# where ID =" & rsBarCodes(0)
    strBarCode = rsBarCodes(1)
'    strBarCode = "SWlw72TSywzZ"
    strBarCodeTXT = Format(IP, "0#") & "-" & Format(rsBarCodes(0), "00000#")
'    strBarCodeTXT = Format(IP, "0#") & "-" & "000009"
Else
    Select Case TicketTypes(1, i)
        Case 1
            iTicketType = "81"
        Case 2
            iTicketType = "84"
        Case 3
            iTicketType = "82"
        Case 16
            iTicketType = "83"
        Case Else
            iTicketType = "85"
    End Select
    'strBarCode = iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    strBarCode = iTicketType & Format(IP, "0#") & Trim(str(SessionID)) & Format(K, "0#")
    strBarCodeTXT = strBarCode
End If


printLocation = rsHeaders("Location")
printShow = rsHeaders("Header2")
printPrice = Format(TicketTypes(3, i), "$#.00")
testTicketType = "81"
'Calculate print locations for SHOW and VENUE
iPrintShow = 395 - CInt((Len(printShow) * 25) / 2)
'iPrintShow = 375 - CInt((Len(printShow) * 25) / 2)
iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

If TicketPrinter = 1 Then
    'BOCA PRINTER
    strPrint = "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
    strPrint = strPrint & "<NR><RC90,15><F7><HW1,1>" & printPrice
    strPrint = strPrint & "<RC90,700><F7>" & printPrice
    'strPrint = strPrint & "<RC130,10><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC120,150><LT3><HX525>"
    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
    strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
    'strPrint = strPrint & "<RC180,10><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
    If ShowID = 59 Then
        strPrint = strPrint & "<RC180,150><F10><HW1,1>" & EventType
    Else
        strPrint = strPrint & "<RC180,150><F10><HW1,1>**** " & EventType & " ****"
    End If
    strPrint = strPrint & "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC220,150><LT3><HX525>"
    'strPrint = strPrint & "<RC270,10><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC270,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC230,200><F3>" & rsHeaders("Header4")
    strPrint = strPrint & "<RC270,700><F3>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC270,250><F9>" & Now()
    'strPrint = strPrint & "<RC300,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
    If ShowID = 59 Then
        strPrint = strPrint & "<RC320,240><F9><HW1,1>SALES@ADMITONEPRODUCTS.COM"
    Else
        strPrint = strPrint & "<RC290,200><F13><HW2,1>NO REFUNDS OR EXCHANGES"
    End If
    'strPrint = strPrint & "<RC290,200><F13><HW2,1>" & rsHeaders("Header5")
'    If ShowID = 57 Then
'        If TicketTypes(5, i) = "ADULT" Then
'            strPrint = strPrint & "<RC350,100><F3><HW1,1>INCLUDES FREE LIFT TICKET VOUCHER"
'        Else
'            strPrint = strPrint & "<RC350,100><F3><HW1,1>DOES NOT INCLUDE LIFT TICKET VOUCHER"
'        End If
'    End If
    strPrint = strPrint & "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC320,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC0,850><LT5><HY370>"
    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(K)
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & strBarCodeTXT

    If AOPBarcode Then
        'strPrint = strPrint & "<RL><RC250,870><F3><HW1,1>" & strBarCodeTXT
        strPrint = strPrint & "<RL><RC270,870><F3><HW1,1>" & strBarCodeTXT
    Else
        'strPrint = strPrint & "<RL><RC270,870><F3><HW1,1>" & strBarCodeTXT
        strPrint = strPrint & "<RL><RC300,870><F3><HW1,1>" & strBarCodeTXT
    End If
'''''3 of 9
    'strPrint = strPrint & "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    'interleaved 2 of 5
    'strPrint = strPrint & "<RC20,990><FL10><X2>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'strPrint = strPrint & "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'strPrint = strPrint & "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
   If AOPBarcode Then
'''''code 128
        strPrint = strPrint & "<RC40,990><OL10><X2>^" & strBarCode & "^"
   Else
   '''''3 of 9
        'strPrint = strPrint & "<RC20,990><FL10><X3>:" & strBarCode & ":"
        'strPrint = strPrint & "<RC60,990><FL10><X3>:" & strBarCode & ":"
        'strPrint = strPrint & "<RC60,990><FL10><X3>*" & strBarCode & "*"
        '
        'strPrint = strPrint & "<RC60,990><OL10><X2>^" & strBarCode & "^"
        'interleaved 2 of 5
        strPrint = strPrint & "<RC60,990><FL10><X3>:" & strBarCode & ":"
    
    End If
    
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " " & EventType) * 13) / 2)
    'strPrint = strPrint & "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    If ShowID = 59 Then
        strPrint = strPrint & "<RC300,1015><F9><HW1,1>" & printShow
    Else
        strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    End If
    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    'strPrint = strPrint & "<RC340,1060><F2><HW1,1>Non Refundable  No Exchanges"
    'strPrint = strPrint & "<RC270,1080><F2><HW1,1>" & ANTransactionCode
    strPrint = strPrint & "<RC270,1060><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    strPrint = strPrint & "<p>"

    SerialPortPrinter.output = strPrint
     
'     ack_found = False
'    If wait_status = True Then
'        wait_for_ack                 'Wait for the ACK
'    End If
    If problem = True Then GoTo PrintErr
   
    
    Sleep 700
    'Sleep 900
'   Do
'        DoEvents
'        Buffer$ = Buffer$ & SerialPortPrinter.Input
'        iCycles = iCycles + 1
'        If iCycles > 10 Then
'        'If iCycles > 30 Then
'           PrinterError = True
'           If bDebug Then MsgBox "PrinterError Set, iCycles=" & CStr(iCycles)
'
'            Buffer$ = "XX"
'        End If
'    Loop Until Len(Buffer$) > 0
    If bDebug Then MsgBox "End Buffer Loop"
ElseIf TicketPrinter = 2 Then
    Dim p As VB.Printer
    'Dim offset As Integer
    'NOTE: there is a -30 offset for PA
    'offset = -30
    
    For Each p In VB.Printers
        'If p.DeviceName = "PA ITL2002F PT" Then
        If p.DeviceName = "Generic / Text Only" Then
        Set Printer = p
        End If
    Next

    'Printer.Print "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    Printer.Print "<NR><RC20," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
    Printer.Print "<NR><RC60,15><F7><HW1,1>" & printPrice
    Printer.Print "<RC60,700><F7>" & printPrice
    'printer.print "<RC130,10><F7>" & rsHeaders("Header5")
    'Printer.Print "<RC100,15><F7>" & rsHeaders("Header5")
    Printer.Print "<RC90,150><LT3><HX525>"
    Printer.Print "<RC100," & CStr(iPrintShow) & "><F10>" & printShow
    'Printer.Print "<RC100,700><F7>" & rsHeaders("Header5")
    'printer.print "<RC180,10><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC150,15><F3><HW2,1>" & TicketTypes(5, i)
    If ShowID = 59 Then
        Printer.Print "<RC150,150><F10><HW1,1>" & EventType
    Else
        Printer.Print "<RC150,150><F10><HW1,1>**** " & EventType & " ****"
    End If
    Printer.Print "<RC150,700><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC190,150><LT3><HX525>"
    'printer.print "<RC270,10><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC240,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC200,200><F3>" & rsHeaders("Header4")
    Printer.Print "<RC240,700><F3>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC240,250><F9>" & Now()
    
    'Printer.Print "<RC270,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
    
    If ShowID = 59 Then
        Printer.Print "<RC300,240><F9><HW1,1>SALES@ADMITONEPRODUCTS.COM"
    Else
        Printer.Print "<RC270,200><F13><HW2,1>NO REFUNDS OR EXCHANGES"
    End If

    
    Printer.Print "<RC290,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC290,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC0,850><LT5><HY370>"
    Printer.Print "<RC10,1005><LT5><VX330>"
    Printer.Print "<RC10,1035><LT5><VX330>"
    'printer.print "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(K)
    '' HG BarCode Printer.Print "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    'AOP Barcode
    'Printer.Print "<RL><RC320,870><F3><HW1,1>" & rsBarCodes(1)
    '''' Remove for AOP Printer.Print "<RL><RC320,870><F3><HW1,1>" & rsBarCodes(1)
    'Printer.Print "<RL><RC320,870><F3><HW1,1>" & Format(rsBarCodes(0), "00000#")
    If AOPBarcode Then
        Printer.Print "<RL><RC270,870><F3><HW1,1>" & strBarCodeTXT
    Else
        Printer.Print "<RL><RC250,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    End If
    '3 of 9
    'printer.print "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    'interleaved 2 of 5
    'printer.print "<RC20,990><FL10><X2>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'printer.print "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    ''HG BARCODE
   ' Printer.Print "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
    ''AOP BARCODE
    If AOPBarcode Then
        Printer.Print "<RC20,990><OL10><X2>^" & rsBarCodes(1) & "^"
    Else
        Printer.Print "<RC20,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
    End If
    'code 128  DOESN'T WORK
    'printer.print "<RC20,990><OL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " " & EventType) * 13) / 2)

    'printer.print "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    If ShowID = 59 Then
        Printer.Print "<RC300,1015><F9><HW1,1>" & printShow
    Else
        Printer.Print "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    End If
    Printer.Print "<RC340,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    'Printer.Print "<RC320,1060><F2><HW1,1>Non Refundable  No Exchanges"
    Printer.Print "<RC300,1080><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    Printer.Print "<p>"
    Sleep 3000
    Printer.EndDoc

    If bDebug Then MsgBox "End Buffer Loop"
End If
Call LogClick("Print BarCode", strBarCode)
Exit Sub
PrintErr:
If bDebug Then MsgBox Err.Description

End Sub



Sub PrintReceiptHSG()
Dim strPrint As String
Dim printLocation As String
Dim iPrintLocation As Integer
Dim printShow As String
Dim iPrintShow As Integer
Dim printPrice As String
Dim testJournalID As Long
Dim testDeviceID As String
Dim iTicketType As String
'Dim i As Integer
Dim rsHeaders As Recordset
Dim thisType As Integer
If bDebug Then MsgBox "ENTER HSG Receipt"
            
Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)

Select Case EventType
Case "AUTOSHOW"
    EventType = "AUTO SHOW"
Case "SKISHOW"
    EventType = "SKI SHOW"
Case "FAIR"
    EventType = "FAIR"
Case "AOP"
    EventType = "** 866-236-4817 **"
End Select


'Select Case TicketTypes(1, i)
'Case 1
'    iTicketType = "810"
'Case 3
'    iTicketType = "820"
'Case 16
'    iTicketType = "830"
'End Select
''iTicketType = "8" & Format(TicketTypes(1, i), "0#")
printLocation = rsHeaders("Location")
printShow = rsHeaders("Header2")
'printPrice = Format(TicketTypes(3, i), "$#.00")
printPrice = Format(TotalPrice, "$#.00")
''testJournalID = 123456
''testDeviceID = "19"
'testTicketType = "81"
'testNumTix = 1

iPrintShow = 410 - CInt((Len(printShow) * 25) / 2)
iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)
If TicketPrinter = 1 Then
    'BOCA
    strPrint = "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
    strPrint = strPrint & "<NR><RC90,15><F7><HW1,1>" & Format(printPrice, "$0#.00")
    strPrint = strPrint & "<RC90,700><F7>" & Format(printPrice, "$0#.00")
    'strPrint = strPrint & "<RC130,10><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC120,150><LT3><HX525>"
    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
    strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
    'strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC180,150><F10><HW1,1>**** AUTO SHOW****"
    'strPrint = strPrint & "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC220,150><LT3><HX525>"
    strPrint = strPrint & "<RC270,15><F3><HW1,1>" & TotTicketCount & " Ticket"
    strPrint = strPrint & "<RC230,200><F3>" & MOP & "  ****" & Right(CardNumber, 4)
    strPrint = strPrint & "<RC270,700><F3>" & TotTicketCount & " Ticket"
    strPrint = strPrint & "<RC270,250><F9>" & Now()
    strPrint = strPrint & "<RC300,200><F13><HW2,1>*****RECEIPT*****"
    strPrint = strPrint & "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC320,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC0,850><LT5><HY370>"
    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(TotTicketCount)
    'strPrint = strPrint & "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(TotTicketCount) & "*"
    strPrint = strPrint & "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(TotTicketCount, "0#") & "*"
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " AUTO SHOW") * 13) / 2)

    'strPrint = strPrint & "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    strPrint = strPrint & "<RC340,1060><F2><HW1,1>Non Refundable  No Exchanges"
    If bDebug Then MsgBox "Send Print Command"
    strPrint = strPrint & "<p>"

    SerialPortPrinter.output = strPrint
    Sleep 700
'   Do
'        DoEvents
'        Buffer$ = Buffer$ & SerialPortPrinter.Input
'
'        Loop Until Len(Buffer$) > 0
  ElseIf TicketPrinter = 2 Then
  ''********************************************''
      Dim p As VB.Printer
    'Dim offset As Integer
    'NOTE: there is a -30 offset for PA
    'offset = -30
    
    For Each p In VB.Printers
        'If p.DeviceName = "PA ITL2002F PT" Then
        If p.DeviceName = "Generic / Text Only" Then
        Set Printer = p
        End If
    Next

    Printer.Print "<NR><RC20," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    Printer.Print "<NR><RC60,15><F7><HW1,1>" & printPrice
    Printer.Print "<RC60,700><F7>" & printPrice
    ''Printer.Print "<RC100,15><F7>" & rsHeaders("Header5")
    Printer.Print "<RC90,150><LT3><HX525>"
    Printer.Print "<RC100," & CStr(iPrintShow) & "><F10>" & printShow
    ''Printer.Print "<RC100,700><F7>" & rsHeaders("Header5")
    ''Printer.Print "<RC150,15><F3><HW2,1>" & TicketTypes(5, i)
    If ShowID = 59 Then
        Printer.Print "<RC150,150><F10><HW1,1>" & EventType
    Else
        Printer.Print "<RC150,150><F10><HW1,1>**** " & EventType & " ****"
    End If
    ''Printer.Print "<RC150,700><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC190,150><LT3><HX525>"
    If TotTicketCount > 1 Then
        Printer.Print "<RC240,15><F3>" & TotTicketCount & " Tickets"
    Else
        Printer.Print "<RC240,15><F3>" & TotTicketCount & " Ticket"
    End If
    Printer.Print "<RC200,200><F3>" & MOP & "  ****" & Right(CardNumber, 4)
    If TotTicketCount > 1 Then
        Printer.Print "<RC240,700><F3>" & TotTicketCount & " Tickets"
    Else
        Printer.Print "<RC240,700><F3>" & TotTicketCount & " Ticket"
    End If
    Printer.Print "<RC240,250><F9>" & Now()
    Printer.Print "<RC270,200><F13><HW2,1>***** RECEIPT ****"

    
    Printer.Print "<RC290,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC290,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC0,850><LT5><HY370>"
    Printer.Print "<RC10,1005><LT5><VX330>"
'    Printer.Print "<RC10,1035><LT5><VX330>"
    If AOPBarcode Then
        Printer.Print "<RL><RC270,910><F9><HW1,1>" & strBarCodeTXT
    Else
        Printer.Print "<RL><RC250,910><F9><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    End If
    Printer.Print "<RC340,970><F10><HW1,1>**RECEIPT**"
'    If AOPBarcode Then
'        Printer.Print "<RC20,990><OL10><X2>^" & rsBarCodes(1) & "^"
'    Else
'        Printer.Print "<RC20,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
'    End If
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
'    iPrintShow = 200 + CInt((Len(printShow & " AUTO SHOW") * 13) / 2)

    'printer.print "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
'    If ShowID = 59 Then
'        Printer.Print "<RC300,1015><F9><HW1,1>" & printShow
'    Else
'        Printer.Print "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
'    End If
    Printer.Print "<RC340,1045><F2><HW1,1>KEEP THIS RECEIPT FOR YOUR RECORDS"
    'Printer.Print "<RC320,1060><F2><HW1,1>Non Refundable  No Exchanges"
    Printer.Print "<RC240,1080><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    Printer.Print "<p>"

    Printer.EndDoc
    If bDebug Then MsgBox "End Buffer Loop"
  
  
  
  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'    Printer.Print "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
'    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
'    Printer.Print "<NR><RC90,15><F7><HW1,1>" & Format(printPrice, "$0#.00")
'    Printer.Print "<RC90,700><F7>" & Format(printPrice, "$0#.00")
'    'printer.print "<RC130,10><F7>" & rsHeaders("Header5")
'    Printer.Print "<RC130,15><F7>" & rsHeaders("Header5")
'    Printer.Print "<RC120,150><LT3><HX525>"
'    Printer.Print "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
'    Printer.Print "<RC130,700><F7>" & rsHeaders("Header5")
'    'printer.print "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
'    Printer.Print "<RC180,150><F10><HW1,1>**** AUTO SHOW****"
'    'printer.print "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
'    Printer.Print "<RC220,150><LT3><HX525>"
'    Printer.Print "<RC270,15><F3><HW1,1>" & TotTicketCount & " Ticket"
'    Printer.Print "<RC230,200><F3>" & MOP & "  ****" & Right(CardNumber, 4)
'    Printer.Print "<RC270,700><F3>" & TotTicketCount & " Ticket"
'    Printer.Print "<RC270,250><F9>" & Now()
'    Printer.Print "<RC300,200><F13><HW2,1>*****RECEIPT*****"
'    Printer.Print "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
'    Printer.Print "<RC320,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
'    Printer.Print "<RC0,850><LT5><HY370>"
'    Printer.Print "<RC40,1005><LT5><VX330>"
'    Printer.Print "<RC40,1035><LT5><VX330>"
'    'printer.print "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(TotTicketCount)
'    'printer.print "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(TotTicketCount) & "*"
'    Printer.Print "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(TotTicketCount, "0#") & "*"
'    If bDebug Then MsgBox "DISCLAIMER"
'
'    'Disclaimer
'    iPrintShow = 200 + CInt((Len(printShow & " AUTO SHOW") * 13) / 2)
'
'    'printer.print "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
'    Printer.Print "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " AUTO SHOW"
'    Printer.Print "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
'    Printer.Print "<RC340,1060><F2><HW1,1>Non Refundable  No Exchanges"
'    If bDebug Then MsgBox "Send Print Command"
'    Printer.Print "<p>"
End If

End Sub


Sub PrintTicketCoupon()
            Dim rsHeaders As Recordset
            Dim thisType As Integer
'            SerialPortPrinter.CommPort = 4
'            SerialPortPrinter.Settings = "9600,N,8,1"
'            ' Open the port.
'            SerialPortPrinter.PortOpen = True

            ''Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
            'If bDebug Then MsgBox strPrint
            
            strPrint = Chr(2) & Chr(11) & Chr(2) & Chr(11) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) ''    {clear printer buffer}
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint
            ''''''''''''''NO BAR CODE '''''''''''''''''''''''''
'''            'strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)  ''    //init barcode Vertical
'''            If xxxx = 1 Then
'''                strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8)
'''            ElseIf xxxx = 2 Then
'''                strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2)
'''            ElseIf xxxx = 3 Then
'''                strPrint = Chr(2) & Chr(8) & Chr(1)
'''            ElseIf xxxx = 4 Then
'''                strPrint = Chr(2) & Chr(8)
'''            ElseIf xxxx = 5 Then
'''                strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)
'''            ElseIf xxxx = 6 Then
'''                strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)
'''            Else
'''                strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)  ''    //init barcode Vertical
'''            End If
'''            SerialPortPrinter.Output = strPrint
'''            '
'''            'thisType = 0
'''            strPrint = Chr(2) & Chr(16) & "COUPON"
'''            SerialPortPrinter.Output = strPrint
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
             strPrint = Chr(2) & Chr(16) & Chr(8) & " *AUTO SHOW STORE DISCOUNT*"

            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(17) & Chr(2) & "$2 OFF"
            
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(17) & Chr(11) & "N CONCOURSE & GALLERIA"
            
            SerialPortPrinter.output = strPrint
               strPrint = Chr(2) & Chr(17) & Chr(34) & "  $2 OFF"
            
            SerialPortPrinter.output = strPrint

            strPrint = Chr(2) & Chr(18) & Chr(2) & "2008NY"
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(11) & "MINIMUM $15 PURCHASE"  'UCase(ln(2))"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(34) & "  2008NY"
            SerialPortPrinter.output = strPrint
            
            strPrint = Chr(2) & Chr(19) & Chr(2) & "COUPON"
            SerialPortPrinter.output = strPrint
            
            strPrint = Chr(2) & Chr(19) & Chr(11) & "******* $2 OFF ****** " 'UCase(ln(3))"
            SerialPortPrinter.output = strPrint
            
                strPrint = Chr(2) & Chr(19) & Chr(34) & "  COUPON"
            SerialPortPrinter.output = strPrint
            
            strPrint = Chr(2) & Chr(20) & Chr(2) & "CPN#1"
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(20) & Chr(11) & "****MARCH 3 - 7, 2004**"  ''UCase(ln(4))
            strPrint = Chr(2) & Chr(20) & Chr(11) & "MARCH 21 - 30, 2008"  ''UCase(ln(4))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(34) & "  CPN#1"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(2) & "K01"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(11) & Now()
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(34) & "  K01"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(1) & "2008NY"
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(22) & Chr(10) & Format(Now(), "m/d/yyyy")
            strPrint = Chr(2) & Chr(22) & Chr(10) & "NOT TO BE COMBINED WITH"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(34) & "  2008NY"
            SerialPortPrinter.output = strPrint
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(11) & "    ANY OTHER OFFERS"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(34) & "   A1234"
            SerialPortPrinter.output = strPrint

           SerialPortPrinter.output = Chr(2) & "pn"
'    SerialPortPrinter.PortOpen = False

End Sub



Sub PrintTicketsNY(i As Integer, K As Integer)
Dim strPrint As String
Dim printLocation As String
Dim iPrintLocation As Integer
Dim printShow As String
Dim iPrintShow As Integer
Dim printPrice As String
Dim testJournalID As Long
Dim testDeviceID As String
Dim iTicketType As String
Dim rsHeaders As Recordset
Dim rsBarCodes As Recordset
Dim thisType As Integer
Dim iCycles As Integer
Dim strBarCode As String
Dim strBarCodeTXT As String
Dim strEventType As String
Dim printTax1 As String

printTax1 = "$12.86+1.14tax"
On Error GoTo PrintErr

If bDebug Then MsgBox "ENTER HSG PRINT"
iCycles = 0
'Get Show information
Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
'Set EVENT TYPE for ticket
    EventType = "AUTO SHOW"
'Create appropriate Barcode
Select Case TicketTypes(1, i)
    Case 1
        iTicketType = "81"
        printTax1 = "$12.86+$1.14tax"
    Case 2
        iTicketType = "84"
    Case 3
        iTicketType = "82"
        printTax1 = "$3.67+$0.33tax"
    Case 16
        iTicketType = "83"
        printTax1 = "$4.59+$0.41tax"
    Case Else
        iTicketType = "85"
End Select
strBarCode = iTicketType & Format(IP, "0#") & Trim(str(SessionID)) & Format(K, "0#")
strBarCodeTXT = strBarCode

'Show Location
printLocation = rsHeaders("Location")
printShow = rsHeaders("Header2")
printPrice = Format(TicketTypes(3, i), "$#.00")
'Calculate print locations for SHOW and VENUE
iPrintShow = 395 - CInt((Len(printShow) * 25) / 2)
iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

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
    strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC120,150><LT3><HX525>"
    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
    strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
    strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC180,150><F10><HW1,1>**** " & EventType & " ****"
    strPrint = strPrint & "<RC180,700><F3><HW2,1>" & TicketTypes(5, i)
    strPrint = strPrint & "<RC220,150><LT3><HX525>"
    strPrint = strPrint & "<RC270,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC230,200><F3>" & rsHeaders("Header4")
    strPrint = strPrint & "<RC270,700><F3>" & CStr(K) & " of " & TotTicketCount
    strPrint = strPrint & "<RC270,250><F9>" & Now()
    strPrint = strPrint & "<RC290,200><F13><HW2,1>NO REFUNDS OR EXCHANGES"
    strPrint = strPrint & "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC320,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC0,850><LT5><HY370>"
    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
    strPrint = strPrint & "<RL><RC300,870><F3><HW1,1>" & strBarCodeTXT

    strPrint = strPrint & "<RC60,990><FL10><X3>:" & strBarCode & ":"
  
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " " & EventType) * 13) / 2)
    strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    strPrint = strPrint & "<RC270,1060><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    strPrint = strPrint & "<p>"

    SerialPortPrinter.output = strPrint

    Sleep 700
    'Sleep 900
'   Do
'        DoEvents
'        Buffer$ = Buffer$ & SerialPortPrinter.Input
'        iCycles = iCycles + 1
'        If iCycles > 10 Then
'        'If iCycles > 30 Then
'           PrinterError = True
'           If bDebug Then MsgBox "PrinterError Set, iCycles=" & CStr(iCycles)
'
'            Buffer$ = "XX"
'        End If
'    Loop Until Len(Buffer$) > 0
If bDebug Then MsgBox "End Buffer Loop"
Call LogClick("Print BarCode", strBarCode)
Exit Sub
PrintErr:
If bDebug Then MsgBox Err.Description

End Sub

Sub PrintTicketsTony(i As Integer, K As Integer)
            Dim rsHeaders As Recordset
            Dim thisType As Integer
            
            Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
            'If bDebug Then MsgBox strPrint
            
            strPrint = Chr(2) & Chr(11) & Chr(2) & Chr(11) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) ''    {clear printer buffer}
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint

            strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)  ''    //init barcode Vertical
            SerialPortPrinter.output = strPrint
            'If bDebug Then MsgBox strPrint


            If BarCodeType = "2" And EventCity <> "NEW YORK" Then
                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCode(EventCodeID, CStr(K - 1), TicketCount)
            ElseIf EventCity = "NEW YORK" Then
                thisType = TicketTypes(1, i)
                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCodeNY(K, thisType)
                ''strPrint = Chr(2) & Chr(16) & "3" & ConstructBarCodeNY(K, thisType)
            Else
                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCode0(K)
            End If
            'If bDebug Then MsgBox strPrint

            SerialPortPrinter.output = strPrint

            'strPrint = Chr(2) & Chr(16) & Chr(8) & "**** MTCC **** SOUTH BUILDING" '' & " " & UCase(Location_name)
            strPrint = Chr(2) & Chr(16) & Chr(8) & rsHeaders("Location") '' & " " & UCase(Location_name)
            'If bDebug Then MsgBox strPrint

            SerialPortPrinter.output = strPrint
            If TicketTypes(1, i) = 8 Then
                'Family 3
                 strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i) / 3, "$#.00")
            ElseIf TicketTypes(1, i) = 9 Then
                'Family 4
                strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i) / 4, "$#.00")
            ElseIf TicketTypes(1, i) = 14 Then
                'Family 4
                strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i) / 4, "$#.00")
            ElseIf TicketTypes(1, i) = 13 Then
                '2 Day Pass
                strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i) / 2, "$#.00")
            ElseIf TicketTypes(1, i) = 10 Or TicketTypes(1, i) = 11 Or TicketTypes(1, i) = 12 Then
                strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i) / 2, "$#.00")
            Else
                strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i), "$#.00")
            End If
           ' If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(17) & Chr(11) & "METRO TORONTO CONVENTION" 'UCase(ln(1))"
            strPrint = Chr(2) & Chr(17) & Chr(11) & UCase(rsHeaders("Header1")) 'UCase(ln(1))"
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint
            If TicketTypes(1, i) = 8 Then
                'Family 3
                strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i) / 3, "$#.00")
            ElseIf TicketTypes(1, i) = 9 Then
                'Family 4
                strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i) / 4, "$#.00")
            ElseIf TicketTypes(1, i) = 14 Then
                'Family 4
                strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i) / 4, "$#.00")
            ElseIf TicketTypes(1, i) = 13 Then
                '2 Day Pass
                strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i) / 2, "$#.00")
            ElseIf TicketTypes(1, i) = 10 Or TicketTypes(1, i) = 11 Or TicketTypes(1, i) = 12 Then
            '2 for 1
                 strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i) / 2, "$#.00")
            Else
                strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i), "$#.00")
            End If
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint

            strPrint = Chr(2) & Chr(18) & Chr(2) & UCase(EventCode)
            'If bDebug Then MsgBox strPrint
            
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(11) & UCase(rsHeaders("Header2"))  'UCase(ln(2))"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(34) & UCase(EventCode)
            SerialPortPrinter.output = strPrint
            
            'If TicketTypes(1, i) = 14 Then
            '    strPrint = Chr(2) & Chr(19) & Chr(2) & "FAM X4"
            'ElseIf TicketTypes(1, i) = 13 Then
            '    strPrint = Chr(2) & Chr(19) & Chr(2) & "2DAY X2"
            'Else
                strPrint = Chr(2) & Chr(19) & Chr(2) & UCase(TicketTypes(5, i))
            'End If
            SerialPortPrinter.output = strPrint
            
            'strPrint = Chr(2) & Chr(19) & Chr(11) & "****CANADA BLOOMS****"  'UCase(ln(3))"
            strPrint = Chr(2) & Chr(19) & Chr(11) & UCase(rsHeaders("Header3")) 'UCase(ln(3))"
            SerialPortPrinter.output = strPrint
            
            'If TicketTypes(1, i) = 14 Then
            '    strPrint = Chr(2) & Chr(19) & Chr(34) & "FAM X4"
            'ElseIf TicketTypes(1, i) = 13 Then
            '    strPrint = Chr(2) & Chr(19) & Chr(34) & "2DAY X2"
            'Else
                strPrint = Chr(2) & Chr(19) & Chr(34) & UCase(TicketTypes(5, i))
            'End If
            SerialPortPrinter.output = strPrint
            
            strPrint = Chr(2) & Chr(20) & Chr(2) & " TIX#" & CStr(K)
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(20) & Chr(11) & "****MARCH 3 - 7, 2004**"  ''UCase(ln(4))
            strPrint = Chr(2) & Chr(20) & Chr(11) & UCase(rsHeaders("Header4"))  ''UCase(ln(4))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(34) & " TIX#" & CStr(K)
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(2) & UCase(Left(SellerCode, 6))
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(21) & Chr(11) & UCase(Format(Now(), " MMM D YYYY")) & " 9:00 AM" 'UCase(EPDATE)
            'strPrint = Chr(2) & Chr(21) & Chr(11) & UCase(rsHeaders("EPDATE")) 'UCase(EPDATE)
            strPrint = Chr(2) & Chr(21) & Chr(11) & UCase(EPDATE)
            'If bDebug Then msgboxBox strPrint
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(34) & UCase(Left(SellerCode, 6))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(1) & UCase(Trim(EventCode))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(10) & Format(Now(), "m/d/yyyy") & " " & MOP
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(34) & UCase(Trim(EventCode))
            SerialPortPrinter.output = strPrint
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(23) & Chr(11) & "GOOD FOR ONE DAY ONLY"  ''UCase(ln(5))
            If TicketTypes(1, i) = 16 Then
            ''PROGRAM
                strPrint = Chr(2) & Chr(23) & Chr(11) & "GOOD FOR PROGRAM ONLY"  ''UCase(ln(5))
            ElseIf TicketTypes(1, i) = 18 Then
                strPrint = Chr(2) & Chr(23) & Chr(11) & "VALID MONDAY TO FRIDAY"  ''UCase(ln(5))
            Else
                strPrint = Chr(2) & Chr(23) & Chr(11) & rsHeaders("Header5")  ''UCase(ln(5))
            End If
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(34) & "A" & Trim(JournalID) ''& UCase(Trim(JComputerID) & Trim(JournalID))
            SerialPortPrinter.output = strPrint

           SerialPortPrinter.output = Chr(2) & "pn"

End Sub


Function ConstructBarCode(EventCodeID As String, TotalTicketNumber As String, TicketCount As String) As String
    Dim i                       As Integer
    Dim j                       As Integer
    Dim K                       As Integer
    Dim n2                      As Integer
    Dim a                       As String
    Dim strEventCodeID          As String
    Dim strBarcodeString        As String
    Dim strTicketNumberString   As String
    Dim strTicketNumberString2  As String
    Dim intTicketNumberLength   As Integer
    Dim charMap(9) As String
    charMap(0) = "2"
    charMap(1) = "4"
    charMap(2) = "5"
    charMap(3) = "7"
    charMap(4) = "9"
    charMap(5) = "1"
    charMap(6) = "3"
    charMap(7) = "8"
    charMap(8) = "0"
    charMap(9) = "6"

    strEventCodeID = EventCodeID
    strBarcodeString = CStr(CInt(strEventCodeID) Mod 1000)
    
    If Len(strBarcodeString) = 0 Then strBarcodeString = "000"
    If Len(strBarcodeString) = 1 Then strBarcodeString = "00" & strBarcodeString
    If Len(strBarcodeString) = 2 Then strBarcodeString = "0" & strBarcodeString
    If Len(strBarcodeString) > 1 Then strBarcodeString = Left(strBarcodeString, 3)
    
    strBarcodeString = CStr(9 - ((CInt(TotalTicketNumber) + CInt(TicketCount)) * 2) Mod 7) & strBarcodeString
    
    strTicketNumberString = CStr(CInt(TotalTicketNumber) + CInt(TicketCount))
    intTicketNumberLength = Len(strTicketNumberString)
       
    For i = 1 To 7 - intTicketNumberLength
        strTicketNumberString = "0" & strTicketNumberString
    Next i
    
    strTicketNumberString2 = strTicketNumberString
  
    For i = 1 To 7
        n2 = Asc(Mid(strTicketNumberString2, i, 1)) - Asc("0")
 '       If (n2 < 0) Or (n2 > 9) Then
 '           MsgBox "Create BarCodes Failed (n2)"
 '           Exit functiom
  '      End If
        Mid(strTicketNumberString2, i, 1) = CStr(charMap(n2))
    Next i
    
    '// store string2 back into original
    strTicketNumberString = strTicketNumberString2
    
    '// add barcode string in front
    strBarcodeString = strBarcodeString & strTicketNumberString
    
    If strBarcodeString <> "" Then
        '// store the barcode string
        a = strBarcodeString
        For j = 1 To Len(a)
            Mid(a, j, 1) = Chr(Asc(Mid(a, j, 1)) - 48)
        Next j
        j = Len(a)
        K = 0
        Do While j >= 0
            Mid(a, j, 1) = Chr(Asc(Mid(a, j, 1)) * 2)
            If Mid(a, j, 1) > Chr(9) Then K = K + 1
            j = j - 2
        Loop
        strBarcodeString = strBarcodeString & CStr(K Mod 10)
    End If
    
   ConstructBarCode = strBarcodeString



End Function

Function ConstructBarCodeNY(TotalTicketNumber As Integer, ByRef thisTicketType As Integer) As String
    Dim i                       As Integer
    Dim j                       As Integer
    Dim K                       As Integer
    Dim strBarcodeString        As String
'        JComputerID = "A"
'        j = Len(Trim(JournalID))
'        strBarcodeString = "1"
'        If UCase(Trim(JComputerID)) = "A" Then strBarcodeString = "1"
'        If UCase(Trim(JComputerID)) = "B" Then strBarcodeString = "2"
'        If UCase(Trim(JComputerID)) = "C" Then strBarcodeString = "3"
'        If UCase(Trim(JComputerID)) = "D" Then strBarcodeString = "4"
'        If UCase(Trim(JComputerID)) = "E" Then strBarcodeString = "5"
'        For i = 1 To 9 - j
'             strBarcodeString = strBarcodeString & "0"
'        Next i
'        strBarcodeString = strBarcodeString & Trim(JournalID)
'        strBarcodeString = Left(JournalID, 2) & "Z" & Right(JournalID, 3)
        Select Case thisTicketType
        Case 1
            'strBarcodeString = "81" & Right(SellerCode, 2) & Format(Right(CStr(SessionID), 6), "00000#")
            strBarcodeString = "810" & JournalID
        Case 3
            'strBarcodeString = "82" & Right(SellerCode, 2) & Format(Right(CStr(SessionID), 6), "00000#")
            strBarcodeString = "820" & JournalID
        Case 16
             'strBarcodeString = "83" & Right(SellerCode, 2) & Format(Right(CStr(SessionID), 6), "00000#")
             strBarcodeString = "830" & JournalID
        End Select
        
'        strBarcodeString = "88" & Right(SellerCode, 2) & Format(Right(CStr(SessionID), 6), "00000#")
'        For i = 1 To 8
'            strBarcodeString = strBarcodeString & Trim(CStr(TotalTicketNumber))
'        Next i
        If TotalTicketNumber >= 99 Then TotalTicketNumber = 0
           TicketNumStr = CStr(TotalTicketNumber)
        If (Len(TicketNumStr) < 2) Then TicketNumStr = "0" & TicketNumStr
        strBarcodeString = strBarcodeString & TicketNumStr
   
        ConstructBarCodeNY = strBarcodeString



End Function


Function ConstructBarCode0(TotalTicketNumber As Integer) As String
    Dim i                       As Integer
    Dim j                       As Integer
    Dim K                       As Integer
    Dim strBarcodeString        As String
'        JComputerID = "A"
        j = Len(Trim(JournalID))
        strBarcodeString = "1"
        If UCase(Trim(JComputerID)) = "A" Then strBarcodeString = "1"
        If UCase(Trim(JComputerID)) = "B" Then strBarcodeString = "2"
        If UCase(Trim(JComputerID)) = "C" Then strBarcodeString = "3"
        If UCase(Trim(JComputerID)) = "D" Then strBarcodeString = "4"
        If UCase(Trim(JComputerID)) = "E" Then strBarcodeString = "5"
        For i = 1 To 9 - j
             strBarcodeString = strBarcodeString & "0"
        Next i
        strBarcodeString = strBarcodeString & Trim(JournalID)
        If TotalTicketNumber >= 99 Then TotalTicketNumber = 0
           TicketNumStr = CStr(TotalTicketNumber)
        If (Len(TicketNumStr) < 2) Then TicketNumStr = "0" & TicketNumStr
        strBarcodeString = strBarcodeString & TicketNumStr
        ConstructBarCode0 = strBarcodeString

End Function


Sub PrintReceipt()
            Dim rsHeaders As Recordset
            Dim TotalPrice As Double
            Dim totalTickets As Integer
            TotalPrice = 0
            totalTickets = 0
'            Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
            For i = 0 To UBound(TicketTypes, 2)
               If TotalTicketSold(i) > 0 Then
                    TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                    totalTickets = totalTickets + TotalTicketSold(i)
                End If
            Next i
            
            Set rsHeaders = db.OpenRecordset("Select ShowName from SHOWS where showID =" & ShowID)
           
            strPrint = Chr(2) & Chr(11) & Chr(2) & Chr(11) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) ''    {clear printer buffer}
            
            SerialPortPrinter.output = strPrint

            strPrint = Chr(2) & Chr(8) & Chr(1) & Chr(2) & Chr(8) & Chr(5)  ''    //init barcode Vertical
            SerialPortPrinter.output = strPrint


'            If BarCodeType = "2" Then
'                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCode(EventCodeID, CStr(K - 1), TicketCount)
'            Else
'                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCode0(K)
'            End If
'            SerialPortPrinter.Output = strPrint

            'strPrint = Chr(2) & Chr(16) & Chr(8) & "**** MTCC **** SOUTH BUILDING" '' & " " & UCase(Location_name)
            strPrint = Chr(2) & Chr(16) & Chr(8) & "          ***RECEIPT***" '' & " " & UCase(Location_name)
            SerialPortPrinter.output = strPrint

            'strPrint = Chr(2) & Chr(17) & Chr(2) & Format(TicketTypes(3, i), "$#.00")
            'SerialPortPrinter.Output = strPrint
            strPrint = Chr(2) & Chr(17) & Chr(11) & rsHeaders(0) 'UCase(ln(1))"
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(17) & Chr(34) & Format(TicketTypes(3, i), "$#.00")
            'SerialPortPrinter.Output = strPrint

            'strPrint = Chr(2) & Chr(18) & Chr(2) & UCase(EventCode)
            'SerialPortPrinter.Output = strPrint
            'strPrint = Chr(2) & Chr(18) & Chr(11) & rsHeaders("Header2")  'UCase(ln(2))"
            'SerialPortPrinter.Output = strPrint
            'strPrint = Chr(2) & Chr(18) & Chr(34) & UCase(EventCode)
            'SerialPortPrinter.Output = strPrint

            'strPrint = Chr(2) & Chr(19) & Chr(2) & UCase(TicketTypes(2, i))
            'SerialPortPrinter.Output = strPrint
            strPrint = Chr(2) & Chr(19) & Chr(11) & totalTickets & " TICKETS for " & Format(TotalPrice, "$#0.00") 'UCase(ln(3))"
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(19) & Chr(34) & UCase(TicketTypes(2, i))
            'SerialPortPrinter.Output = strPrint
            
            strPrint = Chr(2) & Chr(20) & Chr(2) & " TIX#" & CStr(K)
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(20) & Chr(11) & "****MARCH 3 - 7, 2004**"  ''UCase(ln(4))
            strPrint = Chr(2) & Chr(20) & Chr(11) & rsHeaders("Header4")  ''UCase(ln(4))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(34) & " TIX#" & CStr(K)
            SerialPortPrinter.output = strPrint
            
            'strPrint = Chr(2) & Chr(21) & Chr(2) & UCase(Left(SellerCode, 6))
            'SerialPortPrinter.Output = strPrint
            'strPrint = Chr(2) & Chr(21) & Chr(11) & UCase(Format(Now(), " MMM D YYYY")) & " 9:00 AM" 'UCase(EPDATE)
            strPrint = Chr(2) & Chr(21) & Chr(11) & UCase(rsHeaders("EPDATE")) 'UCase(EPDATE)
            'If bDebug Then MsgBox strPrint
            'SerialPortPrinter.Output = strPrint
            'strPrint = Chr(2) & Chr(21) & Chr(34) & UCase(Left(SellerCode, 6))
            'SerialPortPrinter.Output = strPrint
            
            strPrint = Chr(2) & Chr(22) & Chr(1) & UCase(Trim(EventCode))
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(10) & Format(Now(), "m/d/yyyy") & " " & MOP
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(34) & UCase(Trim(EventCode))
            SerialPortPrinter.output = strPrint
            SerialPortPrinter.output = strPrint
            'strPrint = Chr(2) & Chr(23) & Chr(11) & "GOOD FOR ONE DAY ONLY"  ''UCase(ln(5))
            'strPrint = Chr(2) & Chr(23) & Chr(11) & rsHeaders("Header5")  ''UCase(ln(5))
            'SerialPortPrinter.Output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(34) & "A" & Trim(JournalID) ''& UCase(Trim(JComputerID) & Trim(JournalID))
            SerialPortPrinter.output = strPrint

           SerialPortPrinter.output = Chr(2) & "pn"
End Sub

Sub PrintReceiptTony()
        Dim strPrint As String
            ADDRESS1 = "3560 Carnation Circle"
            ADDRESS2 = "Seal Beach"
            ADDRESS3 = "CA"
            bankmessage = "Bank Message"
            totalDollar = "10.00"
            CustomAccttype = "CustType"
            ret_ref_num = "1111"
            ApproveCode = "1"
            TerminalID = "ABCD"
            CardNumber = "1234567890"
            CardExpire = "06/05"
            
            l = Len(InitPrintString)
            For i = 0 To l - 1
                ' kb[0] := InitPrintString[i];
                ' kb[1] := char(0);
                 SerialPortPrinter.output = Mid(strPrint, i, 1) & Chr(0)
            Next i
            
            strPrint = Chr(13) & Chr(10) & Chr(2) & Chr(15) & Chr(13) & Chr(13) & Chr(2) & Chr(23) & Chr(15) & Chr(20) & Chr(1)
            SerialPortPrinter.output = strPrint
          
            strPrint = Chr(2) & Chr(11) & Chr(2) & Chr(11) & "@BDEFGIKO@**Q***"
             SerialPortPrinter.output = strPrint
            strPrint = Chr(13) & Chr(10) & Chr(0)
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(15) & Chr(13) & Chr(10) & Chr(2) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(0)
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(16) & Chr(1) & ADDRESS1
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(17) & Chr(1) & ADDRESS2
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(1) & ADDRESS3
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(1) & "ACCT#:"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(7) & CardNumber
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(1) & " PURCHASE"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(1) & bankmessage
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(28) & " DEBIT RECORD"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(28) & " HOST DATE"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(40) & " TIME"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(28) & Format(Now(), "mm/dd/yyyy")
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(38) & Format(Now(), "hh:mm")
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(29 & 1) & " AMT"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(34 + 6) & " $" & totalDollar
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(17) & Chr(47) & CustomAccttype
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(47) & " EXPIRY:"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(18) & Chr(55) & CardExpire
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(19) & Chr(50) & " RRN"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(20) & Chr(47) & ret_ref_num
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(44 + 3) & " AUTH#:"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(21) & Chr(51 + 3) & ApproveCode
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(22) & Chr(44 + 3) & " TERM#:"
            SerialPortPrinter.output = strPrint
            strPrint = Chr(2) & Chr(23) & Chr(44 + 3) & TerminalID
            SerialPortPrinter.output = strPrint
            SerialPortPrinter.output = Chr(2) & " pn"
End Sub

Sub PrintTickets()
    
    Dim strPrint As String
    Dim i As Integer
    Dim j As Integer
    Dim K As Integer
    Dim m As Integer
    Dim n As Integer
    Dim bProgram As Boolean
    Dim bNoPrintBypass As Boolean
    bNoPrintBypass = True
    K = 0
    bProgram = False
    If bNoPrintBypass Then
    On Error GoTo PrintProblem
        'If TicketPrinter = 1 Then
        wait_status = True
        Response = True
        ready = True
        problem = False
        duration = 0.5
        Display_Flag = True
        SerialPortPrinter.CommPort = 4
        'SerialPortPrinter.CommPort = 4
        'SerialPortPrinter.CommPort = 5
        SerialPortPrinter.Settings = "9600,N,8,1"
        'SerialPortPrinter.OutBufferSize = 1024
        SerialPortPrinter.OutBufferSize = 2048
        ' Open the port.
        SerialPortPrinter.RThreshold = 1
        SerialPortPrinter.SThreshold = 1
        SerialPortPrinter.InputMode = comInputModeText
        SerialPortPrinter.InputLen = 0
        SerialPortPrinter.InBufferCount = 0
        SerialPortPrinter.InputMode = comInputModeText
        SerialPortPrinter.Handshaking = comNone
        SerialPortPrinter.PortOpen = True
        '   ElseIf TicketPrinter = 2 Then
        '            Dim p As VB.Printer
        '
        '            For Each p In VB.Printers
        '                If p.DeviceName = "PA ITL2002F PT" Then
        '                Set Printer = p
        '                End If
        '            Next
        '  End If
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 And Not PrinterError Then
                For j = 1 To TotalTicketSold(i)
                    'If bDebug Then MsgBox TicketTypes(1, i)
                    '''''                      If TicketTypes(1, i) = 8 Then
                    '''''                        'Family 3
                    '''''                        For n = 1 To 3
                    '''''                            K = K + 1
                    '''''                            'If bDebug Then MsgBox "K:" & K
                    '''''                            'Call PrintTicketsTony(i, K)
                    '''''                            Call PrintTicketsHSG(i, K)
                    '''''                        Next n
                    '''''                      ElseIf TicketTypes(1, i) = 9 Or TicketTypes(1, i) = 14 Then
                    '''''                        'Family 4
                    '''''                        For n = 1 To 4
                    '''''                            K = K + 1
                    '''''                            'Call PrintTicketsTony(i, K)
                    '''''                            Call PrintTicketsHSG(i, K)
                    '''''                        Next n
                    '''''                      ElseIf TicketTypes(1, i) = 13 Then
                    '''''                        '2 for 1
                    '''''                        For n = 1 To 2
                    '''''                            K = K + 1
                    '''''                            'Call PrintTicketsTony(i, K)
                    '''''                            Call PrintTicketsHSG(i, K)
                    '''''                        Next n
                    '''''                      ElseIf TicketTypes(1, i) = 10 Or TicketTypes(1, i) = 11 Or TicketTypes(1, i) = 12 Then
                    '''''                        '2 for 1
                    '''''                        For n = 1 To 2
                    '''''                            K = K + 1
                    '''''                            'Call PrintTicketsTony(i, K)
                    '''''                            Call PrintTicketsHSG(i, K)
                    '''''                        Next n
                    ''''''                       ElseIf TicketTypes(1, i) = 16 Then
                    ''''''                        'PROGRAM
                    ''''''                            K = K + 1
                    ''''''                            'Call PrintTicketsTony(i, K)
                    ''''''                            Call PrintTicketsHSG(i, K)
                    ''''''                            'Call PrintTicketCoupon
                    ''''''                            'bProgram = True
                    '''''                     Else
                    K = K + 1
                    '                If bDebug Then MsgBox "j:" & j & ",k:" & K
                    'Call PrintTicketsTony(i, K)
                    '''                        If K Mod 4 = 0 Then
                    '''                          SerialPortPrinter.PortOpen = False
                    '''                          DoEvents
                    '''                          Sleep 500
                    '''
                    '''                          SerialPortPrinter.CommPort = 4
                    '''                          SerialPortPrinter.Settings = "9600,N,8,1"
                    '''                          SerialPortPrinter.OutBufferSize = 2048
                    '''                          SerialPortPrinter.InputLen = 0
                    '''                          SerialPortPrinter.PortOpen = True
                    '''                        End If
                    '                        If ShowID = 57 Then
                    '                            Call PrintTicketsX(i, K)
                    '                        Else
                    Call PrintTicketsBoca(i, K)
                    'Call PrintTicketsHSG(i, K)
                    'Call PrintTicketsNY(i, K)
                    If problem Then GoTo PrintProblem
                    '                            'Call PrintTicketsNY(i, K)
                    '                        End If
                    '''                strPrint = "<CB><RC70,20><F3><HW1,1>" & Format(TicketTypes(3, i), "$##.00") & "<RC100,1><F3><HW1,1>" & EventType & "<RC150,20><F3><HW2,1>" & UCase(TicketTypes(2, i)) & "<RC210,20><F3><HW1,1>TIX#" & CStr(k) & "<RC250,20><F3><HW1,1>" & Left(SellerCode, 6) & "<RC300,20><F9><HW1,1>" & Trim(EventCode) & "<RC330,1><F3><HW1,1>A" & Trim(JournalID) & "<RC10,160><F3><HW2,1>METRO CONVENTION  CENTRE & SKYDOME<RC120,200><F3><HW1,1>CANADIAN INTERNATIONAL<RC160,190><F3><HW2,1>****AUTOSHOW 2004****<RC230,210><F3><HW1,1>FEBRUARY 13 - 22, 2004"
                    '''
                    '''                'If bDebug Then MsgBox CStr(Len(strPrint))
                    '''                If bDebug Then MsgBox strPrint
                    '''
                    '''                SerialPortPrinter.Output = strPrint
                    ''''                Do
                    ''''                   DoEvents
                    ''''                buffer$ = buffer$ & SerialPortPrinter.Input
                    ''''                Loop Until Len(buffer$) > 0
                    '''                ''strPrint = "<RC270,210><F3><HW1,1>" & Format(Now(), "MMM DD, YYYY") & " 10:30 AM" & "<RC310,220><F3><HW1,1>" & Format(Now(), "mm/dd/yyyy hh:mm") & " " & MOP & "<RC340,220><F3><HW1,1>GOOD FOR ONE DAY ONLY<RC70,700><F3><HW1,1>" & Format(TicketTypes(3, i), "$##.00") & "<RC100,700><F3><HW1,1>" & EventType & "<RC150,700><F3><HW2,1>" & UCase(TicketTypes(2, i)) & "<RC210,700><F3><HW1,1>TIX#" & CStr(k) & "<RC250,700><F3><HW1,1>" & Left(SellerCode, 6) & "<RC300,700><F9><HW1,1>" & Trim(EventCode) & "<RC330,700><F3><HW1,1>A" & Trim(JournalID) & "<RL><RC280,870><F3><HW1,1>123456789012<RC60,990><NL10><X2>*123456789012*"
                    '''                strPrint = "<RC270,210><F3><HW1,1>" & Format(Now(), "MMM DD, YYYY") & " 10:30 AM" & "<RC310,220><F3><HW1,1>" & Format(Now(), "mm/dd/yyyy hh:mm") & " " & MOP & "<RC340,220><F3><HW1,1>GOOD FOR ONE DAY ONLY<RC70,700><F3><HW1,1>" & Format(TicketTypes(3, i), "$##.00") & "<RC100,700><F3><HW1,1>" & EventType & "<RC150,700><F3><HW2,1>" & UCase(TicketTypes(2, i)) & "<RC210,700><F3><HW1,1>TIX#" & CStr(k) & "<RC250,700><F3><HW1,1>" & Left(SellerCode, 6) & "<RC300,700><F9><HW1,1>" & Trim(EventCode) & "<RC330,700><F3><HW1,1>A" & Trim(JournalID)    ''' & "<RL><RC300,870><F3><HW1,1>" & ConstructBarCode(EventCodeID, CStr(k - 1), TicketCount) & "<RC160,950><FL><X2>" & ConstructBarCode(EventCodeID, CStr(k - 1), TicketCount)
                    '''                SerialPortPrinter.Output = strPrint
                    '''
                    '''                strPrint = Chr(2) & Chr(16) & "2" & ConstructBarCode(EventCodeID, CStr(k - 1), TicketCount) & "pn"
                    '''                'strPrint = strPrint & "<p>"
                    '''                'If bDebug Then MsgBox CStr(Len(strPrint))
                    '''                If bDebug Then MsgBox strPrint
                    '''
                    '''                SerialPortPrinter.Output = strPrint
                    '''                Sleep 600
                    '''                Do
                    '''                    DoEvents
                    '''                    buffer$ = buffer$ & SerialPortPrinter.Input
                    '''                Loop Until Len(buffer$) > 0
                    '''              End If
                Next j
            End If
        Next i

        If bReceipt Then
            'frmReceipt.Show 1
            'If bPrintReceipt Then
            PrintReceiptHSG()
            'End If
        End If
        If TicketPrinter = 1 Then
            SerialPortPrinter.PortOpen = False
        End If
    Else
        K = 5
    End If
    TotalPrice = 0
    For i = 0 To UBound(TicketTypes, 2)
        If TotalTicketSold(i) > 0 Then
            TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
        End If
    Next i

    Timer1.interval = 1000
    Timer1.Enabled = True
    db.Execute "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount,SessionID) values(" & ShowID & ",#" & Now() & "#," & TotalPrice & "," & SessionID & ")"
    rs = db.OpenRecordset("Select Max(TicketReceiptID) as TRID from PURCHASE_INFO")
    For i = 0 To UBound(TicketTypes, 2)
        If TotalTicketSold(i) > 0 Then db.Execute "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
    Next i

    rsTicketstock = db.OpenRecordset("Select * from TICKET_STOCK")
    If bProgram Then K = K + 1
    db.Execute "Update TICKET_STOCK set TicketStock=" & CStr(rsTicketstock(0) - K) & ",StartingTix=" & CStr(rsTicketstock(1) + K)
    'If bDebug Then MsgBox "Out of Print"
    Exit Sub
PrintProblem:
    PrinterError = True
End Sub

Sub PrintTicketsOLD()
Dim i As Integer
Dim j As Integer
Dim TotalPrice As Integer
Dim rsTicketstock As Recordset
Dim numTickets As Integer
Dim LineNo(8) As Integer
Dim FontSize(8) As Integer
Dim RightSide As Integer

numTickets = 0

RightSide = 5100
LineNo(1) = 200
LineNo(2) = 500
LineNo(3) = 900
LineNo(4) = 1200
LineNo(5) = 200
LineNo(6) = 1600
LineNo(7) = 1900
LineNo(8) = 2300

FontSize(1) = 14
FontSize(2) = 12
FontSize(3) = 12
FontSize(4) = 14
FontSize(5) = 12
FontSize(6) = 10
FontSize(7) = 12
FontSize(8) = 12

For i = 0 To UBound(TicketTypes, 2)
    If TotalTicketSold(i) > 0 Then
        With Printer
            .Copies = TotalTicketSold(i)
            
            .Orientation = 2
            
            .Font = "Ariel Narrow"
            .FontBold = True
            
            .FontSize = FontSize(2)
            .CurrentX = 50
            .CurrentY = LineNo(2)
            Printer.Print Format(TicketTypes(3, i), "$##.00") 'price
            
            .FontSize = FontSize(3)
            .CurrentX = 50
            .CurrentY = LineNo(3)
            Printer.Print "Price1"
            
            .FontSize = FontSize(4)
            .CurrentX = 50
            .CurrentY = LineNo(4)
            Printer.Print UCase(TicketTypes(2, i))
            
            .FontSize = FontSize(6)
            .CurrentX = 50
            .CurrentY = LineNo(6)
            Printer.Print strComputerName
            
            .FontSize = FontSize(7)
            .CurrentX = 50
            .CurrentY = LineNo(7)
            Printer.Print EventCode
            
            .FontSize = FontSize(1)
            .CurrentX = 1100
            .CurrentY = LineNo(1)
            Printer.Print "** CANADIAN INTL AUTO SHOW **"
            
            .FontSize = FontSize(2)
            .CurrentX = 1500
            .CurrentY = LineNo(2)
            Printer.Print "FEB 13 - 22, 2004"
            
            .FontSize = FontSize(3)
            .CurrentX = 1200
            .CurrentY = LineNo(3)
            Printer.Print "VALID FOR ONE DAY ONLY"
            
            .FontSize = 12
            .CurrentX = 1200
            .CurrentY = LineNo(4)
            Printer.Print "CANADIAN INTL AUTO SHOW"
            'Printer.Print "**2004 AUTO SHOW**"
            
            .FontSize = FontSize(6)
            .CurrentX = 1200
            .CurrentY = LineNo(6)
            Printer.Print Format(Now(), "MMM dd, yyyy") & " 10:30 AM"
            
            .FontSize = FontSize(7)
            .CurrentX = 1200
            .CurrentY = LineNo(7)
            Printer.Print Format(Now(), "mm/dd/yyyy") & " MC"
            
            .FontSize = FontSize(8)
            .CurrentX = 1200
            .CurrentY = LineNo(8)
            Printer.Print "VALID FOR FEB 13 - 22, 2004"
            
            .FontSize = FontSize(2)
            .CurrentX = RightSide
            .CurrentY = LineNo(2)
            Printer.Print Format(TicketTypes(3, i), "$##.00")
            
            .FontSize = FontSize(3)
            .CurrentX = RightSide
            .CurrentY = LineNo(3)
            Printer.Print "Price1"
            
            .FontSize = FontSize(4)
            .CurrentX = RightSide
            .CurrentY = LineNo(4)
            Printer.Print UCase(TicketTypes(2, i))
            
            .FontSize = FontSize(6)
            .CurrentX = RightSide
            .CurrentY = LineNo(6)
            Printer.Print strComputerName
            
            .FontSize = FontSize(7)
            .CurrentX = RightSide
            .CurrentY = LineNo(7)
            Printer.Print EventCode
            
            .FontSize = FontSize(8)
            .CurrentX = RightSide
            .CurrentY = LineNo(8)
            Printer.Print ""
            .EndDoc
        End With
    End If
Next i
For i = 0 To UBound(TicketTypes, 2)
    If TotalTicketSold(i) > 0 Then
        TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
    End If
Next i

'Timer1.Interval = 1000
'Timer1.Enabled = True
db.Execute "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount) values(" & ShowID & ",#" & Now() & "#," & TotalPrice & ")"
Set rs = db.OpenRecordset("Select Max(TicketReceiptID) as TRID from PURCHASE_INFO")
For i = 0 To UBound(TicketTypes, 2)
    If TotalTicketSold(i) > 0 Then db.Execute "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
Next i

Set rsTicketstock = dbLocal.OpenRecordset("Select * from TICKET_STOCK")

dbLocal.Execute "Update TICKET_STOCK set TicketStock=" & CStr(rsTicketstock(0) - numTickets)
''''' CONFIRM

''''' SEND TO TM
End Sub



Sub PrintTicketsX(i As Integer, K As Integer)
Dim strPrint As String
Dim printLocation As String
Dim iPrintLocation As Integer
Dim printShow As String
Dim iPrintShow As Integer
Dim printPrice As String
Dim testJournalID As Long
Dim testDeviceID As String
Dim iTicketType As String
Dim rsHeaders As Recordset
Dim rsBarCodes As Recordset
Dim thisType As Integer
Dim iCycles As Integer
Dim strBarCode As String
Dim strBarCodeTXT As String
Dim strEventType As String

If bDebug Then MsgBox "ENTER HSG PRINT"
iCycles = 0
'Get Show information
Set rsHeaders = db.OpenRecordset("Select * from TICKET_HEADERS where ShowID=" & ShowID)
'Set EVENT TYPE for ticket
Select Case EventType
Case "AUTOSHOW"
    EventType = "AUTO SHOW"
Case "SKISHOW"
    EventType = "SKI SHOW"
Case "FAIR"
    EventType = "FAIR"
End Select

'Create appropriate Barcode
If AOPBarcode Then
    'Get next AOP barcode
    Set rsBarCodes = db.OpenRecordset("Select top 1 ID, Barcode from BARCODES where UsedDateTime is null ORDER BY ID")
    db.Execute "UPDATE BARCODES set UsedDateTime=#" & Now() & "# where ID =" & rsBarCodes(0)
    strBarCode = rsBarCodes(1)
    strBarCodeTXT = Format(rsBarCodes(0), "00000#")
Else
    Select Case TicketTypes(1, i)
        Case 1
            iTicketType = "810"
        Case 3
            iTicketType = "820"
        Case 16
            iTicketType = "830"
    End Select
    strBarCode = iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    strBarCodeTXT = strBarCode
End If


printLocation = rsHeaders("Location")
printShow = rsHeaders("Header2")
printPrice = Format(TicketTypes(3, i), "$#.00")
testTicketType = "81"
'Calculate print locations for SHOW and VENUE
iPrintShow = 395 - CInt((Len(printShow) * 25) / 2)
'iPrintShow = 375 - CInt((Len(printShow) * 25) / 2)
iPrintLocation = 410 - CInt((Len(printLocation) * 20) / 2)

If TicketPrinter = 1 Then
    'BOCA PRINTER
 '''''''''SKI DAZZLE '''''''''''''''''''''''''''''''''''''''''''''''''''''
 ''''DONT PRINT THIS
''    strPrint = "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
''    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
''    strPrint = strPrint & "<NR><RC90,15><F7><HW1,1>" & printPrice
    strPrint = strPrint & "<RC90,770><F7>" & printPrice
''    'strPrint = strPrint & "<RC130,10><F7>" & rsHeaders("Header5")
''    strPrint = strPrint & "<RC130,15><F7>" & rsHeaders("Header5")
''    strPrint = strPrint & "<RC120,150><LT3><HX525>"
''    strPrint = strPrint & "<RC130," & CStr(iPrintShow) & "><F10>" & printShow
''  strPrint = strPrint & "<RC130,700><F7>" & rsHeaders("Header5")
''    'strPrint = strPrint & "<RC180,10><F3><HW2,1>" & TicketTypes(5, i)
''    strPrint = strPrint & "<RC180,15><F3><HW2,1>" & TicketTypes(5, i)
''    strPrint = strPrint & "<RC180,150><F10><HW1,1>**** " & EventType & " ****"
    strPrint = strPrint & "<RC180,770><F3><HW2,1>" & TicketTypes(5, i)
'    strPrint = strPrint & "<RC220,150><LT3><HX525>"
'    'strPrint = strPrint & "<RC270,10><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
'    strPrint = strPrint & "<RC270,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
'    strPrint = strPrint & "<RC230,200><F3>" & rsHeaders("Header4")
    strPrint = strPrint & "<RC270,770><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
'    strPrint = strPrint & "<RC270,250><F9>" & Now()
    'strPrint = strPrint & "<RC300,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
'    strPrint = strPrint & "<RC290,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
    If ShowID = 57 Then
        If TicketTypes(5, i) = "ADULT" Then
            strPrint = strPrint & "<RC350,50><F3><HW1,1>INCLUDES FREE LIFT TICKET VOUCHER"
        Else
            strPrint = strPrint & "<RC350,50><F3><HW1,1>DOES NOT INCLUDE LIFT TICKET VOUCHER"
        End If
    End If
'    strPrint = strPrint & "<RC320,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC320,770><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    strPrint = strPrint & "<RC0,850><LT5><HY370>"
    strPrint = strPrint & "<RC40,1005><LT5><VX330>"
    strPrint = strPrint & "<RC40,1035><LT5><VX330>"
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(K)
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    'strPrint = strPrint & "<RL><RC320,870><F3><HW1,1>" & strBarCodeTXT

    If AOPBarcode Then
        'strPrint = strPrint & "<RL><RC250,870><F3><HW1,1>" & strBarCodeTXT
        strPrint = strPrint & "<RL><RC250,890><F9><HW1,1>" & strBarCodeTXT
    Else
        strPrint = strPrint & "<RL><RC270,870><F3><HW1,1>" & strBarCodeTXT
    End If
'''''3 of 9
    'strPrint = strPrint & "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    'interleaved 2 of 5
    'strPrint = strPrint & "<RC20,990><FL10><X2>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'strPrint = strPrint & "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'strPrint = strPrint & "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
   If AOPBarcode Then
'''''code 128
        strPrint = strPrint & "<RC20,990><OL10><X2>^" & strBarCode & "^"
   Else
   '''''3 of 9
        strPrint = strPrint & "<RC20,990><FL10><X3>:" & strBarCode & ":"
    End If
    
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " AUTO SHOW") * 13) / 2)
    'strPrint = strPrint & "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    strPrint = strPrint & "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    strPrint = strPrint & "<RC360,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    strPrint = strPrint & "<RC340,1060><F2><HW1,1>Non Refundable  No Exchanges"
    strPrint = strPrint & "<RC270,1075><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    strPrint = strPrint & "<p>"

    SerialPortPrinter.output = strPrint
    Sleep 700
    'Sleep 900
'   Do
'        DoEvents
'        Buffer$ = Buffer$ & SerialPortPrinter.Input
'        iCycles = iCycles + 1
'        If iCycles > 10 Then
'        'If iCycles > 30 Then
'           PrinterError = True
'           If bDebug Then MsgBox "PrinterError Set, iCycles=" & CStr(iCycles)
'
'            Buffer$ = "XX"
'        End If
'    Loop Until Len(Buffer$) > 0
    If bDebug Then MsgBox "End Buffer Loop"
ElseIf TicketPrinter = 2 Then
    Dim p As VB.Printer
    'Dim offset As Integer
    'NOTE: there is a -30 offset for PA
    'offset = -30
    
    For Each p In VB.Printers
        If p.DeviceName = "PA ITL2002F PT" Then
        Set Printer = p
        End If
    Next

    'Printer.Print "<NR><RC50," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    Printer.Print "<NR><RC20," & CStr(iPrintLocation) & "><F8><HW1,1>" & printLocation
    'strPrint = strPrint & "<NR><RC90,10><F7><HW1,1>" & printPrice
    Printer.Print "<NR><RC60,15><F7><HW1,1>" & printPrice
    Printer.Print "<RC60,700><F7>" & printPrice
    'printer.print "<RC130,10><F7>" & rsHeaders("Header5")
    Printer.Print "<RC100,15><F7>" & rsHeaders("Header5")
    Printer.Print "<RC90,150><LT3><HX525>"
    Printer.Print "<RC100," & CStr(iPrintShow) & "><F10>" & printShow
    Printer.Print "<RC100,700><F7>" & rsHeaders("Header5")
    'printer.print "<RC180,10><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC150,15><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC150,150><F10><HW1,1>**** " & EventType & " ****"
    Printer.Print "<RC150,700><F3><HW2,1>" & TicketTypes(5, i)
    Printer.Print "<RC190,150><LT3><HX525>"
    'printer.print "<RC270,10><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC240,15><F3><HW1,1>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC200,200><F3>" & rsHeaders("Header4")
    Printer.Print "<RC240,700><F3>" & CStr(K) & " of " & TotTicketCount
    Printer.Print "<RC240,250><F9>" & Now()
    Printer.Print "<RC270,200><F13><HW2,1>GOOD FOR ONE DAY ONLY"
    Printer.Print "<RC290,15><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC290,700><F9><HW1,1>" & Format(Now(), "MM/DD/YYYY")
    Printer.Print "<RC0,850><LT5><HY370>"
    Printer.Print "<RC10,1005><LT5><VX330>"
    Printer.Print "<RC10,1035><LT5><VX330>"
    'printer.print "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & JournalID & CStr(K)
    '' HG BarCode Printer.Print "<RL><RC320,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    'AOP Barcode
    'Printer.Print "<RL><RC320,870><F3><HW1,1>" & rsBarCodes(1)
    '''' Remove for AOP Printer.Print "<RL><RC320,870><F3><HW1,1>" & rsBarCodes(1)
    'Printer.Print "<RL><RC320,870><F3><HW1,1>" & Format(rsBarCodes(0), "00000#")
    If AOPBarcode Then
        Printer.Print "<RL><RC320,870><F3><HW1,1>" & Format(rsBarCodes(0), "00000#")
    Else
        Printer.Print "<RL><RC250,870><F3><HW1,1>" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#")
    End If
    '3 of 9
    'printer.print "<RC20,990><NL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    'interleaved 2 of 5
    'printer.print "<RC20,990><FL10><X2>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    'printer.print "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & ":"
    ''HG BARCODE
   ' Printer.Print "<RC65,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
    ''AOP BARCODE
    If AOPBarcode Then
        Printer.Print "<RC20,990><OL10><X2>^" & rsBarCodes(1) & "^"
    Else
        Printer.Print "<RC20,990><FL10><X3>:" & iTicketType & Format(IP, "0#") & Right(JournalID, 5) & Format(K, "0#") & ":"
    End If
    'code 128  DOESN'T WORK
    'printer.print "<RC20,990><OL10><X2>*" & iTicketType & Format(IP, "0#") & JournalID & CStr(K) & "*"
    If bDebug Then MsgBox "DISCLAIMER"

    'Disclaimer
    iPrintShow = 200 + CInt((Len(printShow & " AUTO SHOW") * 13) / 2)

    'printer.print "<RC360,1015><F9><HW1,1>" & printShow & " AUTO SHOW"
    Printer.Print "<RC" & iPrintShow & ",1015><F9><HW1,1>" & printShow & " " & EventType
    Printer.Print "<RC340,1045><F2><HW1,1>Taxes Incl. Subject to Show Rules"
    Printer.Print "<RC320,1060><F2><HW1,1>Non Refundable  No Exchanges"
    Printer.Print "<RC250,1080><F2><HW1,1>" & ANTransactionCode
    If bDebug Then MsgBox "Send Print Command"
    Printer.Print "<p>"

    Printer.EndDoc
    If bDebug Then MsgBox "End Buffer Loop"
End If

End Sub

Sub WriteToDAT()
Dim strData As String
Dim strData2 As String
Dim Discount(10) As String
Dim DiscountName(10) As String
Dim i As Integer
Discount(0) = "A"
Discount(1) = "B"
Discount(2) = "C"
Discount(3) = "D"
Discount(4) = "E"

DiscountName(0) = "ADULT"
DiscountName(1) = "SENIOR"
DiscountName(2) = "STUDENT"
DiscountName(3) = ""
'If bTest Then
'     EventType = "TESTATM"
'Else
'     EventType = "CANADA BLOOMS"
'End If
'On Error GoTo procError
'PROCESS TicketMaster information to DAT FILE
Open App.path & "/" & Format(Now, "ddmmmyy") & ".Dat" For Append As #1  ' Open file for output.
       'Initialize purchase information
       'EventID = "456       "
       'EventCode = "TEST01"
       MOP = ""
       JournalID = "000"
       JComputerID = "A"
       TicketCount = "000"
       EventCodeID = "000"
        If Len(EventCode) < 19 Then
            EventCode = Trim(EventCode) & Space(19 - Len(Trim(EventCode)))
        Else
            EventCode = Left(EventCode, 19)
        End If
        strData = "OFFLINEBLOCK" & Chr(13) + Chr(10) & "OENT " & SellerCode & "    " & Password & "    " & Chr(10)
        strData = strData & "Location:1"
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then
                strData = strData & "Item:" & EventID & "A          " & EventCode & "P1    " & Discount(i) & CStr(TotalTicketSold(i)) & "        " & DiscountName(i) & " / Price1" & EventCode & "                           " & Chr(10)
            End If
        Next i
        strData = strData & Chr(13) & Chr(10) & "ENDOFBLOCK" & Chr(13) & Chr(10)
        Print #1, strData
        Dim TotalPrice As Double
        'Credit Card Type
        If Left(CardNumber, 2) = "34" Or Left(CardNumber, 2) = "37" Then
            MOP = "AMX"
        ElseIf Left(CardNumber, 1) = "5" Then
            MOP = "MC"
        ElseIf Left(CardNumber, 1) = "4" Then
            MOP = "VISA"
        ElseIf Left(CardNumber, 3) = "300" Or Left(CardNumber, 3) = "303" Or Left(CardNumber, 3) = "302" Or Left(CardNumber, 3) = "303" Or Left(CardNumber, 3) = "304" Or Left(CardNumber, 3) = "305" Or Left(CardNumber, 2) = "36" Or Left(CardNumber, 2) = "38" Then
            MOP = "DSC"
        ElseIf Left(CardNumber, 4) = "2131" Or Left(CardNumber, 4) = "1800" Then
            MOP = "JCB"
        ElseIf Left(CardNumber, 6) = "628181" Then
            MOP = "SEARS"
        Else
            MOP = "OTHER"
        End If
         For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then
                TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
           End If
        Next i
        fTotalPrice = Format(CStr(TotalPrice), "$#.00")
        tspaces = 10 - Len(fTotalPrice)
        If tspaces < 0 Then tspaces = 0
        'x = "Invoice#  000             11:31:41   TOTAL " & Format(CStr(TotalPrice), "$#.00") & Space(tspaces) & "  SALE       CASH       TEST01    " & SellerCode & Space(10 - Len(SellerCode)) & Chr(10) & Chr(10) & "  1    ADULT / PRICE1 2003 ROYAL WINTER FAIR200 $16.00     "
        strData = "JOURNALBLOCK" & Chr(13) + Chr(10) & "Invoice#  000             " & Format(Now(), "hh:mm:ss") & "   TOTAL " & Format(CStr(TotalPrice), "$#.00") & Space(tspaces) & "  SALE       CASH       " & SellerCode & Space(10 - Len(SellerCode))
                For i = 0 To UBound(TicketTypes, 2)
                    If TotalTicketSold(i) > 0 Then
                        strData = strData & Chr(10) & "  " & CStr(TotalTicketSold(i)) & Space(9 - Len(DiscountName(i))) & DiscountName(i) & " / PRICE1 " & EventType & " " & Format(TotalTicketSold(i) * TicketTypes(3, i), "#.00")
                   End If
                Next i
                strData = strData & "  ENDOFBLOCK" & Chr(13) & Chr(10)
        
        Print #1, strData
        
        strData = "OFFLINEBLOCK" & Chr(13) + Chr(10) & "CENT " & SellerCode & "    " & Password & "    " & Chr(10)
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then
                'TotalPrice = TotalPrice + TotalTicketSold(i) * TicketTypes(3, i)
                 strData = strData & "Item:" & EventID & "A          " & EventCode & "P1    " & Discount(i) & CStr(TotalTicketSold(i)) & "         " & Format(TicketTypes(3, i), "$#.00") & Space(10 - Len(Format(TicketTypes(3, i), "$#.00"))) & Format(TotalTicketSold(i) * TicketTypes(3, i), "#.00") & Space(10 - Len(Format(TotalTicketSold(i) * TicketTypes(3, i), "#.00"))) & "0.00      0.00      " & DiscountName(i) & " / Price1 " & EventCode & "              " & Chr(10)
           End If
        Next i
        strData = strData & "ComputerID:A" & Chr(10)
        strData = strData & "JournalID:" & JournalID & Chr(10)
        strData = strData & "MOP:" & MOP & Chr(10)
        strData = strData & "Name:" & CardName & Chr(10)
        strData = strData & "CCNum:" & CardNumber & Chr(10)
        strData = strData & "Expiry:" & Right(CardExpire, 2) & "/" & Left(CardExpire, 2) & Chr(10)
        strData = strData & "GTOTAL:" & Format(TotalPrice, "#.00") & Chr(10)
        strData = strData & "TOTAL:" & Format(TotalPrice, "#.00") & Chr(10)
        strData = strData & "GSTTOTAL:0.00" & Chr(10)
        strData = strData & "PSTTOTAL:0.00" & Chr(10)
        strData = strData & "@#end#@" & Chr(13) & Chr(10) & "ENDOFBLOCK" & Chr(13) & Chr(10)
        Print #1, strData
        Close #1
        lblMessage.Caption = "Your Tickets are now PRINTING..."
End Sub

Private Sub Form_Load()
Dim xreturn As Boolean
Dim ResponseCode As String
On Error GoTo procError
'If bTest Then
'    Timer1.Interval = 1000
'    Timer1.Enabled = True
'Else
'If bOffLine Then
'    'write to event.dat
'
'    'print tickets
'     lblMessage.Caption = "Your Tickets are now PRINTING..."
'     Refresh
''     If bDebug Then MsgBox "Printing"
'     TicketCount = "1111"
'     EventCodeID = "11"
'     BarCodeType = "0"
'     JComputerID = "A"
'     JournalID = "123456"
'     WriteToDAT
'     Call LogClick("Processing", "WriteOffLine")
'     PrintTickets
'     Call LogClick("Processing", "PrintTickets")
'     Timer1.Interval = 3000
'     Timer1.Enabled = True
''ElseIf bDEMO Then
''     lblMessage.Caption = "Your Tickets are now PRINTING..."
''     Refresh
'''     If bDebug Then MsgBox "Printing"
''     TicketCount = "1111"
''     EventCodeID = "11"
''     If EventCity = "NEW YORK" Then
''        BarCodeType = "9"
''     Else
''        BarCodeType = "0"
''     End If
''     JComputerID = "A"
''     JournalID = "123456"
''     'WriteToDAT
''     'Call LogClick("Processing", "WriteOffLine")
''     PrintTickets
''     Call LogClick("Processing", "PrintTickets")
''     Timer1.Interval = 3000
''     Timer1.Enabled = True
'ElseIf bNoPorts Then
'     Timer1.Interval = 3000
'     Timer1.Enabled = True
'Else
If bDEMO Then
      Timer4.interval = 2000
      Timer4.Enabled = True
Else
      Timer4.interval = 500
      Timer4.Enabled = True
End If
'      frmWebBrowser.Show 1
'        If bDebug Then MsgBox "CONFIRM TICKETS response" & Chr(10) & ANResponseCode & " " & ANTranactionCode
'        If ANResponseCode = 1 Then
'            lblMessage.Caption = "Your Tickets are now PRINTING..."
'            Refresh
'''            i = InStr(InStr(1, strData, "TICKETCOUNT") + 12, strData, Chr(10)) - (InStr(1, strData, "TICKETCOUNT") + 12)
'''            TicketCount = Mid(strData, InStr(1, strData, "TICKETCOUNT") + 12, i)
'''            i = InStr(InStr(1, strData, "EVENTCODEID") + 12, strData, Chr(10)) - (InStr(1, strData, "EVENTCODEID") + 12)
'''            EventCodeID = Mid(strData, InStr(1, strData, "EVENTCODEID") + 12, i)
'''            i = InStr(InStr(1, strData, "BARCODETYPE") + 12, strData, Chr(10)) - (InStr(1, strData, "BARCODETYPE") + 12)
'''            BarCodeType = Mid(strData, InStr(1, strData, "BARCODETYPE") + 12, i)
'           BarCodeType = "0"
'           EventCode = "2008DC"
'           'ShowID = "45"
'            ''SETUP
'            'thisType = 1
'            'TicketTypes(1, i) = 1
'            'TicketTypes(2, i) = 1
'            'TicketTypes(3, i) = 5
'            'TicketTypes(4, i) = 1
'            'TicketTypes(5, i) = "ADULT"
'            EventCodeID = 1
'            TicketCount = 1
'            'SellerCode = "ATMT01"
'            If Len(ANTransactionCode) < 4 Then
'                JournalID = "1234567"
'            Else
'                JournalID = Right(ANTransactionCode, 7)
'            End If
'            JComputerID = 1
'            'MOP = "VISA"
'            EPDATE = Now()
'            'BarCodeType = "0"
'
'           ''TicketCount = "1"
'           If bDebug Then MsgBox "Preprint: " & JournalID
'           PrintTickets
'            Call LogClick("Processing", "TicketsPrinted")
'            Timer1.Interval = 3000
'            Timer1.Enabled = True
'        ElseIf ANResponseCode = 2 Then
'            lblMessage.Caption = "Credit card not accepted..."
'            Call LogClick("Processing", "CardDeclined")
'            Timer2.Interval = 3000
'            Timer2.Enabled = True
'        ElseIf ANResponseCode = 3 Then
'            lblMessage.Caption = "Processing problem - please try again..."
'            Call LogClick("Processing", "ProcessingProblem")
'            Timer2.Interval = 3000
'            Timer2.Enabled = True
'        Else
'            lblMessage.Caption = "Processing problem - please try again..."
'            Call LogClick("Processing", "ProcessingProblem")
'            Timer2.Interval = 3000
'            Timer2.Enabled = True
'
'        End If

    'Timer3.Interval = 10000
    'Timer3.Enabled = True
'End If
'End If
Exit Sub
procError:
   If Not bDEMO Then
    If Err.Number = 8002 Then
             Call LogClick("Processing", "TicketProblem")
             lblMessage.Caption = "Ticket printer problem... Please contact agent!"
    Else
        lblMessage.Caption = "Processing problem - please use a different card..."
    End If
    Timer2.interval = 3000
    Timer2.Enabled = True
  Else
     Call LogClick("Processing", "PrintTickets")
     Timer1.interval = 3000
     Timer1.Enabled = True
  End If
End Sub



Private Sub Image1_Click()
'End
End Sub

Private Sub SerialPortPrinter_OnComm()
    'Possible Errors or events control through case statement
    'Handle each event or error by placing code below each case statement
    'Comment out the Display_Text statements not needed.
    Select Case SerialPortPrinter.CommEvent

        'A Break was received
        Case comEventBreak
            Call Display_Text("A Break was received.")             'debug statement
    
        'CD (RLSD) Timeout
        Case comEventCDTO
            Call Display_Text("CD (RLSD) Timeout.")                'debug statement
    
        'CTS Timeout
        Case comEventCTSTO
            Call Display_Text("CTS Timeout.")                      'debug statement
    
        'DSR Timeout
        Case comEventDSRTO
            Call Display_Text("DSR Timeout.")                      'debug statement
    
        'Framing Error
        Case comEventFrame
            Call Display_Text("Framing Error.")                    'debug statement
    
        'Data Lost
        Case comEventOverrun
            Call Display_Text("Data Lost.")                        'debug statement
    
        'Receive buffer overflow
        Case comEventRxOver
           Call Display_Text("Receive buffer overflow.")          'debug statement
    
        'Parity Error
        Case comEventRxParity
           Call Display_Text("Parity Error.")                     'debug statement
            
        'Transmit buffer full
        Case comEventTxFull
            Call Display_Text("Transmit buffer full.")             'debug statement
            
        'Unexpected error retrieving DCB]
        Case comEventDCB
            Call Display_Text("Unexpected error retrieving DCB.")  'debug statement

        'Change in the CD line.
        Case comEvCD
           Call Display_Text("Change in the CD line. CD = " & SerialPortPrinter.CDHolding)      'debug statement
'            If (ComPort.CDHolding = True) Then
'                ShpCD.FillColor = Green
'            Else
'                ShpCD.FillColor = Red
'            End If
        
        'Change in the CTS line.
        Case comEvCTS
           Call Display_Text("Change in the CTS line. CTS = " & SerialPortPrinter.CTSHolding)      'debug statement
'            If (ComPort.CTSHolding = True) Then
'                ShpCTS.FillColor = Green
'            Else
'                ShpCTS.FillColor = Red
'            End If
        
        'Change in the DSR line.
        Case comEvDSR
            Call Display_Text("Change in the DSR line. DSR = " & SerialPortPrinter.DSRHolding)      'debug statement
'            If (ComPort.DSRHolding = True) Then
'                ShpDSR.FillColor = Green
'            Else
'                ShpDSR.FillColor = Red
'            End If
        
        'Change in the Ring Indicator.
        Case comEvRing
            Call Display_Text("Change in the Ring Indicator.")      'debug statement
    
        'Received RThreshold number of chars.
        Case comEvReceive
            Call Display_Text("Receive. Ready = " & ready)         'debug statement
'            ShpRD.FillColor = Green                 'make Receive data light green
'            ShpTD.FillColor = Red                   'make Transmit data light red
        
            'The ready flag is set in find_baud() once the baud rate has
            'been established.  From that point forward all reading of data
            'from the printer will happen through here
            'If (ready) Then
            '    'Buffer = Buffer & FrmBoca.ComPort.Input
            '    Receive (MAX_BUFFER_SIZE)           'read print buffer
            'End If
            If (ready) Then
                Buffer = Buffer & SerialPortPrinter.Input
                Receive (MAX_BUFFER_SIZE)           'read print buffer
            End If

        'There are SThreshold number of characters in the transmit buffer.
        Case comEvSend
            Call Display_Text("Transmit")          'debug statement
'            ShpRD.FillColor = Red                   'make Receive data light red
'            ShpTD.FillColor = Green                 'make Transmit data light green
    
        'An EOF charater was found in the input stream
        Case comEvEOF
            Call Display_Text("EOF")               'debug statement
    
        'Report possible error condition for unknown comm event
        Case Else
            Call Display_Text("Unknown ComPort case = " & SerialPortPrinter.CommEvent)
        
    End Select

End Sub

Private Sub Timer1_Timer()
'Wait for ticket to print before showing screen
Timer1.interval = 0
Timer1.Enabled = False
If bDebug Then MsgBox "Show PRINT PAGE"
frmPrinting.Show
Unload Me

End Sub


Private Sub Timer2_Timer()
''Back to WELCOME if problem with credit card
Timer2.interval = 0
Timer2.Enabled = False
db.Execute "UPDATE SESSION set SessionStop=#" & Now() & "# where SessionID=" & SessionID

'If bMultiple Then
'    frmWelcomeMult.Show
'Else
    If bTicketmation Then
        bDEMO = False
        bTicketmation = False
    End If
    'frmWelcome.Show
    'If UseAOP Then
        frmFirstPageAOP.Show
    'Else
    '    frmFirstPage.Show
    'End If
'End If
Unload Me

End Sub



Private Sub Timer3_Timer()
Timer3.interval = 0
Timer3.Enabled = False
bServer = False
lblMessage.Caption = "We are sorry but there is a problem.  Please use another machine."
lblMessage.FontSize = 14
Timer2.interval = 3000
Timer2.Enabled = True
'End
End Sub

Private Sub Timer4_Timer()
'Allow time for screen SHOW
Timer4.interval = 0
Timer4.Enabled = False
'GET CARD AUTHORIZATION FROM AUTHORIZENET THRU WEB INTERFACE
If bDEMO Then
    'Set up credit card authorization
    ANResponseCode = 1
    'ANResponseCode = 99
    
    'If Len(CardNumber) > 0 Then
    '    ANTransactionCode = Right(CardNumber, 8)
    'Else
      Randomize Timer
      randomnumber = Int((99999999 - 1234567 + 1) * Rnd) + 1234567
      ANTransactionCode = "99" & Right(CStr(randomnumber), 8)
    'End If
Else
' If over $100 then as for zip code
    'If TotalPrice > 15 Then
    If TotTicketCount > iMaxTix Then
           frmZipCode.Show 1
           If Len(Trim(ZipCode)) < 5 Then
                ANResponseCode = 4
'                lblMessage.Caption = "You must enter Zip Code.  Transaction Terminated."
'                'Back to WELCOME
'                Refresh
'                Timer2.interval = 4000
'                Timer2.Enabled = True
           Else
                frmWebBrowser.Show 1
           End If
    Else
        ZipCode = ""
        frmWebBrowser.Show 1
    End If

End If
If bDebug Then MsgBox "CONFIRM TICKETS response" & Chr(10) & ANResponseCode & " " & ANTranactionCode
'RESPONSE FROM AUTHORIZENET
If ANResponseCode = 1 Then
    Call LogClick("AN", Right(CardNumber, 4) & "CardAccepted")
    lblMessage.Caption = "Your Tickets are now PRINTING..."
    Refresh
    BarCodeType = "0"
    '''TM info for ticket
    EventCode = "2014NY"
    EventCodeID = 1
    JComputerID = 1
    EPDATE = Now()
    ''''''''''''''''
    TicketCount = 1
    If Len(ANTransactionCode) < 4 Then
        'Int((HighestValue - LowestValue + 1) * Rnd) + LowestValue
        'JournalID = Format(IP, "0#") & Format(Int((99999) * Rnd), "0000#")
        Randomize Timer
        randomnumber = Int((99999999 - 1234567 + 1) * Rnd) + 1234567

        JournalID = Right(str(randomnumber), 6)
'        JournalID = Right(CardNumber, 6)
    Else
        'JournalID = Right(ANTransactionCode, 7)
        JournalID = Right(ANTransactionCode, 6)
    End If
    If bDebug Then MsgBox "Preprint: " & JournalID
    PrintTickets
    Call LogClick("Processing", "TicketsPrinted")
    'Wait for ticket to print
    Timer1.interval = 3000
    Timer1.Enabled = True
ElseIf ANResponseCode = 2 Then
    lblMessage.Caption = "Credit card not accepted..."
    Call LogClick("AN", Right(CardNumber, 4) & "CardDeclined")
    'Back to WELCOME
    Timer2.interval = 4000
    Timer2.Enabled = True
ElseIf ANResponseCode = 3 Then
    lblMessage.Caption = "Processing problem - please try again..."
    Call LogClick("AN", Right(CardNumber, 4) & "ProcessingProblem")
    Timer2.interval = 4000
    Timer2.Enabled = True
ElseIf ANResponseCode = 4 Then
    lblMessage.Caption = "You must enter Zip Code.  Transaction Terminated."
    Call LogClick("AN", Right(CardNumber, 4) & "Zip Not Entered")
    Timer2.interval = 4000
    Timer2.Enabled = True
ElseIf ANResponseCode = -1 Then
    lblMessage.Caption = "Transaction Cancelled.  Not a VALID COUPON."
    Call LogClick("AN", Right(CardNumber, 4) & "InvalidCoupon")
    Timer2.interval = 4000
    Timer2.Enabled = True
Else
    lblMessage.Caption = "Processing problem - please use different card..."
    Call LogClick("AN", Right(CardNumber, 4) & "ProcessingProblem")
    Timer2.interval = 4000
    Timer2.Enabled = True

End If

End Sub


Private Sub TimerACK_Timer()
    timer_flag = True
    TimerACK.Enabled = False

End Sub


