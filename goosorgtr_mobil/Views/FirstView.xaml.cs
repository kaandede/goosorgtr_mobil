using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.Views;

public partial class FirstView : ContentPage
{
    ParentViewModel parentViewModel = new ParentViewModel();

    public FirstView(ParentViewModel parentViewModel)
	{
		InitializeComponent();
        BindingContext = parentViewModel;

    }
    private async void First_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login(parentViewModel));
    }
   
}