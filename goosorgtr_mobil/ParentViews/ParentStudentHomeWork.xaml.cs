namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWork : ContentPage
{

    public ParentStudentHomeWork()
    {
        InitializeComponent();
 
    }


    private async void OnDerslerButtonClicked(object sender, EventArgs e)
    {
     
        await Navigation.PushAsync(new ParentStudentHomeWorkDetails());
        //await Shell.Current.GoToAsync(nameof(ParentStudentHomeWorkDetails));

    }

    private async void OnDersProgramiButtonClicked(object sender, EventArgs e)
    {
        // Ders Program� sayfas�na y�nlendirme
        await Navigation.PushAsync(new ParentStudentCourseSchedule());
  
    }
}
