Imports SQLite

Public Class SaleRepository
    Private ReadOnly _db As SQLiteConnection

    Public Sub New(dbPath As String)
        _db = New SQLiteConnection(dbPath)
        _db.CreateTable(Of Sale)()
    End Sub

    Public Function GetAll() As List(Of Sale)
        Return _db.Table(Of Sale)().ToList()
    End Function

    Public Sub Add(sale As Sale)
        _db.Insert(sale)
    End Sub

    Public Sub Update(sale As Sale)
        _db.Update(sale)
    End Sub

    Public Sub Delete(id As Integer)
        _db.Delete(Of Sale)(id)
    End Sub
End Class