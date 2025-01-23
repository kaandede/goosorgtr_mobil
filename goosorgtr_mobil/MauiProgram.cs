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
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(Microsoft.Maui.Controls.Maps.Map),
                        typeof(Microsoft.Maui.Maps.Handlers.MapHandler));
                })
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
            builder.Services.AddSingleton<AnnouncementViewModel>();
            builder.Services.AddScoped<ParentMainPage>();
            builder.Services.AddScoped<ParentNotification>();
            builder.Services.AddScoped<ParentStudentHomeWorkDetails>();
            builder.Services.AddScoped<ParentStudentLocation>();
            builder.Services.AddScoped<Login>();
            builder.Services.AddScoped<FirstView>();
            builder.Services.AddScoped<Profile>();
            builder.Services.AddScoped<GeneratedImage>();
            builder.Services.AddScoped<ParentNotificationSettings>();
            builder.Services.AddScoped<NotificationSettingsViewModel>();
            builder.Services.AddScoped<ParentNotificationSettings>();
            builder.Services.AddScoped<ChatListPage>();
            builder.Services.AddScoped<ChatPage>();
            builder.Services.AddScoped<ChatConversation>();
            builder.Services.AddScoped<ChatMessage>();
            builder.Services.AddScoped<MesajlasmaViewModel>();
            builder.Services.AddScoped<MesajViewModel>();
            //builder.Services.AddScoped<DersDetay2>();
            builder.Services.AddTransient<ServisHarita>();
            builder.Services.AddTransient<ProfileSettingsPage>();
            builder.Services.AddTransient<YardımDestek>();
            builder.Services.AddTransient<SecurityPage>();
            builder.Services.AddTransient<ForgotPasswordPage>();
            builder.Services.AddTransient<VerificationCodePage>();
            builder.Services.AddTransient<NewPasswordPage>();
            builder.Services.AddTransient<OkulOdemeleriPage>();
            builder.Services.AddTransient<IzinTalebiPage>(); 
            builder.Services.AddTransient<OgretmenGorusmesiPage>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IPreferencesService, PreferencesService>();
            builder.Services.AddTransient<ExamsPage>(); 
            builder.Services.AddTransient<ReportCardPage>();
            builder.Services.AddTransient<GradesPage>();

            //#if ANDROID
            //    builder.ConfigureMauiHandlers(handlers =>
            //    {
            //        handlers.AddHandler(typeof(Microsoft.Maui.Controls.Maps.Map),
            //            typeof(Microsoft.Maui.Maps.Handlers.MapHandler));
            //    });
            //#endif
#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
