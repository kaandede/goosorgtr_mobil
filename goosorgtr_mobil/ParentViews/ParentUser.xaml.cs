using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentUser : ContentPage
{
	public ParentUser(ParentViewModel parentViewModel)
	{
		InitializeComponent();
		BindingContext = parentViewModel;
    }
}