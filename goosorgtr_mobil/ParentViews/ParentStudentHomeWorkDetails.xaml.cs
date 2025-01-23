using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWorkDetails : ContentPage
{
    public ParentStudentHomeWorkDetails()
    {
        InitializeComponent();



        var viewModel = new LessonDetailsViewModel();

        BindingContext = viewModel;
    }

   async private void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ExamsPage));
    }

    async private void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GradesPage));
    }

    async private void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ReportCardPage));
    }
}
