using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Login_Button_Clicked(object sender, EventArgs e)
    {
         Application.Current.MainPage = new ParentMainPage();
    }

    private async void OnLabelTapped(object sender, EventArgs e)
    {
        // Action to perform when the label is tapped
        await DisplayAlert("Týklandý!", "Giriþ Sayfasýna Yönlendiriliyorsunuz.", "Tamam");
        Application.Current.MainPage = new FirstView();
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}