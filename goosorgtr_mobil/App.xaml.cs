﻿using goosorgtr_mobil.Models;
using goosorgtr_mobil.ParentViews;
using goosorgtr_mobil.Views;
using Microsoft.Maui.Handlers;

namespace goosorgtr_mobil
{
    public partial class App : Application
    {
        ParentViewModel parentViewModel = new ParentViewModel();    
        public App(ParentViewModel parentViewModel)
        {
            InitializeComponent();

            MainPage = new AppShell(parentViewModel);
           


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
