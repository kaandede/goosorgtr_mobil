using goosorgtr_mobil.Models;
using goosorgtr_mobil.Views;
using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentMainPage : ContentPage
{
	public ObservableCollection<Profile> Profiles { get; set; }
	public ObservableCollection<GeneratedImage> GeneratedImages { get; set; }

	public ParentMainPage()
	{
		InitializeComponent();
		LoadData();
		BindingContext = this;
	}

    private void LoadData()
    {
		Profiles = new ObservableCollection<Profile>
		{
			new Profile
			{
				Name = "Name",
				ProfileImage="dotnet_bot.png",
				NoPhotos= 12
			}
		};

        GeneratedImages = new ObservableCollection<GeneratedImage>
        {
            new GeneratedImage
            {
                ImagePath = "dotnet_bot.png",
				MainKeyword="Castle",
				Keyword = new List<string>
				{
					"Epic, hill, mountain, trees, blue sky"
				}
            }
        };
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Login();
    }
}