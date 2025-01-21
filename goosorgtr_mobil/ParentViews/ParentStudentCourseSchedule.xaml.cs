using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentCourseSchedule : ContentPage
{
    public CourseScheduleViewModel _model;
    public ParentStudentCourseSchedule()
    {
        InitializeComponent();
        _model = new CourseScheduleViewModel();
        BindingContext = _model;

    }
    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync();
        await _model.DersProgramiDoldur();
        base.OnAppearing();
    }
}
