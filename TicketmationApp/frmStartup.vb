Imports System.IO

Public Class frmStartup
    Dim imNo As Integer
    Dim numcycles As Integer
    Dim ClickClick1 As Boolean
    Dim ClickClick2 As Boolean

    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim processes As Process() = Process.GetProcesses()
        Dim foundMe As Boolean = False
        Dim iTicketStock As Integer
        lMessage.Text = ""
        'determine internet connection
        bHaveInternet = HaveInternetConnection()
        If Not bHaveInternet Then
            lMessage.Text = "***************NI********************"
            lMessage.Left = lblWelcome.Width / 2 + lblWelcome.Left - lMessage.Width / 2
            ClickImage1.Visible = False
            ClickImage2.Visible = False
            Exit Sub
        End If
        'Determine if existing Process
        For Each item In processes
            If item.MainWindowTitle.Length > 0 Then
                Dim hWnd As IntPtr = Process.GetProcessesByName(item.ProcessName.ToString)(0).MainWindowHandle
                If item.ProcessName.ToString = "TicketmationApp" Then
                    If Not foundMe Then
                        foundMe = True
                    Else
                        lMessage.Text = "*********App is running-Reboot**********"
                        lMessage.Left = lblWelcome.Width / 2 + lblWelcome.Left - lMessage.Width / 2
                        ClickImage1.Visible = False
                        ClickImage2.Visible = False
                        Exit Sub
                        'MsgBox("Application is running!")
                        'End
                    End If
                End If
            End If
        Next
        bStartup = True
        'Check Ticket Stock
        Try
            iTicketStock = GetTicketStock()
            If iTicketStock <= 10 Then
                lblWelcome.Text = "This Machine is currently OUT OF TICKET STOCK"
            Else
                lblWelcome.Text = "This Machine is currently OUT OF SERVICE"
            End If
        Catch err As Exception
            lMessage.Text = err.Message
            lMessage.Left = lblWelcome.Width / 2 + lblWelcome.Left - lMessage.Width / 2
            If lMessage.Left < 0 Then lMessage.Left = 0
            ClickImage1.Visible = False
            ClickImage2.Visible = False
        End Try
        'Check Printer
        Try
            AxMSComm1.CommPort = 4
            AxMSComm1.Settings = "9600,N,8,1"
            AxMSComm1.OutBufferSize = 2048
            '' Open the port.
            AxMSComm1.RThreshold = 1
            AxMSComm1.SThreshold = 1
            ''MSComm.InputMode = comInputModeText
            AxMSComm1.InputLen = 0
            AxMSComm1.InBufferCount = 0
            ''MSComm.InputMode = comInputModeText
            ''MSComm.Handshaking = comNone
            AxMSComm1.PortOpen = True
        Catch err As Exception
            'Printer Not Attached
            lMessage.Text = "*************Printer Not Attached*********************"
            lMessage.Left = lblWelcome.Width / 2 + lblWelcome.Left - lMessage.Width / 2
            If lMessage.Left < 0 Then lMessage.Left = 0
            ClickImage1.Visible = False
            ClickImage2.Visible = False
        End Try


        'KEY       
        TodaysKey = Weekday(Now()) Mod 3
        If TodaysKey = 0 Then TodaysKey = 3
        lTodaysKey.Text = Str(TodaysKey)
    End Sub
    Private Sub ImgStop_DblClick(sender As Object, e As EventArgs) Handles ImgStop.DoubleClick
        'frmMainAN.Show()
        End
        Me.Close()
    End Sub
    Private Sub ClickImage1_Click(sender As Object, e As EventArgs) Handles ClickImage1.Click
        ClickClick1 = True
        ClickTimer.Enabled = True
        ClickTimer.Interval = 5000
    End Sub

    Private Sub ClickImage2_Click(sender As Object, e As EventArgs) Handles ClickImage2.Click
        If ClickClick1 Then
            ClickTimer.Enabled = False
            ClickClick1 = False
            fTicketmation.Show()
        End If
    End Sub
    Private Sub ClickTimer_Tick(sender As Object, e As EventArgs) Handles ClickTimer.Tick
        ClickClick1 = False
        ClickTimer.Stop()
    End Sub

 
    Private Sub ImgStop_Click(sender As Object, e As EventArgs) Handles ImgStop.DragDrop
        End
    End Sub
End Class
