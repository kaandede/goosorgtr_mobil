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

            RegisterRoutes();

            // Navigation event handler'ı ekle
            Navigating += AppShell_Navigating;
            Navigated += AppShell_Navigated;
        }

        private void RegisterRoutes()
        {
            // Mevcut route kayıtlarınız
            Routing.RegisterRoute(nameof(ParentUser), typeof(ParentUser));
            Routing.RegisterRoute(nameof(ParentStudentHomeWorkDetails), typeof(ParentStudentHomeWorkDetails));
            Routing.RegisterRoute(nameof(ParentNotificationSettings), typeof(ParentNotificationSettings));
            Routing.RegisterRoute(nameof(FirstView), typeof(FirstView));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(ChatListPage), typeof(ChatListPage));
            Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
            Routing.RegisterRoute(nameof(NewChatPage), typeof(NewChatPage));
            Routing.RegisterRoute(nameof(YardimDestek), typeof(YardimDestek));
            Routing.RegisterRoute(nameof(ProfileSettingsPage), typeof(ProfileSettingsPage));
            Routing.RegisterRoute(nameof(SecurityPage), typeof(SecurityPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(NewPasswordPage), typeof(NewPasswordPage));
            Routing.RegisterRoute(nameof(VerificationCodePage), typeof(VerificationCodePage));
            Routing.RegisterRoute(nameof(OkulOdemeleriPage), typeof(OkulOdemeleriPage));
            Routing.RegisterRoute(nameof(OgretmenGorusmesiPage), typeof(OgretmenGorusmesiPage));
            Routing.RegisterRoute(nameof(IzinTalebiPage), typeof(IzinTalebiPage));
            Routing.RegisterRoute(nameof(ExamsPage), typeof(ExamsPage));
            Routing.RegisterRoute(nameof(ReportCardPage), typeof(ReportCardPage));
            Routing.RegisterRoute("GradesPage", typeof(GradesPage));
        }

        private void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            if (IsMainPage(e.Target.Location.OriginalString))
            {
                SetValue(Shell.TabBarIsVisibleProperty, true);
            }
        }

        private void AppShell_Navigated(object sender, ShellNavigatedEventArgs e)
        {
            // Navigation tamamlandıktan sonra TabBar kontrolü
            if (IsMainPage(e.Current.Location.OriginalString))
            {
                SetValue(Shell.TabBarIsVisibleProperty, true);
            }
        }

        private bool IsMainPage(string route)
        {
            var mainPages = new[]
            {
                "ParentMainPage",
                "ParentStudentLocation",
                "ParentNotification",
                "ParentStudentHomeWork",
                
            };

            return mainPages.Any(page => route.Contains(page));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("token", string.Empty);
            Preferences.Set("username", string.Empty);
            Shell.Current.GoToAsync(nameof(Login));
        }
    }
}