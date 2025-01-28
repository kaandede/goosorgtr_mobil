namespace goosorgtr_mobil.ParentViews;
using goosorgtr_mobil.ViewModels;

[QueryProperty(nameof(StudentId), "StudentId")]
public partial class GradesPage : ContentPage
{
    private int _studentId;
    public int StudentId
    {
        get => _studentId;
        set
        {
            _studentId = value;
            LoadGradesForStudent();
        }
    }

    private readonly GradePageViewModel _viewModel;

    public GradesPage(GradePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private async void LoadGradesForStudent()
    {
        if (_studentId > 0)
        {
            await _viewModel.LoadStudentGrades(_studentId);
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var savedStudentId = Preferences.Get("SelectedStudentId", string.Empty);
        if (savedStudentId == string.Empty)
        {
            _studentId = int.Parse(savedStudentId);
            await _viewModel.LoadStudentGrades(_studentId);
        }
    }
}