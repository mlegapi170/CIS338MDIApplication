Public Class Item
    Private m_name As String
    Private m_price As Double

    Public Sub New(ByVal name As String, ByVal price As Double)
        m_name = name
        m_price = price
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return m_name
        End Get
    End Property

    Public ReadOnly Property Price As Double
        Get
            Return m_price
        End Get
    End Property
End Class
