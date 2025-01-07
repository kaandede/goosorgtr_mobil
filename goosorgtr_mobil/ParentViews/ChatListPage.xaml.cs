using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ChatListPage : ContentPage
{
	public ChatListPage()
	{
		InitializeComponent();
		BindingContext = new MesajlasmaViewModel();

    }
}