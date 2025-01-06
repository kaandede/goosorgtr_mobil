using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;
using Microsoft.Maui.Controls;

namespace goosorgtr_mobil.ParentViews
{
    public partial class Duyuru : ContentPage
    {
        public Duyuru()
        {
            InitializeComponent();
        }

        // Seçilen duyurunun detay sayfasýna gitmek için
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                // Seçilen duyuruyu al
                var selectedAnnouncement = e.CurrentSelection[0] as Announcement;

                if (selectedAnnouncement != null)
                {
                    // Detay sayfasýna git
                    Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
                }

                // Seçimi sýfýrla (CollectionView'de görünüm temizliði için)
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
