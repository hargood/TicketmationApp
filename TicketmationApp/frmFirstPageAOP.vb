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
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class frmFirstPageAOP
    Dim ClickClick1 As Boolean
    Dim ClickClick2 As Boolean
    Dim bTouch As Boolean = False
    Private Sub frmFirstPageAOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim iTicketStock As Integer
        Dim iBatch As Integer = 0
        Dim i As Integer
        Dim j As Integer
        frmMainAN.Close()
        '****
        TimerChip.Enabled = False
        imgShow.Top = 0
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
        TimerChip.Enabled = True
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

    Private Sub TimerChip_Tick(sender As Object, e As EventArgs) Handles TimerChip.Tick
        TimerChip.Enabled = False
    End Sub
    Private Sub PageClicked()
        If bTouch Then
            bTouch = False
        End If
    End Sub

    Private Sub imInsertCard_Click(sender As Object, e As EventArgs) Handles imInsertCard.Click
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
End Class