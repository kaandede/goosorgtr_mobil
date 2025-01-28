using goosorgtr_mobil.Models;
using goosorgtr_mobil.ViewModels;
using goosorgtr_mobil.Views;
using static System.Net.Mime.MediaTypeNames;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentMainPage : ContentPage
{
    public ParentViewModel _parentViewModel;
    private GradePageViewModel _grandewievmodel;

    public ParentMainPage()
    {
        InitializeComponent();
        _parentViewModel = new ParentViewModel();
        _grandewievmodel = new GradePageViewModel(); // Initialize GradePageViewModel
        BindingContext = _parentViewModel;
        mrbKullaniciMesaj.Text = $"Merhaba, {Preferences.Get("username", string.Empty)}";
    }
    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync(false);


        var token = Preferences.Get("token", string.Empty);

        if (string.IsNullOrEmpty(token))
        {
            //token yoksa-giriþ yapýlmamýþsa - giriþe yönlendir
            await Shell.Current.GoToAsync("Login");
        }

        //kullanýcý rolünü al

        //if veli veli ise bu þekilde çaðýr
        var role = Preferences.Get("UserRole", string.Empty);


        if (role == "Parent")
        {
           _parentViewModel.OgrenciGetir(0,true);
        }
        else
        {
            //veli deðilse örnek için 50 ile çaðýr
            _parentViewModel.OgrenciGetir(50);
        }


     
        base.OnAppearing();

    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(Login));
    }

    private async void User_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ParentUser));
        //await Navigation.PushAsync(new ParentUser());
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ServisHarita());
    }

    private async void Tapduyuru_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new DuyuruPage());
    }
    private async void Tapharcama_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ParentHarcama());
    }
    private async void ogrenciListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var ogrenci = (Profile)e.CurrentSelection[0];
            Preferences.Set("seciliOgrenciUserId", ogrenci.userId.ToString());
            Preferences.Set("seciliOgrenciId", ogrenci.studentId.ToString());

            // Seçilen öðrencinin notlarýný çek
            await _grandewievmodel.LoadStudentGrades(int.Parse(ogrenci.studentId.ToString()));
        }
    }
}