using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using goosorgtr_mobil.Models;
using System.Windows.Input;
using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.ViewModels
{
    public class AnnouncementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Announcement> Announcements { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        private ObservableCollection<Announcement> allAnnouncements;
        public ICommand ItemTappedCommand { get; }
        private string selectedCategory;
        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    FilterAnnouncements();
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        public AnnouncementViewModel()
        {
            // Örnek duyurular
            allAnnouncements = new ObservableCollection<Announcement>
            {
                new Announcement { Title = "Spor Etkinliği", Date = "2025-01-10", Category = "Spor", Details = "Bu etkinlik stadyumda yapılacaktır." },
                new Announcement { Title = "Eğitim Semineri", Date = "2025-01-15", Category = "Eğitim", Details = "Seminer çevrimiçi yapılacaktır." },
                new Announcement { Title = "Tiyatro Gösterisi", Date = "2025-01-20", Category = "Kültür", Details = "Tiyatro salonunda gösterilecektir." },
            };

            Announcements = new ObservableCollection<Announcement>(allAnnouncements);

            Categories = new ObservableCollection<string> { "Tümü", "Spor", "Eğitim", "Kültür" };
            SelectedCategory = "Tümü";

            ItemTappedCommand = new Command<Announcement>(OnItemTapped);
        }

        private void FilterAnnouncements()
        {
            if (SelectedCategory == "Tümü")
                Announcements = new ObservableCollection<Announcement>(allAnnouncements);
            else
                Announcements = new ObservableCollection<Announcement>(
                    allAnnouncements.Where(a => a.Category == SelectedCategory));

            OnPropertyChanged(nameof(Announcements));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnItemTapped(Announcement selectedAnnouncement)
        {
            if (selectedAnnouncement != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
            }
        }
    }
}
