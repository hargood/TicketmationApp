<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatch
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
        Me.GridBatches = New System.Windows.Forms.DataGridView()
        Me.BatchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Track1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Track2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubmitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        CType(Me.GridBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridBatches
        '
        Me.GridBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridBatches.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchID, Me.Track1, Me.Track2, Me.Price, Me.SubmitDate})
        Me.GridBatches.Location = New System.Drawing.Point(12, 93)
        Me.GridBatches.Name = "GridBatches"
        Me.GridBatches.RowTemplate.Height = 40
        Me.GridBatches.Size = New System.Drawing.Size(2305, 603)
        Me.GridBatches.TabIndex = 0
        '
        'BatchID
        '
        Me.BatchID.HeaderText = "BatchID"
        Me.BatchID.Name = "BatchID"
        Me.BatchID.Width = 40
        '
        'Track1
        '
        Me.Track1.HeaderText = "Track1"
        Me.Track1.Name = "Track1"
        Me.Track1.Width = 400
        '
        'Track2
        '
        Me.Track2.HeaderText = "Track2"
        Me.Track2.Name = "Track2"
        Me.Track2.Width = 400
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.Width = 50
        '
        'SubmitDate
        '
        Me.SubmitDate.HeaderText = "Date"
        Me.SubmitDate.Name = "SubmitDate"
        Me.SubmitDate.Width = 150
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(1145, 729)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(362, 153)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(1544, 729)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(362, 153)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "DELETE"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(1955, 729)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(362, 153)
        Me.cmdSubmit.TabIndex = 3
        Me.cmdSubmit.Text = "SUBMIT"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'frmBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2442, 938)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GridBatches)
        Me.Name = "frmBatch"
        Me.Text = "frmBatch"
        CType(Me.GridBatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridBatches As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents BatchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Track1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Track2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubmitDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
