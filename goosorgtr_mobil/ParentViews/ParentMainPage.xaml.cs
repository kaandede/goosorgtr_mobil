using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;
using System.Collections.ObjectModel;

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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       Navigation.PushAsync(new service());
    }

    private void Tapduyuru_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Duyuru());
    }
    private void Tapharcama_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new harcama());
    }
}