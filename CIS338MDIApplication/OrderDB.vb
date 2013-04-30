Public Class OrderDB
    Private m_orders As Collection

    Public Sub new()
        m_orders = New Collection
    End Sub

    Public Sub addOrder(ByVal myorder As Order) 'add validation here
        If(Not isValidOrderID(myorder.OrderNumber.ToString))
            Throw New InvalidOrderIDException("ID already used.")
            Else
            m_orders.Add(myorder, myorder.OrderNumber.ToString)
        End If
    End Sub

    Public Sub updateOrder(ByVal id As Integer)

    End Sub

    Public Sub removeOrder(ByVal id As Integer)

    End Sub

    Public Function getOrder(ByVal id As Integer) As Order
        Dim myorder As Order

        Return myorder
    End Function

    Public Function getNextAvailableOrderNumber As Integer
        If m_orders.Count = 0
            Return 1
        End If
        Dim result As Integer = 0
        Dim max As Integer = 0
        For Each temporder As Order In m_orders
            If max < temporder.OrderNumber
                max = temporder.OrderNumber
            End If
        Next
        result = max + 1

        Return result 
    End Function

    Public Function validateOrder(ByVal anOrder As Order, ByRef message As String) As Boolean
        Dim result As Boolean = True
        If Not isValidOrderID(anOrder.OrderNumber)
            result = False
            message += "Order Number is already used. Try using " & getNextAvailableOrderNumber & vbNewLine
        End If
        If Not anOrder.validateOrder(message)
            result = False

        End If

        Return result
    End Function

    Private Function isValidOrderID(ByVal id As Integer) As Boolean
        Dim result As Boolean = True
        If m_orders.Contains(id.ToString)
            result = False
        End If
        Return result
    End Function

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
