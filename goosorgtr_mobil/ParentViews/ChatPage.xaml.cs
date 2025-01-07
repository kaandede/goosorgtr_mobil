using goosorgtr_mobil.ViewModels;

namespace goosorgtr_mobil.ParentViews;

public partial class ChatPage : ContentPage
{
	public ChatPage()
	{
		InitializeComponent();
		BindingContext = new MesajViewModel();
	}
}