using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;
using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentMainPage : ContentPage
{
    ParentViewModel parentViewModel = new ParentViewModel();

    public ParentMainPage(ParentViewModel parentViewModel)
	{
		InitializeComponent();
        BindingContext = parentViewModel;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
  
        await Shell.Current.GoToAsync($"//{nameof(Login)}");
    }

    private void User_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ParentUser(parentViewModel));
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