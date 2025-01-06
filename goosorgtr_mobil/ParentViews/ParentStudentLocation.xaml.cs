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

        // Okul butonuna t�kland���nda
        private void OnOkulClicked(object sender, EventArgs e)
        {
            KonumLabel.Text = "Bulundu�un Konum: Okul";
            ZamanLabel.Text = "Okulsa: Saat 10:30'a giri� yap�ld�.";
        }

        // Servis butonuna t�kland���nda
        private void OnServisClicked(object sender, EventArgs e)
        {
            KonumLabel.Text = "Bulundu�un Konum: Servis";
            ZamanLabel.Text = "Servisle: Saat 09:30'a bindi.";
        }
    }
}
