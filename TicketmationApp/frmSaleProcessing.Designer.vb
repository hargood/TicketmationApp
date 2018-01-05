<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaleProcessing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaleProcessing))
        Me.lTopMessage = New System.Windows.Forms.Label()
        Me.EventTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lEvents = New System.Windows.Forms.Label()
        Me.timerReselt = New System.Windows.Forms.Timer(Me.components)
        Me.timerResult = New System.Windows.Forms.Timer(Me.components)
        Me.imgInsertCard = New System.Windows.Forms.PictureBox()
        CType(Me.imgInsertCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lTopMessage
        '
        Me.lTopMessage.Font = New System.Drawing.Font("Arial", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTopMessage.Location = New System.Drawing.Point(46, 150)
        Me.lTopMessage.Name = "lTopMessage"
        Me.lTopMessage.Size = New System.Drawing.Size(1825, 109)
        Me.lTopMessage.TabIndex = 0
        Me.lTopMessage.Text = "INSERT CARD"
        Me.lTopMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'EventTimer
        '
        Me.EventTimer.Interval = 1000
        '
        'lEvents
        '
        Me.lEvents.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lEvents.Location = New System.Drawing.Point(1629, 734)
        Me.lEvents.Name = "lEvents"
        Me.lEvents.Size = New System.Drawing.Size(756, 333)
        Me.lEvents.TabIndex = 2
        Me.lEvents.Text = "EVENTS"
        Me.lEvents.Visible = False
        '
        'timerReselt
        '
        Me.timerReselt.Interval = 3000
        '
        'timerResult
        '
        Me.timerResult.Interval = 7000
        '
        'imgInsertCard
        '
        Me.imgInsertCard.Image = CType(resources.GetObject("imgInsertCard.Image"), System.Drawing.Image)
        Me.imgInsertCard.Location = New System.Drawing.Point(219, 262)
        Me.imgInsertCard.Name = "imgInsertCard"
        Me.imgInsertCard.Size = New System.Drawing.Size(1144, 834)
        Me.imgInsertCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgInsertCard.TabIndex = 1
        Me.imgInsertCard.TabStop = False
        Me.imgInsertCard.Visible = False
        '
        'frmSaleProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2397, 1108)
        Me.Controls.Add(Me.lEvents)
        Me.Controls.Add(Me.imgInsertCard)
        Me.Controls.Add(Me.lTopMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSaleProcessing"
        Me.Text = "frmSaleProcessing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgInsertCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lTopMessage As System.Windows.Forms.Label
    Friend WithEvents EventTimer As System.Windows.Forms.Timer
    Friend WithEvents lEvents As System.Windows.Forms.Label
    Friend WithEvents timerReselt As System.Windows.Forms.Timer
    Friend WithEvents timerResult As System.Windows.Forms.Timer
    Friend WithEvents imgInsertCard As System.Windows.Forms.PictureBox
End Class
