using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews;

public partial class DersDetay2 : ContentPage
{
    public ParentStudentHomeWorkViewModel _parentStudentHomeWorkViewModel;
    public DersDetay2()
	{
		InitializeComponent();
        BindingContext = _parentStudentHomeWorkViewModel;

    }
}