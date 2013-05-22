Public Class Controller
    Private myItemDB As ItemDB
    Private myOrderDB As OrderDB

    Public Sub New()
        myItemDB = New ItemDB
        myOrderDB = New OrderDB


    End Sub

    Public Function addOrder(ByVal anOrder As Order) As boolean
        Try
            myOrderDB.addOrder(anOrder.copy)
            Return true
        Catch ex As Exception
            Return false
        Finally

        End Try
        
    End Function 

    Public Sub updateOrder(ByVal anOrder As Order)
        myOrderDB.updateOrder(anOrder.copy)
    End Sub

    Public Function getOrder(ByVal id As Integer) As Order
        Try
            Return myOrderDB.getOrder(id).copy
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        
    End Function

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

    ReadOnly Property Orders As Collection
        Get
            Return myOrderDB.getAllOrders
        End Get
    End Property

End Class
