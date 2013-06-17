Imports BusinessLogic

Public Class OrderForm

    Private m_mousedown As Boolean = False
    Private changedFlag As Boolean = False
    Private m_order As Order
    Private m_controller As Controller
    Private m_menu As ArrayList
    Private m_orderItemLabels As ArrayList
    Private initialTop, initialLeft As Integer
    Private lastknowngoodorderNo As Integer

    Public Sub New(ByRef parentController As Controller)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_controller = parentController
        m_order = New Order
        m_order.OrderNumber = m_controller.getNextAvailableNumber
        lastknowngoodorderNo = m_controller.getNextAvailableNumber
        m_menu = New ArrayList
        initialTop = btnNewItem.Top
        initialLeft = btnNewItem.Left
        m_orderItemLabels = New ArrayList
        changedFlag = False
    End Sub

    Public Sub New(ByRef parentController As Controller, ByVal anOrder As Order)
        Me.New(parentController)
        m_order = anOrder
        lastknowngoodorderNo = m_order.OrderNumber 
    End Sub

    Private Sub OrderForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If changedFlag
            Dim result
            result = MessageBox.Show("Do you want to save your work before closing the order?","Save?",MessageBoxButtons.YesNoCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            Select Case result
                Case DialogResult.Yes
                    If Not saveForm
                        e.Cancel = True
                    End If
                Case DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub OrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'populate menu
        For Each menuItem As Item In m_controller.Menu.ItemCollection
            Dim itemLabel, priceLabel As New Label
            m_menu.Add(itemLabel)
            itemLabel.Text = menuItem.Name
            itemLabel.Left = 10
            itemLabel.Top = 20 + 30 * m_menu.IndexOf(itemLabel)
            priceLabel.Text = Format(menuItem.Price, "c")
            priceLabel.Left = 140
            priceLabel.Top = itemLabel.Top
            priceLabel.Width = 40
            priceLabel.TextAlign = ContentAlignment.TopRight
            'drag drop controls
            AddHandler itemLabel.MouseDown, AddressOf mouseDownAction
            AddHandler itemLabel.MouseMove, AddressOf mouseMoveAction

            pnlMenu.Controls.Add(itemLabel)
            pnlMenu.Controls.Add(priceLabel)
        Next

        tmr.Enabled = True
        lblDateTime.Text += Now.ToString
        Me.Text += " " & m_order.OrderNumber
        txtOrderNo.Text = m_order.OrderNumber.ToString
        txtServerName.Text = m_order.ServerName
        drawOrderItems 
        updateOrderTotals()
        updateTotalLabels()
        changedFlag = false
    End Sub

    Private Sub removeItemAction(ByVal sender As Button, ByVal e As System.EventArgs)
        m_order.removeItem(sender.Tag)
        drawOrderItems()
        updateOrderTotals()
        updateTotalLabels()
    End Sub

    Private Sub removeNewItemAction(ByVal sender As Button, ByVal e As System.EventArgs)
        drawOrderItems()
        updateOrderTotals()
        updateTotalLabels()
    End Sub

    Private Sub changeItemAction(ByVal sender As ComboBox, ByVal e As System.EventArgs)
        Try
            m_order.addItem(m_controller.Menu.ItemCollection.Item(sender.SelectedItem))
            'update quantity on added item
            m_order.getItem(sender.SelectedItem).Quantity = m_order.getItem(sender.Tag).Quantity
            'remove old item
            m_order.removeItem(sender.Tag)
            'redraw order panel
            drawOrderItems()
            updateOrderTotals()
            updateTotalLabels()
        Catch ex As Exception
            sender.SelectedItem = sender.Tag
            'send message to user
        End Try
    End Sub

    Private Sub changeNewItemAction(ByVal sender As ComboBox, ByVal e As System.EventArgs)
        Try
            m_order.addItem(m_controller.Menu.ItemCollection.Item(sender.SelectedItem))
            'redraw order panel
            drawOrderItems()
            updateOrderTotals()
            updateTotalLabels()
        Catch ex As Exception
            sender.SelectedIndex = -1
            'send message to user
        End Try
    End Sub

    Private Sub quantityChangedAction(ByVal sender As NumericUpDown, ByVal e As System.EventArgs)
        'change quantity of orderitem
        m_order.getItem(sender.Tag).Quantity = sender.Value
        'update all values
        updateOrderTotals()
        updateTotalLabels()
    End Sub

    Private Sub updateOrderTotals()
        lblSalesTaxValue.Width = 60
        lblOrderTotalValue.Width = 60
        lblSalesTotalValue.Width = 60
        If m_order.getAllItems.Count = 0 Then
            lblSalesTaxValue.Text = Format(0, "c")
            lblOrderTotalValue.Text = Format(0, "c")
            lblSalesTotalValue.Text = Format(0, "c")
        Else
            lblSalesTaxValue.Text =  Format(m_order.calculateTotal * CoffeeConstants.SALESTAX, "c")
            lblOrderTotalValue.Text =  Format(m_order.calculateTotal, "c")
            lblSalesTotalValue.Text = Format(m_order.calculateTotalWithTax, "c")
        End If
        lblSalesTaxValue.TextAlign = ContentAlignment.TopRight
        lblOrderTotalValue.TextAlign = ContentAlignment.TopRight
        lblSalesTotalValue.TextAlign = ContentAlignment.TopRight
        changedFlag = True
    End Sub

    Private Sub updateTotalLabels()
        For Each aLabel As Label In m_orderItemLabels
            aLabel.Text = "Total: " & Format(m_order.getItem(aLabel.Tag).calcTotal, "c")
        Next
    End Sub

    Private Sub mouseDownAction(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_mousedown = True
    End Sub

    Private Sub mouseMoveAction(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_mousedown Then
            sender.DoDragDrop(sender.Text, DragDropEffects.Copy)
        Else
            m_mousedown = False
        End If

    End Sub

    Private Sub btnNewItem_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnNewItem.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btnNewItem_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnNewItem.DragDrop
        If btnNewItem.Enabled Then
            Try
                'add to order
                m_order.addItem(m_controller.Menu.ItemCollection.Item(e.Data.GetData(DataFormats.StringFormat)))
                'redraw
                drawOrderItems()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        m_mousedown = False
    End Sub

    Private Sub btnNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewItem.Click
        Dim btnRemove As New Button
        Dim cboMenu As New ComboBox
        Dim nudQuantity As New NumericUpDown
        Dim lblTotal As New Label
        Dim lblItem As New Label
        Dim lblQuantity As New Label

        'prepare and add items to grpOrder
        btnRemove.Left = btnNewItem.Left
        btnRemove.Top = btnNewItem.Top
        btnRemove.Width = 15
        btnRemove.Text = "X"
        AddHandler btnRemove.Click, AddressOf removeNewItemAction

        lblItem.Left = btnRemove.Right + 3
        lblItem.Top = btnRemove.Top
        lblItem.Text = "Item: "
        lblItem.Width = 30
        cboMenu.Left = lblItem.Right + 3
        cboMenu.Top = btnRemove.Top
        populateCBO(cboMenu)
        cboMenu.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler cboMenu.SelectedIndexChanged, AddressOf changeNewItemAction

        lblQuantity.Left = cboMenu.Right + 3
        lblQuantity.Top = btnRemove.Top
        lblQuantity.Text = "Quantity: "
        lblQuantity.Width = 50
        nudQuantity.Left = lblQuantity.Right + 3
        nudQuantity.Top = btnRemove.Top
        nudQuantity.Minimum = 0
        nudQuantity.Value = 0
        nudQuantity.Width = 60

        lblTotal.Text = "Total: " & Format(0, "c")
        lblTotal.Left = nudQuantity.Right + 3
        lblTotal.Top = btnRemove.Top
        lblTotal.TextAlign = ContentAlignment.TopRight

        pnlOrder.Controls.Add(btnRemove)
        pnlOrder.Controls.Add(cboMenu)
        pnlOrder.Controls.Add(nudQuantity)
        pnlOrder.Controls.Add(lblTotal)
        pnlOrder.Controls.Add(lblItem)
        pnlOrder.Controls.Add(lblQuantity)
        btnNewItem.Top += 22

        'disable controls before adding
        nudQuantity.Enabled = False
        btnNewItem.Enabled = False

    End Sub

    Private Sub populateCBO(ByRef acbox As ComboBox)
        For Each anItem As Item In m_controller.Menu.ItemCollection
            acbox.Items.Add(anItem.Name)
        Next
    End Sub

    Private Sub drawOrderItems()
        'clear items on order panel
        pnlOrder.Controls.Clear()
        m_orderItemLabels.Clear()
        btnNewItem.Top = initialTop
        btnNewItem.Left = initialLeft
        btnNewItem.Enabled = True
        pnlOrder.Controls.Add(btnNewItem)
        'add items to panel
        For Each myOrderItem As OrderItem In m_order.getAllItems
            Dim btnRemove As New Button
            Dim cboMenu As New ComboBox
            Dim nudQuantity As New NumericUpDown
            Dim lblTotal As New Label
            Dim lblItem As New Label
            Dim lblQuantity As New Label

            'prepare and add items to pnlOrder
            btnRemove.Left = btnNewItem.Left
            btnRemove.Top = btnNewItem.Top
            btnRemove.Width = 15
            btnRemove.Text = "X"
            btnRemove.Tag = myOrderItem.Item.Name
            AddHandler btnRemove.Click, AddressOf removeItemAction

            lblItem.Left = btnRemove.Right + 3
            lblItem.Top = btnRemove.Top
            lblItem.Text = "Item: "
            lblItem.Width = 30
            cboMenu.Left = lblItem.Right + 3
            cboMenu.Top = btnRemove.Top
            populateCBO(cboMenu)
            cboMenu.DropDownStyle = ComboBoxStyle.DropDownList
            cboMenu.SelectedItem = myOrderItem.Item.Name
            cboMenu.Tag = myOrderItem.Item.Name
            AddHandler cboMenu.SelectedIndexChanged, AddressOf changeItemAction

            lblQuantity.Left = cboMenu.Right + 3
            lblQuantity.Top = btnRemove.Top
            lblQuantity.Text = "Quantity: "
            lblQuantity.Width = 50
            nudQuantity.Left = lblQuantity.Right + 3
            nudQuantity.Top = btnRemove.Top
            nudQuantity.Minimum = 0
            nudQuantity.Value = myOrderItem.Quantity
            nudQuantity.Width = 60
            nudQuantity.Tag = myOrderItem.Item.Name
            nudQuantity.ReadOnly = True
            AddHandler nudQuantity.ValueChanged, AddressOf quantityChangedAction

            lblTotal.Text = "Total: " & Format(myOrderItem.calcTotal, "c")
            lblTotal.Left = nudQuantity.Right + 3
            lblTotal.Top = btnRemove.Top
            lblTotal.Tag = myOrderItem.Item.Name
            lblTotal.TextAlign = ContentAlignment.TopRight
            m_orderItemLabels.Add(lblTotal)


            pnlOrder.Controls.Add(btnRemove)
            pnlOrder.Controls.Add(cboMenu)
            pnlOrder.Controls.Add(nudQuantity)
            pnlOrder.Controls.Add(lblTotal)
            pnlOrder.Controls.Add(lblItem)
            pnlOrder.Controls.Add(lblQuantity)
            btnNewItem.Top += 22
        Next

    End Sub



    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        lblDateTime.Text = "Date/Time: " & Now
    End Sub

    Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
        Me.Close()
    End Sub

    Private Sub btnSaveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveOrder.Click
        saveForm 
    End Sub

    Private Sub btnNewOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewOrder.Click
        m_order = New Order
        lastknowngoodorderNo = m_controller.getNextAvailableNumber
        m_order.OrderNumber = m_controller.getNextAvailableNumber
        drawOrderItems()
        'update labels
        updateOrderTotals()
        updateTotalLabels()
        txtOrderNo.Text = m_order.OrderNumber.ToString
        txtServerName.Text = ""
        changedFlag = False
    End Sub

    Private Sub txtOrderNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderNo.TextChanged
        Dim result As Integer = 0
        If Integer.TryParse(txtOrderNo.Text, result) Then
            m_order.OrderNumber = result
            lastknowngoodorderNo = result
            
            Me.Text = "New Order " & m_order.OrderNumber
            changedFlag = True
        Else
            txtOrderNo.Text = lastknowngoodorderNo
        End If
    End Sub

    Private Sub txtServerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServerName.TextChanged
        m_order.ServerName = txtServerName.Text
        changedFlag = True
    End Sub

    Public Function saveForm As Boolean
        'do validation
        Dim formSaved As Boolean = False
        Dim message As String = Nothing
        Dim isSaving As Boolean = true
        If m_controller.validateOrder(m_order, message) Then
            m_order.TimeStamp = Now
            If not m_controller.addOrder(m_order)
                'ask if want to update
                Dim result = MessageBox.Show("Do you wish to update order "& m_order.OrderNumber &"?", "Update Order",MessageBoxButtons.YesNo , _
                                           MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2)
                If result = Windows.Forms.DialogResult.Yes 
                    m_controller.updateOrder(m_order)
                    Else
                    isSaving = false
                End If
            End if 
            If isSaving 
                'send message to parent that an order changed
                CType(Me.MdiParent, CoffeeRoastersParentForm).updateSummary
                MessageBox.Show("Order No. " & m_order.OrderNumber & vbNewLine & "Server Name: " & m_order.ServerName & vbNewLine & _
                                        "Sales Total: " & Format(m_order.calculateTotalWithTax, "c") & vbNewLine & "Saved at " & _
                                        m_order.TimeStamp & ".", "Order Saved", MessageBoxButtons.OK)
                changedFlag = False
                formSaved = True
                
            End If
            'Me.Close()
        Else
            MessageBox.Show("The following needs correcting:" & vbNewLine & message, "Validations Not Passed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return formSaved
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'ask to delete order
        Dim result = MessageBox.Show("Delete Order "& m_order.OrderNumber &"?","Delete Order",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'delete if yes
        If result = Windows.Forms.DialogResult.Yes
            'check if order exists in db
            If m_controller.orderExists(m_order.OrderNumber)
                'delete order
                m_controller.removeOrder(m_order.OrderNumber)
                'cleanup form and update summary forms
                CType(Me.MdiParent, CoffeeRoastersParentForm).updateSummary
                btnNewOrder.PerformClick
                Me.ActiveControl = txtOrderNo
            Else
                'show error if order does not exist
                MessageBox.Show("Order is not in database!","Can not delete",MessageBoxButtons.OK,MessageBoxIcon.Error)
            End If
        End If

    End Sub
End Class
