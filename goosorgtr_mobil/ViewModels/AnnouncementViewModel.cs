using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using goosorgtr_mobil.Models;
using System.Windows.Input;
using goosorgtr_mobil.ParentViews;
using GoosClient.Services;
using GoosClient.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace goosorgtr_mobil.ViewModels
{
    public partial class AnnouncementViewModel : BaseViewModel
    {


        public ObservableCollection<DuyuruModel> Announcements { get; set; } = new();
        public ObservableCollection<string> Categories { get; set; }
    
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
       

            Categories = new ObservableCollection<string> { "Tümü", "Spor", "Eğitim", "Kültür" };
            SelectedCategory = "Tümü";

            ItemTappedCommand = new Command<DuyuruModel>(OnItemTapped);

        
        }

        private void FilterAnnouncements()
        {
            //if (SelectedCategory == "Tümü")
            //    Announcements = new ObservableCollection<Announcement>(allAnnouncements);
            //else
            //    Announcements = new ObservableCollection<Announcement>(
            //        allAnnouncements.Where(a => a.Category == SelectedCategory));

            //OnPropertyChanged(nameof(Announcements));
        }


        private async void OnItemTapped(DuyuruModel selectedAnnouncement)
        {
            if (selectedAnnouncement != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AnnouncementDetailPage(selectedAnnouncement));
            }
        }

        [RelayCommand]
        public async Task DuyurulariDoldur()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Announcements.Any()) Announcements.Clear();
                var duyurular = await UserService.GetDuyurularAsync();
                foreach (var duyuru in duyurular) Announcements.Add(duyuru);

                OnPropertyChanged(nameof(Announcements));
           
            }
            catch (Exception ex)
            {
               
                await Shell.Current.DisplayAlert("Hata", "Sistemde bir hata oluştu", "Tamam");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }

         
           
        }

    }
}
