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
            await DisplayAlert("Uyar�", "L�tfen t�m alanlar� doldurun.", "Tamam");
            return;
        }

        if (newPasswordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Uyar�", "�ifreler e�le�miyor.", "Tamam");
            return;
        }

        // �ifre de�i�tirme i�lemi burada yap�lacak
        await DisplayAlert("Ba�ar�l�", "�ifreniz ba�ar�yla de�i�tirildi.", "Tamam");
        await Navigation.PopToRootAsync();
    }
}