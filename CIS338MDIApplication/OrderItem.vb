Public Class OrderItem
    Private m_item As Item
    Private m_quantity As Integer

    Public Sub New(ByVal item As Item, ByVal quantity As Integer)
        m_item = item
        m_quantity = m_quantity
    End Sub

    Public ReadOnly Property Item As Item
        Get
            Return m_item
        End Get
    End Property

    Public Property Quantity As Integer
        Get
            Return m_quantity
        End Get
        Set(value As Integer)
            m_quantity = value
        End Set
    end property

    Public Function calcTotal As Double
        Dim value As Double = 0.0
            value = m_quantity * m_item.Price
        Return value 
    End Function
End Class
