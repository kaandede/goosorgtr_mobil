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

    
    void SwipeItem_Tapped(System.Object sender, SwipeItemTapEventArgs e)
    {
        this.collectionView.DeleteItem(e.ItemHandle);
    }

    private void btnNotificationSetting_Clicked(object sender, EventArgs e)
    {

    }
}