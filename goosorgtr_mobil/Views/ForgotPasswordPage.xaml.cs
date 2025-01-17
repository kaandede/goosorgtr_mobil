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
            await DisplayAlert("Uyar�", "L�tfen email adresinizi girin.", "Tamam");
            return;
        }

        // Email do�rulama kodunu g�nderme i�lemi burada yap�lacak
        await Navigation.PushAsync(new VerificationCodePage());
    }
}