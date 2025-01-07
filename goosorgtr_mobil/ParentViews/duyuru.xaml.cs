using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews
{
    public partial class Duyuru : ContentPage
    {
        public Duyuru()
        {
            InitializeComponent();
        }

        private async void OnAnnouncementSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedAnnouncement = e.CurrentSelection[0] as Announcement;
                if (selectedAnnouncement != null)
                {
                    await Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
                }

                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
