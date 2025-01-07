using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ChatPage : ContentPage
{
	public ChatPage(string ChatId)
	{
		InitializeComponent();
		BindingContext = new MesajViewModel();
	}
}