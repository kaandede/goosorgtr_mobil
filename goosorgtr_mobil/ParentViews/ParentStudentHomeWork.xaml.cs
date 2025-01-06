namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWork : ContentPage
{

    public ParentStudentHomeWork()
    {
        InitializeComponent();
    }

    private async void OnDerslerButtonClicked(object sender, EventArgs e)
    {
        // Dersler sayfas�na y�nlendirme
        await Navigation.PushAsync(new ParentStudentHomeWorkDetails());
    }

    private async void OnDersProgramiButtonClicked(object sender, EventArgs e)
    {
        // Ders Program� sayfas�na y�nlendirme
        await Navigation.PushAsync(new ParentStudentHomeWork());
    }
}
