Imports MTSCRANET
Imports MTLIB

Module MagTekDevice
    Public _SwipeScanner As MTSCRA
    Public deviceList As New List(Of MTLIB.MTDeviceInformation)()
    Public m_connectionState As MTConnectionState
    Private m_startTransactionActionPending As Boolean
    Private m_turnOffLEDPending As Boolean
    Private m_emvMessageFormat As Integer = 0
    Private m_emvMessageFormatRequestPending As Boolean = False
    Private m_emvARCType As Integer

    Delegate Sub deviceListDispatcher(ByVal deviceList)
    Delegate Sub updateDisplayDispatcher(ByVal text As String)
    Delegate Sub clearDispatcher()
    Delegate Sub updateStateDispatcher(state As MTConnectionState)
    Delegate Sub userSelectionsDisptacher(title As String, selectionList As List(Of String), timeout As Long)
    Delegate Sub DataReceivedHandler(ByVal sender As Object, ByVal cardData As IMTCardData)
    Public Sub OpenDevice()
        _SwipeScanner = New MTSCRA()
        AddHandler _SwipeScanner.OnDeviceConnectionStateChanged, AddressOf OnDeviceConnectionStateChanged
        AddHandler _SwipeScanner.OnCardDataState, AddressOf OnCardDataStateChanged
        AddHandler _SwipeScanner.OnDataReceived, AddressOf OnDataReceived
        AddHandler _SwipeScanner.OnDeviceResponse, AddressOf OnDeviceResponse
        AddHandler _SwipeScanner.OnDeviceExtendedResponse, AddressOf OnDeviceExtendedResponse
        AddHandler _SwipeScanner.OnTransactionStatus, AddressOf OnTransactionStatus
        AddHandler _SwipeScanner.OnDisplayMessageRequest, AddressOf OnDisplayMessageRequest
        AddHandler _SwipeScanner.OnUserSelectionRequest, AddressOf OnUserSelectionRequest
        AddHandler _SwipeScanner.OnARQCReceived, AddressOf OnARQCReceived
        AddHandler _SwipeScanner.OnTransactionResult, AddressOf OnTransactionResult
        AddHandler _SwipeScanner.OnEMVCommandResult, AddressOf OnEMVCommandResult
        _SwipeScanner.setConnectionType(MTConnectionType.USB)
        If Not _SwipeScanner.isDeviceConnected Then
            _SwipeScanner.openDevice()
        End If
    End Sub
    Private Sub OnDeviceList(ByVal sender As Object, ByVal connectionType As MTLIB.MTConnectionType, ByVal deviceList As List(Of MTLIB.MTDeviceInformation)())

        'If deviceList.Count > 0 Then
        '    'Dim device As var
        '    For Each Device() In deviceList
        '        MsgBox(Device)
        '    Next

        'End If

    End Sub
    Private Sub OnDisplayMessageRequest(ByVal sender As Object, ByVal data() As Byte)
        MsgBox("OnDisplayMessageRequest")
        Dim message As String = ""

        If (data IsNot Nothing) And (data.Length > 0) Then
            message = System.Text.Encoding.UTF8.GetString(data)
            ' MsgBox(data)
            MsgBox(message)
        Else
            MsgBox("EMPTY")
        End If



    End Sub
    Private Sub OnTransactionStatus(ByVal sender As Object, ByVal data() As Byte)

        Dim message As String = ""
        'MsgBox("[OnTransactionStatus] data=" & System.Text.Encoding.UTF8.GetString(data))
        If (data.Length > 0) Then
            message = System.Text.Encoding.UTF8.GetString(data)
            'MsgBox(data)
            'MsgBox(message)
            MsgBox("[OnTransactionStatus] data=" & message)
        Else
            MsgBox("[OnTransactionStatus] No Data")
        End If


    End Sub

    Private Sub OnDeviceConnectionStateChanged(sender As Object, state As MTLIB.MTConnectionState)
        ' MsgBox("[OnDeviceConnectionStateChanged] state=" & state)


        updateState(state)
    End Sub

    Private Sub OnCardDataStateChanged(sender As Object, state As MTLIB.MTCardDataState)
        MsgBox("OnCardDataStateChanged")
        Select Case state
            Case MTCardDataState.DataError
                MsgBox("[Data Error]")
                Exit Select
            Case MTCardDataState.DataNotReady
                MsgBox("[Data Not Ready]")
                Exit Select
            Case MTCardDataState.DataReady
                MsgBox("[Data Ready]")
                Exit Select
        End Select
    End Sub

    Private Sub OnDataReceived(sender As Object, cardData As IMTCardData)
        MsgBox("[Raw Data]")
        MsgBox(_SwipeScanner.getResponseData())

        MsgBox("[Card Data]")
        ''        msgBox(getCardInfo())

        MsgBox("[TLV Payload]")
        'msgBox(cardData.getTLVPayload())
    End Sub
    Private Sub OnDeviceResponse(sender As Object, data As String)
        'MsgBox("[Device Response] data=" & data)
        'msgBox(data)

        If m_emvMessageFormatRequestPending Then
            m_emvMessageFormatRequestPending = False

            Dim emvMessageFormatResponseByteArray As Byte() = MTParser.getByteArrayFromHexString(data)

            If emvMessageFormatResponseByteArray.Length = 3 Then
                If (emvMessageFormatResponseByteArray(0) = 0) AndAlso (emvMessageFormatResponseByteArray(1) = 1) Then
                    m_emvMessageFormat = emvMessageFormatResponseByteArray(2)
                End If
            End If
        ElseIf m_startTransactionActionPending Then
            m_startTransactionActionPending = False
            StartTransaction()
        End If
    End Sub
    Private Sub OnDeviceExtendedResponse(sender As Object, data As String)
        MsgBox("[Device Extended Response]")
        MsgBox(data)

        ''processDeviceExtendedResponse(data)
    End Sub
    Private Sub OnUserSelectionRequest(sender As Object, data As Byte())
        MsgBox("[User Selection Request]")

        MsgBox(MTParser.getHexString(data))

        ''processSelectionRequest(data)
    End Sub
    Private Sub OnARQCReceived(sender As Object, data As Byte())
        MsgBox("[ARQC Received]")
        MsgBox(data)
        MsgBox(MTParser.getHexString(data))

        'Dim parsedTLVList As List(Of Dictionary(Of [String], [String])) = MTParser.parseEMVData(data, True, "")

        'If parsedTLVList IsNot Nothing Then
        '    Dim deviceSNString As [String] = MTParser.getTagValue(parsedTLVList, "DFDF25")
        '    Dim deviceSN As Byte() = MTParser.getByteArrayFromHexString(deviceSNString)

        '    msgBox("SN Bytes=" + deviceSNString)

        '    Dim response As Byte() = Nothing

        '    Dim arc As Byte() = Nothing

        '    If m_emvARCType = 0 Then
        '        arc = ApprovedARC
        '    ElseIf m_emvARCType = 1 Then
        '        arc = DeclinedARC
        '    ElseIf m_emvARCType = 2 Then
        '        arc = QuickChipARC
        '    End If

        '    If m_emvMessageFormat = 0 Then
        '        response = buildAcquirerResponseFormat0(deviceSN, arc)
        '    ElseIf m_emvMessageFormat = 1 Then
        '        Dim macKSNString As [String] = MTParser.getTagValue(parsedTLVList, "DFDF54")
        '        Dim macKSN As Byte() = MTParser.getByteArrayFromHexString(macKSNString)

        '        Dim macEncryptionTypeString As [String] = MTParser.getTagValue(parsedTLVList, "DFDF55")
        '        Dim macEncryptionType As Byte() = MTParser.getByteArrayFromHexString(macEncryptionTypeString)

        '        response = buildAcquirerResponseFormat1(macKSN, macEncryptionType, deviceSN, arc)
        '    End If

        '    setAcquirerResponse(response)
        'End If

    End Sub
    Private Sub OnTransactionResult(sender As Object, data As Byte())
        'MsgBox("[Transaction Result] data=" & MTParser.getHexString(data))

        'If data IsNot Nothing Then
        '    If data.Length > 0 Then
        '        Dim signatureRequired As Boolean = (data(0) <> 0)

        '        Dim lenBatchData As Integer = data.Length - 3
        '        If lenBatchData > 0 Then
        '            Dim batchData As Byte() = New Byte(lenBatchData - 1) {}

        '            Array.Copy(data, 3, batchData, 0, lenBatchData)

        '            msgBox("(Parsed Batch Data)")

        '            Dim parsedTLVList As List(Of Dictionary(Of [String], [String])) = MTParser.parseEMVData(batchData, False, "")
        '            'List<Dictionary<String, String>> parsedTLVList = MTParser.parseTLVData(batchData, false);

        '            displayParsedTLV(parsedTLVList)

        '            Dim approved As Boolean = False

        '            If m_emvMessageFormat = 0 Then
        '                Dim cidString As [String] = MTParser.getTagValue(parsedTLVList, "9f27")
        '                Dim cidValue As Byte() = MTParser.getByteArrayFromHexString(cidString)


        '                If cidValue IsNot Nothing Then
        '                    If cidValue.Length > 0 Then
        '                        If (cidValue(0) And CByte(&H40)) <> 0 Then
        '                            approved = True
        '                        End If
        '                    End If
        '                End If
        '            ElseIf m_emvMessageFormat = 1 Then
        '                Dim statusString As [String] = MTParser.getTagValue(parsedTLVList, "dfdf1a")
        '                Dim statusValue As Byte() = MTParser.getByteArrayFromHexString(statusString)


        '                If statusValue IsNot Nothing Then
        '                    If statusValue.Length > 0 Then
        '                        If statusValue(0) = 0 Then
        '                            approved = True
        '                        End If
        '                    End If
        '                End If
        '            End If

        '            If approved Then
        '                If signatureRequired Then
        '                    displayMessage2("( Signature Required )")
        '                Else
        '                    displayMessage2("( No Signature Required )")
        '                End If
        '            End If
        '        End If
        '    End If
        'End If

        'setLED(False)
    End Sub
    Private Sub OnEMVCommandResult(sender As Object, data As Byte())
        'MsgBox("[EMV Command Result]: data=" & MTParser.getHexString(data))

        If m_turnOffLEDPending Then
            m_turnOffLEDPending = False
            _SwipeScanner.sendCommandToDevice(MTDeviceConstants.SCRA_DEVICE_COMMAND_STRING_SET_LED_OFF)
        End If
    End Sub
    Private Sub updateState(state As MTConnectionState)
        m_connectionState = state

        Try
            Select Case state
                Case MTConnectionState.Connecting
                    MsgBox("[Connecting....]")
                    'displayDeviceInformation()
                    Exit Select
                Case MTConnectionState.Connected
                    If _SwipeScanner.isDeviceEMV() Then
                        MsgBox("This device supports EMV.")
                        requestEMVMessageFormat()
                    End If
                    MsgBox("[Connected]")
                    'clearMessage()
                    'clearMessage2()
                    Exit Select
                Case MTConnectionState.Disconnecting
                    MsgBox("[Disconnecting....]")
                    Exit Select
                Case MTConnectionState.Disconnected
                    MsgBox("[Disconnected]")
                    Exit Select
            End Select

        Catch ex As Exception
        End Try

    End Sub
    Private Sub StartTransaction()
        Dim timeLimit As Byte = &H3C
        Dim cardType As Byte = &H2    ' Chip Only
        'byte cardType = 0x03; // Chip and MSR
        Dim [option] As Byte = &H0
        Dim amount As Byte() = New Byte() {&H0, &H0, &H0, &H0, &H15, &H0}
        Dim transactionType As Byte = &H0   ' Purchase
        'byte transactionType = 0x04; // Goods
        'byte transactionType = 0x50; // Test
        Dim cashBack As Byte() = New Byte() {&H0, &H0, &H0, &H0, &H0, &H0}
        Dim currencyCode As Byte() = New Byte() {&H8, &H40}
        Dim reportingOption As Byte = &H2

        Dim result As Long = _SwipeScanner.startTransaction(timeLimit, cardType, [option], amount, transactionType, cashBack, currencyCode, reportingOption)
        MsgBox("[Start Transaction] (Result=" & result & ")")
    End Sub
    Private Sub requestEMVMessageFormat()
        Dim task__1 As Task = Task.Factory.StartNew(Function()
                                                        'Await Task.Delay(1000)

                                                        m_emvMessageFormatRequestPending = True

                                                        Dim status As Integer = sendCommand("000168")

                                                        If status <> MTSCRA.SEND_COMMAND_SUCCESS Then
                                                            m_emvMessageFormatRequestPending = False
                                                        End If

                                                    End Function)
    End Sub
    Private Function sendCommand(command As String) As Integer
        Dim result As Integer = MTSCRA.SEND_COMMAND_ERROR

        If _SwipeScanner.isDeviceConnected() Then
            MsgBox("[Sending Command] :" & command)

            result = _SwipeScanner.sendCommandToDevice(command)
        End If

        Return result
    End Function
End Module
