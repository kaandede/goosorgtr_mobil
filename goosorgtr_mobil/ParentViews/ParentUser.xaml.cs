using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentUser : ContentPage
{
  
    public ParentUser()
    {
        InitializeComponent();
        BindingContext = new ParentViewModel();
       
    }

    private async void lblBildirimAyar_Tapped(object sender, TappedEventArgs e)
    {
 
        await Shell.Current.GoToAsync(nameof(ParentNotificationSettings));

        //await Navigation.PushAsync(new ParentNotificationSettings());
    }




    private async void mesajlarlbl_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ChatListPage));
    }

    private void btnCikis_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("token",string.Empty);
        Preferences.Set("username", string.Empty);
  
        Shell.Current.GoToAsync($"//{nameof(Login)}");
    }
    private async void profilayarlar_Tapped(object sender, TappedEventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(ProfileSettingsPage));

    }
    private async void yardimdestek_Tapped(object sender, TappedEventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(Yard�mDestek));

    }
    private async void gizlilik_Tapped(object sender, TappedEventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(SecurityPage));

    }
}