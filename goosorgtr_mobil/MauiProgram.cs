using CommunityToolkit.Maui;
using DevExpress.Maui;
using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;
using goosorgtr_mobil.ViewModels;
using goosorgtr_mobil.Views;
using Microsoft.Extensions.Logging;

namespace goosorgtr_mobil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
               .UseMauiApp<App>()
                .UseDevExpress()
                .UseMauiCommunityToolkit()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressControls()
                .UseMauiMaps()
                .UseDevExpressCollectionView()
                .UseDevExpressDataGrid()
                .UseDevExpressTreeView()
                .UseDevExpressEditors()
  

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Nexa-ExtraLight.ttf", "NexaLight");
                    fonts.AddFont("Nexa-Heavy.ttf", "NexaHeavy");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Aller_Rg.ttf", "AllerRg");
                    fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                    fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                });


            builder.Services.AddSingleton<ParentViewModel>();
            builder.Services.AddTransient<ParentMainPage>();
            builder.Services.AddTransient<ParentUser>();
            builder.Services.AddTransient<ParentNotification>();
            builder.Services.AddTransient<ParentStudentHomeWorkDetails>();
            builder.Services.AddTransient<ParentStudentLocation>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<FirstView>();
            builder.Services.AddTransient<Profile>();
            builder.Services.AddTransient<GeneratedImage>();
            builder.Services.AddTransient<ParentNotificationSettings>();
            builder.Services.AddTransient<NotificationSettingsViewModel>();
            builder.Services.AddTransient<ParentNotificationSettings>();
   
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IPreferencesService, PreferencesService>();
          

#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
