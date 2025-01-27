namespace goosorgtr_mobil.ParentViews;
using goosorgtr_mobil.ViewModels;

    public partial class GradesPage : ContentPage
    {
        GradePageViewModel _viewModel;

        public GradesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GradePageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        await _viewModel.LoadGrades();
        }
    }
