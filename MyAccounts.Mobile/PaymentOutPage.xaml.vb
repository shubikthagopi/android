Imports Microsoft.Maui.Controls

Partial Public Class PaymentOutPage
    Inherits ContentPage

    Private ReadOnly repo As New PaymentOutRepository("myaccounts.db3")

    Public Sub New()
        InitializeComponent()
        LoadPayments()
    End Sub

    Private Sub OnSavePayment(sender As Object, e As EventArgs)
        Dim payment As New PaymentOut With {
            .PayDate = PayDatePicker.Date,
            .Supplier = SupplierEntry.Text,
            .Mode = ModePicker.SelectedItem.ToString(),
            .Amount = Double.Parse(PayAmountEntry.Text)
        }
        repo.Add(payment)
        LoadPayments()
    End Sub

    Private Sub LoadPayments()
        PaymentsList.ItemsSource = repo.GetAll()
    End Sub
End Class