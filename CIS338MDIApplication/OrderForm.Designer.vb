<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderForm
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
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.grpOrder = New System.Windows.Forms.GroupBox()
        Me.pnlOrder = New System.Windows.Forms.Panel()
        Me.btnNewItem = New System.Windows.Forms.Button()
        Me.lblOrderTotal = New System.Windows.Forms.Label()
        Me.lblOrderTax = New System.Windows.Forms.Label()
        Me.lblSalesTotal = New System.Windows.Forms.Label()
        Me.grpBoxTotals = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnNewOrder = New System.Windows.Forms.Button()
        Me.btnSaveOrder = New System.Windows.Forms.Button()
        Me.btnCloseOrder = New System.Windows.Forms.Button()
        Me.grpOrderInfo = New System.Windows.Forms.GroupBox()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpMenu.SuspendLayout()
        Me.grpOrder.SuspendLayout()
        Me.pnlOrder.SuspendLayout()
        Me.grpBoxTotals.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrderInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMenu
        '
        Me.grpMenu.Controls.Add(Me.pnlMenu)
        Me.grpMenu.Location = New System.Drawing.Point(22, 63)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(212, 383)
        Me.grpMenu.TabIndex = 0
        Me.grpMenu.TabStop = False
        Me.grpMenu.Text = "Menu"
        '
        'pnlMenu
        '
        Me.pnlMenu.AutoScroll = True
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(3, 16)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(206, 364)
        Me.pnlMenu.TabIndex = 0
        '
        'grpOrder
        '
        Me.grpOrder.Controls.Add(Me.pnlOrder)
        Me.grpOrder.Location = New System.Drawing.Point(240, 156)
        Me.grpOrder.Name = "grpOrder"
        Me.grpOrder.Size = New System.Drawing.Size(413, 290)
        Me.grpOrder.TabIndex = 1
        Me.grpOrder.TabStop = False
        Me.grpOrder.Text = "Order"
        '
        'pnlOrder
        '
        Me.pnlOrder.AutoScroll = True
        Me.pnlOrder.Controls.Add(Me.btnNewItem)
        Me.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrder.Location = New System.Drawing.Point(3, 16)
        Me.pnlOrder.Name = "pnlOrder"
        Me.pnlOrder.Size = New System.Drawing.Size(407, 271)
        Me.pnlOrder.TabIndex = 0
        '
        'btnNewItem
        '
        Me.btnNewItem.AllowDrop = True
        Me.btnNewItem.Location = New System.Drawing.Point(4, 3)
        Me.btnNewItem.Name = "btnNewItem"
        Me.btnNewItem.Size = New System.Drawing.Size(370, 27)
        Me.btnNewItem.TabIndex = 0
        Me.btnNewItem.Text = "Drag Menu Item Here or Click Here to add to Order"
        Me.btnNewItem.UseVisualStyleBackColor = True
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.AutoSize = True
        Me.lblOrderTotal.Location = New System.Drawing.Point(6, 19)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(66, 13)
        Me.lblOrderTotal.TabIndex = 2
        Me.lblOrderTotal.Text = "Order Total: "
        '
        'lblOrderTax
        '
        Me.lblOrderTax.AutoSize = True
        Me.lblOrderTax.Location = New System.Drawing.Point(12, 45)
        Me.lblOrderTax.Name = "lblOrderTax"
        Me.lblOrderTax.Size = New System.Drawing.Size(60, 13)
        Me.lblOrderTax.TabIndex = 3
        Me.lblOrderTax.Text = "Sales Tax: "
        '
        'lblSalesTotal
        '
        Me.lblSalesTotal.AutoSize = True
        Me.lblSalesTotal.Location = New System.Drawing.Point(6, 73)
        Me.lblSalesTotal.Name = "lblSalesTotal"
        Me.lblSalesTotal.Size = New System.Drawing.Size(66, 13)
        Me.lblSalesTotal.TabIndex = 4
        Me.lblSalesTotal.Text = "Sales Total: "
        '
        'grpBoxTotals
        '
        Me.grpBoxTotals.Controls.Add(Me.lblOrderTotal)
        Me.grpBoxTotals.Controls.Add(Me.lblSalesTotal)
        Me.grpBoxTotals.Controls.Add(Me.lblOrderTax)
        Me.grpBoxTotals.Location = New System.Drawing.Point(519, 452)
        Me.grpBoxTotals.Name = "grpBoxTotals"
        Me.grpBoxTotals.Size = New System.Drawing.Size(134, 92)
        Me.grpBoxTotals.TabIndex = 5
        Me.grpBoxTotals.TabStop = False
        Me.grpBoxTotals.Text = "Totals"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CIS338MDIApplication.My.Resources.Resources.coffeee
        Me.PictureBox1.Location = New System.Drawing.Point(504, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(146, 137)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'btnNewOrder
        '
        Me.btnNewOrder.Location = New System.Drawing.Point(240, 450)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Size = New System.Drawing.Size(91, 94)
        Me.btnNewOrder.TabIndex = 7
        Me.btnNewOrder.Text = "New Order"
        Me.btnNewOrder.UseVisualStyleBackColor = True
        '
        'btnSaveOrder
        '
        Me.btnSaveOrder.Location = New System.Drawing.Point(337, 449)
        Me.btnSaveOrder.Name = "btnSaveOrder"
        Me.btnSaveOrder.Size = New System.Drawing.Size(85, 94)
        Me.btnSaveOrder.TabIndex = 8
        Me.btnSaveOrder.Text = "Save Order"
        Me.btnSaveOrder.UseVisualStyleBackColor = True
        '
        'btnCloseOrder
        '
        Me.btnCloseOrder.Location = New System.Drawing.Point(428, 450)
        Me.btnCloseOrder.Name = "btnCloseOrder"
        Me.btnCloseOrder.Size = New System.Drawing.Size(85, 94)
        Me.btnCloseOrder.TabIndex = 9
        Me.btnCloseOrder.Text = "Close"
        Me.btnCloseOrder.UseVisualStyleBackColor = True
        '
        'grpOrderInfo
        '
        Me.grpOrderInfo.Controls.Add(Me.txtServerName)
        Me.grpOrderInfo.Controls.Add(Me.txtOrderNo)
        Me.grpOrderInfo.Controls.Add(Me.lblDateTime)
        Me.grpOrderInfo.Controls.Add(Me.lblServer)
        Me.grpOrderInfo.Controls.Add(Me.lblOrderNo)
        Me.grpOrderInfo.Location = New System.Drawing.Point(25, 452)
        Me.grpOrderInfo.Name = "grpOrderInfo"
        Me.grpOrderInfo.Size = New System.Drawing.Size(205, 90)
        Me.grpOrderInfo.TabIndex = 10
        Me.grpOrderInfo.TabStop = False
        Me.grpOrderInfo.Text = "Order Information"
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Location = New System.Drawing.Point(33, 19)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(49, 13)
        Me.lblOrderNo.TabIndex = 0
        Me.lblOrderNo.Text = "Order #: "
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(7, 45)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(75, 13)
        Me.lblServer.TabIndex = 1
        Me.lblServer.Text = "Server Name: "
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Location = New System.Drawing.Point(18, 73)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(64, 13)
        Me.lblDateTime.TabIndex = 2
        Me.lblDateTime.Text = "Date/Time: "
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(88, 12)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(100, 20)
        Me.txtOrderNo.TabIndex = 3
        Me.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(88, 38)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(100, 20)
        Me.txtServerName.TabIndex = 4
        Me.txtServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tmr
        '
        Me.tmr.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("AntiquaSSK", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cal Poly Coffee Roasters"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 32)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "3801 Temple Ave." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pomona, CA 91768"
        '
        'OrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(665, 556)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpOrderInfo)
        Me.Controls.Add(Me.btnCloseOrder)
        Me.Controls.Add(Me.btnSaveOrder)
        Me.Controls.Add(Me.btnNewOrder)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grpBoxTotals)
        Me.Controls.Add(Me.grpOrder)
        Me.Controls.Add(Me.grpMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "OrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Order"
        Me.grpMenu.ResumeLayout(False)
        Me.grpOrder.ResumeLayout(False)
        Me.pnlOrder.ResumeLayout(False)
        Me.grpBoxTotals.ResumeLayout(False)
        Me.grpBoxTotals.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrderInfo.ResumeLayout(False)
        Me.grpOrderInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Friend WithEvents grpOrder As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewItem As System.Windows.Forms.Button
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlOrder As System.Windows.Forms.Panel
    Friend WithEvents lblOrderTotal As System.Windows.Forms.Label
    Friend WithEvents lblOrderTax As System.Windows.Forms.Label
    Friend WithEvents lblSalesTotal As System.Windows.Forms.Label
    Friend WithEvents grpBoxTotals As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnNewOrder As System.Windows.Forms.Button
    Friend WithEvents btnSaveOrder As System.Windows.Forms.Button
    Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
    Friend WithEvents grpOrderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
