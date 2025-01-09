using CommunityToolkit.Mvvm.ComponentModel;

namespace goosorgtr_mobil.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {     

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;
        public bool IsNotLoading => !isLoading;

        [ObservableProperty]
        bool isRefreshing;

    }
}
