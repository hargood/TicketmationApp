<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecifyTickets
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
        Me.lSelect = New System.Windows.Forms.Label()
        Me.PanelTicketButton1 = New System.Windows.Forms.Panel()
        Me.lDesc1 = New System.Windows.Forms.Label()
        Me.lTax1 = New System.Windows.Forms.Label()
        Me.lCategory1 = New System.Windows.Forms.Label()
        Me.PanelTicketButton2 = New System.Windows.Forms.Panel()
        Me.lDesc2 = New System.Windows.Forms.Label()
        Me.lTax2 = New System.Windows.Forms.Label()
        Me.lCategory2 = New System.Windows.Forms.Label()
        Me.PanelTicketButton3 = New System.Windows.Forms.Panel()
        Me.lDesc3 = New System.Windows.Forms.Label()
        Me.lTax3 = New System.Windows.Forms.Label()
        Me.lCategory3 = New System.Windows.Forms.Label()
        Me.PanelKeyPad = New System.Windows.Forms.GroupBox()
        Me.cmdKeyPad10 = New System.Windows.Forms.Button()
        Me.cmdKeyPad9 = New System.Windows.Forms.Button()
        Me.cmdKeyPad8 = New System.Windows.Forms.Button()
        Me.cmdKeyPad7 = New System.Windows.Forms.Button()
        Me.cmdKeyPad6 = New System.Windows.Forms.Button()
        Me.cmdKeyPad5 = New System.Windows.Forms.Button()
        Me.cmdKeyPad4 = New System.Windows.Forms.Button()
        Me.cmdKeyPad3 = New System.Windows.Forms.Button()
        Me.cmdKeyPad2 = New System.Windows.Forms.Button()
        Me.cmdKeyPad1 = New System.Windows.Forms.Button()
        Me.FrameTicketSum1 = New System.Windows.Forms.GroupBox()
        Me.bCancel1 = New System.Windows.Forms.Button()
        Me.lblCategoryAmount1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdPurchase = New System.Windows.Forms.Button()
        Me.FrameTicketSum3 = New System.Windows.Forms.GroupBox()
        Me.bCancel3 = New System.Windows.Forms.Button()
        Me.lblCategoryAmount3 = New System.Windows.Forms.Label()
        Me.FrameTicketSum2 = New System.Windows.Forms.GroupBox()
        Me.bCancel2 = New System.Windows.Forms.Button()
        Me.lblCategoryAmount2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.SpecifyTicketTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PanelTicketButton1.SuspendLayout()
        Me.PanelTicketButton2.SuspendLayout()
        Me.PanelTicketButton3.SuspendLayout()
        Me.PanelKeyPad.SuspendLayout()
        Me.FrameTicketSum1.SuspendLayout()
        Me.FrameTicketSum3.SuspendLayout()
        Me.FrameTicketSum2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lSelect
        '
        Me.lSelect.AutoSize = True
        Me.lSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lSelect.ForeColor = System.Drawing.Color.Green
        Me.lSelect.Location = New System.Drawing.Point(24, 28)
        Me.lSelect.Name = "lSelect"
        Me.lSelect.Size = New System.Drawing.Size(1446, 55)
        Me.lSelect.TabIndex = 0
        Me.lSelect.Text = "Please Select a Ticket Category that you would like to Purchase"
        '
        'PanelTicketButton1
        '
        Me.PanelTicketButton1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelTicketButton1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTicketButton1.Controls.Add(Me.lDesc1)
        Me.PanelTicketButton1.Controls.Add(Me.lTax1)
        Me.PanelTicketButton1.Controls.Add(Me.lCategory1)
        Me.PanelTicketButton1.Location = New System.Drawing.Point(98, 124)
        Me.PanelTicketButton1.Name = "PanelTicketButton1"
        Me.PanelTicketButton1.Size = New System.Drawing.Size(451, 312)
        Me.PanelTicketButton1.TabIndex = 1
        Me.PanelTicketButton1.Visible = False
        '
        'lDesc1
        '
        Me.lDesc1.AutoSize = True
        Me.lDesc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDesc1.Location = New System.Drawing.Point(88, 240)
        Me.lDesc1.Name = "lDesc1"
        Me.lDesc1.Size = New System.Drawing.Size(191, 32)
        Me.lDesc1.TabIndex = 5
        Me.lDesc1.Text = "13 and Older"
        '
        'lTax1
        '
        Me.lTax1.AutoSize = True
        Me.lTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTax1.Location = New System.Drawing.Point(89, 125)
        Me.lTax1.Name = "lTax1"
        Me.lTax1.Size = New System.Drawing.Size(198, 25)
        Me.lTax1.TabIndex = 3
        Me.lTax1.Text = "$15.00 plus $1.00 tax"
        '
        'lCategory1
        '
        Me.lCategory1.AutoSize = True
        Me.lCategory1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCategory1.Location = New System.Drawing.Point(39, 39)
        Me.lCategory1.Name = "lCategory1"
        Me.lCategory1.Size = New System.Drawing.Size(306, 55)
        Me.lCategory1.TabIndex = 0
        Me.lCategory1.Text = "Adult $16.00"
        '
        'PanelTicketButton2
        '
        Me.PanelTicketButton2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelTicketButton2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTicketButton2.Controls.Add(Me.lDesc2)
        Me.PanelTicketButton2.Controls.Add(Me.lTax2)
        Me.PanelTicketButton2.Controls.Add(Me.lCategory2)
        Me.PanelTicketButton2.Location = New System.Drawing.Point(98, 493)
        Me.PanelTicketButton2.Name = "PanelTicketButton2"
        Me.PanelTicketButton2.Size = New System.Drawing.Size(451, 312)
        Me.PanelTicketButton2.TabIndex = 6
        Me.PanelTicketButton2.Visible = False
        '
        'lDesc2
        '
        Me.lDesc2.AutoSize = True
        Me.lDesc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDesc2.Location = New System.Drawing.Point(88, 241)
        Me.lDesc2.Name = "lDesc2"
        Me.lDesc2.Size = New System.Drawing.Size(191, 32)
        Me.lDesc2.TabIndex = 5
        Me.lDesc2.Text = "13 and Older"
        '
        'lTax2
        '
        Me.lTax2.AutoSize = True
        Me.lTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTax2.Location = New System.Drawing.Point(81, 108)
        Me.lTax2.Name = "lTax2"
        Me.lTax2.Size = New System.Drawing.Size(198, 25)
        Me.lTax2.TabIndex = 3
        Me.lTax2.Text = "$15.00 plus $1.00 tax"
        '
        'lCategory2
        '
        Me.lCategory2.AutoSize = True
        Me.lCategory2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCategory2.Location = New System.Drawing.Point(33, 21)
        Me.lCategory2.Name = "lCategory2"
        Me.lCategory2.Size = New System.Drawing.Size(306, 55)
        Me.lCategory2.TabIndex = 0
        Me.lCategory2.Text = "Adult $16.00"
        '
        'PanelTicketButton3
        '
        Me.PanelTicketButton3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelTicketButton3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTicketButton3.Controls.Add(Me.lDesc3)
        Me.PanelTicketButton3.Controls.Add(Me.lTax3)
        Me.PanelTicketButton3.Controls.Add(Me.lCategory3)
        Me.PanelTicketButton3.Location = New System.Drawing.Point(98, 862)
        Me.PanelTicketButton3.Name = "PanelTicketButton3"
        Me.PanelTicketButton3.Size = New System.Drawing.Size(451, 312)
        Me.PanelTicketButton3.TabIndex = 6
        Me.PanelTicketButton3.Visible = False
        '
        'lDesc3
        '
        Me.lDesc3.AutoSize = True
        Me.lDesc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lDesc3.Location = New System.Drawing.Point(88, 256)
        Me.lDesc3.Name = "lDesc3"
        Me.lDesc3.Size = New System.Drawing.Size(191, 32)
        Me.lDesc3.TabIndex = 5
        Me.lDesc3.Text = "13 and Older"
        '
        'lTax3
        '
        Me.lTax3.AutoSize = True
        Me.lTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTax3.Location = New System.Drawing.Point(81, 103)
        Me.lTax3.Name = "lTax3"
        Me.lTax3.Size = New System.Drawing.Size(198, 25)
        Me.lTax3.TabIndex = 3
        Me.lTax3.Text = "$15.00 plus $1.00 tax"
        '
        'lCategory3
        '
        Me.lCategory3.AutoSize = True
        Me.lCategory3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCategory3.Location = New System.Drawing.Point(36, 18)
        Me.lCategory3.Name = "lCategory3"
        Me.lCategory3.Size = New System.Drawing.Size(306, 55)
        Me.lCategory3.TabIndex = 0
        Me.lCategory3.Text = "Adult $16.00"
        '
        'PanelKeyPad
        '
        Me.PanelKeyPad.BackColor = System.Drawing.Color.LightYellow
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad10)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad9)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad8)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad7)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad6)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad5)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad4)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad3)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad2)
        Me.PanelKeyPad.Controls.Add(Me.cmdKeyPad1)
        Me.PanelKeyPad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PanelKeyPad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelKeyPad.ForeColor = System.Drawing.Color.Maroon
        Me.PanelKeyPad.Location = New System.Drawing.Point(578, 124)
        Me.PanelKeyPad.Name = "PanelKeyPad"
        Me.PanelKeyPad.Size = New System.Drawing.Size(1332, 548)
        Me.PanelKeyPad.TabIndex = 7
        Me.PanelKeyPad.TabStop = False
        Me.PanelKeyPad.Text = "Select number of ADULT tickets (Cancel for 0)"
        Me.PanelKeyPad.Visible = False
        '
        'cmdKeyPad10
        '
        Me.cmdKeyPad10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmdKeyPad10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad10.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad10.Location = New System.Drawing.Point(1074, 313)
        Me.cmdKeyPad10.Name = "cmdKeyPad10"
        Me.cmdKeyPad10.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad10.TabIndex = 10
        Me.cmdKeyPad10.Text = "Cancel"
        Me.cmdKeyPad10.UseVisualStyleBackColor = False
        '
        'cmdKeyPad9
        '
        Me.cmdKeyPad9.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad9.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad9.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad9.Location = New System.Drawing.Point(813, 313)
        Me.cmdKeyPad9.Name = "cmdKeyPad9"
        Me.cmdKeyPad9.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad9.TabIndex = 9
        Me.cmdKeyPad9.Text = "9"
        Me.cmdKeyPad9.UseVisualStyleBackColor = False
        '
        'cmdKeyPad8
        '
        Me.cmdKeyPad8.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad8.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad8.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad8.Location = New System.Drawing.Point(552, 313)
        Me.cmdKeyPad8.Name = "cmdKeyPad8"
        Me.cmdKeyPad8.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad8.TabIndex = 8
        Me.cmdKeyPad8.Text = "8"
        Me.cmdKeyPad8.UseVisualStyleBackColor = False
        '
        'cmdKeyPad7
        '
        Me.cmdKeyPad7.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad7.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad7.Location = New System.Drawing.Point(291, 313)
        Me.cmdKeyPad7.Name = "cmdKeyPad7"
        Me.cmdKeyPad7.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad7.TabIndex = 7
        Me.cmdKeyPad7.Text = "7"
        Me.cmdKeyPad7.UseVisualStyleBackColor = False
        '
        'cmdKeyPad6
        '
        Me.cmdKeyPad6.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad6.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad6.Location = New System.Drawing.Point(30, 313)
        Me.cmdKeyPad6.Name = "cmdKeyPad6"
        Me.cmdKeyPad6.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad6.TabIndex = 6
        Me.cmdKeyPad6.Text = "6"
        Me.cmdKeyPad6.UseVisualStyleBackColor = False
        '
        'cmdKeyPad5
        '
        Me.cmdKeyPad5.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad5.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad5.Location = New System.Drawing.Point(1074, 49)
        Me.cmdKeyPad5.Name = "cmdKeyPad5"
        Me.cmdKeyPad5.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad5.TabIndex = 5
        Me.cmdKeyPad5.Text = "5"
        Me.cmdKeyPad5.UseVisualStyleBackColor = False
        '
        'cmdKeyPad4
        '
        Me.cmdKeyPad4.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad4.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad4.Location = New System.Drawing.Point(813, 49)
        Me.cmdKeyPad4.Name = "cmdKeyPad4"
        Me.cmdKeyPad4.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad4.TabIndex = 4
        Me.cmdKeyPad4.Text = "4"
        Me.cmdKeyPad4.UseVisualStyleBackColor = False
        '
        'cmdKeyPad3
        '
        Me.cmdKeyPad3.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad3.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad3.Location = New System.Drawing.Point(552, 49)
        Me.cmdKeyPad3.Name = "cmdKeyPad3"
        Me.cmdKeyPad3.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad3.TabIndex = 3
        Me.cmdKeyPad3.Text = "3"
        Me.cmdKeyPad3.UseVisualStyleBackColor = False
        '
        'cmdKeyPad2
        '
        Me.cmdKeyPad2.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad2.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad2.Location = New System.Drawing.Point(291, 49)
        Me.cmdKeyPad2.Name = "cmdKeyPad2"
        Me.cmdKeyPad2.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad2.TabIndex = 2
        Me.cmdKeyPad2.Text = "2"
        Me.cmdKeyPad2.UseVisualStyleBackColor = False
        '
        'cmdKeyPad1
        '
        Me.cmdKeyPad1.BackColor = System.Drawing.Color.Silver
        Me.cmdKeyPad1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyPad1.ForeColor = System.Drawing.Color.Black
        Me.cmdKeyPad1.Location = New System.Drawing.Point(30, 49)
        Me.cmdKeyPad1.Name = "cmdKeyPad1"
        Me.cmdKeyPad1.Size = New System.Drawing.Size(230, 200)
        Me.cmdKeyPad1.TabIndex = 0
        Me.cmdKeyPad1.Text = "1"
        Me.cmdKeyPad1.UseVisualStyleBackColor = False
        '
        'FrameTicketSum1
        '
        Me.FrameTicketSum1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FrameTicketSum1.Controls.Add(Me.bCancel1)
        Me.FrameTicketSum1.Controls.Add(Me.lblCategoryAmount1)
        Me.FrameTicketSum1.Location = New System.Drawing.Point(646, 124)
        Me.FrameTicketSum1.Name = "FrameTicketSum1"
        Me.FrameTicketSum1.Size = New System.Drawing.Size(748, 78)
        Me.FrameTicketSum1.TabIndex = 13
        Me.FrameTicketSum1.TabStop = False
        Me.FrameTicketSum1.Visible = False
        '
        'bCancel1
        '
        Me.bCancel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.bCancel1.Location = New System.Drawing.Point(537, 9)
        Me.bCancel1.Name = "bCancel1"
        Me.bCancel1.Size = New System.Drawing.Size(205, 63)
        Me.bCancel1.TabIndex = 12
        Me.bCancel1.Text = "Cancel"
        Me.bCancel1.UseVisualStyleBackColor = False
        '
        'lblCategoryAmount1
        '
        Me.lblCategoryAmount1.AutoSize = True
        Me.lblCategoryAmount1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCategoryAmount1.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoryAmount1.Location = New System.Drawing.Point(9, 17)
        Me.lblCategoryAmount1.Name = "lblCategoryAmount1"
        Me.lblCategoryAmount1.Size = New System.Drawing.Size(390, 46)
        Me.lblCategoryAmount1.TabIndex = 11
        Me.lblCategoryAmount1.Text = "3 @ $12.00 = $36.00"
        Me.lblCategoryAmount1.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdCancel.Location = New System.Drawing.Point(77, 1442)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(279, 161)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdPurchase
        '
        Me.cmdPurchase.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPurchase.Location = New System.Drawing.Point(855, 1451)
        Me.cmdPurchase.Name = "cmdPurchase"
        Me.cmdPurchase.Size = New System.Drawing.Size(828, 169)
        Me.cmdPurchase.TabIndex = 9
        Me.cmdPurchase.Text = "PURCHASE THESE TICKETS"
        Me.cmdPurchase.UseVisualStyleBackColor = False
        Me.cmdPurchase.Visible = False
        '
        'FrameTicketSum3
        '
        Me.FrameTicketSum3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FrameTicketSum3.Controls.Add(Me.bCancel3)
        Me.FrameTicketSum3.Controls.Add(Me.lblCategoryAmount3)
        Me.FrameTicketSum3.Location = New System.Drawing.Point(658, 862)
        Me.FrameTicketSum3.Name = "FrameTicketSum3"
        Me.FrameTicketSum3.Size = New System.Drawing.Size(748, 80)
        Me.FrameTicketSum3.TabIndex = 11
        Me.FrameTicketSum3.TabStop = False
        Me.FrameTicketSum3.Visible = False
        '
        'bCancel3
        '
        Me.bCancel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.bCancel3.Location = New System.Drawing.Point(531, 11)
        Me.bCancel3.Name = "bCancel3"
        Me.bCancel3.Size = New System.Drawing.Size(205, 63)
        Me.bCancel3.TabIndex = 12
        Me.bCancel3.Text = "Cancel"
        Me.bCancel3.UseVisualStyleBackColor = False
        '
        'lblCategoryAmount3
        '
        Me.lblCategoryAmount3.AutoSize = True
        Me.lblCategoryAmount3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCategoryAmount3.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoryAmount3.Location = New System.Drawing.Point(6, 20)
        Me.lblCategoryAmount3.Name = "lblCategoryAmount3"
        Me.lblCategoryAmount3.Size = New System.Drawing.Size(390, 46)
        Me.lblCategoryAmount3.TabIndex = 11
        Me.lblCategoryAmount3.Text = "3 @ $12.00 = $36.00"
        Me.lblCategoryAmount3.Visible = False
        '
        'FrameTicketSum2
        '
        Me.FrameTicketSum2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FrameTicketSum2.Controls.Add(Me.bCancel2)
        Me.FrameTicketSum2.Controls.Add(Me.lblCategoryAmount2)
        Me.FrameTicketSum2.Location = New System.Drawing.Point(640, 491)
        Me.FrameTicketSum2.Name = "FrameTicketSum2"
        Me.FrameTicketSum2.Size = New System.Drawing.Size(748, 80)
        Me.FrameTicketSum2.TabIndex = 13
        Me.FrameTicketSum2.TabStop = False
        Me.FrameTicketSum2.Visible = False
        '
        'bCancel2
        '
        Me.bCancel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.bCancel2.Location = New System.Drawing.Point(537, 11)
        Me.bCancel2.Name = "bCancel2"
        Me.bCancel2.Size = New System.Drawing.Size(205, 63)
        Me.bCancel2.TabIndex = 12
        Me.bCancel2.Text = "Cancel"
        Me.bCancel2.UseVisualStyleBackColor = False
        '
        'lblCategoryAmount2
        '
        Me.lblCategoryAmount2.AutoSize = True
        Me.lblCategoryAmount2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCategoryAmount2.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoryAmount2.Location = New System.Drawing.Point(9, 20)
        Me.lblCategoryAmount2.Name = "lblCategoryAmount2"
        Me.lblCategoryAmount2.Size = New System.Drawing.Size(390, 46)
        Me.lblCategoryAmount2.TabIndex = 11
        Me.lblCategoryAmount2.Text = "3 @ $12.00 = $36.00"
        Me.lblCategoryAmount2.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(888, 1364)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(663, 69)
        Me.lblTotal.TabIndex = 15
        Me.lblTotal.Text = "Ticket Purchase Total: "
        Me.lblTotal.Visible = False
        '
        'SpecifyTicketTimer
        '
        Me.SpecifyTicketTimer.Interval = 10000
        '
        'frmSpecifyTickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1933, 1848)
        Me.Controls.Add(Me.FrameTicketSum2)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.FrameTicketSum3)
        Me.Controls.Add(Me.FrameTicketSum1)
        Me.Controls.Add(Me.cmdPurchase)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.PanelKeyPad)
        Me.Controls.Add(Me.PanelTicketButton3)
        Me.Controls.Add(Me.PanelTicketButton2)
        Me.Controls.Add(Me.PanelTicketButton1)
        Me.Controls.Add(Me.lSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSpecifyTickets"
        Me.Text = "frmSpecifyTickets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelTicketButton1.ResumeLayout(False)
        Me.PanelTicketButton1.PerformLayout()
        Me.PanelTicketButton2.ResumeLayout(False)
        Me.PanelTicketButton2.PerformLayout()
        Me.PanelTicketButton3.ResumeLayout(False)
        Me.PanelTicketButton3.PerformLayout()
        Me.PanelKeyPad.ResumeLayout(False)
        Me.FrameTicketSum1.ResumeLayout(False)
        Me.FrameTicketSum1.PerformLayout()
        Me.FrameTicketSum3.ResumeLayout(False)
        Me.FrameTicketSum3.PerformLayout()
        Me.FrameTicketSum2.ResumeLayout(False)
        Me.FrameTicketSum2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lSelect As System.Windows.Forms.Label
    Friend WithEvents PanelTicketButton1 As System.Windows.Forms.Panel
    Friend WithEvents lDesc1 As System.Windows.Forms.Label
    Friend WithEvents lTax1 As System.Windows.Forms.Label
    Friend WithEvents lCategory1 As System.Windows.Forms.Label
    Friend WithEvents PanelTicketButton2 As System.Windows.Forms.Panel
    Friend WithEvents lDesc2 As System.Windows.Forms.Label
    Friend WithEvents lTax2 As System.Windows.Forms.Label
    Friend WithEvents lCategory2 As System.Windows.Forms.Label
    Friend WithEvents PanelTicketButton3 As System.Windows.Forms.Panel
    Friend WithEvents lDesc3 As System.Windows.Forms.Label
    Friend WithEvents lTax3 As System.Windows.Forms.Label
    Friend WithEvents lCategory3 As System.Windows.Forms.Label
    Friend WithEvents PanelKeyPad As System.Windows.Forms.GroupBox
    Friend WithEvents cmdKeyPad1 As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdPurchase As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad2 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad10 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad9 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad8 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad7 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad6 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad5 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad4 As System.Windows.Forms.Button
    Friend WithEvents cmdKeyPad3 As System.Windows.Forms.Button
    Friend WithEvents FrameTicketSum3 As System.Windows.Forms.GroupBox
    Friend WithEvents bCancel3 As System.Windows.Forms.Button
    Friend WithEvents lblCategoryAmount3 As System.Windows.Forms.Label
    Friend WithEvents FrameTicketSum1 As System.Windows.Forms.GroupBox
    Friend WithEvents bCancel1 As System.Windows.Forms.Button
    Friend WithEvents lblCategoryAmount1 As System.Windows.Forms.Label
    Friend WithEvents FrameTicketSum2 As System.Windows.Forms.GroupBox
    Friend WithEvents bCancel2 As System.Windows.Forms.Button
    Friend WithEvents lblCategoryAmount2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents SpecifyTicketTimer As System.Windows.Forms.Timer
End Class
