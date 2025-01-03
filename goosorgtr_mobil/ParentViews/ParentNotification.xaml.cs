using goosorgtr_mobil.ViewModels;
using DevExpress.Maui.CollectionView;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Core;
using System.Globalization;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentNotification : ContentPage
{
	public ParentNotification()
	{
		InitializeComponent();
		BindingContext = new NotificationViewModel();
        filterBottomSheet.State = BottomSheetState.HalfExpanded;
    }

    private void FilterTabHeaderTapped(object sender, ItemHeaderTappedEventArgs e)
    {
        UpdateBottomSheetState(e.Index);
    }


    void SwipeItem_Tapped(System.Object sender, SwipeItemTapEventArgs e)
    {
        this.collectionView.DeleteItem(e.ItemHandle);
    }

    private void filterTabView_ItemHeaderTapped(object sender, ItemHeaderTappedEventArgs e)
    {
        UpdateBottomSheetState(e.Index);
    }

    void UpdateBottomSheetState(int selectedIndex)
    {
        if (selectedIndex == 2)
            filterBottomSheet.State = BottomSheetState.FullExpanded;
        else
            filterBottomSheet.State = BottomSheetState.HalfExpanded;
    }
}
public class IsFilterEmptyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is FilterValueInfo filterInfo && filterInfo != null)
        {
            return filterInfo.Count == 0;
        }
        else if (value is int selectedFilterItems)
        {
            return selectedFilterItems == 0;
        }
        return true;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}