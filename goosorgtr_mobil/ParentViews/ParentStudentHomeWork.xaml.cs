namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWork : ContentPage
{

    public ParentStudentHomeWork()
    {
        InitializeComponent();
    }
    protected async override void OnAppearing()
    {

        base.OnAppearing();
        await Navigation.PopToRootAsync(false);
    }

    private async void OnDerslerButtonClicked(object sender, EventArgs e)
    {
     
        //await Navigation.PushAsync(new ParentStudentHomeWorkDetails());
        await Shell.Current.GoToAsync(nameof(ParentStudentHomeWorkDetails));

    }

    private async void OnDersProgramiButtonClicked(object sender, EventArgs e)
    {
        // Ders Programý sayfasýna yönlendirme
        await Navigation.PushAsync(new ParentStudentCourseSchedule());
  
    }
}
