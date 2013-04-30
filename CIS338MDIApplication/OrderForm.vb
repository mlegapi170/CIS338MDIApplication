Public Class OrderForm

    Private m_mousedown As Boolean = False
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
            priceLabel.TextAlign = ContentAlignment.TopLeft
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
        If m_order.getAllItems.Count = 0 Then
            lblOrderTax.Text = "Sales Tax: " & Format(0, "c")
            lblOrderTotal.Text = "Order Total: " & Format(0, "c")
            lblSalesTotal.Text = "Sales Total: " & Format(0, "c")
        Else
            lblOrderTax.Text = "Sales Tax: " & Format(m_order.calculateTotal * CoffeeConstants.SALESTAX, "c")
            lblOrderTotal.Text = "Order Total: " & Format(m_order.calculateTotal, "c")
            lblSalesTotal.Text = "Sales Total: " & Format(m_order.calculateTotalWithTax, "c")
        End If
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
            AddHandler nudQuantity.ValueChanged, AddressOf quantityChangedAction

            lblTotal.Text = "Total: " & Format(myOrderItem.calcTotal, "c")
            lblTotal.Left = nudQuantity.Right + 3
            lblTotal.Top = btnRemove.Top
            lblTotal.Tag = myOrderItem.Item.Name
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
        'do validation
        Dim message As String = Nothing
        If m_controller.validateOrder(m_order, message) Then
            m_order.TimeStamp = Now
            m_controller.addOrder(m_order)
            MessageBox.Show("Order No. " & m_order.OrderNumber & vbNewLine & "Server Name: " & m_order.ServerName & vbNewLine & _
                            "Sales Total: " & Format(m_order.calculateTotalWithTax, "c") & vbNewLine & "Saved at " & _
                            m_order.TimeStamp & ".", "Order Saved", MessageBoxButtons.OK)
            Me.Close()
        Else
            MessageBox.Show("The following needs correcting:" & vbNewLine & message, "Validations Not Passed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

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
    End Sub

    Private Sub txtOrderNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderNo.TextChanged
        Dim result As Integer = 0
        If Integer.TryParse(txtOrderNo.Text, result) Then
            m_order.OrderNumber = result
            lastknowngoodorderNo = result
            
            Me.Text = "New Order " & m_order.OrderNumber
        Else
            txtOrderNo.Text = lastknowngoodorderNo
        End If
    End Sub

    Private Sub txtServerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServerName.TextChanged
        m_order.ServerName = txtServerName.Text
    End Sub
End Class
