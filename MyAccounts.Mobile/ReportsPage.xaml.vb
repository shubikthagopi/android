Imports Microsoft.Maui.Controls

Partial Public Class ReportsPage
    Inherits ContentPage

    Private ReadOnly salesRepo As New SaleRepository("myaccounts.db3")
    Private ReadOnly payRepo As New PaymentOutRepository("myaccounts.db3")
    Private ReadOnly bankRepo As New BankRepository("myaccounts.db3")

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub OnRefreshReport(sender As Object, e As EventArgs)
        Dim totalSales = salesRepo.GetAll().Sum(Function(s) s.Amount)
        Dim totalPayments = payRepo.GetAll().Sum(Function(p) p.Amount)
        Dim totalBank = bankRepo.GetAll().Sum(Function(b) b.Deposit)

        SalesTotalLabel.Text = totalSales.ToString("F2")
        PaymentsTotalLabel.Text = totalPayments.ToString("F2")
        BankTotalLabel.Text = totalBank.ToString("F2")
        NetAmountLabel.Text = (totalSales - totalPayments + totalBank).ToString("F2")
    End Sub
End Class