namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWork : ContentPage
{

    public ParentStudentHomeWork()
    {
        InitializeComponent();
    }

    private async void OnDerslerButtonClicked(object sender, EventArgs e)
    {
        // Dersler sayfasýna yönlendirme
        await Navigation.PushAsync(new ParentStudentHomeWorkDetails());
    }

    private async void OnDersProgramiButtonClicked(object sender, EventArgs e)
    {
        // Ders Programý sayfasýna yönlendirme
        await Navigation.PushAsync(new ParentStudentHomeWork());
    }
}
