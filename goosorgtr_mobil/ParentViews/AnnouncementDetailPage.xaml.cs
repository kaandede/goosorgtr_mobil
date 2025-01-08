using GoosClient.Models;
using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews
{
    public partial class AnnouncementDetailPage : ContentPage
    {
        public AnnouncementDetailPage(DuyuruModel selectedAnnouncement)
        {
            InitializeComponent();
            BindingContext = selectedAnnouncement;
        }
    }
}
