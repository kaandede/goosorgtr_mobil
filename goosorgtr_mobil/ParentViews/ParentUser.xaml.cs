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

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(Login)}");
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

   

    
}