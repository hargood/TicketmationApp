<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicketStock
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
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.KeyPad1 = New System.Windows.Forms.Button()
        Me.KeyPad2 = New System.Windows.Forms.Button()
        Me.KeyPad3 = New System.Windows.Forms.Button()
        Me.KeyPad4 = New System.Windows.Forms.Button()
        Me.KeyPad5 = New System.Windows.Forms.Button()
        Me.KeyPad10 = New System.Windows.Forms.Button()
        Me.KeyPad9 = New System.Windows.Forms.Button()
        Me.KeyPad8 = New System.Windows.Forms.Button()
        Me.KeyPad7 = New System.Windows.Forms.Button()
        Me.KeyPad6 = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblRemaining
        '
        Me.lblRemaining.AutoSize = True
        Me.lblRemaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemaining.Location = New System.Drawing.Point(83, 138)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(560, 78)
        Me.lblRemaining.TabIndex = 0
        Me.lblRemaining.Text = "Remaining Stock"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(12, 700)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(381, 173)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(817, 700)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(433, 173)
        Me.cmdReset.TabIndex = 5
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'txtStock
        '
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(777, 138)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(276, 90)
        Me.txtStock.TabIndex = 6
        Me.txtStock.Text = "999"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KeyPad1
        '
        Me.KeyPad1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad1.Location = New System.Drawing.Point(130, 279)
        Me.KeyPad1.Name = "KeyPad1"
        Me.KeyPad1.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad1.TabIndex = 8
        Me.KeyPad1.Text = "1"
        Me.KeyPad1.UseVisualStyleBackColor = True
        '
        'KeyPad2
        '
        Me.KeyPad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad2.Location = New System.Drawing.Point(296, 279)
        Me.KeyPad2.Name = "KeyPad2"
        Me.KeyPad2.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad2.TabIndex = 9
        Me.KeyPad2.Text = "2"
        Me.KeyPad2.UseVisualStyleBackColor = True
        '
        'KeyPad3
        '
        Me.KeyPad3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad3.Location = New System.Drawing.Point(481, 279)
        Me.KeyPad3.Name = "KeyPad3"
        Me.KeyPad3.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad3.TabIndex = 10
        Me.KeyPad3.Text = "3"
        Me.KeyPad3.UseVisualStyleBackColor = True
        '
        'KeyPad4
        '
        Me.KeyPad4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad4.Location = New System.Drawing.Point(660, 279)
        Me.KeyPad4.Name = "KeyPad4"
        Me.KeyPad4.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad4.TabIndex = 11
        Me.KeyPad4.Text = "4"
        Me.KeyPad4.UseVisualStyleBackColor = True
        '
        'KeyPad5
        '
        Me.KeyPad5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad5.Location = New System.Drawing.Point(833, 279)
        Me.KeyPad5.Name = "KeyPad5"
        Me.KeyPad5.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad5.TabIndex = 12
        Me.KeyPad5.Text = "5"
        Me.KeyPad5.UseVisualStyleBackColor = True
        '
        'KeyPad10
        '
        Me.KeyPad10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad10.Location = New System.Drawing.Point(833, 449)
        Me.KeyPad10.Name = "KeyPad10"
        Me.KeyPad10.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad10.TabIndex = 17
        Me.KeyPad10.Text = "0"
        Me.KeyPad10.UseVisualStyleBackColor = True
        '
        'KeyPad9
        '
        Me.KeyPad9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad9.Location = New System.Drawing.Point(660, 449)
        Me.KeyPad9.Name = "KeyPad9"
        Me.KeyPad9.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad9.TabIndex = 16
        Me.KeyPad9.Text = "9"
        Me.KeyPad9.UseVisualStyleBackColor = True
        '
        'KeyPad8
        '
        Me.KeyPad8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad8.Location = New System.Drawing.Point(481, 449)
        Me.KeyPad8.Name = "KeyPad8"
        Me.KeyPad8.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad8.TabIndex = 15
        Me.KeyPad8.Text = "8"
        Me.KeyPad8.UseVisualStyleBackColor = True
        '
        'KeyPad7
        '
        Me.KeyPad7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad7.Location = New System.Drawing.Point(296, 449)
        Me.KeyPad7.Name = "KeyPad7"
        Me.KeyPad7.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad7.TabIndex = 14
        Me.KeyPad7.Text = "7"
        Me.KeyPad7.UseVisualStyleBackColor = True
        '
        'KeyPad6
        '
        Me.KeyPad6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad6.Location = New System.Drawing.Point(130, 449)
        Me.KeyPad6.Name = "KeyPad6"
        Me.KeyPad6.Size = New System.Drawing.Size(136, 128)
        Me.KeyPad6.TabIndex = 13
        Me.KeyPad6.Text = "6"
        Me.KeyPad6.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(415, 700)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(381, 173)
        Me.cmdClear.TabIndex = 18
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'frmTicketStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 1051)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.KeyPad10)
        Me.Controls.Add(Me.KeyPad9)
        Me.Controls.Add(Me.KeyPad8)
        Me.Controls.Add(Me.KeyPad7)
        Me.Controls.Add(Me.KeyPad6)
        Me.Controls.Add(Me.KeyPad5)
        Me.Controls.Add(Me.KeyPad4)
        Me.Controls.Add(Me.KeyPad3)
        Me.Controls.Add(Me.KeyPad2)
        Me.Controls.Add(Me.KeyPad1)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblRemaining)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTicketStock"
        Me.Text = "Ticketstock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRemaining As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents KeyPad1 As System.Windows.Forms.Button
    Friend WithEvents KeyPad2 As System.Windows.Forms.Button
    Friend WithEvents KeyPad3 As System.Windows.Forms.Button
    Friend WithEvents KeyPad4 As System.Windows.Forms.Button
    Friend WithEvents KeyPad5 As System.Windows.Forms.Button
    Friend WithEvents KeyPad10 As System.Windows.Forms.Button
    Friend WithEvents KeyPad9 As System.Windows.Forms.Button
    Friend WithEvents KeyPad8 As System.Windows.Forms.Button
    Friend WithEvents KeyPad7 As System.Windows.Forms.Button
    Friend WithEvents KeyPad6 As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
End Class
