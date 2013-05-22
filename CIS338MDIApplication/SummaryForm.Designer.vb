<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryForm
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
        Me.lstSummary = New System.Windows.Forms.ListView()
        Me.clmOrderNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmServer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmDateUpdated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lstSummary
        '
        Me.lstSummary.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmOrderNo, Me.clmTotal, Me.clmServer, Me.clmDateUpdated})
        Me.lstSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSummary.FullRowSelect = True
        Me.lstSummary.GridLines = True
        Me.lstSummary.Location = New System.Drawing.Point(0, 0)
        Me.lstSummary.MultiSelect = False
        Me.lstSummary.Name = "lstSummary"
        Me.lstSummary.Size = New System.Drawing.Size(557, 285)
        Me.lstSummary.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstSummary.TabIndex = 0
        Me.lstSummary.UseCompatibleStateImageBehavior = False
        Me.lstSummary.View = System.Windows.Forms.View.Details
        '
        'clmOrderNo
        '
        Me.clmOrderNo.Text = "Order Number"
        Me.clmOrderNo.Width = 112
        '
        'clmTotal
        '
        Me.clmTotal.Text = "Sales Total"
        Me.clmTotal.Width = 80
        '
        'clmServer
        '
        Me.clmServer.Text = "Server Name"
        Me.clmServer.Width = 102
        '
        'clmDateUpdated
        '
        Me.clmDateUpdated.Text = "Date Last Updated"
        Me.clmDateUpdated.Width = 129
        '
        'SummaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 285)
        Me.Controls.Add(Me.lstSummary)
        Me.Name = "SummaryForm"
        Me.Text = "SummaryForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstSummary As System.Windows.Forms.ListView
    Friend WithEvents clmOrderNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmServer As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmDateUpdated As System.Windows.Forms.ColumnHeader
End Class
