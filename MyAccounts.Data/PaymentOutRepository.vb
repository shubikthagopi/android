Imports SQLite

Public Class PaymentOutRepository
    Private ReadOnly _db As SQLiteConnection

    Public Sub New(dbPath As String)
        _db = New SQLiteConnection(dbPath)
        _db.CreateTable(Of PaymentOut)()
    End Sub

    Public Function GetAll() As List(Of PaymentOut)
        Return _db.Table(Of PaymentOut)().ToList()
    End Function

    Public Sub Add(payment As PaymentOut)
        _db.Insert(payment)
    End Sub

    Public Sub Update(payment As PaymentOut)
        _db.Update(payment)
    End Sub

    Public Sub Delete(id As Integer)
        _db.Delete(Of PaymentOut)(id)
    End Sub
End Class