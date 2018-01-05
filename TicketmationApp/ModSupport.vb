Module ModSupport
    '***************************   Start of Constants   ******************************
    Public Const MAX_BUFFER_SIZE = 256
    Public Const ACK = 6                       'Hex value => 0x06
    Public Const NAK = 21                      'Hex value => 0x15
    Public Const XON = 17                      'Hex value => 0x11
    Public Const ASCII_CR = 13                 'Hex value => 0x0d
    Public Const ASCII_SPACE = 32              'Hex value => 0x20
    Public Const ASCII_OPEN_BRACKET = 60       'Hex value => 0x3c
    Public Const ASCII_TILDE = 126             'Hex value => 0x7e
    Public Const WRITE_PIPE = 1                'Hex value => 0x01
    Public Const READ_PIPE = 130               'Hex value => 0x82

    '' Sound constants
    '   Public Const SND_SYNC = &H0
    '   Public Const SND_ASYNC = &H1
    '   Public Const SND_NODEFAULT = &H2
    '   Public Const SND_LOOP = &H8
    '   Public Const SND_NOSTOP = &H10

    '***************************   End of Constatnts   *******************************

    '****************   Start of Global Variables   ***************
    Public ptr_buffer As Long                           'Pointer to read/write text buffer
    Public Str_Size As Long                             'Size of text buffer
    Public Buffer As Object
    Public text(0 To (MAX_BUFFER_SIZE - 1)) As Byte     'Read/Write text buffer
    Public path As String
    Public length As Long
    Public Display_Flag As Boolean
    Public CR, LF, TB As String                         'Return,line feed and Tab
    Public Baud, Bits, Parity As String
    Public flow_control As String
    Public wait_status As Boolean

    '    'These variables are used to control the verbal aspects of returned status
    '    Public speaking As Boolean
    Public duration As Double
    Public message As String

    'Used to signify a major problem, like communication
    Public problem, timeout, ack_found, timer_flag As Boolean
    'Used to signify a minor problem, like ticket jam or out of stock
    'Public recovery As Boolean
    Public ready As Boolean
    Public Response As Boolean
    'Public Black, Blue, Green, Cyan, Red, Magenta, Yellow, White, Brown 'Colors
    'Public Txtinterface As String           'string name of the current open port

    ''****************   End of Global Variables   ***************
    '
    '    Public Declare Function sndPlaySound Lib "WINMM.DLL" Alias "sndPlaySoundA" _
    '    (ByVal lpszSoundName As String, ByVal uFlags As Long) As Long
    '

    '**************************************************************************************
    '*
    '* Routine Name  : Initial_State()
    '*
    '* This routine is the equivalent to a startup routine.  When the main form initially
    '* loads this routine will execute.
    '**************************************************************************************
    Public Sub Initial_State()

        CR = Chr(13)               'Use this for a carriage return
        LF = Chr(10)               'Use this for a line feed
        TB = Chr(9)                'Use this for a horizontal Tab
        ' speaking = True             'Verbal Status Wave files will be played
        wait_status = False         'Auto status read is off
        problem = False             'Start with no problem
        duration = 0.5
        Display_Flag = True

        'Establish Colors for lights, etc.
        'Colors

    End Sub

    '**************************************************************************************
    '*
    '* Routine Name  : Transmit(text_data As String)
    '*
    '* This routine writes data out the Serial Port.
    '**************************************************************************************
    Public Sub Transmit(text_data As String)

        '    Dim myvar
        '
        ''   Enable_RTS              'Enable RTS for 232/422 adapter
        '
        '    'If this application does not already have the com port open, then open
        '    'it now.
        '    If (FrmBoca.ComPort.PortOpen <> True) Then
        '
        '        'Use this in case the com port is already in use by another application
        '        'An error will be generated if that is true.  Rather than let our application
        '        'crash or hang, trap the error and branch to not_open:
        '        'From there report it to the user then return to the initial state
        '        On Error GoTo Not_Open
        '
        '        FrmBoca.ComPort.PortOpen = True     'All is clear so open the com port
        '        On Error Resume Next                'return to standard error handling
        '        GoTo Is_Open
        '
        'Not_Open:   myvar = MsgBox("Dos, Basic or another application must be using it already.", 0, "Port busy")
        '        Initial_State                       'return application to the initial state
        '        GoTo Port_Busy                      'exit gracefully
        '    End If
        '
        'Is_Open:
        '
        '    'Here is where we test the printer for busy before a transmit.  This gives
        '    'some flow control.
        '    Call control_the_flow
        '
        '    FrmBoca.ShpTD.FillColor = Green         'Transmit starting so set light green
        '    FrmBoca.ComPort.output = text_data
        '
        'Port_Busy: 'Disable_RTS                     'Disable RTS for 232/422 adapter
        '
        '    FrmBoca.ShpTD.FillColor = Red           'Transmit complete so set light red
        '    On Error Resume Next

    End Sub
    '**************************************************************************************
    '*
    '* Routine Name  : Receive(size As Integer)
    '*
    '* This routine reads data from the Serial port.
    '**************************************************************************************
    Public Sub Receive(size As Integer)

        Dim Count As Integer
        Dim myvar

        'set 1/10 second status response wait period
        'timer_flag = False
        'FrmBoca.Timer1.interval = 100
        'FrmBoca.Timer1.Enabled = True
        ' Wait 0.1 seconds for data to come back to the serial port.
        'Do
        '    DoEvents
        'Loop Until timer_flag = True

        'FrmBoca.Timer1.Enabled = False

        'Read port
        'On Error GoTo Not_Open    '8018
        'FrmBoca.ShpRD.FillColor = Green       'Receive starting so set light green
        'Buffer = FrmBoca.ComPort.Input
        'On Error Resume Next    '8018

        'Verify the buffer length is no greater than 255 (0xff) which
        'is the largest value that can be stored in the byte known as text(0)
        length = Len(Buffer)
        If length < MAX_BUFFER_SIZE Then
            text(0) = length
        Else
            text(0) = MAX_BUFFER_SIZE - 1
        End If
        length = text(0)
        For Count = 1 To length
            text(Count) = Asc(Mid(Buffer, Count, 1))
            'Display_Text ("byte = " & text(Count))
        Next Count
        Buffer = ""
        Establish_Status()

        GoTo Is_Open
        'Not_Open: myvar = MsgBox("Either a unidirectional driver is in the way or another application must be using " & FrmBoca.Txtinterface & " already.", 0, "Port busy")
        '    Display_Text ("Status read aborted")
        Initial_State()

