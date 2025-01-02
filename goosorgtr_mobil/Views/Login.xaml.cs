using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.Views;

public partial class Login : ContentPage
{
    ParentViewModel parentViewModel = new ParentViewModel();    

    public Login(ParentViewModel parentViewModel)
	{
		InitializeComponent();
        BindingContext = parentViewModel;
    }


   private bool LoginIsSuccessful()
    {
        return true;
    }

    private void Login_Button_Clicked(object sender, EventArgs e)
    {
         
        if (LoginIsSuccessful())
        {
            Shell.Current.GoToAsync($"//{nameof(ParentMainPage)}");

        }
    }


}