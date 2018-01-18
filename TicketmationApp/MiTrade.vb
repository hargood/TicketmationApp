Module MiTrade
    'DEVICE
    Public IP As String
    Public TerminalID As String
    Public strComputerName As String
    Public intComPort As Integer
    Public SessionCounter As String
    Public strConnectionString As String = "MSAccess"
    Public bHaveInternet As Boolean = True

    'DATABASE
    '    Public con As New OledbConnection("Provider=microsoft.Jet.oledb.4.0DataSource=D:\mydata.mdb;")
    '    Public wrkjet As DataTable
    '    'Public db As Database
    '    Public rsShows As DataTable
    '    Public rsShow As DataTable
    '    Public rsTicketTypes As DataTable

    '    '''TICKET INFORMATION
    '    Public TicketPrinter As Integer   '1 BOCA   2 PA
    Public SelectedTicket As Integer
    Public TicketPrices(3) As Double
    Public TicketTypes(5, 3) As String
    Public TotalTicketSold(3) As Integer
    '    Public BarCodeType As String
    Public TotTicketCount As Integer
    Public TicketCount As String
    Public TicketStock As Integer
    Public BarCode As String

    '    '''SHOW INFORMATION
    Public ShowID As Integer
    Public ShowName As String
    Public SQLShowID As Integer
    Public ShowImage As String
    Public ShowStartDate As Date
    Public TodaysKey As Integer
    Public AuthNetLogIDCP As String
    Public AuthNetLogIDCNP As String
    Public AuthNetKeyCP As String
    Public AuthNetKeyCNP As String
    Public imgRatio As Decimal = 1.0
    '    '''CREDIT CARD INFORMATION
    Public AccountNumber As String      'Track2 Data
    Public Track1 As String
    Public CardType As String
    Public CardNumber As String
    Public CardExpire As String
    Public CardName As String
    Public CardFirstName As String
    Public CardLastName As String
    Public MOP As String                'Credit Card Type
    '    Public TotalPrice As Currency
    Public TotalPrice As Integer
    Public ZipCode As String
    '    Public strDebitString As String     'For Debit Card Processing
    '    Public strPageImageCC As String     'Suffix for page graphic indicating CC used
    '    Public ConvenienceFee As Currency
    '    Public ConvenienceFeeType As Integer
    '    Public CouponCode As String
    '    Public EMail As String

    '    '''PROCESSING INFORMATION
    Public SwipTime As Date
    Public SessionID As Long
    '    Public webCounter As Integer
    Public iSwipe As Integer
    Public PrinterError As Boolean
    Public SwipeProcess As Boolean = True
    Public DeclineMessage As String = ""
    Public errorMessage As String = ""
    '    '''TICKETMASTER
    '    Public SellerCode As String
    '    Public Password As String
    '    Public JournalID As String
    '    Public JComputerID As String
    '    Public EventCodeID As String
    Public EventType As String
    Public EventCity As String
    Public EventReference As String
    '    Public EventID As String
    '    Public EventCode As String
    '    Public ShowReference As String
    '    Public EPDATE As String
    Public bServer As Boolean           'TICKETMASTER Server does not respond
    '    Public bOffLine As Boolean          'Off-Line Mode

    '    '''AUTHORIZENET
    Public bAN As Boolean               'Use AuthorizeNet Indicator
    '    Public ANResponseCode As Integer
    Public ANTransactionCode As String

    '    ''''EMV
    Public CardApproved As Boolean = False
    Public TransactionID As String = ""
    Public PurchaseID As Integer = 0
    Public ReferenceID As String = ""

    '    '''CONTROLS
    Public bEMV As Boolean = False    'True: use EMV processor, False:Swipe
    Public bChange As Boolean = False          'Change Purchase Indicator
    'Public dbLocal As Database          '***NOT USED
    Public bTest As Boolean             'Use Test Event - **NOT USED**
    Public bDebug As Boolean            'Debug messages provided
    Public bDebit As Boolean            'Indicates a Debit Card is being used
    Public bMultiple As Boolean         'Multiple event indicator
    Public bNoPorts As Boolean          '***NOT USED
    Public bDEMO As Boolean             'Credit Card Authorization bypassed - No Barcode
    Public bDEMOP As Boolean            'Credit Card Authorization bypassed  -Turn On Barcode
    Public bTicketmation As Boolean     'Indicated a single DEMO is executing
    Public bStartup As Boolean          'Indicates on STARTUP Screen
    Public NotAllowDebit As Boolean     'NO debit cards (always TRUE)
    Public VisaMCOnly As Boolean        'AMEX Allowed (True-NO, False-YES)
    Public AllowDiscover As Boolean     'Allow Discover
    Public GetZip As Boolean            'Acquire Zip Code
    Public bGetEMail As Boolean          'Acquire EMail
    Public bRestart As Boolean
    Public NoAN As Boolean              'Do not actually Proceess Card
    Public DBOpen As Boolean            'Indicates if DB has been open
    Public bConvenienceFee As Boolean   'Charge a Convenience Fee
    Public bAcceptConvenienceFee As Boolean
    Public bReceipt As Boolean          'Ask about Receipt
    Public bPrintReceipt As Boolean     'Print Receipt
    Public bNoPrintBypass As Boolean    'Don't print Ticlets
    Public UseAOP As Boolean            'AOP Screen
    Public AOPBarcode As Boolean        'Use AOP Barcodes
    Public bBatch As Boolean            'Uploading Batch info
    Public nBatch As Integer            'Number of Batch items
    Public bUseBU As Boolean            'USE backup website
    Public iMaxTix As Integer           'Maximum tickets until ZIP Requested
    Public bPrintError As Boolean       'Indicates that restart is from print error

    '    Private Declare Function GetComputerName _
    '    Lib "kernel32" Alias "GetComputerNameA" ( _
    '    ByVal lpBuffer As String, nSize As Long) As Long

    '    Private Const MAX_COMPUTERNAME_LENGTH As Long = 15&

    '    Public Declare Function GetInputState Lib "user32" () As Long

    '    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)


    '    'API's Function Declarations

    '    Private Declare Function IsWindow Lib "user32" (ByVal hwnd As Long) As Long


    '    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" ( _
    '       ByVal hwnd As Long, _
    '       ByVal nIndex As Long) As Long


    '    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" ( _
    '       ByVal hwnd As Long, _
    '       ByVal wMsg As Long, _
    '       ByVal wParam As Long, _
    '       ByVal lParam As Long) As Long


    '    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" ( _
    '       ByVal lpClassName As Any, _
    '       ByVal lpWindowName As String) As Long

    '    Public Declare Function URLDownloadToFile Lib "urlmon" Alias _
    '        "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, _
    '        ByVal szFileName As String, ByVal dwReserved As Long, _
    '        ByVal lpfnCB As Long) As Long

    '    'API Constants

    '    Public Const GWL_STYLE = -16

    '    Public Const WS_DISABLED = &H8000000

    '    Public Const WM_CANCELMODE = &H1F

    '    Public Const WM_CLOSE = &H10


    '    Public Function IsTaskRunning(sWindowName As String) As Boolean
    '        Dim hwnd As Long, hWndOffline As Long

    '        On Error GoTo IsTaskRunning_Eh
    '        'get handle of the application
    '        'if handle is 0 the application is currently not running
    '        hwnd = FindWindow(0&, sWindowName)
    '        If hwnd = 0 Then
    '            IsTaskRunning = False
    '            Exit Function
    '        Else
    '            IsTaskRunning = True
    '        End If


    'IsTaskRunning_Exit:
    '        Exit Function


    'IsTaskRunning_Eh:
    '        Call ShowError(sWindowName, "IsTaskRunning")

    '    End Function


    '    Public Function EndTask(sWindowName As String) As Integer
    '        Dim x As Long, ReturnVal As Long, TargetHwnd As Long

    '        'find handle of the application
    '        TargetHwnd = FindWindow(0&, sWindowName)
    '        If TargetHwnd = 0 Then Exit Function

    '        If IsWindow(TargetHwnd) = False Then
    '            GoTo EndTaskFail
    '        Else
    '            'close application
    '            If Not (GetWindowLong(TargetHwnd, GWL_STYLE) And WS_DISABLED) Then
    '                x = PostMessage(TargetHwnd, WM_CLOSE, 0, 0&)
    '                DoEvents()
    '            End If
    '        End If

    '        GoTo EndTaskSucceed


    'EndTaskFail:
    '        ReturnVal = False
    '        MsgBox("EndTask: cannot terminate " & sWindowName & " task")
    '        GoTo EndTaskEndSub


    'EndTaskSucceed:
    '        ReturnVal = True


    'EndTaskEndSub:
    '        EndTask% = ReturnVal

    '    End Function


    '    Public Function ShowError(sText As String, sProcName As String)
    '        'this function displays an error that occurred

    '        Dim sMsg As String
    '        sMsg = "Error # " & str(Err.Number) & " was generated by " _
    '             & Err.Source & vbCrLf & Err.Description
    '        MsgBox(sMsg, vbCritical, sText & Space(1) & sProcName)
    '        Exit Function


    '    End Function

    '    Public Function CurrentMachineName() As String

    '        Dim lSize As Long
    '        Dim sBuffer As String
    '        sBuffer = Space$(MAX_COMPUTERNAME_LENGTH + 1)
    '        lSize = Len(sBuffer)

    '        If GetComputerName(sBuffer, lSize) Then
    '            CurrentMachineName = Left$(sBuffer, lSize)
    '        End If

    '    End Function
    '    Sub LogClick(FromForm, Click)
    '        db.Execute "Insert into LOG (LogTime,SessionID,ClickFrom) values(#" & Now() & "#," & SessionID & ",'" & FromForm & ":" & Click & "')"

    '    End Sub

    '    Sub OpenDataBase()
    '        Dim rsInfo As Recordset
    '        '    On Error GoTo DB_Error
    '        wrkjet = CreateWorkspace("", "admin", "", dbUseJet)
    '        Dim strpath As String
    '        strpath = App.path & "\WUS.mdb"
    '        db = wrkjet.OpenDataBase(strpath)
    '        '    Set dbLocal = wrkjet.OpenDataBase(strpath)
    '        '    Set rsInfo = db.OpenRecordset("Select * from SETUP_INFO")
    '        '    If rsInfo.EOF Then
    '        '        dbLocal.Execute "INSERT INTO SETUP_INFO (ComputerName,DatabaseServer) values('" & CurrentMachineName() & "','" & App.Path & "')"
    '        '        Set db = dbLocal
    '        '    Else
    '        '        'If StrComp(App.Path, rsInfo("DatabaseServer")) <> 0 Then
    '        '           'different server
    '        '            strComputerName = rsInfo("ComputerName")
    '        '            strpath = rsInfo("DatabaseServer") & "\WUS.mdb"
    '        '            Set db = wrkjet.OpenDataBase(strpath)
    '        '        'End If
    '        '    End If
    '        'DB_Error:
    '        '    dbLocal.Execute "DELETE from SETUP_INFO"
    '        '    dbLocal.Execute "INSERT INTO SETUP_INFO (ComputerName,DatabaseServer) values('" & CurrentMachineName() & "','" & App.Path & "')"
    '        '    Set rsInfo = dbLocal.OpenRecordset("Select * from SETUP_INFO")
    '        '    strpath = rsInfo("DatabaseServer") & "\WUS.mdb"
    '        '    Set db = wrkjet.OpenDataBase(strpath)
    '    End Sub
    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function


End Module
