using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentMainPage : ContentPage
{


    public ParentMainPage()
	{
		InitializeComponent();
        BindingContext = new ParentViewModel();
    }
    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync(false);
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