using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;
using goosorgtr_mobil.Views;

namespace goosorgtr_mobil
{
    public partial class AppShell : Shell
    {
        ParentViewModel parentViewModel = new ParentViewModel();

        public AppShell(ParentViewModel parentViewModel)
        {
            InitializeComponent();
            BindingContext = parentViewModel;
       
          
      
            Routing.RegisterRoute(nameof(ParentUser), typeof(ParentUser));   
            Routing.RegisterRoute(nameof(ParentStudentHomeWorkDetails), typeof(ParentStudentHomeWorkDetails));
            Routing.RegisterRoute(nameof(DersDetay2), typeof(DersDetay2));
            Routing.RegisterRoute(nameof(ParentNotificationSettings), typeof(ParentNotificationSettings));            
            Routing.RegisterRoute(nameof(FirstView), typeof(FirstView));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(ChatListPage), typeof(ChatListPage));
            Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
            //Routing.RegisterRoute(nameof(ServisHarita), typeof(ServisHarita));
            Routing.RegisterRoute(nameof(NewChatPage), typeof(NewChatPage));
            Routing.RegisterRoute(nameof(YardımDestek), typeof(YardımDestek));
            Routing.RegisterRoute(nameof(ProfileSettingsPage), typeof(ProfileSettingsPage));
            Routing.RegisterRoute(nameof(SecurityPage), typeof(SecurityPage));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("token", string.Empty);
            Preferences.Set("username", string.Empty);
            Shell.Current.GoToAsync($"//{nameof(Login)}");
        }
    }
}
