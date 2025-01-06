namespace goosorgtr_mobil.ParentViews;

public partial class ParentNotificationSettings : ContentPage
{
	public ParentNotificationSettings()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        var s = Shell.Current.Navigation;

        base.OnAppearing();
    }

    private async void geribtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}