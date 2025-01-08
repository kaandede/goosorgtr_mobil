using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWorkDetails : ContentPage
{
    public ParentStudentHomeWorkViewModel _parentStudentHomeWorkViewModel;

    public ParentStudentHomeWorkDetails()
    {
        InitializeComponent();
        BindingContext = _parentStudentHomeWorkViewModel;
    }

    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync();
        base.OnAppearing();
    }
    private async void OnDersProgramiClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ders Program�", "Ders Program� detaylar� g�sterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new DersProgramiPage());
    }

    private async void OnOdevlerClicked(object sender, EventArgs e)
    {
        await DisplayAlert("�devler", "�devler detaylar� g�sterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new OdevlerPage());
    }

    private async void OnDersNotlariClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ders Notlar�", "Ders Notlar� detaylar� g�sterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new DersNotlariPage());
    }
}
