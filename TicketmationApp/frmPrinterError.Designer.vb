<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinterError
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
        Me.ImgStop = New System.Windows.Forms.PictureBox()
        Me.lPrintError = New System.Windows.Forms.Label()
        Me.lSubMessage = New System.Windows.Forms.Label()
        CType(Me.ImgStop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImgStop
        '
        Me.ImgStop.Image = Global.TicketmationApp.My.Resources.Resources.ticketmation_logo_trans
        Me.ImgStop.Location = New System.Drawing.Point(28, 31)
        Me.ImgStop.Name = "ImgStop"
        Me.ImgStop.Size = New System.Drawing.Size(476, 108)
        Me.ImgStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgStop.TabIndex = 1
        Me.ImgStop.TabStop = False
        '
        'lPrintError
        '
        Me.lPrintError.AutoSize = True
        Me.lPrintError.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPrintError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lPrintError.Location = New System.Drawing.Point(74, 320)
        Me.lPrintError.Name = "lPrintError"
        Me.lPrintError.Size = New System.Drawing.Size(1905, 105)
        Me.lPrintError.TabIndex = 2
        Me.lPrintError.Text = "A PRINTER PROBLEM HAS OCCURRED.  "
        '
        'lSubMessage
        '
        Me.lSubMessage.AutoSize = True
        Me.lSubMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lSubMessage.Location = New System.Drawing.Point(495, 461)
        Me.lSubMessage.Name = "lSubMessage"
        Me.lSubMessage.Size = New System.Drawing.Size(776, 61)
        Me.lSubMessage.TabIndex = 3
        Me.lSubMessage.Text = "Please See Attendent For Help"
        '
        'frmPrinterError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2027, 897)
        Me.Controls.Add(Me.lSubMessage)
        Me.Controls.Add(Me.lPrintError)
        Me.Controls.Add(Me.ImgStop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPrinterError"
        Me.Text = "frmPrinterError"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ImgStop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImgStop As System.Windows.Forms.PictureBox
    Friend WithEvents lPrintError As System.Windows.Forms.Label
    Friend WithEvents lSubMessage As System.Windows.Forms.Label
End Class
