namespace goosorgtr_mobil.Views;

public partial class FirstView : ContentPage
{
	public FirstView()
	{
		InitializeComponent();
	}
    private async void First_Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Giri�", "Giri� yapma sayfas�na y�nlendirileceksiniz.", "Tamam");
        Application.Current.MainPage = new Login();
    }
}