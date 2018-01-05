Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module CreditCardProcessing
    Public Sub Sale()
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        'Dim reader As StreamReader
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing
        Dim rList As New ArrayList
        'frmSaleProcessing.iState = 1
        ' Specify the sale end point  
        Dim address = New Uri("https://localhost:60353/api/sale")

        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)

        ' Set type to POST !Important  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"


        ' Build the request
        data = New StringBuilder()
        data.Append("Refnum=" + SessionID.ToString)  ' // Reference Number (Optional)
        data.Append("&Amount=" + (100 * TotalPrice).ToString)       ' // Amount, NO DECIMALS
        data.Append("&TipType=" + "None")     ' // Leave at None

        ' Create a byte array of the data we want to send  
        byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

        ' Set the content length in the request headers  
        request.ContentLength = byteData.Length

        ' Write data  
        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        'Try
        '    ' Get response  
        '    response = DirectCast(request.GetResponse(), HttpWebResponse)

        '    ' Get the response stream into a reader  
        '    reader = New StreamReader(response.GetResponseStream())

        '    ' Store the response, will use later
        '    Dim resp = reader.ReadToEnd()

        '    Try
        '        Dim rawResponse As String = New JavaScriptSerializer().Deserialize(Of Object)(resp)
        '        Dim json As JObject = JObject.Parse(rawResponse)
        '        Dim err As Boolean = json.SelectToken("Error")

        '        If err = True Then
        '            rList.Add(False)
        '            rList.Add(json.SelectToken("Message"))
        '            rList.Add("")
        '        ElseIf err = False Then
        '            rList.Add(True)
        '            rList.Add(json.SelectToken("Message"))
        '            rList.Add(json.SelectToken("Reference"))
        '        End If

        '        Return rList
        '    Catch ex As Exception
        '        'Console.WriteLine(ex)
        '    End Try

        'Finally
        '    If Not response Is Nothing Then response.Close()
        'End Try

    End Sub

    Public Sub Events()
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing
        Dim rList As New ArrayList
        Dim GotAll As Integer = 0
        'Turn off Timer
        frmSaleProcessing.EventTimer.Stop()
        ' Specify the sale end point  
        Dim address = New Uri("https://localhost:60353/api/getevents")

        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)

        ' Set type to POST !Important  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"


        ' Build the request
        data = New StringBuilder()

        ' Create a byte array of the data we want to send  
        byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

        ' Set the content length in the request headers  
        request.ContentLength = byteData.Length

        ' Write data  
        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            ' Get response  
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Get the response stream into a reader  
            reader = New StreamReader(response.GetResponseStream())

            ' Store the response, will use later
            Dim resp = reader.ReadToEnd()
            ''*********************

            '*******************

            Try
                Dim rawResponse As String = New JavaScriptSerializer().Deserialize(Of Object)(resp)
                Dim json As JObject = JObject.Parse(rawResponse)
                Dim err As Boolean = json.SelectToken("Error")
                ''Process Events
                '' Console.Write(resp)

                '' No Events exist 
                If err = True Then
                    '    rList.Add(False)
                    '    rList.Add(json.SelectToken("Message"))
                    '    rList.Add("")
                    '    ' No Errors, events returned
                ElseIf err = False Then
                    Dim jsonEvents As Object = Nothing
                    Dim jsonEventParameters As Object = Nothing
                    'Change to card data
                    Dim EventType As String = ""
                    Dim EventName As String = ""
                    Dim Notification As String = ""
                    Dim Message As String = ""
                    json.TryGetValue("Events", jsonEvents)
                    'For Each transType As Dictionary(Of String, Object) In jsonEvents
                    For Each transType As Object In jsonEvents
                        'TransType
                        'frmSaleProcessing.lTopMessage.Text = transType.ToString

                        transType.TryGetValue("Type", EventType)
                        transType.TryGetValue("TypeName", EventName)
                        transType.TryGetValue("EventParameters", jsonEventParameters)
                        'test print
                        'frmSaleProcessing.lEvents.Text = jsonEventParameters.ToString

                        '        'jsonEventParameters.tryGetvalue("NOTIFICATION", Notification)
                        '        'jsonEventParameters.tryGetvalue("UPDATE", Message)
                        '        'Form1.lMessages.Text =
                        '        'Form1.lMessages.Text = EventName & "Notification:" & Notification & "Update:" & Message
                        '        Message = ""
                        '        'MsgBox(jsonEventParameters.Count.ToString)
                        For Each ParameterType As Object In jsonEventParameters
                            '            Select Case frmSaleProcessing.iState
                            '                Case 1 'check card inserted
                            If ParameterType.Item("Key").ToString = "UPDATE" And ParameterType.Item("Value").ToString = "CardRequested" Then
                                frmSaleProcessing.lTopMessage.Text = "INSERT CARD"
                                frmSaleProcessing.imgInsertCard.Visible = True
                                'frmSaleProcessing.bDone = True
                                'Return
                            End If
                            '                Case 2
                            If ParameterType.Item("Key").ToString = "NOTIFICATION" And ParameterType.Item("Value").ToString = "Inserted" Then
                                frmSaleProcessing.lTopMessage.Text = "DO NOT REMOVE CARD"
                                frmSaleProcessing.imgInsertCard.Visible = False
                                'frmSaleProcessing.bDone = True
                                'Return
                                'frmSaleProcessing.iState = 2
                            End If
                            '                Case 3
                            If ParameterType.Item("Key").ToString = "PAN_MASKED" Then
                                CardNumber = ParameterType.Item("Value").ToString
                                frmSaleProcessing.imgInsertCard.Visible = False
                                'frmSaleProcessing.iState = 3
                                'GotAll = GotAll + 1
                            End If
                            If ParameterType.Item("Key").ToString = "REFERENCE" Then
                                ReferenceID = ParameterType.Item("Value").ToString
                                frmSaleProcessing.imgInsertCard.Visible = False
                                'frmSaleProcessing.iState = 3
                                'GotAll = GotAll + 1
                            End If
                            '                    'If ParameterType.Item("Key").ToString = "CARD_SCHEME_ID" Then
                            '                    '    Form1.lMessages.Text = ParameterType.Item("Value").ToString
                            '                    '    Form1.iState = 3
                            '                    'End If
                            '                    'Case 3
                            If ParameterType.Item("Key").ToString = "TRANSACTION_RESULT" And ParameterType.Item("Value").ToString = "APPROVED" Then
                                frmSaleProcessing.lTopMessage.Text = ParameterType.Item("Value").ToString
                                CardApproved = True
                                'GotAll = GotAll + 1
                                'frmSaleProcessing.iState = 4
                            End If
                            If ParameterType.Item("Key").ToString = "TRANSACTION_RESULT" And ParameterType.Item("Value").ToString = "DECLINED" Then
                                frmSaleProcessing.lTopMessage.Text = ParameterType.Item("Value").ToString
                                'GotAll = GotAll + 1
                                CardApproved = False
                                'frmSaleProcessing.iState = 4
                            End If
                            '                    If GotAll = 2 Then frmSaleProcessing.bDone = True
                            '                    Return
                            '                Case 4
                            If ParameterType.Item("Key").ToString = "UPDATE" And ParameterType.Item("Value").ToString = "CardRemovalRequested" Then
                                frmSaleProcessing.lTopMessage.Text = "REMOVE CARD"
                                frmSaleProcessing.imgInsertCard.Image = Image.FromFile(Application.StartupPath & "\RemoveVISA.gif")
                                frmSaleProcessing.imgInsertCard.Visible = True
                                'frmSaleProcessing.iState = 5
                                'frmSaleProcessing.bDone = True
                                'Return
                            End If
                            '                Case 5
                            If ParameterType.Item("Key").ToString = "NOTIFICATION" And ParameterType.Item("Value").ToString = "Removed" Then
                                'frmSaleProcessing.lTopMessage.Text = "PRINT"
                                'frmSaleProcessing.iState = 0
                                frmAuthorize.Show()
                                frmSaleProcessing.Close()
                                'frmSaleProcessing.bDone = True
                                'Return
                            End If
                            '                Case 6

                            '                    Select Case ParameterType.Item("Key").ToString

                            '                        Case "UPDATE"
                            '                            Message = Message & " " & ParameterType.Item("Value").ToString
                            '                        Case "NOTIFICATION"
                            '                            Message = Message & " " & ParameterType.Item("Value").ToString
                            '                        Case "CARD_SCHEME_ID"
                            '                            'MsgBox(ParameterType.Item("Value").ToString)
                            '                            Message = Message & " " & "Card Type:" & ParameterType.Item("Value").ToString
                            '                        Case "TRANSACTION_RESULT"
                            '                            'MsgBox(ParameterType.Item("Value").ToString)
                            '                            'Message = Message & " " & "Transaction Result:" & ParameterType.Item("Value").ToString
                            '                            frmSaleProcessing.lTopMessage.Text = ParameterType.Item("Value").ToString
                            '                        Case "ACQUIRER_RESPONSE_CODE"
                            '                            'Form1.lResponse.Text = ParameterType.Item("Value").ToString
                            '                            'Form1.Timer1.Stop()
                            '                        Case "PAN_MASKED"
                            '                            frmSaleProcessing.lTopMessage.Text = ParameterType.Item("Value").ToString

                            '                    End Select
                            '            End Select
                            '            ' Message = ParameterType.Item("UPDATE").Value(0)
                            '            'ParameterType.TryGetValue("UPDATE", Message)
                            '            'Form1.lMessages.Text =
                            '            'MsgBox(EventName & "Notification:" & Notification & "Update:" & Message)
                        Next
                        '        'Form1.lMessages.Text = EventName & "Notification:" & Notification & "Update:" & Message
                        '        ' Form1.lMessages.Text = Message

                    Next


                    'Dim jsonString As String = "{ ""Error"" : false, ""Events"" : [{""Type"": 10, ""TypeName"": ""GetStatus"", ""EventParameters"":[ { ""Key"": ""PaymentDeviceStatus"", ""Value"": ""PINPAD_BUSY""} , {""Key"":""PaymentPlatformStatus"",""Value"": ""PLATFORM_NOT_AVAILABLE""}]}]}"

                    'Dim token As JToken
                    'For Each value As Object In json
                    '    token = JObject.Parse(value.ToString())


                    '    'Console.WriteLine("{0} {1}", rel, href)
                    'Next value
                    ' Returned Parameters
                    'Error (True/False)
                    'Events (Array/Object)
                    'Events.Type = The type of event
                    'Events.TypeName = The calling method
                    'Events.EventParameters.Key (Misc extended detail returned from chipDNA)
                    'Events.EventParameters.Value (Misc extended detail returned from chipDNA)
                    '
                    '
                    ' REAL EXAMPLE OF DATA RETURNED BELOW
                    ' "{ "Error" : false, "Events" : [{"Type": 10, "TypeName": "GetStatus", "EventParameters":[ { "Key": "PaymentDeviceStatus", "Value": "PINPAD_BUSY"} , {"Key":"PaymentPlatformStatus","Value": "PLATFORM_NOT_AVAILABLE"}]}]}"
                    ' The Events will return the various events states, Card Inserted, Card cancelled etc Below is an example implmented in Java
                    ' You can use a Select case statement instead of switch, you can either handle it in this routine or create specific functions that handle it
                    '
                    'EXAMPLE
                    'For (y = 0; y < chipEvents.Events.length; y++) {
                    '
                    '   var sender = chipEvents.Events[y].TypeName;
                    '   var EventArgs = chipEvents.Events[y].EventParameters;
                    '
                    '	Switch(sender) {
                    '               Case pEngine.TRANSACTION_FINISHED
                    '               pEngine.onTransactionFinished(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.TRANSACTION_UPDATE
                    '               pEngine.onTransactionUpdate(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.TRANSACTION_PAUSED
                    '               pEngine.onTransactionPaused(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.UPDATE_TRANSACTION_PARAMETERS_FINISHED
                    '               pEngine.onUpdateTransactionParametersFinished(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.CAPTURE_RECEIPT
                    '               pEngine.onCaptureReceipt(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.CARD_NOTIFICATION
                    '               pEngine.onCardNotification(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.CARD_DETAILS
                    '               pEngine.onCardDetails(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.CREDENTIALS_FAIL
                    '               pEngine.onCredentialsFail(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.PAYMENT_DEVICE_AVAILABILITY_CHANGE
                    '               pEngine.onPaymentDeviceAvailabilityChange(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.TMS_UPDATE
                    '               pEngine.onTmsUpdate(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.ERROR
                    '               pEngine.onError(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.CHIP_DNA_ERROR
                    '               pEngine.onChipDnaError(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SET_IDLE_MESSAGE
                    '               pEngine.onSetIdleMessage(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SALE_STARTED
                    '               pEngine.onSaleStarted(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SALE_INITIATED
                    '               pEngine.onSaleInitiated(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SALE_CONFIRMED
                    '               pEngine.onSaleConfirmed(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SALE_REFUNDED
                    '               pEngine.onSaleRefunded(sender, EventArgs);
                    '               break;
                    '
                    '               Case pEngine.SALE_VOIDED
                    '               pEngine.onSaleVoided(sender, EventArgs);
                    '               break;
                    '
                    'Default
                    'pEngine.onUnrecognizedSender(sender, EventArgs);
                    '               break;
                    '				}
                    '	}

                    'rList.Add(True)
                    'rList.Add(json.SelectToken("Message"))
                    'rList.Add(json.SelectToken("Reference"))
                    frmSaleProcessing.EventTimer.Start()

                End If


            Catch ex As Exception
                'Console.WriteLine(ex)
            End Try

        Finally
            If Not response Is Nothing Then response.Close()
        End Try

    End Sub
End Module
