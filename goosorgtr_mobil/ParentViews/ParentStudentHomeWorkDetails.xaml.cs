using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews
{
    public partial class ParentStudentHomeWorkDetails : ContentPage
    {
        private LessonDetailsViewModel _model;

        public ParentStudentHomeWorkDetails()
        {
            InitializeComponent();
            _model = new LessonDetailsViewModel();
            BindingContext = _model;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _model.DersleriDoldur();
        }
    }
}