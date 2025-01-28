using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoosClient.Models;
using GoosClient.Services;
using goosorgtr_mobil.ParentViews;
using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ViewModels
{
    public partial class AnnouncementViewModel : BaseViewModel
    {

        public ObservableCollection<DuyuruModel> Announcements { get; set; } = new();
        public ObservableCollection<string> Categories { get; set; }

        [ObservableProperty]
        private string _selectedCategory;
 

        public AnnouncementViewModel()
        {
       

            Categories = new ObservableCollection<string> { "Tümü", "Spor", "Eğitim", "Kültür" };
            SelectedCategory = "Tümü";

      
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

        [RelayCommand]
        private async void ItemTapped(DuyuruModel selectedAnnouncement)
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
