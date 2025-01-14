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

    protected  override void OnAppearing()
    {
 
         base.OnAppearing();
    }
  
    private async void Ondersdetay2Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DersDetay2));

    }
   
}
