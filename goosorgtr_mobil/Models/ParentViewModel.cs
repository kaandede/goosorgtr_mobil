using CommunityToolkit.Mvvm.ComponentModel;
using GoosClient.Services;
using System.Collections.ObjectModel;

namespace goosorgtr_mobil.Models
{
    public partial class ParentViewModel : ObservableObject
    {
        public ObservableCollection<Profile> Profiles { get; set; } = new();
        public ObservableCollection<GeneratedImage> GeneratedImages { get; set; } = new();

        public ParentViewModel()
        {

        

        }

        public async void OgrenciGetir()
        {
            if (Profiles.Count == 0)
            {
                var liste = await UserService.GetStudentsAsync();
                if (liste.Count > 0) {

                    for (int i = 0; i < 2; i++)
                    {
                        Profiles.Add(new Profile()
                        {
                            Name = liste[i].NameSurname,
                            NoPhotos = int.Parse(liste[i].StudentNumber),
                            Konum = "Okula Giriş Yapıldı",
                            Descreption = "Servisten İndi",
                            Saat = "08:30",
                            ProfileImage = "kiz_ogrenci_1.jpg",
                            Id = liste[i].Id,
                            userId = liste[i].UserId,
                            
                        });

                    }
                }
            
            }

        }


    }
}
