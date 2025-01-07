using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goosorgtr_mobil.Models
{
    public partial class ParentViewModel : ObservableObject
    {
        public ObservableCollection<Profile> Profiles { get; set; } = new();
        public ObservableCollection<GeneratedImage> GeneratedImages { get; set; } = new();

        public ParentViewModel()
        {
            Profiles.Add(new Profile()
            {
                Name = "Öğrenci 1",
                ProfileImage = "back14.png",
                NoPhotos = 3,
                Konum = "Yemekhane",
                Descreption = "Öğle Yemeği Molası",
                Saat = "12:30"
            });
              
            Profiles.Add(new Profile()
            {
                Name = "Öğrenci 2",
                ProfileImage = "back13.png",
                NoPhotos = 9,
                Konum = "Sınıf",
                Descreption = "Ders İşleniyor",
                Saat = "09:30"
            });   
            Profiles.Add(new Profile()
            {
                Name = "Öğrenci 3",
                ProfileImage = "back3.png",
                NoPhotos = 11,
                Konum = "Okula Giriş Yapıldı",
                Descreption = "Servisten İndi",
                Saat = "08:30"
            });

            GeneratedImages.Add(new GeneratedImage()
            {
                ImagePath = "dotnet_bot.png",
                MainKeyword = "Castle",
                Keyword = new List<string>
                {
                    "Epic, hill, mountain, trees, blue sky"
                }
            });

        }
    }
}
