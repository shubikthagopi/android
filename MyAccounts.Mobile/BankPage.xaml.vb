Imports Microsoft.Maui.Controls

Partial Public Class BankPage
    Inherits ContentPage

    Private ReadOnly repo As New BankRepository("myaccounts.db3")

    Public Sub New()
        InitializeComponent()
        LoadBank()
    End Sub

    Private Sub OnSaveBank(sender As Object, e As EventArgs)
        Dim entry As New Bank With {
            .EntryDate = BankDatePicker.Date,
            .OpeningBalance = Double.Parse(OpeningEntry.Text),
            .Deposit = Double.Parse(DepositEntry.Text)
        }
        repo.Add(entry)
        LoadBank()
    End Sub

    Private Sub LoadBank()
        BankList.ItemsSource = repo.GetAll()
    End Sub
End Class