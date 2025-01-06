using DevExpress.Maui.CollectionView;
using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentNotification : ContentPage
{
	public ParentNotification()
	{
		InitializeComponent();
		BindingContext = new NotificationViewModel();
    
    }
    protected async override void OnAppearing()
    {

        base.OnAppearing();
        await Navigation.PopToRootAsync(false);
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (BindingContext is NotificationViewModel viewModel)
        {
            viewModel.SearchText = searchBar.Text;
            viewModel.FilterNotificationsCommand.Execute(null);
        }
    }

    private void FilterButton_Clicked(object sender, EventArgs e)
    {
        // Unfocus the search bar when filter button is clicked
        searchBar.Unfocus();
    }
}