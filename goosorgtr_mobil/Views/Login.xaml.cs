using GoosClient.Services;
using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.Views;

public partial class Login : ContentPage
{
    ParentViewModel parentViewModel = new ParentViewModel();

    public Login(ParentViewModel parentViewModel)
    {
        InitializeComponent();
        BindingContext = parentViewModel;
    }


    private async void Login_Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtParola.Text))
        {
            await Shell.Current.DisplayAlert("Hata", "Kullanýcý adý ve parola giriniz", "Tamam");
        }

        var sonuc = await UserService.Login(txtKullaniciAdi.Text, txtParola.Text);

        //var examlar = await UserService.GetExamAsync();

        if (sonuc)
        {
            Preferences.Set("username", txtKullaniciAdi.Text);

            await Shell.Current.GoToAsync($"//{nameof(ParentMainPage)}");
        }
        else
        {
            await Shell.Current.DisplayAlert("Hata", "Kullanýcý adý veya parola hatalý", "Tamam");
        }



    }


}