using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews
{
    [QueryProperty(nameof(StudentId), "StudentId")]
    public partial class ExamsPage : ContentPage
    {
        private int _studentId;
        public int StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                LoadExamsForStudent();
            }
        }

        private readonly ExamPageViewModel _viewModel;

        public ExamsPage(ExamPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        private async void LoadExamsForStudent()
        {
            if (_studentId > 0)
            {
                await _viewModel.LoadStudentExams();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var savedStudentId = Preferences.Get("SelectedStudentId", 0);
            if (savedStudentId > 0)
            {
                _studentId = savedStudentId;
                await _viewModel.LoadStudentExams();
            }
        }
    }
}