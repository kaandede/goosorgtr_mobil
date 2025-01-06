using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentCourseSchedule : ContentPage
{
    public ParentStudentCourseSchedule()
    {
        InitializeComponent();
        BindingContext = new CourseScheduleViewModel();
    }
}
