
Public Class frmLog

    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Log(3, 10) As String
        Dim row As String()
        Dim i As Integer
        Dim j As Integer
        LogGrid.Columns(0).Width = 50
        LogGrid.Columns(1).Width = 150
        LogGrid.Columns(2).Width = 300
        Me.Height = cmdClose.Top + cmdClose.Height + 20
        Me.Width = LogGrid.Left + LogGrid.Width + 50
        Dim Last3Sessions(3) As Integer
        Last3Sessions = GetLast3Sessions()
        For i = 1 To 3
            If Last3Sessions(i) > 0 Then
                Log = GetLog(Last3Sessions(i))
                For j = 1 To 10
                    If Log(1, j).Length > 0 Then
                        row = New String() {Log(1, j), Log(2, j), Log(3, j)}
                        LogGrid.Rows.Add(row)
                    End If
                Next

            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub
End Class