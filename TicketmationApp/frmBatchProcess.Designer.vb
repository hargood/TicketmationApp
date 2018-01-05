<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchProcess
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
        Me.lMessage = New System.Windows.Forms.Label()
        Me.timerBatchProcess = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lMessage
        '
        Me.lMessage.AutoSize = True
        Me.lMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMessage.Location = New System.Drawing.Point(149, 206)
        Me.lMessage.Name = "lMessage"
        Me.lMessage.Size = New System.Drawing.Size(1213, 91)
        Me.lMessage.TabIndex = 1
        Me.lMessage.Text = "PROCESSING... PLEASE WAIT"
        '
        'timerBatchProcess
        '
        Me.timerBatchProcess.Interval = 3000
        '
        'frmBatchProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1504, 873)
        Me.Controls.Add(Me.lMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBatchProcess"
        Me.Text = "frmBatchProcess"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lMessage As System.Windows.Forms.Label
    Friend WithEvents timerBatchProcess As System.Windows.Forms.Timer
End Class
