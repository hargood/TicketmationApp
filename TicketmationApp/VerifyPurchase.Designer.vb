<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerifyPurchase
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
        Me.lblPurchaseSummary = New System.Windows.Forms.Label()
        Me.lblTix1 = New System.Windows.Forms.Label()
        Me.lblTix2 = New System.Windows.Forms.Label()
        Me.lblTix3 = New System.Windows.Forms.Label()
        Me.lblSum = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.cmdBuy = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPurchaseSummary
        '
        Me.lblPurchaseSummary.BackColor = System.Drawing.Color.White
        Me.lblPurchaseSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPurchaseSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblPurchaseSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchaseSummary.Location = New System.Drawing.Point(356, 263)
        Me.lblPurchaseSummary.Name = "lblPurchaseSummary"
        Me.lblPurchaseSummary.Size = New System.Drawing.Size(1347, 125)
        Me.lblPurchaseSummary.TabIndex = 0
        Me.lblPurchaseSummary.Text = "PURCHASE SUMMARY"
        Me.lblPurchaseSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTix1
        '
        Me.lblTix1.BackColor = System.Drawing.Color.White
        Me.lblTix1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTix1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTix1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTix1.Location = New System.Drawing.Point(356, 388)
        Me.lblTix1.Name = "lblTix1"
        Me.lblTix1.Size = New System.Drawing.Size(1347, 64)
        Me.lblTix1.TabIndex = 1
        '
        'lblTix2
        '
        Me.lblTix2.BackColor = System.Drawing.Color.White
        Me.lblTix2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTix2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTix2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTix2.Location = New System.Drawing.Point(356, 452)
        Me.lblTix2.Name = "lblTix2"
        Me.lblTix2.Size = New System.Drawing.Size(1347, 64)
        Me.lblTix2.TabIndex = 2
        '
        'lblTix3
        '
        Me.lblTix3.BackColor = System.Drawing.Color.White
        Me.lblTix3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTix3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTix3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTix3.Location = New System.Drawing.Point(356, 516)
        Me.lblTix3.Name = "lblTix3"
        Me.lblTix3.Size = New System.Drawing.Size(1347, 64)
        Me.lblTix3.TabIndex = 3
        '
        'lblSum
        '
        Me.lblSum.BackColor = System.Drawing.Color.White
        Me.lblSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSum.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSum.Location = New System.Drawing.Point(356, 598)
        Me.lblSum.Name = "lblSum"
        Me.lblSum.Size = New System.Drawing.Size(1347, 64)
        Me.lblSum.TabIndex = 4
        Me.lblSum.Text = "PURCHASE SUMMARY"
        '
        'lblHeading
        '
        Me.lblHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.Color.Green
        Me.lblHeading.Location = New System.Drawing.Point(370, 81)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(1301, 156)
        Me.lblHeading.TabIndex = 5
        Me.lblHeading.Text = "Please verify the purchase information below and touch BUY to complete purchase"
        Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdBuy
        '
        Me.cmdBuy.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdBuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdBuy.FlatAppearance.BorderSize = 3
        Me.cmdBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuy.ForeColor = System.Drawing.Color.Yellow
        Me.cmdBuy.Location = New System.Drawing.Point(644, 743)
        Me.cmdBuy.Name = "cmdBuy"
        Me.cmdBuy.Size = New System.Drawing.Size(641, 319)
        Me.cmdBuy.TabIndex = 6
        Me.cmdBuy.Text = "BUY"
        Me.cmdBuy.UseVisualStyleBackColor = False
        '
        'btnChange
        '
        Me.btnChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChange.Location = New System.Drawing.Point(43, 773)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(382, 121)
        Me.btnChange.TabIndex = 7
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(43, 966)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(382, 121)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'VerifyPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1956, 1254)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.cmdBuy)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.lblSum)
        Me.Controls.Add(Me.lblTix3)
        Me.Controls.Add(Me.lblTix2)
        Me.Controls.Add(Me.lblTix1)
        Me.Controls.Add(Me.lblPurchaseSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VerifyPurchase"
        Me.Text = "VerifyPurchase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPurchaseSummary As System.Windows.Forms.Label
    Friend WithEvents lblTix1 As System.Windows.Forms.Label
    Friend WithEvents lblTix2 As System.Windows.Forms.Label
    Friend WithEvents lblTix3 As System.Windows.Forms.Label
    Friend WithEvents lblSum As System.Windows.Forms.Label
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents cmdBuy As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
