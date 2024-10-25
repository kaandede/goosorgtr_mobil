using goosorgtr_mobil.Views;
using Microsoft.Maui.Handlers;

namespace goosorgtr_mobil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FirstView();
               

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
#if __ANDROID__
                 handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
