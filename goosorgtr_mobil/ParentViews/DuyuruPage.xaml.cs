using GoosClient.Models;
using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews
{
    public partial class DuyuruPage : ContentPage
    {
        public AnnouncementViewModel _model;
        public DuyuruPage()
        {
            InitializeComponent();
            _model = new AnnouncementViewModel();
            BindingContext =_model;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await _model.DuyurulariDoldur();
        }

        private async void OnAnnouncementSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedAnnouncement = e.CurrentSelection[0] as DuyuruModel;
                if (selectedAnnouncement != null)
                {
                    await Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
                }

                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
