Imports System.IO
Imports System.Runtime
Imports System.Windows.Input
Imports System.Management
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows
Imports Microsoft.Win32
'Imports Microsoft.PointOfService
Imports System.Security.Permissions
'Imports ctlUSBHID

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class frmFirstPage
    'Public MTCardReader As ctlUSBHID.USBHID
    Dim ClickClick1 As Boolean
    Dim ClickClick2 As Boolean
    Dim bTouch As Boolean = False
    'WithEvents myExplorer As PosExplorer
    'WithEvents myMsr As Msr
    'WithEvents CardReader As New System.IO.Ports.SerialPort
    'WithEvents myCardReader As New System.IO.Ports.SerialPort

    Private Sub frmFirstPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim iTicketStock As Integer
        Dim iBatch As Integer = 0
        Dim i As Integer
        Dim j As Integer

        AxUSBHID1.PortOpen = True

        'frmMainAN.Close()
        '****
        'TimerChip.Enabled = False
        imgShow.Top = 0
        imgShow.Width = imgShow.Height * imgRatio
        imgShow.Image = Image.FromFile(Application.StartupPath & "\" & ShowImage)
        imgShow.Left = lblPurchaseHere.Left + lblPurchaseHere.Width / 2 - imgShow.Width / 2
        'specify credit card icons
        If VisaMCOnly Then
            imgCC3.Visible = False
        Else
            imgCC3.Visible = True
        End If

        If AllowDiscover Then
            imgCC4.Visible = True
        Else
            imgCC4.Visible = False

        End If

        iBatch = GetBatch()
        If iBatch = 0 Then
            nBatch = 0
        Else
            nBatch = iBatch
        End If
        lBatch.Text = Trim(Str(nBatch))

        iTicketStock = GetTicketStock()
        'Clear Ticket info
        For i = 0 To 3
            TicketPrices(i) = 0.0
            TotalTicketSold(i) = 0
            For j = 0 To 5
                TicketTypes(j, i) = "0"
            Next
        Next
        TotTicketCount = 0
        TicketCount = "0"
        If iTicketStock <= 10 Then
            frmStartup.Show()
        Else
            lStock.Text = iTicketStock.ToString
        End If
        bDEMO = False
        bDEMOP = False
        'TimerChip.Enabled = True
    End Sub
    Private Sub ClickImage1_Click(sender As Object, e As EventArgs) Handles ClickImage1.Click
        ClickClick1 = True
        ClickTimer.Enabled = True
        ClickTimer.Interval = 5000
    End Sub
    Private Sub ClickImage2_Click(sender As Object, e As EventArgs) Handles ClickImage2.Click
        If ClickClick1 Then
            'ClickTimer.Interval = 0
            ClickTimer.Enabled = False
            ClickClick1 = False
            ' End
            fTicketmation.Show()
            'Unload Me
        End If
    End Sub

    Private Sub ClickTimer_Tick(sender As Object, e As EventArgs) Handles ClickTimer.Tick
        ClickClick1 = False
        ClickTimer.Enabled = False
    End Sub

    Private Sub PageClicked()
        If bTouch Then
            bTouch = False
        End If
    End Sub

    Private Sub imInsertCard_Click(sender As Object, e As EventArgs)
        'validate internet
        'bHaveInternet = HaveInternetConnection()
        If Not HaveInternetConnection() Then
            frmStartup.Show()

            frmStartup.lMessage.Text = "*************** NO INTERNET CONNECTION ********************"
            frmStartup.lMessage.Left = frmStartup.lblWelcome.Width / 2 + frmStartup.lblWelcome.Left - frmStartup.lMessage.Width / 2

            Me.Close()
            Exit Sub
        End If
        NewSessionID()
        LogClick("First Page", "to Specify Tickets")
        frmSpecifyTickets.Show()
        Me.Close()

    End Sub
    Private Sub AxUSBHID1_CardDataChanged(sender As Object, e As EventArgs) Handles AxUSBHID1.CardDataChanged
        ' If SwipeProcess Then
        'Dim abTrack1() As Byte
        'Dim abTrack2() As Byte
        'Dim abTrack3() As Byte
        'Dim i As Long
        'Dim j As Integer
        'Dim strOutput As String

        'ImBadSwipe.Visible = False
        lblBadSwipe.Text = "THIS MACHINE DOES NOT ACCEPT THIS TYPE OF CARD PLEASE USE A DIFFERENT CARD"
        lblBadSwipe.Visible = False
        '    TimerBadSwipe.interval = 0
        '    TimerBadSwipe.Enabled = False
        Call LogClick("Swipe", "Process Swipe")

        iSwipe = 0
        '    Timer_idleMinutes.interval = 0
        '    Timer_idleMinutes.Enabled = False

        'With AxUSBHID1
        'Try
        If (AxUSBHID1.GetTrack(1) <> "" Or AxUSBHID1.GetTrack(2) <> "" Or AxUSBHID1.GetTrack(3) <> "") Then
            If InStr(1, AxUSBHID1.GetTrack(2), "=") = 0 Then
                lblBadSwipe.Visible = True
                imgSwipe.Visible = False
                Call LogClick("Swipe", "Invalid Card")
                TimerWrongCard.Interval = 3000
                TimerWrongCard.Start()
                'Exit Sub
            Else
                AccountNumber = AxUSBHID1.GetTrack(2)
                Track1 = AxUSBHID1.GetTrack(1)
                '            End If

                SwipTime = Now()
                'AccountNumber = .GetTrack(2)
                If Len(AccountNumber) > 0 Then
                    CardType = Mid(AccountNumber, InStr(1, AccountNumber, "=") + 5, 3)
                    CardNumber = Mid(AccountNumber, 2, InStr(1, AccountNumber, "=") - 2)
                    'Credit Card Type
                    If Strings.Left(CardNumber, 2) = "34" Or Strings.Left(CardNumber, 2) = "37" Then
                        MOP = "AMX"
                    ElseIf Strings.Left(CardNumber, 1) = "5" Then
                        MOP = "MC"
                    ElseIf Strings.Left(CardNumber, 1) = "4" Then
                        MOP = "VISA"
                    ElseIf Strings.Left(CardNumber, 3) = "300" Or Strings.Left(CardNumber, 3) = "303" Or Strings.Left(CardNumber, 3) = "302" Or Strings.Left(CardNumber, 3) = "303" Or Strings.Left(CardNumber, 3) = "304" Or Strings.Left(CardNumber, 3) = "305" Or Strings.Left(CardNumber, 2) = "36" Or Strings.Left(CardNumber, 2) = "38" Then
                        MOP = "DSC"
                    ElseIf Strings.Left(CardNumber, 4) = "2131" Or Strings.Left(CardNumber, 4) = "1800" Then
                        MOP = "JCB"
                    ElseIf Strings.Left(CardNumber, 6) = "628181" Then
                        MOP = "SEARS"
                    Else
                        MOP = "OTHER"
                    End If
                    If (CardType = "120" Or CardType = "220") And NotAllowDebit Then
                        lblBadSwipe.Visible = True
                        imgSwipe.Visible = False
                        Call LogClick("Swipe", "No Debit Accepted")
                        TimerWrongCard.Interval = 3000
                        TimerWrongCard.Start()

                        'Exit Sub
                    ElseIf VisaMCOnly And Strings.Left(CardNumber, 1) = "3" Then
                        If NotAllowDebit Then
                            lblBadSwipe.Visible = True
                        Else
                            lblBadSwipe.Visible = True
                        End If
                        Call LogClick("Swipe", "No AMEX Accepted")
                        imgSwipe.Visible = False
                        TimerWrongCard.Interval = 3000
                        TimerWrongCard.Start()

                        'Exit Sub
                    ElseIf Strings.Left(CardNumber, 4) = "6011" And Not AllowDiscover Then
                        lblBadSwipe.Visible = True
                        imgSwipe.Visible = False
                        Call LogClick("Swipe", "No Discover Accepted")

                        TimerWrongCard.Interval = 3000
                        TimerWrongCard.Start()
                        ' Exit Sub
                    ElseIf Strings.Left(CardNumber, 1) <> "5" And Strings.Left(CardNumber, 1) <> "4" And Strings.Left(CardNumber, 1) <> "3" And Strings.Left(CardNumber, 4) <> "6011" And CardType <> "120" And CardType <> "220" Then
                        lblBadSwipe.Visible = True
                        imgSwipe.Visible = False
                        Call LogClick("Swipe", "Invalid Card")
                        TimerWrongCard.Interval = 3000
                        TimerWrongCard.Start()

                        'Exit Sub
                        'End If
                    Else
                        ''NO PROBLEMS ... CARD OK - Get data
                        'Timer_idleMinutes.interval = 0
                        'Timer_idleMinutes.Enabled = False
                        CardExpire = Mid(AccountNumber, InStr(1, AccountNumber, "=") + 1, 4)
                        'Track1 = .GetTrack(1)
                        'If bDebug Then MsgBox("Track1=" & Track1)
                        'If bDebug Then MsgBox("Track2=" & AccountNumber)
                        CardFirstName = AxUSBHID1.GetFName
                        CardLastName = AxUSBHID1.GetLName

                        If Len(Track1) > 1 Then
                            CardName = Trim(Mid(Track1, InStr(1, Track1, "^") + 1, InStr((InStr(1, Track1, "^") + 1), Track1, "^") - InStr(1, Track1, "^") - 1))
                        Else
                            CardName = AxUSBHID1.GetLName & "/" & AxUSBHID1.GetFName
                        End If

                        AxUSBHID1.ClearBuffer()
                        AxUSBHID1.PortOpen = False
                        NewSessionID()
                        SwipTime = Now()
                        'Start New session
                        'db.Execute "Insert into SESSION (SessionStart) values(#" & Now() & "#)"
                        'Set rs = db.OpenRecordset("Select max(SessionID) from SESSION")
                        'SessionID = rs(0)
                        Call LogClick("Swipe", "Card Accepted")
                        ''''''''''''''''''USE TIMER STUPID
                        '           TimerStupid.Interval = 600
                        '           Call LogClick("Swipe", "Timer Set")
                        '''''''''''''''''''''''''''''''''''
                        '' Turn all timers OFF
                        ' Timer_idleMinutes.Enabled = False
                        'TimerBadSwipe.Enabled = False
                        'TimerClick.Enabled = False
                        'TimerStupid.Enabled = False
                        TimerWrongCard.Stop()
                        '''''use kluge'''''''''''
                        '*****UT THIS BACK
                        'Call LogClick("After Swipe", "To KLUGE")
                        SwipeProcess = True
                        'For i = 1 To 100
                        '    'DoEvents()
                        'Next i
                        TimerNextPage.Interval = 500
                        TimerNextPage.Start()
                        'frmSpecifyTickets.Show()
                        ' Me.Close()
                    End If
                End If
            End If

        Else
            lblBadSwipe.Visible = True
            imgSwipe.Visible = False
            Call LogClick("Swipe", "Invalid Card")
            TimerWrongCard.Interval = 3000
            TimerWrongCard.Start()
        End If
                'Catch ex As Exception
                '    lblBadSwipe.Visible = True
                '    Call LogClick("Swipe", "Invalid Card")
                '    TimerWrongCard.Interval = 3000
                '    TimerWrongCard.Start()
                '    Exit Sub
                'End Try
                ' End With
                'frmSpecifyTickets.Show()
                'Me.Close()
                'Exit Sub
                'Else
                '    lblBadSwipe.Visible = True
                '    Call LogClick("Swipe", "Invalid Card")
                '    TimerWrongCard.Interval = 3000
                '    TimerWrongCard.Start()
                '    SwipeProcess = True
                '      End If


    End Sub
    Private Sub AxUSBHID1_CardDataError(sender As Object, e As EventArgs) Handles AxUSBHID1.CardDataError
        SwipeProcess = False
        'MsgBox("BAD SWIPE")
        'Call LogClick("Swipe", "Bad Swipe")
        lblBadSwipe.Text = "Card not read.  Please RESWIPE CARD."
        imgSwipe.Visible = False
        lblBadSwipe.Visible = True
        TimerWrongCard.Start()
        'TimerBadSwipe.interval = 3000
        'TimerBadSwipe.Enabled = True
        SwipeProcess = True
    End Sub

    Private Sub TimerWrongCard_Tick(sender As Object, e As EventArgs) Handles TimerWrongCard.Tick
        lblBadSwipe.Visible = False
        imgSwipe.Visible = True
        TimerWrongCard.Stop()

    End Sub

    Private Sub TimerNextPage_Tick(sender As Object, e As EventArgs) Handles TimerNextPage.Tick
        TimerNextPage.Stop()

        frmSpecifyTickets.Show()
        Me.Close()
    End Sub
End Class