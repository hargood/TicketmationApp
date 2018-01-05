<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdTicketStock = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdSecurity = New System.Windows.Forms.Button()
        Me.txtSecurity = New System.Windows.Forms.TextBox()
        Me.lblSecurity = New System.Windows.Forms.Label()
        Me.cmdBegin = New System.Windows.Forms.Button()
        Me.CheckAmex = New System.Windows.Forms.CheckBox()
        Me.CheckDiscover = New System.Windows.Forms.CheckBox()
        Me.cmdSessionCounter = New System.Windows.Forms.Button()
        Me.txtSessionCounter = New System.Windows.Forms.TextBox()
        Me.cmdDeviveUP = New System.Windows.Forms.Button()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.lblSessCntr = New System.Windows.Forms.Label()
        Me.lblDevID = New System.Windows.Forms.Label()
        Me.lblSelectEvent = New System.Windows.Forms.Label()
        Me.ComboEvents = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdTicketStock
        '
        Me.cmdTicketStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTicketStock.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cmdTicketStock.FlatAppearance.BorderSize = 20
        Me.cmdTicketStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdTicketStock.Location = New System.Drawing.Point(563, 354)
        Me.cmdTicketStock.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdTicketStock.Name = "cmdTicketStock"
        Me.cmdTicketStock.Size = New System.Drawing.Size(536, 107)
        Me.cmdTicketStock.TabIndex = 31
        Me.cmdTicketStock.Text = "Set Ticket Stock"
        Me.cmdTicketStock.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdExit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cmdExit.FlatAppearance.BorderSize = 2
        Me.cmdExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(174, 848)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(500, 202)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "EXIT"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdSecurity
        '
        Me.cmdSecurity.BackColor = System.Drawing.Color.Silver
        Me.cmdSecurity.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdSecurity.FlatAppearance.BorderSize = 4
        Me.cmdSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSecurity.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSecurity.Location = New System.Drawing.Point(2157, 426)
        Me.cmdSecurity.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSecurity.Name = "cmdSecurity"
        Me.cmdSecurity.Size = New System.Drawing.Size(117, 90)
        Me.cmdSecurity.TabIndex = 29
        Me.cmdSecurity.Text = "+"
        Me.cmdSecurity.UseVisualStyleBackColor = False
        '
        'txtSecurity
        '
        Me.txtSecurity.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecurity.Location = New System.Drawing.Point(2027, 426)
        Me.txtSecurity.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSecurity.Name = "txtSecurity"
        Me.txtSecurity.Size = New System.Drawing.Size(100, 62)
        Me.txtSecurity.TabIndex = 28
        Me.txtSecurity.Text = "6"
        Me.txtSecurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSecurity
        '
        Me.lblSecurity.AutoSize = True
        Me.lblSecurity.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecurity.Location = New System.Drawing.Point(1380, 426)
        Me.lblSecurity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSecurity.Name = "lblSecurity"
        Me.lblSecurity.Size = New System.Drawing.Size(368, 56)
        Me.lblSecurity.TabIndex = 27
        Me.lblSecurity.Text = "Security Cutoff"
        '
        'cmdBegin
        '
        Me.cmdBegin.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdBegin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdBegin.FlatAppearance.BorderSize = 2
        Me.cmdBegin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.cmdBegin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBegin.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBegin.Location = New System.Drawing.Point(174, 625)
        Me.cmdBegin.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdBegin.Name = "cmdBegin"
        Me.cmdBegin.Size = New System.Drawing.Size(500, 202)
        Me.cmdBegin.TabIndex = 26
        Me.cmdBegin.Text = "START"
        Me.cmdBegin.UseVisualStyleBackColor = False
        '
        'CheckAmex
        '
        Me.CheckAmex.AutoSize = True
        Me.CheckAmex.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAmex.Location = New System.Drawing.Point(563, 246)
        Me.CheckAmex.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckAmex.Name = "CheckAmex"
        Me.CheckAmex.Size = New System.Drawing.Size(200, 60)
        Me.CheckAmex.TabIndex = 25
        Me.CheckAmex.Text = "AMEX"
        Me.CheckAmex.UseVisualStyleBackColor = True
        '
        'CheckDiscover
        '
        Me.CheckDiscover.AutoSize = True
        Me.CheckDiscover.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckDiscover.Location = New System.Drawing.Point(563, 148)
        Me.CheckDiscover.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckDiscover.Name = "CheckDiscover"
        Me.CheckDiscover.Size = New System.Drawing.Size(389, 60)
        Me.CheckDiscover.TabIndex = 24
        Me.CheckDiscover.Text = "Discover Card"
        Me.CheckDiscover.UseVisualStyleBackColor = True
        '
        'cmdSessionCounter
        '
        Me.cmdSessionCounter.BackColor = System.Drawing.Color.Silver
        Me.cmdSessionCounter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdSessionCounter.FlatAppearance.BorderSize = 4
        Me.cmdSessionCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSessionCounter.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSessionCounter.Location = New System.Drawing.Point(2157, 286)
        Me.cmdSessionCounter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSessionCounter.Name = "cmdSessionCounter"
        Me.cmdSessionCounter.Size = New System.Drawing.Size(117, 90)
        Me.cmdSessionCounter.TabIndex = 23
        Me.cmdSessionCounter.Text = "+"
        Me.cmdSessionCounter.UseVisualStyleBackColor = False
        '
        'txtSessionCounter
        '
        Me.txtSessionCounter.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSessionCounter.Location = New System.Drawing.Point(2027, 286)
        Me.txtSessionCounter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSessionCounter.Name = "txtSessionCounter"
        Me.txtSessionCounter.Size = New System.Drawing.Size(100, 62)
        Me.txtSessionCounter.TabIndex = 22
        Me.txtSessionCounter.Text = "1"
        Me.txtSessionCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdDeviveUP
        '
        Me.cmdDeviveUP.BackColor = System.Drawing.Color.Silver
        Me.cmdDeviveUP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdDeviveUP.FlatAppearance.BorderSize = 4
        Me.cmdDeviveUP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdDeviveUP.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeviveUP.Location = New System.Drawing.Point(2157, 167)
        Me.cmdDeviveUP.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDeviveUP.Name = "cmdDeviveUP"
        Me.cmdDeviveUP.Size = New System.Drawing.Size(117, 90)
        Me.cmdDeviveUP.TabIndex = 21
        Me.cmdDeviveUP.Text = "+"
        Me.cmdDeviveUP.UseVisualStyleBackColor = False
        '
        'txtIP
        '
        Me.txtIP.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIP.Location = New System.Drawing.Point(2027, 167)
        Me.txtIP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(100, 62)
        Me.txtIP.TabIndex = 20
        Me.txtIP.Text = "1"
        Me.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSessCntr
        '
        Me.lblSessCntr.AutoSize = True
        Me.lblSessCntr.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSessCntr.Location = New System.Drawing.Point(1380, 286)
        Me.lblSessCntr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSessCntr.Name = "lblSessCntr"
        Me.lblSessCntr.Size = New System.Drawing.Size(405, 56)
        Me.lblSessCntr.TabIndex = 19
        Me.lblSessCntr.Text = "Session Counter"
        '
        'lblDevID
        '
        Me.lblDevID.AutoSize = True
        Me.lblDevID.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevID.Location = New System.Drawing.Point(1626, 179)
        Me.lblDevID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDevID.Name = "lblDevID"
        Me.lblDevID.Size = New System.Drawing.Size(241, 56)
        Me.lblDevID.TabIndex = 18
        Me.lblDevID.Text = "Device ID"
        '
        'lblSelectEvent
        '
        Me.lblSelectEvent.AutoSize = True
        Me.lblSelectEvent.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectEvent.Location = New System.Drawing.Point(180, 65)
        Me.lblSelectEvent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelectEvent.Name = "lblSelectEvent"
        Me.lblSelectEvent.Size = New System.Drawing.Size(340, 56)
        Me.lblSelectEvent.TabIndex = 17
        Me.lblSelectEvent.Text = "Select EVENT"
        '
        'ComboEvents
        '
        Me.ComboEvents.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboEvents.FormattingEnabled = True
        Me.ComboEvents.Location = New System.Drawing.Point(563, 58)
        Me.ComboEvents.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboEvents.Name = "ComboEvents"
        Me.ComboEvents.Size = New System.Drawing.Size(1710, 63)
        Me.ComboEvents.TabIndex = 16
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2335, 1087)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdTicketStock)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSecurity)
        Me.Controls.Add(Me.txtSecurity)
        Me.Controls.Add(Me.lblSecurity)
        Me.Controls.Add(Me.cmdBegin)
        Me.Controls.Add(Me.CheckAmex)
        Me.Controls.Add(Me.CheckDiscover)
        Me.Controls.Add(Me.cmdSessionCounter)
        Me.Controls.Add(Me.txtSessionCounter)
        Me.Controls.Add(Me.cmdDeviveUP)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.lblSessCntr)
        Me.Controls.Add(Me.lblDevID)
        Me.Controls.Add(Me.lblSelectEvent)
        Me.Controls.Add(Me.ComboEvents)
        Me.Name = "Test"
        Me.Text = "TEST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdTicketStock As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSecurity As System.Windows.Forms.Button
    Friend WithEvents txtSecurity As System.Windows.Forms.TextBox
    Friend WithEvents lblSecurity As System.Windows.Forms.Label
    Friend WithEvents cmdBegin As System.Windows.Forms.Button
    Friend WithEvents CheckAmex As System.Windows.Forms.CheckBox
    Friend WithEvents CheckDiscover As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSessionCounter As System.Windows.Forms.Button
    Friend WithEvents txtSessionCounter As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeviveUP As System.Windows.Forms.Button
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents lblSessCntr As System.Windows.Forms.Label
    Friend WithEvents lblDevID As System.Windows.Forms.Label
    Friend WithEvents lblSelectEvent As System.Windows.Forms.Label
    Friend WithEvents ComboEvents As System.Windows.Forms.ComboBox
End Class
