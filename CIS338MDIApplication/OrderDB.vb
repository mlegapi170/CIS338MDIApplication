Public Class OrderDB
    Private m_orders As Collection

    Public Sub new()
        m_orders = New Collection
    End Sub

    Public Sub addOrder(ByVal myorder As Order)

    End Sub

    Public Sub updateOrder(ByVal id As Integer)

    End Sub

    Public Sub removeOrder(ByVal id As Integer)

    End Sub

    Public Function getOrder(ByVal id As Integer) As Order
        Dim myorder As Order

        Return myorder
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
