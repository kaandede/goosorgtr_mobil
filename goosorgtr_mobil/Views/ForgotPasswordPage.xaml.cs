namespace goosorgtr_mobil.Views;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailEntry.Text))
        {
            await DisplayAlert("Uyarý", "Lütfen email adresinizi girin.", "Tamam");
            return;
        }

        // Email doðrulama kodunu gönderme iþlemi burada yapýlacak
        await Navigation.PushAsync(new VerificationCodePage());
    }
}