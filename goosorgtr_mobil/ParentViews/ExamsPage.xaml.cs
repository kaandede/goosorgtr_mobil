using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews
{
    public partial class ExamsPage : ContentPage
{
    ExamPageViewModel _viewModel;
        
    public ExamsPage()
    {
            InitializeComponent();
        BindingContext = _viewModel = new ExamPageViewModel();
    }

        protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadExams();
    }
}
}