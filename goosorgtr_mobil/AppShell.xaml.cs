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
            Routing.RegisterRoute(nameof(ParentNotificationSettings), typeof(ParentNotificationSettings));            
            Routing.RegisterRoute(nameof(FirstView), typeof(FirstView));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
        }
      
        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //    Shell.Current.GoToAsync($"//{nameof(Login)}");
        //}
    }
}
