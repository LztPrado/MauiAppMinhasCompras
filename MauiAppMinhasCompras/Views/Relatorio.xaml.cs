using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    public Relatorio()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            List<Produto> produtos = await App.Db.GetAll();

            double alimentos = produtos
                .Where(p => p.Categoria == "Alimentos")
                .Sum(p => p.Total);

            double higiene = produtos
                .Where(p => p.Categoria == "Higiene")
                .Sum(p => p.Total);

            double limpeza = produtos
                .Where(p => p.Categoria == "Limpeza")
                .Sum(p => p.Total);

            double outros = produtos
                .Where(p => p.Categoria == "Outros")
                .Sum(p => p.Total);

            double total = produtos.Sum(p => p.Total);

            lbl_alimentos.Text = $"Alimentos: {alimentos:C}";
            lbl_higiene.Text = $"Higiene: {higiene:C}";
            lbl_limpeza.Text = $"Limpeza: {limpeza:C}";
            lbl_outros.Text = $"Outros: {outros:C}";
            lbl_total.Text = $"Total geral: {total:C}";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}