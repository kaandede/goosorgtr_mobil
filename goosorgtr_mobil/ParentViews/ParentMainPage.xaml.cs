using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;
using static System.Net.Mime.MediaTypeNames;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentMainPage : ContentPage
{
    public ParentViewModel _parentViewModel;

    public ParentMainPage()
	{
		InitializeComponent();
        _parentViewModel = new ParentViewModel();
        BindingContext = _parentViewModel;

        mrbKullaniciMesaj.Text = $"Merhaba, {Preferences.Get("username",string.Empty)}";
    }
    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync(false);
        _parentViewModel.OgrenciGetir();
        base.OnAppearing();
    
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
  
        await Shell.Current.GoToAsync($"//{nameof(Login)}");
    }

    private async void User_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ParentUser));
        //await Navigation.PushAsync(new ParentUser());
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       await Navigation.PushAsync(new service());
    }

    private async void Tapduyuru_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Duyuru());
    }
    private async void Tapharcama_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ParentHarcama());
    }
}