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
            Profiles.Clear();

            var liste = await UserService.GetStudentsAsync(50);//veli id
            if (liste.Count > 0)
            {
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
                        studentId = liste[i].StudentId,
                        userId = liste[i].UserId
                    });
                }
            }
        }


    }
}