Is_Open:  'GoTo Port_Busy
        'FrmBoca.ShpRD.FillColor = Red       'Receive complete, so set light red
        On Error Resume Next

    End Sub

    '**************************************************************************************
    '*
    '* Routine Name  : Convert()
    '*
    '* This Subroutine converts characters to thier Ascii representation
    '* for the printer
    '**************************************************************************************
    Public Sub Convert(itext As String)

        Dim i As Integer
        'Convert string to byte size ascii integers to send to the printer.
        Str_Size = Len(itext)
        For i = 1 To Str_Size
            text(i - 1) = Asc(Mid(itext, i, 1))
        Next i

        'Set up Global pointer to data string
        '***        ptr_buffer = VarPtr(text(0))

    End Sub


    '**************************************************************************************
    '*
    '* Routine Name  : std_test()
    '*
    '* This routine demonstrates application flow control.  Basically, this is how to
    '* print multiple tickets and read for status in between each ticket before sending
    '* the next ticket.
    '* The file downloaded in this example needs to be FGL text command for an FGL printer.
    '* Should you have an HP emulation printer, the .prn files generated by the HP/PCL
    '* printer drivers could also be downloaded here.  You can make your own prn files with
    '* PCL commands.
    '**************************************************************************************
    Public Sub std_test(binary_file As String, ticket_count As Integer)

        Dim i As Integer
        For i = 1 To ticket_count

            'set status not found for the wait_for_the_ack() routine
            ack_found = False

            'Display_Text ("Test ticket #" & i & " sent to printer") 'test/debug statment

            'Submit tickets to print
            download_file(binary_file)

            'If there is a need to wait for status in between each test ticket,
            'then use application flow control which looks for the ACK
            If wait_status = True Then
                wait_for_ack()                 'Wait for the ACK
            End If
        Next i

    End Sub

    '**************************************************************************************
    '*
    '* Routine Name  : download_file()
    '*
    '* This routine will download any file through the current open port.
    '**************************************************************************************
    Public Sub download_file(file_name As String)
        '    Dim i As Integer
        '    Dim byte_count As Integer
        '    Dim Code As String

        '    On Error Resume Next                            'standard error handling

        'Open file_name For Binary As #2                 'open the disk file

        '    byte_count = LOF(2)                             'determine length of file

        '    For i = 1 To byte_count                         'loop for entire file
        '    Code = Input(1, #2)                         'Read one byte from input file
        '        Transmit(Code)                             'Write one byte to the printer
        '    Next i

        'Close #2                                        'close file


    End Sub


    '**************************************************************************************
    '*
    '* Routine Name  : Establish_Status()
    '*
    '* This routine will evaluate incoming data from the printer.  Some data will be text
    '* messages which will be displayed.  The rest of the data represents printer status.
    '* The status values are displayed below in the Case statement.
    '**************************************************************************************
    Public Sub Establish_Status()

        Dim i As Integer                    'counter
        Dim status_response As String       'Status read from Printer
        Dim file_name As String             'Wave files
        Dim upperbound, lowerbound As Integer
        Dim pos As Integer
        Dim start As Integer
        Dim finish As Integer
        Dim counter As Integer
        Dim header As Boolean

        header = False
        file_name = ""

        'Inhibit Display details when requested by setting flag Flase.
        'The default is True so it will display
        If Display_Flag = True Then

            'Debug code when needed
            'If length = 1 Then
            '    Display_Text ("1 Byte Read")
            'Else
            '    If length = 0 Then
            '        Display_Text ("No Status Read")
            '    Else
            '        Display_Text (length & " Bytes Read")
            '    End If
            'End If

            counter = 1
            'Perform loop for each bytes in the string
            For i = 1 To length

                'Correspond status number with a text message
                Select Case text(i)
                    Case 0 '0x00
                        status_response = "Null"

                    Case 1 '0x01
                        status_response = "Start of Heading"

                    Case 2 '0x02
                        status_response = "Start of Text"

                    Case 3 '0x03
                        status_response = "End of Text"

                    Case 4 '0x04
                        status_response = "End of Transmission"

                    Case 5 '0x05
                        status_response = "Test Button Ticket ACK"

                    Case 6 '0x06
                        status_response = "Ticket ACK"
                        ack_found = True             'used by wait_for_status()

                        '                Case 7 '0x07
                        '                    status_response = "Bell"
                        '
                        '                Case 8 '0x08
                        '                    status_response = "Backspace"
                        '
                        '                Case 9 '0x09
                        '                    status_response = "Horizontal Tab"
                        '
                        '                Case 10 '0x0A
                        '                    status_response = "Line Feed"
                        '
                        '                Case 11 '0x0B
                        '                    status_response = "Vertical Tab"
                        '
                        '                Case 12 '0x0C
                        '                    status_response = "Form Feed"
                        '
                        '                Case 13 '0x0D
                        '                    'status_response = "Carriage Return"
                        '                    status_response = ""
                        '
                        '                Case 14 '0x0E
                        '                    status_response = "Shift Out"
                        '
                        '                Case 15 '0x0F
                        '                    status_response = "Shift In"

                    Case 16 '0x10
                        status_response = "Out of Tickets"
                        ' Call LogClick("PrinterStatue", "Out of Tickets")

                        '                    'there are two recorded messages for out of stock.  Let a
                        '                    'random number generator decide which one to play
                        '                    upperbound = 1
                        '                    lowerbound = 0
                        '                    pos = Int((upperbound - lowerbound + 1) * Rnd + lowerbound)
                        '                    If pos = 0 Then
                        '                        file_name = "out.wav"
                        '                    Else
                        '                        file_name = "load.wav"
                        '                    End If

                    Case 17 '0x11
                        status_response = "X-On"
                        'if in a problem state, then recover now.
                        If problem = True Then
                            problem = False                 'Clear flag for application flow control
                            'Call LogClick("PrinterStatue", "Flow Control FIXED")

                            '                        file_name = "thanks.wav"        'Play Thank You voice message
                        End If
                        '                    FrmBoca.printer_ready               'display printer ready

                    Case 18 '0x12
                        status_response = "Power On"

                    Case 19 '0x13
                        status_response = "X-Off"           'Printer communication going offline
                        problem = True                      'Set flag for application flow control
                        'Call LogClick("PrinterStatue", "Flow Control PROBLEM")
                        '                    FrmBoca.printer_busy                'display BUSY

                    Case 20 '0x14
                        status_response = "DC4"

                    Case 21 '0x15
                        status_response = "Ticket NAK"

                    Case 22 '0x16
                        status_response = "Ribbon Low"

                    Case 23 '0x17
                        status_response = "Ribbon Out"

                    Case 24 '0x18
                        status_response = "Ticket Jam"
                        'file_name = "jam.wav"           'set up to play ticket jammed voice messgae
                        problem = True
                        'Call LogClick("PrinterStatue", "Ticket Jam PROBLEM")
                    Case 25 '0x19
                        'status_response = "Illegal Data"
                        status_response = ""

                    Case 26 '0x1A
                        status_response = "Power Up Problem"

                    Case 27 '0x1B
                        status_response = "Escape"

                    Case 28 '0x1C
                        status_response = "Incomplete Logo Stored in FLASH"

                    Case 29 '0x1D
                        status_response = "Cutter Jam"
                        problem = True
                        'Call LogClick("PrinterStatue", "Cutter Jam PROBLEM")

                    Case Else 'this data is probably not status data, but a text response
                        status_response = ""
                End Select

                'If the byte is a printable ASCII character display the value otherwise
                'display the status response
                If text(i) >= ASCII_SPACE And text(i) <= ASCII_TILDE Then
                    message = message & Chr(text(i))
                Else
                    If message <> "" Then
                        Display_Text(message)
                        header = False
                        message = ""
                    End If
                    Display_Text(status_response)
                End If

                'if filename has a value then a voice message is ready to play
                '            If (file_name <> "") Then
                '                Say (file_name)
                '                file_name = ""
                '            End If
                counter = counter + 1

            Next i

            'flush out any residual data in message buffer
            If message <> "" Then
                Display_Text(message)
                header = False
                message = ""
            End If
        End If
    End Sub
    ' This function will receive a string, check to see if the message text
    ' box is currently being used and append the string (and CRLF) to whatever is
    ' currently displayed in the message box
    Public Sub Display_Text(str As String)

        'append new string to old text and throw in CR LF
        '    If FrmBoca.txtmsg.Visible = True Then
        '        FrmBoca.txtmsg.text = FrmBoca.txtmsg.text & str & Chr(13) & Chr(10)
        '    End If
        'If bDebug Then MsgBox str

    End Sub
    'Clear the text from the message box
    Public Sub Clear_Display()
        '    FrmBoca.txtmsg.text = ""        'Clear out text
    End Sub
    '**************************************************************************************
    '*
    '* Routine Name  : Busy()
    '*
    '* This routine updates screen and calls pause.
    '**************************************************************************************
    Public Sub Busy(duration As Double)

        'Limit the pause time to 10 seconds max
        If duration < 0 Or duration > 10 Then
            duration = 2            '2 second delay
        End If

        Pause(duration)           'pause for "duration" # of seconds
    End Sub
    '**************************************************************************************
    '*
    '* Routine Name  : Say(filename As String)
    '*
    '* This routine will play the wav file specified in filename.
    '**************************************************************************************
    Public Sub Say(filename As String)

        Dim SoundName As String
        Dim wFlags As Integer
        Dim x As Integer

        'Plays .wav files
        '    If speaking = True Then
        '        wFlags = SND_ASYNC Or SND_NODEFAULT
        '        x = sndPlaySound(filename, wFlags)
        '        Pause (duration)
        '    End If

    End Sub

    Public Sub control_the_flow()

        'Here is where we test the printer for busy before a transmit.  This gives
        'some flow control.
        'The choices are None, Hardware & Software as control by the Flow Control
        'option buttons on the main form.  This can be coupled with application
        'flow control if desired.
        If (flow_control = "Hardware") Then
            wait_for_DSR()                        'check the DSR line for High or Low
        Else
            If (flow_control = "Software") Then
                wait_for_xon()                    'if there is a problem, wait for the X-On
            End If
        End If

    End Sub

    Public Sub wait_for_DSR()

        'Hardware Flow Control

        'FrmBoca.ComPort.DSRHolding is true when DSR line is high
        'If during a previous transmission there was a problem and the DSR
        'line went low, wait here for the DSR line to go high again
        '    Do
        '        DoEvents
        '    Loop Until FrmBoca.ComPort.DSRHolding = True    'wait here until DSR is high

    End Sub
    Public Sub wait_for_xon()

        'Software Flow Control

        'If during a previous transmission there was a problem and an X-Off
        'is received from the printer, we need to wait here for X-On status
        'to be returned before we proceed.
        Do
            Application.DoEvents()
        Loop Until (problem = False)        'wait here until poblem resolved

        'Once the X-On has been received and run through Establish_Status()
        'the problem flag will be reset to FALSE and we will exit this loop

    End Sub
    Public Sub wait_for_ack()

        'Application Flow Control
        Dim timeout_counter, max_time As Integer

        'We need to wait long enough for the printer to physically print the ticket
        'to expect to find the return status.  How long it takes to print a ticket
        'variest depending on how much data is actually transmitted to the printer.
        timeout_counter = 0                     'initialize time out counter

        'each count represent 1/10 of a second based on the PAUSE in the loop below
        max_time = 20                           '20 ticks allows for a 2 second wait

        ack_found = False                       'reset global flag

        'Wait up to 2 seconds (adjustable) for status to be returned.  The Oncomm
        'interrupt handler will call receive() as soon as a byte appears in the buffer.
        'Establish_Status() gets called from receive() and once the ACK is found
        'the ack_found flag will be set releasing us from this loop.  If the maximum
        'time limit has been reached and still no status, then we can give up and leave
        'this loop, otherwise the application will appear to hang waiting for status
        'that is not coming.
        Do
            Call Pause(0.1)
            Application.DoEvents()
            timeout_counter = timeout_counter + 1       'increment time out counter
        Loop Until ((ack_found = True) Or (timeout_counter > max_time))

        'The ACK could be followed by other bytes of information.
        'Example:
        '   As the printer runs out of stock printing the last ticket it has
        '   three bytes will be returned.  There will be an ACK (0x6) for the
        '   last ticket successfully printed.  This will be followed by an
        '   Out of Ticket stock (0x10) and an X-Off (0x13).  When the X-Off is
        '   detected in Establish_Status() the problem flag is set to true.
        '   Once the ticket stock is reloaded in the printer, then the printer
        '   will generate an X-On, which signals the application it is OK
        '   to continue.

        'if timeout
        If (ack_found = False) Then
            problem = True
            Display_Text("Timeout - No ACK returned with the last ticket.")
        End If

        'Wait in 1/10 of a second segment, in case there are more status bytes
        'after the ACK such as out of stock and X-Off.  It takes some time for
        'the printer to realize it has a problem.
        '    Pause (0.5)                     '1/2 second pause (adjustable)
        '    If problem = True Then
        '        'If there was a problem then wait for Xon to signify the problem is solved
        '        'This step is similar to software control - wait for X-On
        '        wait_for_xon
        '    End If

    End Sub

    'Initiate a pause on the screen.  The real passed represents
    'the number of seconds to pause.  As a failsafe a message box
    'will be used if count is less than or equal to zero.
    Public Sub Pause(seconds As Double)
        Dim interval As Integer

        On Error Resume Next

        interval = seconds * 1000

        If interval <= 0 Then
            MsgBox("You called for a Pause, Sir?", vbOKOnly, "Enter to Continue")
        Else
            timer_flag = False
            frmAuthorize.TimerACK.interval = interval
            frmAuthorize.timerACK.Enabled = True
            frmAuthorize.timerACK.Start()
            'frmTestTicketPrint.TimerACK.interval = interval
            'frmTestTicketPrint.TimerACK.Enabled = True
            ' Wait for timeout.
            Do
                Application.DoEvents()
            Loop Until timer_flag = True
            frmAuthorize.timerACK.Stop()
            '        frmTestTicketPrint.TimerACK.Enabled = False
        End If
    End Sub
    '* these RGB color schemes can be used by name
    Public Sub Colors()
        '    Black = RGB(0, 0, 0)
        '    Blue = RGB(0, 0, 255)
        '    Green = RGB(0, 255, 0)
        '    Cyan = RGB(0, 255, 255)
        '    Red = RGB(255, 0, 0)
        '    Magenta = RGB(255, 0, 255)
        '    Yellow = RGB(255, 255, 0)
        '    Brown = RGB(255, 127, 0)
        '    White = RGB(255, 255, 255)
    End Sub


End Module
