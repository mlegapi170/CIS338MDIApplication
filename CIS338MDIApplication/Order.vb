Public Class Order
    Private m_orderNum As Integer
    Private m_serverName As String
    Private m_timeStamp As Date
    Private m_itemList As Collection

    Public Sub new()
        Me.m_orderNum = -1
        Me.m_serverName = "Error"
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
        value = calculateTotal * CoffeeConstants.SALESTAX
        Return value 
    End Function

    Public Sub addItem(myItem As Item)
        If(m_itemList.Contains(myItem.Name))
            Throw New InvalidItemIDException(myItem.Name + " is already in this order.")
        End If
        m_itemList.Add(myItem, myItem.Name)
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


<Serializable()>  _
Public Class InvalidItemIDException
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
