<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fTicketmation
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
        Me.bLog1 = New System.Windows.Forms.Button()
        Me.bLog2 = New System.Windows.Forms.Button()
        Me.bLog3 = New System.Windows.Forms.Button()
        Me.bLogEnter = New System.Windows.Forms.Button()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'bLog1
        '
        Me.bLog1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bLog1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bLog1.FlatAppearance.BorderSize = 2
        Me.bLog1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.bLog1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bLog1.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLog1.Location = New System.Drawing.Point(52, 38)
        Me.bLog1.Name = "bLog1"
        Me.bLog1.Size = New System.Drawing.Size(267, 267)
        Me.bLog1.TabIndex = 0
        Me.bLog1.Text = "1"
        Me.bLog1.UseVisualStyleBackColor = False
        '
        'bLog2
        '
        Me.bLog2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bLog2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bLog2.FlatAppearance.BorderSize = 2
        Me.bLog2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.bLog2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bLog2.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLog2.Location = New System.Drawing.Point(380, 38)
        Me.bLog2.Name = "bLog2"
        Me.bLog2.Size = New System.Drawing.Size(267, 267)
        Me.bLog2.TabIndex = 1
        Me.bLog2.Text = "2"
        Me.bLog2.UseVisualStyleBackColor = False
        '
        'bLog3
        '
        Me.bLog3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bLog3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bLog3.FlatAppearance.BorderSize = 2
        Me.bLog3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.bLog3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bLog3.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLog3.Location = New System.Drawing.Point(701, 38)
        Me.bLog3.Name = "bLog3"
        Me.bLog3.Size = New System.Drawing.Size(267, 267)
        Me.bLog3.TabIndex = 2
        Me.bLog3.Text = "3"
        Me.bLog3.UseVisualStyleBackColor = False
        '
        'bLogEnter
        '
        Me.bLogEnter.BackColor = System.Drawing.Color.White
        Me.bLogEnter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bLogEnter.FlatAppearance.BorderSize = 2
        Me.bLogEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.bLogEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bLogEnter.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLogEnter.Location = New System.Drawing.Point(178, 360)
        Me.bLogEnter.Name = "bLogEnter"
        Me.bLogEnter.Size = New System.Drawing.Size(696, 161)
        Me.bLogEnter.TabIndex = 3
        Me.bLogEnter.Text = "ENTER"
        Me.bLogEnter.UseVisualStyleBackColor = False
        '
        'TimerTimeOut
        '
        '
        'fTicketmation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1220, 611)
        Me.ControlBox = False
        Me.Controls.Add(Me.bLogEnter)
        Me.Controls.Add(Me.bLog3)
        Me.Controls.Add(Me.bLog2)
        Me.Controls.Add(Me.bLog1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fTicketmation"
        Me.Text = "Admin Keypad"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bLog1 As System.Windows.Forms.Button
    Friend WithEvents bLog2 As System.Windows.Forms.Button
    Friend WithEvents bLog3 As System.Windows.Forms.Button
    Friend WithEvents bLogEnter As System.Windows.Forms.Button
    Friend WithEvents TimerTimeOut As System.Windows.Forms.Timer
End Class
