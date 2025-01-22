using GoosClient.Models;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWorkDetails : ContentPage
{
    public ParentStudentHomeWorkDetails()
    {
        InitializeComponent();



        var viewModel = new ParentStudentHomeWorkViewModel();

        BindingContext = viewModel;
    }
}
