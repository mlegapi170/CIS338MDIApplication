Imports BusinessLogic

Public Class SummaryForm
    Private myCtrl As Controller

    Public Sub New(ByRef parentcontroller As Controller)
        ' This call is required by the designer.
        InitializeComponent()

        myCtrl = parentcontroller


    End Sub
    Private Sub SummaryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initial fill out of form
        fillForm()

    End Sub

    Private Sub fillForm()
        lstSummary.Items.Clear
        For Each anOrder As Order In myCtrl.Orders
            'todo: format strings, add more columns
            Dim line As String() = New String() {anOrder.OrderNumber,Format(anOrder.calculateTotalWithTax,"c"), _
                                                 anOrder.ServerName, anOrder.TimeStamp}
            lstSummary.Items.Add(New ListViewItem(line))
        Next

    End Sub

    Public Sub updateSelf()
        fillForm 
    End Sub


    Private Sub lstSummary_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSummary.MouseDoubleClick
        If lstSummary.SelectedIndices.Count > 0
            For Each index As Integer In lstSummary.SelectedIndices
                Dim line As ListViewItem
                line = lstSummary.Items(index)
                Dim orderid = line.SubItems(0).Text
                CType(Me.MdiParent, CoffeeRoastersParentForm).openForm(Integer.Parse(orderid))
            Next
        End If
    End Sub
End Class