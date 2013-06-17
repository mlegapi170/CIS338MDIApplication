Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class OrderDB
    Private Shared cn As SqlCeConnection
    Private Shared cnString As String = "Data Source=..\..\..\Database\OrderDatabase.sdf"
    'Private Shared cnString As String = "Data Source=.\OrderDatabase.sdf"

    Public Shared Sub addOrder(ByVal orderID As Integer, ByVal servername As String,ByVal ordertotal As Double, ByVal timestamp As Date) 
        Open
        Dim sql = "Insert into Orders (OrderID,ServerName,OrderTotal,Date) values ("
        sql += "'" & orderID & "','"
        sql += servername & "','"
        sql += ordertotal.ToString & "','"
        sql += timestamp.ToString & "')"
        Dim insertcommand As New SqlCeCommand(sql,cn)
        insertcommand.ExecuteNonQuery
        Close
    End Sub

    Public Shared Sub addLine(ByVal orderID As Integer, ByVal item As String, ByVal quantity As Integer)
        Open
        Dim sql = "Insert into OrderItem (OrderID,Item,Quantity) values ('"
        sql += orderID.ToString & "','"
        sql += item & "','"
        sql += quantity.ToString & "')"
        Dim insertcommand As New SqlCeCommand(sql,cn)
        insertcommand.ExecuteNonQuery
        Close
    End Sub

    Public Shared Sub removeOrder(ByVal id As Integer)
        Open
        Dim sql = "Delete From Orders Where OrderID = '" & id &"'"
        Dim deletecommand As New SqlCeCommand(sql,cn)
        deletecommand.ExecuteNonQuery
        Close
    End Sub

    'needs to be closed by controller
    Public Shared Function getOrder(ByVal id As Integer) As SqlCeDataReader
        Open
        Dim sql = "Select * From Orders,OrderItem Where Orders.OrderID = OrderItem.OrderID and Orders.OrderID = '" & id &"'"
        Dim selectcommand As new SqlCeCommand(sql,cn)
        Dim myreader As SqlCeDataReader = selectcommand.ExecuteReader
        'cn.Close
        Return myreader 
    End Function

    'needs to be closed by controller
    public Shared Function getAllOrders() As SqlCeDataReader
        Open
        Dim sql = "Select * From Orders,OrderItem Where Orders.OrderID = OrderItem.OrderID"
        Dim selectcommand As new SqlCeCommand(sql,cn)
        Dim myreader As SqlCeDataReader = selectcommand.ExecuteReader
        'cn.Close
        Return myreader 
    End Function

    Public Shared Function containsID(ByVal id As Integer) As Boolean
        Open
        Dim sql = "Select * From Orders Where OrderID = '" & id &"'"
        Dim selectcommand As new SqlCeCommand(sql,cn)
        Dim count As Integer = selectcommand.ExecuteScalar
        Close
        Return count > 0
    End Function

    Public Shared Sub Close()
        cn.Close
    End Sub

    Public Shared Sub Open()
        cn = New SqlCeConnection
        cn.ConnectionString = cnString
        cn.Open
    End Sub

End Class
