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
