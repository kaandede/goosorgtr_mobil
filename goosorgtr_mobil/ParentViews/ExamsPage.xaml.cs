using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews
{

    public partial class ExamsPage : ContentPage
    {


        private readonly ExamPageViewModel _viewModel;

        public ExamsPage(ExamPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
            LoadExamsForStudent();
        }

        private async void LoadExamsForStudent()
        {

            await _viewModel.LoadStudentExams();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadStudentExams();

        }
    }
}