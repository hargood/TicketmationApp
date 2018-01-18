Imports System.IO
Imports System.Deployment

Public Class frmMainAN

    Public Sub frmMainAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim INIT(3) As Integer
        Dim Show(11) As String
        Dim iDefaults(2) As Integer
        'Dim exePath As String = Application.StartupPath & My.Application.Info.AssemblyName & ".exe"
        'Dim exeDate As DateTime = My.Computer.FileSystem.GetFileInfo(exePath).LastWriteTime
        lVersion.Text = Me.GetType.Assembly.GetName.Version.ToString
        Me.Width = 1000
        Me.Height = 1000
        'Set controls
        bTest = False
        bDebug = False
        bServer = True
        bMultiple = False
        bNoPorts = False
        bDEMO = False
        bAN = True
        'Get INIT
        INIT = GetINIT()
        txtIP.Text = INIT(1).ToString
        txtSessionCounter.Text = INIT(2).ToString
        txtSecurity.Text = INIT(3).ToString
        IP = txtIP.Text
        SessionCounter = txtSessionCounter.Text
        'Get SHOW INFORMTION
        Show = GetShowInfo()
        txtShow.Text = Show(1)
        ShowName = Show(1)
        ShowID = Int(Show(2))
        SQLShowID = Int(Show(3))
        EventType = Show(4)
        EventCity = Show(5)
        ShowImage = Show(6)
        AuthNetLogIDCP = Show(7)
        AuthNetKeyCP = Show(8)
        AuthNetLogIDCNP = Show(9)
        AuthNetKeyCNP = Show(10)
        imgRatio = Decimal.Parse(Show(11))
        'Get DEFAULTS
        iDefaults = GetDefaults()
        If iDefaults(1) = 1 Then CheckDiscover.Checked = True
        If iDefaults(2) = 1 Then CheckAmex.Checked = True
        '            If EventCity = "NEW YORK" Then
        '                rsTix = db.OpenRecordset("Select ShowDateStop from SHOW_TICKET_PRICES where ShowID =" & rs("ShowID") & " and TicketCategoryID=16")
        '                If rsTix(0) >= Now() Then
        '                    cmdCloseNYProgramSale.Caption = "Close Program Sales"
        '                Else
        '                    cmdCloseNYProgramSale.Caption = "Open Program Sales"
        '                End If
        '                cmdCloseNYProgramSale.Visible = True
        '            Else
        '                cmdCloseNYProgramSale.Visible = False
        '            End If
        '        End If
    End Sub

    Private Sub cmdDeviveUP_Click(sender As Object, e As EventArgs) Handles cmdDeviveUP.Click
        If Int(txtIP.Text) = "20" Then
            txtIP.Text = "1"
        Else
            txtIP.Text = Trim(Str(Int(txtIP.Text) + 1))

        End If
    End Sub

    Private Sub cmdSessionCounter_Click(sender As Object, e As EventArgs) Handles cmdSessionCounter.Click
        If Int(txtSessionCounter.Text) = 9 Then
            txtSessionCounter.Text = "1"
        Else
            txtSessionCounter.Text = Trim(Str(Int(txtSessionCounter.Text) + 1))

        End If
    End Sub

    Private Sub cmdBegin_Click(sender As Object, e As EventArgs) Handles cmdBegin.Click
        iMaxTix = Int(txtSecurity.Text)

        IP = txtIP.Text
        SessionCounter = txtSessionCounter.Text

        If CheckAmex.Checked = True Then
            VisaMCOnly = False
        Else
            VisaMCOnly = True
        End If

        If CheckDiscover.Checked = True Then
            AllowDiscover = True
        Else
            AllowDiscover = False
        End If

        UpdateINIT()
        UpdateDefaults()
        ''TEST
        'frmZipCode.Show()

        If bEMV Then
            frmFirstPageAOP.Show()
        Else
            frmFirstPage.Show()
        End If
        Me.Close()


    End Sub

    Private Sub cmdSecurity_Click(sender As Object, e As EventArgs) Handles cmdSecurity.Click
        If Int(txtSecurity.text) = "9" Then
            txtSecurity.text = "1"
        Else
            txtSecurity.text = Trim(Str(Int(txtSecurity.text) + 1))

        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        End
    End Sub


    Private Sub cmdTicketStock_Click(sender As Object, e As EventArgs) Handles cmdTicketStock.Click
        frmTicketStock.Show()
    End Sub

 
    Private Sub cmdLog_Click(sender As Object, e As EventArgs) Handles cmdLog.Click
        frmLog.Show()

    End Sub

    Private Sub cmdBatch_Click(sender As Object, e As EventArgs) Handles cmdBatch.Click
        frmBatch.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lVersion.Click

    End Sub
End Class