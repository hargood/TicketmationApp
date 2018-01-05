<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartup
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartup))
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.ClickImage1 = New System.Windows.Forms.Label()
        Me.ClickImage2 = New System.Windows.Forms.Label()
        Me.ClickTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lTodaysKey = New System.Windows.Forms.Label()
        Me.ImgStop = New System.Windows.Forms.PictureBox()
        Me.lMessage = New System.Windows.Forms.Label()
        Me.AxMSComm1 = New AxMSCommLib.AxMSComm()
        CType(Me.ImgStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxMSComm1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.Font = New System.Drawing.Font("Arial", 60.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.Red
        Me.lblWelcome.Location = New System.Drawing.Point(183, 234)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(1884, 851)
        Me.lblWelcome.TabIndex = 1
        Me.lblWelcome.Text = "This Machine is Currently Out of Service"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ClickImage1
        '
        Me.ClickImage1.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClickImage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClickImage1.Location = New System.Drawing.Point(88, 1329)
        Me.ClickImage1.Name = "ClickImage1"
        Me.ClickImage1.Size = New System.Drawing.Size(564, 227)
        Me.ClickImage1.TabIndex = 2
        Me.ClickImage1.Text = "..."
        Me.ClickImage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClickImage2
        '
        Me.ClickImage2.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClickImage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClickImage2.Location = New System.Drawing.Point(1893, 1221)
        Me.ClickImage2.Name = "ClickImage2"
        Me.ClickImage2.Size = New System.Drawing.Size(569, 394)
        Me.ClickImage2.TabIndex = 3
        Me.ClickImage2.Text = "..."
        Me.ClickImage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClickTimer
        '
        Me.ClickTimer.Enabled = True
        '
        'lTodaysKey
        '
        Me.lTodaysKey.AutoSize = True
        Me.lTodaysKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTodaysKey.Location = New System.Drawing.Point(334, 1258)
        Me.lTodaysKey.Name = "lTodaysKey"
        Me.lTodaysKey.Size = New System.Drawing.Size(52, 55)
        Me.lTodaysKey.TabIndex = 4
        Me.lTodaysKey.Text = "1"
        '
        'ImgStop
        '
        Me.ImgStop.Image = Global.TicketmationApp.My.Resources.Resources.ticketmation_logo_trans
        Me.ImgStop.Location = New System.Drawing.Point(44, 26)
        Me.ImgStop.Name = "ImgStop"
        Me.ImgStop.Size = New System.Drawing.Size(476, 108)
        Me.ImgStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgStop.TabIndex = 0
        Me.ImgStop.TabStop = False
        '
        'lMessage
        '
        Me.lMessage.AutoSize = True
        Me.lMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMessage.ForeColor = System.Drawing.Color.Black
        Me.lMessage.Location = New System.Drawing.Point(861, 926)
        Me.lMessage.Name = "lMessage"
        Me.lMessage.Size = New System.Drawing.Size(485, 39)
        Me.lMessage.TabIndex = 5
        Me.lMessage.Text = "**************Start**************"
        Me.lMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'AxMSComm1
        '
        Me.AxMSComm1.Enabled = True
        Me.AxMSComm1.Location = New System.Drawing.Point(25, 155)
        Me.AxMSComm1.Name = "AxMSComm1"
        Me.AxMSComm1.OcxState = CType(resources.GetObject("AxMSComm1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSComm1.Size = New System.Drawing.Size(86, 86)
        Me.AxMSComm1.TabIndex = 6
        '
        'frmStartup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(3824, 1572)
        Me.ControlBox = False
        Me.Controls.Add(Me.AxMSComm1)
        Me.Controls.Add(Me.lMessage)
        Me.Controls.Add(Me.lTodaysKey)
        Me.Controls.Add(Me.ClickImage2)
        Me.Controls.Add(Me.ClickImage1)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.ImgStop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStartup"
        Me.Text = "Out Of Service"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ImgStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxMSComm1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImgStop As System.Windows.Forms.PictureBox
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents ClickImage1 As System.Windows.Forms.Label
    Friend WithEvents ClickImage2 As System.Windows.Forms.Label
    Friend WithEvents ClickTimer As System.Windows.Forms.Timer
    Friend WithEvents lTodaysKey As System.Windows.Forms.Label
    Friend WithEvents lMessage As System.Windows.Forms.Label
    Friend WithEvents AxMSComm1 As AxMSCommLib.AxMSComm

End Class
