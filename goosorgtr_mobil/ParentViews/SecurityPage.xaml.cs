namespace goosorgtr_mobil.ParentViews;

public partial class SecurityPage : ContentPage
{
	public SecurityPage()
	{
		InitializeComponent();
	}
    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        // Kullanýcýya þifre deðiþtirme iþlemini baþlatan bir mesaj göster.
        bool confirm = await DisplayAlert("Þifre Deðiþtir",
            "Yeni bir þifre belirlemek için yönlendirileceksiniz. Devam etmek istiyor musunuz?",
            "Evet", "Hayýr");

        if (confirm)
        {
            // Þifre deðiþtirme sayfasýna yönlendirme yapýlabilir.
            await DisplayAlert("Bilgi", "Þifre deðiþtirme iþlemi baþlatýldý.", "Tamam");
        }
    }

    // Switch deðiþikliklerini iþlemek istersen:
    private void OnTwoFactorToggled(object sender, ToggledEventArgs e)
    {
        // Ýki faktörlü doðrulama durumu: e.Value -> true/false
        Console.WriteLine($"Ýki Faktörlü Doðrulama Durumu: {e.Value}");
    }

    private void OnRememberSessionToggled(object sender, ToggledEventArgs e)
    {
        // Oturum bilgilerini hatýrla durumu
        Console.WriteLine($"Oturum Bilgilerini Hatýrla Durumu: {e.Value}");
    }

    private void OnLocationServicesToggled(object sender, ToggledEventArgs e)
    {
        // Konum servisleri durumu
        Console.WriteLine($"Konum Servisleri Durumu: {e.Value}");
    }
}