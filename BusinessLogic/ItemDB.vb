Public Class ItemDB
    Private m_items As Collection

    Public Sub New()
        m_items = New Collection

        Dim temp As New Item("Antigua",5.95)
        m_items.Add(temp,temp.Name)
        temp = New Item("Apanas",11.95)
        m_items.Add(temp,temp.Name)
        temp = New Item("Bantu",9.92)
        m_items.Add(temp,temp.Name)
        temp = New Item("Colombia",11.52)
        m_items.Add(temp,temp.Name)
        temp = New Item("Costa Rica",13.60)
        m_items.Add(temp,temp.Name)
        temp = New Item("Ethiopia",9.52)
        m_items.Add(temp,temp.Name)
        temp = New Item("French Roast",10.72)
        m_items.Add(temp,temp.Name)
        temp = New Item("Huehuetenango",10.95)
        m_items.Add(temp,temp.Name)
        temp = New Item("Kenya",13.60)
        m_items.Add(temp,temp.Name)
        temp = New Item("Mexico",11.52)
        m_items.Add(temp,temp.Name)
        temp = New Item("Morning Ed.",9.92)
        m_items.Add(temp,temp.Name)
        temp = New Item("Nepenthe",11.52)
        m_items.Add(temp,temp.Name)
        temp = New Item("Sumatra",9.92)
        m_items.Add(temp,temp.Name)
        temp = New Item("Yemen",8.96)
        m_items.Add(temp,temp.Name)
        temp = New Item("Yemen Mocha",18.52)
        m_items.Add(temp,temp.Name)
        temp = New Item("Zimbabwe",11.52)
        m_items.Add(temp,temp.Name)
    End Sub

    Public ReadOnly Property ItemCollection As Collection
        Get
            Return m_items
        End Get
    End Property
End Class
