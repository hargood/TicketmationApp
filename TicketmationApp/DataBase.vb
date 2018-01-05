Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.OleDb

Module DataBase
    Public con As New OleDbConnection(ConfigurationManager.ConnectionStrings(strConnectionString).ConnectionString)
    Public cmd As New OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim rs As OleDbDataReader
    Dim dt As New DataTable()
    Dim SQL As String

    Public Function GetTicketStock()
        Dim iTicketStock As Integer
        Try
            SQL = "Select * from TICKET_STOCK"
            con.Open()
            cmd.Connection = con
            ds.Clear()
            da = New OleDbDataAdapter(SQL, con)
            da.Fill(ds, "Stock")
            iTicketStock = ds.Tables("Stock").Rows(0).Item(0)
            con.Close()
            Return iTicketStock
        Catch err As Exception
            errorMessage = err.Message.ToString()
            'Throw
            'Finally
            con.Close()
            iTicketStock = 0
            Throw
        End Try
    End Function
    Public Function GetBatch()
        Dim iBatch As Integer
        SQL = "Select count(*) as noBatches from BATCH where BatchUpload=No"
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter(SQL, con)
        da.Fill(ds, "Batch")
        iBatch = ds.Tables("Batch").Rows(0).Item(0)
        con.Close()
        Return iBatch
    End Function
    Public Function GetINIT()
        Dim iINIT(3) As Integer
        SQL = "Select * from INIT"
        con.Open()
        cmd.Connection = con
        cmd = New OleDbCommand(SQL, con)
        rs = cmd.ExecuteReader()
        rs.Read()
        iINIT(1) = rs("IPAddress")
        iINIT(2) = rs("SessionCounter")
        iINIT(3) = rs("SecurityCutoff")
        con.Close()
        Return iINIT
    End Function
    Public Function GetShowInfo()
        Dim Show(11) As String
        SQL = "Select top 1 * from SHOWS where ShowEndDate >=#" & Now() & "#  order by ShowStartDate"
        con.Open()
        cmd.Connection = con
        da.SelectCommand = New OleDbCommand(SQL, con)
        da.Fill(dt)
        If dt Is Nothing Then
            Show(1) = "No Current Shows in DB"
        Else
            Show(1) = dt.Rows(0).Item(1)
            Show(2) = dt.Rows(0).Item(0).ToString
            Show(3) = dt.Rows(0).Item(7).ToString
            Show(4) = dt.Rows(0).Item(5)
            Show(5) = dt.Rows(0).Item(4)
            Show(6) = dt.Rows(0).Item(8)
            Show(7) = dt.Rows(0).Item(9)
            Show(8) = dt.Rows(0).Item(10)
            Show(9) = dt.Rows(0).Item(11)
            Show(10) = dt.Rows(0).Item(12)
            Show(11) = dt.Rows(0).Item(13).ToString
        End If
        con.Close()
        Return Show
    End Function
    Public Sub UpdateINIT()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "UPDATE INIT set IPAddress='" & IP & "',SessionCounter='" & SessionCounter & "',SecurityCutoff='" & iMaxTix.ToString & "'"
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch sqlEx As SqlException
            errorMessage = sqlEx.Message.ToString()
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
    End Sub
    Public Function GetDefaults()
        Dim iDefault(2) As Integer
        SQL = "Select * from SHOW_DEFAULTS where ShowID=" & ShowID.ToString
        con.Open()
        cmd.Connection = con
        cmd = New OleDbCommand(SQL, con)
        rs = cmd.ExecuteReader()
        rs.Read()
        iDefault(1) = rs("AllowDiscover")
        iDefault(2) = rs("AllowAmex")
        con.Close()
        Return iDefault
    End Function
    Public Sub UpdateDefaults()
        Dim iAmex As String = "0"
        Dim iDC As String = "0"

        If frmMainAN.CheckDiscover.Checked Then iDC = "1"
        If frmMainAN.CheckAmex.Checked Then iAmex = "1"
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "UPDATE SHOW_DEFAULTS set AllowDiscover = " & iDC & ",AllowAmex =" & iAmex & " where ShowID=" & ShowID.ToString
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try

    End Sub
    Public Sub GetTickets()
        Dim i As Integer
        SQL = "Select TICKET_CATEGORIES.TicketCategoryID,TicketCategory,TicketPrice,subButtonText,CategoryName from TICKET_CATEGORIES,SHOW_TICKET_PRICES Where TICKET_CATEGORIES.TicketCategoryID=SHOW_TICKET_PRICES.TicketCategoryID and SHOW_TICKET_PRICES.ShowID=" & ShowID & " and #" & Now() & "# <= ShowDateStop and #" & Now() & "# >= ShowDateStart order by SHOW_TICKET_PRICES.ListSequence"
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter(SQL, con)
        'da.Fill(ds, "Tickets")
        ds.Reset()
        da.Fill(ds)
        'Populate 00s and buttons
        i = -1
        For Each Row As DataRow In ds.Tables(0).Rows
            i = i + 1
            For Each Coll As DataColumn In ds.Tables(0).Columns
                Select Case Coll.ColumnName
                    Case "TicketCategoryID"
                        TicketTypes(1, i) = Row(Coll.ColumnName).ToString()
                    Case "TicketCategory"
                        TicketTypes(2, i) = Row(Coll.ColumnName).ToString()
                    Case "TicketPrice"
                        TicketTypes(3, i) = Row(Coll.ColumnName).ToString()
                    Case "subButtonText"
                        'If Not String.IsNullOrEmpty(Row("subButtonText")) Then
                        If Not IsDBNull(Row("subButtonText")) Then
                            TicketTypes(4, i) = Row(Coll.ColumnName).ToString()
                        Else
                            TicketTypes(4, i) = ""
                        End If
                    Case "CategoryName"
                        TicketTypes(5, i) = Row(Coll.ColumnName).ToString()
                End Select
            Next
        Next
        con.Close()
    End Sub
    Public Sub LogClick(ByVal FromForm As String, ByVal Click As String)
        '        db.Execute "Insert into LOG (LogTime,SessionID,ClickFrom) values(#" & Now() & "#," & SessionID & ",'" & FromForm & ":" & Click & "')"

        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert into LOG (LogTime,SessionID,ClickFrom) values(@LogTime,@SessionID,@FromFormClick)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@LogTime", Now().ToString)
            .Parameters.AddWithValue("@SessionID", SessionID)
            .Parameters.AddWithValue("@FromFormClick", FromForm & ":" & Click)
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try

    End Sub
    Public Sub NewSessionID()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO SESSIONS (SessionStart) values(@SessionStart)"
            .Parameters.AddWithValue("@SessionStart", Now().ToString)
        End With
        Try
            con.Open()
            'cmd = New OleDbCommand("INSERT INTO SESSION (SessionStart) values(#" & Now() & "#)", con)
            cmd.ExecuteNonQuery()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
        'db.Execute "Insert into SESSION (SessionStart) values(#" & Now() & "#)"
        cmd = New OleDbCommand("Select max(SessionID) as MaxID from SESSIONS", con)
        rs = cmd.ExecuteReader()
        rs.Read()
        SessionID = rs(0)
        con.Close()
    End Sub
    Public Sub RecordPurchase(ByVal totalPrice As Integer)
        Dim TicketReceiptID As Integer
        Dim cmd As New OleDbCommand
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount,SessionID) values(@ShowID,@PurchaseDate,@otalPrice,@SessionID)"
            .Parameters.AddWithValue("@ShowID", ShowID.ToString)
            .Parameters.AddWithValue("@PurchaseDate", Now().ToString)
            .Parameters.AddWithValue("@TotalPrice", totalPrice.ToString)
            .Parameters.AddWithValue("@SessionID", SessionID.ToString)
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch sqlEx As SqlException
            '            con.Close()
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
        cmd = New OleDbCommand("Select Max(TicketReceiptID) as TRID from PURCHASE_INFO", con)
        con.Open()
        rs = cmd.ExecuteReader()
        rs.Read()
        'Dim cmd As New OleDbCommand
        TicketReceiptID = rs(0).ToString
        con.Close()
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then
                With cmd
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(@TicketreceiptID,@TicketCategoryID,@NumberTickets)"
                    .Parameters.AddWithValue("@TicketreceiptID", TicketReceiptID)
                    .Parameters.AddWithValue("@TicketCategoryID", TicketTypes(1, i))
                    .Parameters.AddWithValue("@NumberTickets", TotalTicketSold(i).ToString)
                End With
                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch sqlEx As SqlException
                    MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
                    con.Close()
                End Try

                'db.Execute "Insert into TICKET_CATEGORY_RECEIPTS (TicketReceiptID,TicketCategoryID,NumberTickets) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
            End If
        Next i
    End Sub
    Public Sub UpdateTicketStock(ByVal K As Integer)
        Dim CurrentStock As Integer
        Dim CurrentTicStart As Integer

        cmd = New OleDbCommand("Select * from TICKET_STOCK", con)
        con.Open()
        rs = cmd.ExecuteReader()
        rs.Read()
        CurrentStock = rs(0)
        CurrentTicStart = rs(1)
        con.Close()

        'If bProgram Then K = K + 1
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update TICKET_STOCK set TicketStock=" & (CurrentStock - K).ToString & ",StartingTix=" & (CurrentTicStart + K).ToString
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try

        con.Close()
    End Sub
    Public Function GetHeaders()
        Dim Headers(7) As String
        Dim i As Integer
        'If (con.State <> ConnectionState.Open) Then con.Open()
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter("Select * from TICKET_HEADERS where ShowID=" & ShowID, con)
        da.Fill(ds, "Headers")
        For i = 1 To 7
            If IsDBNull(ds.Tables("Headers").Rows(0).Item(i)) Then
                Headers(i) = ""
            Else
                Headers(i) = ds.Tables("Headers").Rows(0).Item(i)
            End If
        Next
        con.Close()
        Return Headers
    End Function
    Public Function GetLast3Sessions()
        Dim Last3Sessions(3) As Integer
        Dim i As Integer
        'Select SessionID from SESSION order by SessionID DESC
        For i = 1 To 3
            Last3Sessions(i) = 0
        Next
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter("Select Top 3 SessionID from SESSIONS order by SessionID DESC", con)
        ds.Clear()

        da.Fill(ds, "Sessions")
        If ds.Tables("Sessions").Rows.Count > 0 Then
            For i = 0 To ds.Tables("Sessions").Rows.Count - 1
                Last3Sessions(i + 1) = ds.Tables("Sessions").Rows(i).Item(0)
            Next
        End If

        con.Close()

        Return Last3Sessions
    End Function
    Public Function GetLog(ByVal sessionID As Integer)
        Dim LogItems(3, 10) As String
        Dim i As Integer
        Dim j As Integer
        'Clear
        For i = 0 To 3
            For j = 0 To 10
                LogItems(i, j) = ""
            Next
        Next
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter("Select SessionID,LogTime,ClickFrom from LOG where SessionID=" & sessionID.ToString & " order by LogTime", con)
        ds.Clear()
        da.Fill(ds, "Log")
        For i = 0 To ds.Tables("Log").Rows.Count - 1
                LogItems(1, i + 1) = ds.Tables("Log").Rows(i).Item(0).ToString
                LogItems(2, i + 1) = ds.Tables("Log").Rows(i).Item(1)
                LogItems(3, i + 1) = ds.Tables("Log").Rows(i).Item(2)
            '    'MsgBox(j.ToString & "," & i.ToString & ":" & LogItems(j, i))
        Next
        da.Dispose()
        con.Close()

        'Next
        '      Next
        Return LogItems
    End Function
    Public Sub UpdateSQLPurchase()
        Dim strConnString As String = "Server=54.241.244.28;Database=ticketmation;Integrated Security=false;UID=sa;PWD=s.blufLUL#^0$\M\1%FZ;connection timeout=30;"

        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        ''Test
        '      Dim ShowID as int = 1
        '      Dim PurchaseDateTime as datetime=now()
        '      Dim NoTickets as int = 3
        '      Dim AmountPaid as int = 30
        '      Dim TransactionCode as varchar(50)="123456"
        '      Dim DeviceID as int = 5
        '      Dim StartTime as datetime=Now()
        '      Dim SessionID as int = 1234


        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "AddPurchaseReturnID"
        cmd.Parameters.Add("@ShowID", SqlDbType.Int).Value = SQLShowID
        cmd.Parameters.Add("@PurchaseDateTime", SqlDbType.DateTime).Value = Now()
        cmd.Parameters.Add("@NoTickets", SqlDbType.Int).Value = TotTicketCount
        cmd.Parameters.Add("@AmountPaid", SqlDbType.Int).Value = TotalPrice
        cmd.Parameters.Add("@TransactionCode", SqlDbType.VarChar).Value = ReferenceID
        cmd.Parameters.Add("@DeviceID", SqlDbType.Int).Value = CInt(IP)
        cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = SwipTime
        cmd.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = BarCode
        cmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Direction = ParameterDirection.Output

        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            PurchaseID = cmd.Parameters("@PurchaseID").Value

        Catch ex As Exception
            Throw ex

        Finally
            cmd.Parameters.Clear()
            'con.Close()
            'con.Dispose()
            'cmd.Clear()
        End Try
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "AddPurchaseDetails"
        cmd.Connection = con
        For i = 0 To UBound(TicketTypes, 2) - 1

            cmd.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
            cmd.Parameters.Add("@TicketTypeID", SqlDbType.Int).Value = CInt(TicketTypes(1, i))
            cmd.Parameters.Add("@NoTickets", SqlDbType.Int).Value = TotalTicketSold(i)

            Try
                'con.Open()
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Catch ex As Exception
                Throw ex
            End Try
        Next
        If GetZip Then
            'add to restricted CC
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO ccTransactions values(@CCNumber,@TransDate,@DeviceID)"
            cmd.Connection = con
            Dim CCx As String
            If Right(CardNumber, 1) = "9" Then
                CCx = Left(CardNumber, Len(CardNumber) - 1) & "0"
            Else
                CCx = Left(CardNumber, Len(CardNumber) - 1) & CStr(Int(Right(CardNumber, 1)) + 1)
            End If
            cmd.Parameters.Add("@CCNumber", SqlDbType.VarChar).Value = CCx
            cmd.Parameters.Add("@TransDate", SqlDbType.Date).Value = Now
            cmd.Parameters.Add("@DeviceID", SqlDbType.Int).Value = IP
            cmd.ExecuteNonQuery()
        End If
        cmd.Parameters.Clear()
        con.Close()
        con.Dispose()
    End Sub
    Public Function GetUsedCC(ByVal CC As String) As Boolean
        Dim strConnString As String = "Server=54.241.244.28;Database=ticketmation;Integrated Security=false;UID=sa;PWD=s.blufLUL#^0$\M\1%FZ;connection timeout=30;"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim myDA As New SqlDataAdapter(cmd)
        Dim CCx As String
        Try

            If Right(CC, 1) = "9" Then
                CCx = Left(CC, Len(CC) - 1) & "0"
            Else
                CCx = Left(CC, Len(CC) - 1) & CStr(Int(Right(CC, 1)) + 1)
            End If
            GetUsedCC = False
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE FROM CCTransactions where transDate < '" & DateAdd("d", -1, Now()) & "'"
            cmd.ExecuteNonQuery()

            myDA = New SqlDataAdapter("Select * from CCTransactions where ccNumber='" & CCx & "'", con)
            myDA.Fill(ds, "CC")
            If ds.Tables("CC").Rows.Count = 0 Then
                'Not Used... proceed
                GetUsedCC = False
            Else
                'Used... decline
                GetUsedCC = True
            End If
            con.Close()
        Catch ex As Exception

            GetUsedCC = False
        End Try
        Return GetUsedCC
    End Function

    Public Sub ResetStock(ByVal Stock As String)

        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "UPDATE TICKET_STOCK set TicketStock = " & Stock
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try

    End Sub
    Public Sub SaveBatch()
        'SAVE BATCH
        '    db.Execute "INSERT INTO BATCH (track1,track2,TotalPrice,BatchDateTime,ZipCode) values('" & Track1 & "','" & AccountNumber & "'," & TotalPrice & ",#" & Now() & "#,'" & ZipCode & "')"
        '    Set rs = db.OpenRecordset("Select Max(BatchID) as TRID from BATCH")

        '    For i = 0 To UBound(TicketTypes, 2)
        '        If TotalTicketSold(i) > 0 Then db.Execute "Insert into BATCH_DETAILS (BatchID,TicketTypeID,NumberTix) values(" & rs(0) & "," & TicketTypes(1, i) & "," & TotalTicketSold(i) & ")"
        '    Next i
        Dim BatchID As Integer
        Dim cmd As New OleDbCommand
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "INSERT INTO BATCH (track1,track2,TotalPrice,BatchDateTime,ZipCode) values(@track1,@track2,@totalPrice,@batchDateTime,@zipCode)"
            .CommandText = "INSERT INTO BATCH (track1,track2,TotalPrice,BatchDateTime) values(@track1,@track2,@totalPrice,@batchDateTime)"
            '.CommandText = "INSERT INTO PURCHASE_INFO (ShowID,PurchaseDate,TotalAmount,SessionID) values(@ShowID,@PurchaseDate,@otalPrice,@SessionID)"
            .Parameters.AddWithValue("@track1", Track1)
            .Parameters.AddWithValue("@track2", AccountNumber)
            .Parameters.AddWithValue("@TotalPrice", TotalPrice.ToString)
            .Parameters.AddWithValue("@batchDateTime", Now.ToString)
            '.Parameters.AddWithValue("@zipCode", ZipCode)
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch sqlEx As SqlException
            '            con.Close()
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
        cmd = New OleDbCommand("Select Max(BatchID) as BID from BATCH", con)
        con.Open()
        rs = cmd.ExecuteReader()
        rs.Read()
        'Dim cmd As New OleDbCommand
        BatchID = rs(0).ToString
        con.Close()
        For i = 0 To UBound(TicketTypes, 2)
            If TotalTicketSold(i) > 0 Then
                With cmd
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = "Insert into BATCH_DETAILS (BatchID,TicketTypeID,NumberTix) values(@BatchID,@TicketCategoryID,@NumberTickets)"
                    .Parameters.AddWithValue("@BatchID", BatchID)
                    .Parameters.AddWithValue("@TicketCategoryID", TicketTypes(1, i))
                    .Parameters.AddWithValue("@NumberTickets", TotalTicketSold(i).ToString)
                End With
                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch sqlEx As SqlException
                    MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
                    con.Close()
                End Try
            End If
        Next i
    End Sub
    Public Function Get10Batches()
        Dim Batches(5, 10) As String
        Dim i As Integer
        Dim j As Integer
        'Clear
        Array.Clear(Batches, 0, Batches.Length)
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter("Select * from BATCH where BatchUpload=0 order by BatchID ASC", con)
        ds.Clear()
        da.Fill(ds, "Batches")
        For i = 0 To ds.Tables("Batches").Rows.Count - 1
            Batches(1, i + 1) = ds.Tables("Batches").Rows(i).Item(0).ToString
            Batches(2, i + 1) = ds.Tables("Batches").Rows(i).Item(1).ToString
            Batches(3, i + 1) = ds.Tables("Batches").Rows(i).Item(2).ToString
            Batches(4, i + 1) = ds.Tables("Batches").Rows(i).Item(3).ToString
            Batches(5, i + 1) = ds.Tables("Batches").Rows(i).Item(4).ToString
            '    'MsgBox(j.ToString & "," & i.ToString & ":" & LogItems(j, i))
        Next
        da.Dispose()
        con.Close()

        'Next
        '      Next
        Return Batches
    End Function
    Public Sub DeleteBatch(ByVal BatchID As String)
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Delete from BATCH where BatchID=" & BatchID
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch sqlEx As SqlException
            errorMessage = sqlEx.Message.ToString()
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
    End Sub
    Public Sub GetBatchDetails(ByVal BatchID As String)
        con.Open()
        cmd.Connection = con
        da = New OleDbDataAdapter("select * from BATCH_DETAILS where BatchID=" & BatchID, con)
        ds.Clear()
        da.Fill(ds, "BatchDetails")
        TotTicketCount = 0
        For i = 0 To ds.Tables("BatchDetails").Rows.Count - 1
            TicketTypes(1, i) = ds.Tables("BatchDetails").Rows(i).Item(1).ToString
            TotalTicketSold(i) = ds.Tables("BatchDetails").Rows(i).Item(2).ToString
            TotTicketCount = TotTicketCount + CInt(TotalTicketSold(i))
        Next
        da.Dispose()
        con.Close()
    End Sub
    Public Sub UpdateBatch(ByVal batchid As String)
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "UPDATE BATCH set BatchUpload = Yes Where BatchID=" & batchid
        End With
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message.ToString(), "Error Message")
        End Try
    End Sub
End Module
