using System.Text;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    public TransactionAdd()
    {
        InitializeComponent();

        
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void Button_OnClicked_Save(object? sender, EventArgs e)
    {
        // TO-DO - Validar dados digitados
        IsValidData();
        // TO-DO - Savar no bando de dados
        // TO-DO - Fechar a tela*
    }

    private bool IsValidData()
    {
        var valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) && !double.TryParse(EntryValue.Text, out _))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido com um valor numérico!");
            valid = false;
        }

        if (valid == false)
        {
            LabelError.Text = sb.ToString();
        }
        return valid;
    }
}