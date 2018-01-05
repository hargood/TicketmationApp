Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.OleDb
Imports System.IO

Public Class fTicketmation
    Public BPick(5) As Integer
    Public Picked As Integer
    Public conn As New OleDbConnection(ConfigurationManager.ConnectionStrings(strConnectionString).ConnectionString)
    Public comd As New OleDbCommand
    Dim da As New OleDbDataAdapter()
    Dim dt As New DataTable()
    Dim SQL As String
    Dim rs As OleDbDataReader
    Private Sub fTicketmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BPick(1) = 0
        BPick(2) = 0
        BPick(3) = 0
        Picked = 0
        TimerTimeOut.Interval = 10000
        TimerTimeOut.Enabled = True
        TimerTimeOut.Start()
    End Sub
    Private Sub bLogEnter_Click(sender As Object, e As EventArgs) Handles bLogEnter.Click
        If BPick(1) = TodaysKey And BPick(2) = 1 And BPick(3) = 2 And BPick(4) = 1 And (BPick(5) = 3 Or BPick(5) = 2) And Not bStartup Then
            ' From First Page - Run with no card swipe for test ticket
            bDEMO = True
            If BPick(5) = 3 Then
                bDEMOP = True  'No Barcode
            Else
                bDEMOP = False  'Barcode
            End If
            bTicketmation = True
            '***Set next session
            NewSessionID()
            LogClick("First Page", "Test Ticket")
            'Using cmd As New SqlCommand()
            'With comd
            '    .Connection = conn
            '    .CommandType = CommandType.Text
            '    .CommandText = "INSERT INTO SESSIONS (SessionStart) values(@SessionStart)"
            '    .Parameters.AddWithValue("@SessionStart", Now().ToString)
            'End With
            'Try
            '    conn.Open()
            '    'cmd = New OleDbCommand("INSERT INTO SESSION (SessionStart) values(#" & Now() & "#)", con)
            '    comd.ExecuteNonQuery()
            'Catch sqlEx As SqlException
            '    MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
            'End Try
            ''db.Execute "Insert into SESSION (SessionStart) values(#" & Now() & "#)"
            'comd = New OleDbCommand("Select max(SessionID) as MaxID from SESSIONS", conn)
            'rs = comd.ExecuteReader()
            'rs.Read()
            'SessionID = rs(0)
            'conn.Close()
            BPick(1) = 0
            BPick(2) = 0
            BPick(3) = 0
            BPick(4) = 0
            BPick(5) = 0
            frmSpecifyTickets.Show()
            If bEMV Then
                frmFirstPageAOP.Close()
            Else
                frmFirstPage.Close()
            End If

            Me.Close()
        ElseIf BPick(1) = 1 And BPick(2) = 2 And BPick(3) = 3 And BPick(4) = 2 And BPick(5) = 1 And Not bStartup And Not bPrintError Then
            ' 1-2-3-2-1 From First Page => Admin Page
            bStartup = False
            BPick(1) = 0
            BPick(2) = 0
            BPick(3) = 0
            BPick(4) = 0
            BPick(5) = 0
            'LogClick("First Page", "Exit to Admin")
            If bEMV Then
                frmFirstPageAOP.Close()
            Else
                frmFirstPage.Close()
            End If
            frmMainAN.Show()
            Me.Close()
        ElseIf BPick(1) = 1 And BPick(2) = 2 And BPick(3) = 3 And BPick(4) = 2 And BPick(5) = 1 And bPrintError Then
            ' 1-2-3-2-1 From Printing - OUT
            BPick(1) = 0
            BPick(2) = 0
            BPick(3) = 0
            BPick(4) = 0
            BPick(5) = 0
            ''*frmPrinting.close()
            frmMainAN.Show()
            Me.Close()
        ElseIf BPick(1) = 1 And BPick(2) = 2 And BPick(3) = 3 And BPick(4) = 2 And BPick(5) = 1 And bStartup Then
            '1-2-3-2-1 From STARTUP - to Menu
            BPick(1) = 0
            BPick(2) = 0
            BPick(3) = 0
            BPick(4) = 0
            BPick(5) = 0
            'bDEMO = True
            bStartup = False
            'Moved here for test
            'LogClick("Startup", "to Admin")
            frmMainAN.Show()
            frmStartup.Close()
            Me.Close()
        Else
            'No Code is correct
            BPick(1) = 0
            BPick(2) = 0
            BPick(3) = 0
            BPick(4) = 0
            BPick(5) = 0
            Picked = 0
            Me.Close()
        End If
    End Sub
    Private Sub bLog1_Click(sender As Object, e As EventArgs) Handles bLog1.Click
        If Picked < 5 Then
            Picked = Picked + 1
            BPick(Picked) = 1
        End If
    End Sub
    Private Sub bLog2_Click(sender As Object, e As EventArgs) Handles bLog2.Click
        If Picked < 5 Then
            Picked = Picked + 1
            BPick(Picked) = 2
        End If
    End Sub
    Private Sub bLog3_Click(sender As Object, e As EventArgs) Handles bLog3.Click
        If Picked < 5 Then
            Picked = Picked + 1
            BPick(Picked) = 3
        End If
    End Sub
    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        Me.Close()
    End Sub
End Class