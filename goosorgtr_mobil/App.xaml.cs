using goosorgtr_mobil.Views;

namespace goosorgtr_mobil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }
    }
}
