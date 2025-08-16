Imports Microsoft.Maui.Controls

Partial Public Class SalesPage
    Inherits ContentPage

    Private ReadOnly repo As New SaleRepository("myaccounts.db3")

    Public Sub New()
        InitializeComponent()
        LoadSales()
    End Sub

    Private Sub OnSaveSale(sender As Object, e As EventArgs)
        Dim sale As New Sale With {
            .SaleDate = SaleDatePicker.Date,
            .Amount = Double.Parse(SaleAmountEntry.Text)
        }
        repo.Add(sale)
        LoadSales()
    End Sub

    Private Sub LoadSales()
        SalesList.ItemsSource = repo.GetAll()
    End Sub
End Class