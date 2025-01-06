using System.Collections.ObjectModel;
using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ViewModels
{
    public class AnnouncementViewModel
    {
        public ObservableCollection<Announcement> Announcements { get; set; }

        public AnnouncementViewModel()
        {
            // Dummy veriler
            Announcements = new ObservableCollection<Announcement>
            {
                new Announcement { Title = "Duyuru 1", Date = "06.01.2025", Details = "Detay 1" },
                new Announcement { Title = "Duyuru 2", Date = "07.01.2025", Details = "Detay 2" }
            };
        }
    }
}
