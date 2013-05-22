Public Class Order
    Private m_orderNum As Integer
    Private m_serverName As String
    Private m_timeStamp As Date
    Private m_itemList As Collection

    Public Sub new()
        Me.m_orderNum = -1
        Me.m_serverName = nothing
        Me.m_timeStamp = Now
        m_itemList = New Collection
    End Sub

    Property OrderNumber As Integer
        Get
            Return m_orderNum
        End Get
        Set(value As Integer)
            m_orderNum = value
        End Set
    End Property

    Property ServerName As String
        Get
            Return m_serverName
        End Get
        Set(value As String)
            m_serverName = value
        End Set
    End Property

    Property TimeStamp As Date
        Get
            Return m_timeStamp
        End Get
        Set(value As Date)
            m_timeStamp = value
        End Set
    End Property

    Public Function calculateTotal() As Double
        Dim value As Double = 0
        For Each myItem As OrderItem In m_itemList
            value += myItem.calcTotal
        Next
        Return value
    End Function

    Public Function calculateTotalWithTax() As Double
        Dim value As Double = 0
        value = calculateTotal + calculateTotal * CoffeeConstants.SALESTAX
        Return value 
    End Function

    Public Sub addItem(myItem As Item)
        If(m_itemList.Contains(myItem.Name))
            Throw New InvalidItemIDException(myItem.Name + " is already in this order.")
        End If
        m_itemList.Add(New OrderItem(myItem, 0), myItem.Name)
    End Sub

    Public Function getItem(id As String) As OrderItem
        Dim myitem As OrderItem
        If(Not m_itemList.Contains(id))
            Throw New InvalidItemIDException(id + " is not in this order.")
        End If
        myitem = m_itemList.Item(id)

        Return myitem
    End Function

    Public Sub removeItem(id As String)
        If(Not m_itemList.Contains(id))
            Throw New InvalidItemIDException(id + " is not in this order.")
        End If
        m_itemList.Remove(id)
    End Sub

    Public Function getAllItems() As Collection
        Return m_itemList
    End Function

    Public Function validateOrder(ByRef message As String) As Boolean
        Dim result As Boolean = True
        If m_serverName = Nothing
            result = False
            message += "Server name required." + vbNewLine
        End If
        If m_itemList.Count = 0 or calculateTotalWithTax < 0.01
            result = False
            message += "Order contains no items." + vbNewLine
        End If
        If m_orderNum <= 0
            result = False
            message += "Order number must be greater than 0." + vbNewLine
        End If
        For Each anOrderItem As OrderItem In m_itemList
            If anOrderItem.Quantity <= 0
                result = False
                message += anOrderItem.Item.Name & " quantity is 0 or less." & vbNewLine
            End If
        Next
        Return result
    End Function

    Public Function copy As Order
        Dim newOrder As New Order
        With newOrder
            .ServerName = ServerName
            .OrderNumber = OrderNumber
            .TimeStamp = TimeStamp
        End With

        For Each anOrderItem As OrderItem In getAllItems
            newOrder.m_itemList.Add(anOrderItem.copy, anOrderItem.Item.Name)
        Next

        Return newOrder
    End Function

<Serializable()>  _
Public Class InvalidItemIDException
    Inherits System.Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message & " Change the qunatity if you want to add more of this item.")
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
