using CommunityToolkit.Mvvm.ComponentModel;
using GoosClient.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace goosorgtr_mobil.Models
{
    public partial class ParentViewModel : ObservableObject
    {
        [ObservableProperty]
        private int selectedStudentId;

        public ObservableCollection<Profile> Profiles { get; set; } = new();
        public ObservableCollection<GeneratedImage> GeneratedImages { get; set; } = new();

        public ParentViewModel()
        {

        

        }

        public async void OgrenciGetir(int parentId, bool userIdMi=false)
        {
            try
            {
                Profiles.Clear();
                var liste = await UserService.GetStudentsAsync(parentId, userIdMi);//

                if (liste?.Count > 0)
                {
                    foreach (var student in liste.Take(2))
                    {
                        Profiles.Add(new Profile
                        {
                            Name = student.NameSurname,
                            NoPhotos = int.Parse(student.StudentNumber),
                            Konum = "Okula Giriş Yapıldı",
                            Descreption = "Servisten İndi",
                            Saat = "08:30",
                            ProfileImage = "kiz_ogrenci_1.jpg",
                            Id = student.Id,
                            studentId = student.StudentId,
                            userId = student.UserId,
                            classId = student.ClassId.ToString()
                        });
                    }
                    
                    // İlk öğrenciyi seç ve kaydet
                    if (liste.Count == 1)
                    {
                        SelectedStudentId = liste[0].StudentId;
                        Preferences.Set("SelectedStudentId", SelectedStudentId);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"OgrenciGetir Error: {ex}");
            }
        }

    }
}
