<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthorize
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuthorize))
        Me.lblDoNotRemove = New System.Windows.Forms.Label()
        Me.lblProcessing = New System.Windows.Forms.Label()
        Me.timerProcessing = New System.Windows.Forms.Timer(Me.components)
        Me.timerAuthorize = New System.Windows.Forms.Timer(Me.components)
        Me.timerRemove = New System.Windows.Forms.Timer(Me.components)
        Me.timerACK = New System.Windows.Forms.Timer(Me.components)
        Me.timerTakeTix = New System.Windows.Forms.Timer(Me.components)
        Me.timerDecline = New System.Windows.Forms.Timer(Me.components)
        Me.AxMSComm1 = New AxMSCommLib.AxMSComm()
        Me.lSubText = New System.Windows.Forms.Label()
        Me.SerialPrintPort = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.AxMSComm1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDoNotRemove
        '
        Me.lblDoNotRemove.AutoSize = True
        Me.lblDoNotRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.1!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoNotRemove.ForeColor = System.Drawing.Color.Maroon
        Me.lblDoNotRemove.Location = New System.Drawing.Point(291, 122)
        Me.lblDoNotRemove.Name = "lblDoNotRemove"
        Me.lblDoNotRemove.Size = New System.Drawing.Size(700, 78)
        Me.lblDoNotRemove.TabIndex = 0
        Me.lblDoNotRemove.Text = "Do Not Remove Card"
        Me.lblDoNotRemove.Visible = False
        '
        'lblProcessing
        '
        Me.lblProcessing.AutoSize = True
        Me.lblProcessing.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessing.Location = New System.Drawing.Point(316, 357)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Size = New System.Drawing.Size(1116, 83)
        Me.lblProcessing.TabIndex = 1
        Me.lblProcessing.Text = "PROCESSING... PLEASE WAIT"
        '
        'timerProcessing
        '
        Me.timerProcessing.Interval = 500
        '
        'timerAuthorize
        '
        Me.timerAuthorize.Interval = 2000
        '
        'timerRemove
        '
        Me.timerRemove.Interval = 3000
        '
        'timerACK
        '
        '
        'timerTakeTix
        '
        Me.timerTakeTix.Interval = 2000
        '
        'timerDecline
        '
        Me.timerDecline.Interval = 7000
        '
        'AxMSComm1
        '
        Me.AxMSComm1.Enabled = True
        Me.AxMSComm1.Location = New System.Drawing.Point(12, 12)
        Me.AxMSComm1.Name = "AxMSComm1"
        Me.AxMSComm1.OcxState = CType(resources.GetObject("AxMSComm1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSComm1.Size = New System.Drawing.Size(86, 86)
        Me.AxMSComm1.TabIndex = 2
        '
        'lSubText
        '
        Me.lSubText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lSubText.Location = New System.Drawing.Point(241, 481)
        Me.lSubText.Name = "lSubText"
        Me.lSubText.Size = New System.Drawing.Size(1293, 178)
        Me.lSubText.TabIndex = 3
        '
        'SerialPrintPort
        '
        Me.SerialPrintPort.PortName = "COM4"
        '
        'frmAuthorize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2202, 1263)
        Me.ControlBox = False
        Me.Controls.Add(Me.lSubText)
        Me.Controls.Add(Me.AxMSComm1)
        Me.Controls.Add(Me.lblProcessing)
        Me.Controls.Add(Me.lblDoNotRemove)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAuthorize"
        Me.Text = "frmAuthorize"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AxMSComm1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDoNotRemove As System.Windows.Forms.Label
    Friend WithEvents lblProcessing As System.Windows.Forms.Label
    Friend WithEvents timerProcessing As System.Windows.Forms.Timer
    Friend WithEvents timerAuthorize As System.Windows.Forms.Timer
    Friend WithEvents timerRemove As System.Windows.Forms.Timer
    Friend WithEvents timerACK As System.Windows.Forms.Timer
    Friend WithEvents timerTakeTix As System.Windows.Forms.Timer
    Friend WithEvents timerDecline As System.Windows.Forms.Timer
    Friend WithEvents AxMSComm1 As AxMSCommLib.AxMSComm
    Friend WithEvents lSubText As System.Windows.Forms.Label
    Friend WithEvents SerialPrintPort As System.IO.Ports.SerialPort
End Class
