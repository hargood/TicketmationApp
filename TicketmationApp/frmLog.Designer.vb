<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Me.LogGrid = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Information = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdClose = New System.Windows.Forms.Button()
        CType(Me.LogGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogGrid
        '
        Me.LogGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LogGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DateTime, Me.Information})
        Me.LogGrid.Location = New System.Drawing.Point(12, 43)
        Me.LogGrid.MultiSelect = False
        Me.LogGrid.Name = "LogGrid"
        Me.LogGrid.RowTemplate.Height = 30
        Me.LogGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LogGrid.Size = New System.Drawing.Size(1466, 640)
        Me.LogGrid.TabIndex = 0
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DateTime
        '
        Me.DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DateTime.HeaderText = "Date/Time"
        Me.DateTime.Name = "DateTime"
        Me.DateTime.ReadOnly = True
        Me.DateTime.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DateTime.Width = 300
        '
        'Information
        '
        Me.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Information.HeaderText = "Information"
        Me.Information.Name = "Information"
        Me.Information.ReadOnly = True
        Me.Information.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Information.Width = 1000
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(68, 708)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(436, 153)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1509, 910)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LogGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLog"
        Me.Text = "frmLog"
        CType(Me.LogGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LogGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Information As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
