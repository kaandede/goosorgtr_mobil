namespace goosorgtr_mobil.ParentViews;

public partial class SecurityPage : ContentPage
{
	public SecurityPage()
	{
		InitializeComponent();
	}
    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        // Kullan�c�ya �ifre de�i�tirme i�lemini ba�latan bir mesaj g�ster.
        bool confirm = await DisplayAlert("�ifre De�i�tir",
            "Yeni bir �ifre belirlemek i�in y�nlendirileceksiniz. Devam etmek istiyor musunuz?",
            "Evet", "Hay�r");

        if (confirm)
        {
            // �ifre de�i�tirme sayfas�na y�nlendirme yap�labilir.
            await DisplayAlert("Bilgi", "�ifre de�i�tirme i�lemi ba�lat�ld�.", "Tamam");
        }
    }

    // Switch de�i�ikliklerini i�lemek istersen:
    private void OnTwoFactorToggled(object sender, ToggledEventArgs e)
    {
        // �ki fakt�rl� do�rulama durumu: e.Value -> true/false
        Console.WriteLine($"�ki Fakt�rl� Do�rulama Durumu: {e.Value}");
    }

    private void OnRememberSessionToggled(object sender, ToggledEventArgs e)
    {
        // Oturum bilgilerini hat�rla durumu
        Console.WriteLine($"Oturum Bilgilerini Hat�rla Durumu: {e.Value}");
    }

    private void OnLocationServicesToggled(object sender, ToggledEventArgs e)
    {
        // Konum servisleri durumu
        Console.WriteLine($"Konum Servisleri Durumu: {e.Value}");
    }
}