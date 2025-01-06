using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews
{
    public partial class AnnouncementDetailPage : ContentPage
    {
        public AnnouncementDetailPage(Announcement selectedAnnouncement)
        {
            InitializeComponent();
            BindingContext = selectedAnnouncement; // Seçilen duyuru objesini baðla
        }
    }
}
