using Microsoft.Maui.Controls;

namespace goosorgtr_mobil.ParentViews
{
    public partial class ParentStudentLocation : ContentPage
    {
        public ParentStudentLocation()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            await Navigation.PopToRootAsync(false);
            base.OnAppearing();

        }

        // Okul butonuna týklandýðýnda
        private void OnOkulClicked(object sender, EventArgs e)
        {
            KonumLabel.Text = "Bulunduðun Konum: Okul";
            ZamanLabel.Text = "Okulsa: Saat 10:30'a giriþ yapýldý.";
        }

        // Servis butonuna týklandýðýnda
        private void OnServisClicked(object sender, EventArgs e)
        {
            KonumLabel.Text = "Bulunduðun Konum: Servis";
            ZamanLabel.Text = "Servisle: Saat 09:30'a bindi.";
        }
    }
}
