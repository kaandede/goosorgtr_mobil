using goosorgtr_mobil.Views;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentUser : ContentPage
{
	public ParentUser()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {

        Shell.Current.GoToAsync($"//{nameof(Login)}");
    }

    private void geributon_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ParentMainPage)}");
    }
}