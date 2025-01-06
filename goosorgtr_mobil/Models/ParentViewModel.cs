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
                NoPhotos = 3
            });
              
            Profiles.Add(new Profile()
            {
                Name = "Öğrenci 2",
                ProfileImage = "back13.png",
                NoPhotos = 9
            });   
            Profiles.Add(new Profile()
            {
                Name = "Öğrenci 3",
                ProfileImage = "back3.png",
                NoPhotos = 11
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
