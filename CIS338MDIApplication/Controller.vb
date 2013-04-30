Public Class Controller
    Private myItemDB As ItemDB
    Private myOrderDB As OrderDB

    Public Sub New()
        myItemDB = New ItemDB
        myOrderDB = New OrderDB


    End Sub

    Public Sub addOrder(ByVal anOrder As Order)
        Try
            myOrderDB.addOrder(anOrder)
        Catch ex As Exception

        Finally

        End Try
        
    End Sub

    Public Function validateOrder(ByVal anOrder As Order, ByRef message As String)
        Return myOrderDB.validateOrder(anOrder, message)
    End Function

    Public Function getNextAvailableNumber As Integer
        Return myOrderDB.getNextAvailableOrderNumber
    End Function

    ReadOnly Property Menu As ItemDB
        Get
            Return myItemDB 
        End Get
    End Property
End Class
