﻿using goosorgtr_mobil.Views;

namespace goosorgtr_mobil
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }
       
    }

}
