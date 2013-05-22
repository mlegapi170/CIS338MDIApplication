Imports System.Windows.Forms
Imports BusinessLogic

Public Class CoffeeRoastersParentForm

    Private m_controller As New Controller

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New OrderForm(m_controller)
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub



    Public Sub updateSummary()
        'update all children that are summary forms
        For Each child In Me.MdiChildren
            If TypeOf child Is SummaryForm Then
                CType(child, SummaryForm).updateSelf()
            End If

        Next
    End Sub



    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        If Me.ActiveMdiChild.ActiveControl.Text = "" Then
        Else
            My.Computer.Clipboard.SetText(Me.ActiveMdiChild.ActiveControl.Text)
            Me.ActiveMdiChild.ActiveControl.Text = ""
        End If

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        If Me.ActiveMdiChild.ActiveControl.Text = "" Then
        Else
            My.Computer.Clipboard.SetText(Me.ActiveMdiChild.ActiveControl.Text)
        End If

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.

        Me.ActiveMdiChild.ActiveControl.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        If Me.MdiChildren.Length > 0 Then
            Me.ActiveMdiChild.Close()
        End If

    End Sub

    Private Sub EditMenu_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditMenu.DropDownOpened
        If (Not IsNothing(Me.ActiveMdiChild)) Then
            If Me.ActiveMdiChild.ActiveControl.Name.Contains("txt") Then
                CutToolStripMenuItem.Enabled = True
                CopyToolStripMenuItem.Enabled = True
                If My.Computer.Clipboard.ContainsText Then
                    PasteToolStripMenuItem.Enabled = True
                Else
                    PasteToolStripMenuItem.Enabled = False
                End If

            Else
                CutToolStripMenuItem.Enabled = False
                CopyToolStripMenuItem.Enabled = False
                PasteToolStripMenuItem.Enabled = False
            End If
        Else
            CutToolStripMenuItem.Enabled = False
            CopyToolStripMenuItem.Enabled = False
            PasteToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub CoffeeRoastersParentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CutToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem.Enabled = False
        PasteToolStripMenuItem.Enabled = False
    End Sub

    Private Sub FileMenu_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileMenu.DropDownOpened
        If Me.MdiChildren.Length = 0 Then
            CloseToolStripMenuItem.Enabled = False
        Else
            CloseToolStripMenuItem.Enabled = True
        End If

        If (Not IsNothing(Me.ActiveMdiChild)) Then
            If TypeOf Me.ActiveMdiChild Is OrderForm Then
                SaveToolStripMenuItem.Enabled = True
            Else
                SaveToolStripMenuItem.Enabled = False
            End If
        Else
            SaveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim myDialog = New OpenDialog


        Dim result = myDialog.ShowDialog
        If result = Windows.Forms.DialogResult.Yes Then
            'choose based on what was selected in the dialog
            If myDialog.rdoOpenSummary.Checked Then
                Dim sumForm As SummaryForm = New SummaryForm(m_controller)
                sumForm.MdiParent = Me
                sumForm.Show()
            Else
                Try
                    openForm(Integer.Parse(myDialog.txtOrderNumber.Text))
                Catch ex As Exception
                    MessageBox.Show("Only numbers are accpeted.", "Can not open Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                
            End If
        End If
    End Sub

    Public Sub openForm(ByVal index As Integer)
        Try
            Dim myOrder As Order
            myOrder = m_controller.getOrder(index)
            Dim newOrderForm As New OrderForm(m_controller, myOrder)
            newOrderForm.MdiParent = Me
            newOrderForm.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Can not open Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        CType(Me.ActiveMdiChild, OrderForm).saveForm()
    End Sub
End Class
