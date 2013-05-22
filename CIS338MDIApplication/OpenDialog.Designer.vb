<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.rdoOpenExisting = New System.Windows.Forms.RadioButton()
        Me.rdoOpenSummary = New System.Windows.Forms.RadioButton()
        Me.txtOrderNumber = New System.Windows.Forms.TextBox()
        Me.lblNumer = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(144, 42)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'rdoOpenExisting
        '
        Me.rdoOpenExisting.AutoSize = True
        Me.rdoOpenExisting.Location = New System.Drawing.Point(15, 12)
        Me.rdoOpenExisting.Name = "rdoOpenExisting"
        Me.rdoOpenExisting.Size = New System.Drawing.Size(119, 17)
        Me.rdoOpenExisting.TabIndex = 1
        Me.rdoOpenExisting.TabStop = True
        Me.rdoOpenExisting.Text = "Open Existing Order"
        Me.rdoOpenExisting.UseVisualStyleBackColor = True
        '
        'rdoOpenSummary
        '
        Me.rdoOpenSummary.AutoSize = True
        Me.rdoOpenSummary.Location = New System.Drawing.Point(155, 12)
        Me.rdoOpenSummary.Name = "rdoOpenSummary"
        Me.rdoOpenSummary.Size = New System.Drawing.Size(123, 17)
        Me.rdoOpenSummary.TabIndex = 2
        Me.rdoOpenSummary.TabStop = True
        Me.rdoOpenSummary.Text = "Open Summary Form"
        Me.rdoOpenSummary.UseVisualStyleBackColor = True
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.Location = New System.Drawing.Point(77, 51)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(57, 20)
        Me.txtOrderNumber.TabIndex = 3
        Me.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumer
        '
        Me.lblNumer.AutoSize = True
        Me.lblNumer.Location = New System.Drawing.Point(15, 54)
        Me.lblNumer.Name = "lblNumer"
        Me.lblNumer.Size = New System.Drawing.Size(53, 13)
        Me.lblNumer.TabIndex = 4
        Me.lblNumer.Text = "Order No."
        '
        'OpenDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(302, 83)
        Me.Controls.Add(Me.lblNumer)
        Me.Controls.Add(Me.txtOrderNumber)
        Me.Controls.Add(Me.rdoOpenSummary)
        Me.Controls.Add(Me.rdoOpenExisting)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Open.."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents rdoOpenExisting As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOpenSummary As System.Windows.Forms.RadioButton
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblNumer As System.Windows.Forms.Label

End Class
