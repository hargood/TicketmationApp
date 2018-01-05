<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirstPageAOP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirstPageAOP))
        Me.lblPurchaseHere = New System.Windows.Forms.Label()
        Me.lblNoDiscounts = New System.Windows.Forms.Label()
        Me.lblBadSwipe = New System.Windows.Forms.Label()
        Me.ClickImage2 = New System.Windows.Forms.Label()
        Me.ClickImage1 = New System.Windows.Forms.Label()
        Me.ClickTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerChip = New System.Windows.Forms.Timer(Me.components)
        Me.lBatch = New System.Windows.Forms.Label()
        Me.lStock = New System.Windows.Forms.Label()
        Me.imgCC4 = New System.Windows.Forms.PictureBox()
        Me.imgCC3 = New System.Windows.Forms.PictureBox()
        Me.imgCC2 = New System.Windows.Forms.PictureBox()
        Me.imgCC1 = New System.Windows.Forms.PictureBox()
        Me.imgShow = New System.Windows.Forms.PictureBox()
        Me.imInsertCard = New System.Windows.Forms.PictureBox()
        CType(Me.imgCC4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCC2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgShow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imInsertCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPurchaseHere
        '
        Me.lblPurchaseHere.AutoSize = True
        Me.lblPurchaseHere.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchaseHere.ForeColor = System.Drawing.Color.Navy
        Me.lblPurchaseHere.Location = New System.Drawing.Point(413, 412)
        Me.lblPurchaseHere.Name = "lblPurchaseHere"
        Me.lblPurchaseHere.Size = New System.Drawing.Size(1672, 139)
        Me.lblPurchaseHere.TabIndex = 1
        Me.lblPurchaseHere.Text = "PURCHASE  TICKETS HERE"
        '
        'lblNoDiscounts
        '
        Me.lblNoDiscounts.AutoSize = True
        Me.lblNoDiscounts.Font = New System.Drawing.Font("Arial", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoDiscounts.ForeColor = System.Drawing.Color.Navy
        Me.lblNoDiscounts.Location = New System.Drawing.Point(690, 551)
        Me.lblNoDiscounts.Name = "lblNoDiscounts"
        Me.lblNoDiscounts.Size = New System.Drawing.Size(1140, 56)
        Me.lblNoDiscounts.TabIndex = 2
        Me.lblNoDiscounts.Text = "THIS MACHINE DOES NOT ACCEPT DISCOUNTS"
        '
        'lblBadSwipe
        '
        Me.lblBadSwipe.BackColor = System.Drawing.Color.Yellow
        Me.lblBadSwipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBadSwipe.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblBadSwipe.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBadSwipe.ForeColor = System.Drawing.Color.Red
        Me.lblBadSwipe.Location = New System.Drawing.Point(2528, 1010)
        Me.lblBadSwipe.Name = "lblBadSwipe"
        Me.lblBadSwipe.Size = New System.Drawing.Size(107, 224)
        Me.lblBadSwipe.TabIndex = 3
        Me.lblBadSwipe.Text = "THIS MACHINE DOES NOT ACCEPT THIS TYPE OF CARD PLEASE USE A DIFFERENT CARD"
        Me.lblBadSwipe.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblBadSwipe.Visible = False
        '
        'ClickImage2
        '
        Me.ClickImage2.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClickImage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClickImage2.Location = New System.Drawing.Point(2332, 1462)
        Me.ClickImage2.Name = "ClickImage2"
        Me.ClickImage2.Size = New System.Drawing.Size(569, 227)
        Me.ClickImage2.TabIndex = 9
        Me.ClickImage2.Text = "..."
        Me.ClickImage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClickImage1
        '
        Me.ClickImage1.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClickImage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClickImage1.Location = New System.Drawing.Point(12, 1445)
        Me.ClickImage1.Name = "ClickImage1"
        Me.ClickImage1.Size = New System.Drawing.Size(564, 227)
        Me.ClickImage1.TabIndex = 8
        Me.ClickImage1.Text = "..."
        Me.ClickImage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClickTimer
        '
        Me.ClickTimer.Enabled = True
        '
        'TimerChip
        '
        Me.TimerChip.Enabled = True
        Me.TimerChip.Interval = 2000
        '
        'lBatch
        '
        Me.lBatch.AutoSize = True
        Me.lBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBatch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lBatch.Location = New System.Drawing.Point(237, 1492)
        Me.lBatch.Name = "lBatch"
        Me.lBatch.Size = New System.Drawing.Size(43, 46)
        Me.lBatch.TabIndex = 10
        Me.lBatch.Text = "0"
        '
        'lStock
        '
        Me.lStock.AutoSize = True
        Me.lStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lStock.Location = New System.Drawing.Point(237, 1445)
        Me.lStock.Name = "lStock"
        Me.lStock.Size = New System.Drawing.Size(43, 46)
        Me.lStock.TabIndex = 11
        Me.lStock.Text = "0"
        '
        'imgCC4
        '
        Me.imgCC4.Image = CType(resources.GetObject("imgCC4.Image"), System.Drawing.Image)
        Me.imgCC4.Location = New System.Drawing.Point(1570, 1474)
        Me.imgCC4.Name = "imgCC4"
        Me.imgCC4.Size = New System.Drawing.Size(275, 55)
        Me.imgCC4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCC4.TabIndex = 7
        Me.imgCC4.TabStop = False
        '
        'imgCC3
        '
        Me.imgCC3.Image = CType(resources.GetObject("imgCC3.Image"), System.Drawing.Image)
        Me.imgCC3.Location = New System.Drawing.Point(1381, 1456)
        Me.imgCC3.Name = "imgCC3"
        Me.imgCC3.Size = New System.Drawing.Size(149, 122)
        Me.imgCC3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCC3.TabIndex = 6
        Me.imgCC3.TabStop = False
        '
        'imgCC2
        '
        Me.imgCC2.Image = CType(resources.GetObject("imgCC2.Image"), System.Drawing.Image)
        Me.imgCC2.Location = New System.Drawing.Point(1171, 1456)
        Me.imgCC2.Name = "imgCC2"
        Me.imgCC2.Size = New System.Drawing.Size(155, 108)
        Me.imgCC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCC2.TabIndex = 5
        Me.imgCC2.TabStop = False
        '
        'imgCC1
        '
        Me.imgCC1.Image = CType(resources.GetObject("imgCC1.Image"), System.Drawing.Image)
        Me.imgCC1.Location = New System.Drawing.Point(918, 1456)
        Me.imgCC1.Name = "imgCC1"
        Me.imgCC1.Size = New System.Drawing.Size(166, 122)
        Me.imgCC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCC1.TabIndex = 4
        Me.imgCC1.TabStop = False
        '
        'imgShow
        '
        Me.imgShow.Image = Global.TicketmationApp.My.Resources.Resources.NY_Logo
        Me.imgShow.Location = New System.Drawing.Point(1109, 47)
        Me.imgShow.Name = "imgShow"
        Me.imgShow.Size = New System.Drawing.Size(371, 340)
        Me.imgShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgShow.TabIndex = 0
        Me.imgShow.TabStop = False
        '
        'imInsertCard
        '
        Me.imInsertCard.Image = CType(resources.GetObject("imInsertCard.Image"), System.Drawing.Image)
        Me.imInsertCard.Location = New System.Drawing.Point(759, 624)
        Me.imInsertCard.Name = "imInsertCard"
        Me.imInsertCard.Size = New System.Drawing.Size(949, 793)
        Me.imInsertCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imInsertCard.TabIndex = 12
        Me.imInsertCard.TabStop = False
        '
        'frmFirstPageAOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2805, 1788)
        Me.ControlBox = False
        Me.Controls.Add(Me.imInsertCard)
        Me.Controls.Add(Me.lStock)
        Me.Controls.Add(Me.lBatch)
        Me.Controls.Add(Me.ClickImage2)
        Me.Controls.Add(Me.ClickImage1)
        Me.Controls.Add(Me.imgCC4)
        Me.Controls.Add(Me.imgCC3)
        Me.Controls.Add(Me.imgCC2)
        Me.Controls.Add(Me.imgCC1)
        Me.Controls.Add(Me.lblBadSwipe)
        Me.Controls.Add(Me.lblNoDiscounts)
        Me.Controls.Add(Me.lblPurchaseHere)
        Me.Controls.Add(Me.imgShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFirstPageAOP"
        Me.Text = "Welcome "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgCC4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCC2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgShow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imInsertCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgShow As System.Windows.Forms.PictureBox
    Friend WithEvents lblPurchaseHere As System.Windows.Forms.Label
    Friend WithEvents lblNoDiscounts As System.Windows.Forms.Label
    Friend WithEvents lblBadSwipe As System.Windows.Forms.Label
    Friend WithEvents imgCC1 As System.Windows.Forms.PictureBox
    Friend WithEvents imgCC2 As System.Windows.Forms.PictureBox
    Friend WithEvents imgCC3 As System.Windows.Forms.PictureBox
    Friend WithEvents imgCC4 As System.Windows.Forms.PictureBox
    Friend WithEvents ClickImage2 As System.Windows.Forms.Label
    Friend WithEvents ClickImage1 As System.Windows.Forms.Label
    Friend WithEvents ClickTimer As System.Windows.Forms.Timer
    Friend WithEvents TimerChip As System.Windows.Forms.Timer
    Friend WithEvents lBatch As System.Windows.Forms.Label
    Friend WithEvents lStock As System.Windows.Forms.Label
    Friend WithEvents imInsertCard As System.Windows.Forms.PictureBox
End Class
