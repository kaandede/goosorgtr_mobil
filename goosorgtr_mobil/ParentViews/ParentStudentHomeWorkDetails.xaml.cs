namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWorkDetails : ContentPage
{
    public ParentStudentHomeWorkDetails()
    {
        InitializeComponent();
        BindingContext = new ParentStudentHomeWorkViewModel();
    }
    private async void OnDersProgramiClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ders Programý", "Ders Programý detaylarý gösterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new DersProgramiPage());
    }

    private async void OnOdevlerClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ödevler", "Ödevler detaylarý gösterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new OdevlerPage());
    }

    private async void OnDersNotlariClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ders Notlarý", "Ders Notlarý detaylarý gösterilecek.", "Tamam");
        // Alternatif: await Navigation.PushAsync(new DersNotlariPage());
    }
}
