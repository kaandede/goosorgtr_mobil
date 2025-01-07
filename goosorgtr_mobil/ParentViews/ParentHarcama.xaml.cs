using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentHarcama : ContentPage
{
	public ParentHarcama()
	{
		InitializeComponent();
        BindingContext = new HarcamaListViewModel();
    }

    protected async override void OnAppearing()
    {
        await Navigation.PopToRootAsync();
        base.OnAppearing();
    }
}