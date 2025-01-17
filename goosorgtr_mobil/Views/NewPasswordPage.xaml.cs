namespace goosorgtr_mobil.Views;

public partial class NewPasswordPage : ContentPage
{
	public NewPasswordPage()
	{
		InitializeComponent();
	}
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(newPasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(confirmPasswordEntry.Text))
        {
            await DisplayAlert("Uyarý", "Lütfen tüm alanlarý doldurun.", "Tamam");
            return;
        }

        if (newPasswordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Uyarý", "Þifreler eþleþmiyor.", "Tamam");
            return;
        }

        // Þifre deðiþtirme iþlemi burada yapýlacak
        await DisplayAlert("Baþarýlý", "Þifreniz baþarýyla deðiþtirildi.", "Tamam");
        await Navigation.PopToRootAsync();
    }
}