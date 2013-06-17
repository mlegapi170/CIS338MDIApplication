Imports Database
Imports System.Data.SqlServerCe
Public Class Controller
    Private myItemDB As Menu

    Public Sub New()
        myItemDB = New Menu


    End Sub

    Public Function addOrder(ByVal anOrder As Order) As boolean
        If OrderDB.containsID(anOrder.OrderNumber)
            Return False
        End If
        OrderDB.addOrder(anOrder.OrderNumber, anOrder.ServerName, anOrder.calculateTotalWithTax, anOrder.TimeStamp)
        For Each line As OrderItem In anOrder.getAllItems
            OrderDB.addLine(anOrder.OrderNumber, line.Item.Name, line.Quantity)
        Next
        Return True
    End Function 

    Public Sub updateOrder(ByVal anOrder As Order)
        Me.removeOrder(anOrder.OrderNumber)
        Me.addOrder(anOrder)
    End Sub

    Public Function getOrder(ByVal id As Integer) As Order
        If not OrderDB.containsID(id)
            Throw New InvalidOrderIDException("Order ID not found.")
        End If
        Dim myreader As SqlCeDataReader = OrderDB.getOrder(id)
        Dim anOrder As New Order
        While(myreader.Read)
            anOrder.OrderNumber = myreader("OrderID")
            anOrder.ServerName = myreader("Servername")
            anOrder.TimeStamp = myreader("Date")
            anOrder.addItem(myItemDB.ItemCollection.Item(myreader("Item")), myreader("Quantity"))
        End While
        OrderDB.Close
        Return anOrder
    End Function

    Public Function removeOrder(ByVal id As Integer) As Boolean
        If Not OrderDB.containsID(id)
            Return false
        End If
        OrderDB.removeOrder(id)
        Return true
    End Function

    Public Function validateOrder(ByVal anOrder As Order, ByRef message As String)
        Dim result As Boolean = True
        If Not anOrder.validateOrder(message)
            result = False
        End If
        Return result
    End Function

    Public Function getNextAvailableNumber As Integer
        Dim myorders As Collection = Me.Orders
        If myorders.Count = 0
            Return 1
        End If
        Dim result As Integer = 0
        Dim max As Integer = 0
        For Each temporder As Order In myorders
            If max < temporder.OrderNumber
                max = temporder.OrderNumber
            End If
        Next
        result = max + 1

        Return result 
    End Function

    Public Function orderExists(ByVal id As Integer) As Boolean
        Return OrderDB.containsID(id)
    End Function

    ReadOnly Property Menu As Menu
        Get
            Return myItemDB 
        End Get
    End Property

    ReadOnly Property Orders As Collection
        Get
            Dim myOrders As New Collection
            Dim myOrderReader As SqlCeDataReader = OrderDB.getAllOrders
            While (myOrderReader.Read)
                Dim key As String = myOrderReader("OrderID")
                If Not myOrders.Contains(key) Then
                    Dim anOrder As New Order
                    anOrder.OrderNumber = myOrderReader("OrderID")
                    anOrder.ServerName = myOrderReader("Servername")
                    anOrder.TimeStamp = myOrderReader("Date")
                    myOrders.Add(anOrder,anOrder.OrderNumber)
                End If
                myOrders.Item(key).addItem(myItemDB.ItemCollection.Item(myOrderReader("Item")), myOrderReader("Quantity"))
            End While
            OrderDB.Close
            Return myOrders
        End Get
    End Property

    <Serializable()>  _
Public Class InvalidOrderIDException
    Inherits System.Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
    End Sub

    Public Sub New( _
        ByVal info As System.Runtime.Serialization.SerializationInfo, _
        ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class

End Class
