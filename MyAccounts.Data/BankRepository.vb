Imports SQLite

Public Class BankRepository
    Private ReadOnly _db As SQLiteConnection

    Public Sub New(dbPath As String)
        _db = New SQLiteConnection(dbPath)
        _db.CreateTable(Of Bank)()
    End Sub

    Public Function GetAll() As List(Of Bank)
        Return _db.Table(Of Bank)().ToList()
    End Function

    Public Sub Add(bank As Bank)
        _db.Insert(bank)
    End Sub

    Public Sub Update(bank As Bank)
        _db.Update(bank)
    End Sub

    Public Sub Delete(id As Integer)
        _db.Delete(Of Bank)(id)
    End Sub
End Class