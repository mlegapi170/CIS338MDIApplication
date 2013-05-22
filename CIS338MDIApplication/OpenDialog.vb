Imports System.Windows.Forms

Public Class OpenDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub openDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdoOpenSummary.PerformClick()
    End Sub

    Private Sub rdoOpenExisting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOpenExisting.CheckedChanged
        txtOrderNumber.Enabled = True
    End Sub

    Private Sub rdoOpenSummary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOpenSummary.CheckedChanged
        txtOrderNumber.Enabled = False
    End Sub
End Class
