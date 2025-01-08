using CommunityToolkit.Mvvm.ComponentModel;
using GoosClient.Services;
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

            //Profiles.Add(new Profile()
            //{
            //    Name = "Burak YILMAZ",
            //    ProfileImage = "https://cdn.pixabay.com/photo/2024/08/14/17/34/ai-generated-8969238_640.jpg",
            //    NoPhotos = 3,
            //    Konum = "Yemekhane",
            //    Descreption = "Öğle Yemeği Molası",
            //    Saat = "12:30"
            //});

            //Profiles.Add(new Profile()
            //{
            //    Name = "Kazım YILMAZ",
            //    ProfileImage = "https://media.istockphoto.com/id/1148934322/tr/foto%C4%9Fraf/evde-kamera-g%C3%BCl%C3%BCmseyen-g%C3%BCzel-okul-%C3%A7ocuk.jpg?s=170667a&w=0&k=20&c=0avvoMNAUaFdcZ_auXm7VDi1Y6o9ggLTHDsS0qZa_EQ=",
            //    NoPhotos = 9,
            //    Konum = "Sınıf",
            //    Descreption = "Ders İşleniyor",
            //    Saat = "09:30"
            //});
            //Profiles.Add(new Profile()
            //{
            //    Name = "Ebru Yılmaz",
            //    ProfileImage = "https://media.istockphoto.com/id/1148601093/tr/foto%C4%9Fraf/g%C3%BCzel-g%C3%BCl%C3%BCmseyen-sar%C4%B1%C5%9F%C4%B1n-k%C4%B1z-7-8-ya%C5%9F%C4%B1nda-okul-%C3%BCniformal%C4%B1-%C3%A7ocuk-portresi-arka-plan-g%C3%BCne%C5%9Fli.jpg?s=170667a&w=0&k=20&c=fnT76yAe14ET7IiAzMj-pfF0P1iJ95gtUZEmxuh5H_k=",
            //    NoPhotos = 11,
            //    Konum = "Okula Giriş Yapıldı",
            //    Descreption = "Servisten İndi",
            //    Saat = "08:30"
            //});

            //GeneratedImages.Add(new GeneratedImage()
            //{
            //    ImagePath = "dotnet_bot.png",
            //    MainKeyword = "Castle",
            //    Keyword = new List<string>
            //    {
            //        "Epic, hill, mountain, trees, blue sky"
            //    }
            //});

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
                            ProfileImage = "kiz_ogrenci_1.jpg"

                        });

                    }
                }
            
            }

        }


    }
}
