using goosorgtr_mobil.ViewModels;
using DevExpress.Maui.CollectionView;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentNotification : ContentPage
{
	public ParentNotification()
	{
		InitializeComponent();
		BindingContext = new NotificationViewModel();
	}

    void SwipeItem_Tapped(System.Object sender, SwipeItemTapEventArgs e)
    {
        this.collectionView.DeleteItem(e.ItemHandle);
    }
}