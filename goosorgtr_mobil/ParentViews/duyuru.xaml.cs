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

        // Se�ilen duyurunun detay sayfas�na gitmek i�in
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                // Se�ilen duyuruyu al
                var selectedAnnouncement = e.CurrentSelection[0] as Announcement;

                if (selectedAnnouncement != null)
                {
                    // Detay sayfas�na git
                    Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
                }

                // Se�imi s�f�rla (CollectionView'de g�r�n�m temizli�i i�in)
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
