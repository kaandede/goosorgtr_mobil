using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace goosorgtr_mobil.ParentViews
{
    public partial class OgretmenGorusmesiPage : ContentPage
    {
        public ObservableCollection<string> Ogrenciler { get; set; } = new ObservableCollection<string>
        {
            "Ahmet Y�lmaz", "Ay�e Demir", "Fatma Kara"
        };

        public ObservableCollection<string> Ogretmenler { get; set; } = new ObservableCollection<string>
        {
            "Ali Can (Matematik)", "Mehmet Ak (Fizik)", "Zeynep Do�an (Kimya)"
        };

        public ObservableCollection<string> Saatler { get; set; } = new ObservableCollection<string>
        {
            "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "14:00", "14:30", "15:00"
        };

        public DateTime MinimumTarih { get; set; } = DateTime.Today;

        public OgretmenGorusmesiPage()
        {
            InitializeComponent();
            BindingContext = this;

            ogrenciPicker.ItemsSource = Ogrenciler;
            ogretmenPicker.ItemsSource = Ogretmenler;
            gorusmeSaatiPicker.ItemsSource = Saatler;
        }

        private void OgrenciSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ogrenciPicker.SelectedIndex != -1)
            {
                string secilenOgrenci = Ogrenciler[ogrenciPicker.SelectedIndex];
                DisplayAlert("Se�ilen ��renci", secilenOgrenci, "Tamam");
            }
        }

        private void OgretmenSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ogretmenPicker.SelectedIndex != -1)
            {
                string secilenOgretmen = Ogretmenler[ogretmenPicker.SelectedIndex];
                ogretmenBransLabel.Text = $"Se�ilen ��retmen: {secilenOgretmen}";
            }
        }

        private void GorusmeTarihi_DateSelected(object sender, DateChangedEventArgs e)
        {
            DisplayAlert("Tarih Se�ildi", $"Se�ilen Tarih: {e.NewDate:dd/MM/yyyy}", "Tamam");
        }

        private void GorusmeSaati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gorusmeSaatiPicker.SelectedIndex != -1)
            {
                string secilenSaat = Saatler[gorusmeSaatiPicker.SelectedIndex];
                DisplayAlert("Se�ilen Saat", secilenSaat, "Tamam");
            }
        }

        private async void RandevuOlustur_Clicked(object sender, EventArgs e)
        {
            if (ogrenciPicker.SelectedIndex == -1 ||
                ogretmenPicker.SelectedIndex == -1 ||
                gorusmeSaatiPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Hata", "L�tfen gerekli alanlar� doldurunuz.", "Tamam");
                return;
            }

            string secilenOgrenci = Ogrenciler[ogrenciPicker.SelectedIndex];
            string secilenOgretmen = Ogretmenler[ogretmenPicker.SelectedIndex];
            string secilenSaat = Saatler[gorusmeSaatiPicker.SelectedIndex];
            string secilenTarih = gorusmeTarihi.Date.ToString("dd/MM/yyyy");
            string notlar = gorusmeNotuEditor.Text;

            string mesaj = $"Randevu Olu�turuldu!\n\n" +
                           $"��renci: {secilenOgrenci}\n" +
                           $"��retmen: {secilenOgretmen}\n" +
                           $"Tarih: {secilenTarih}\n" +
                           $"Saat: {secilenSaat}\n" +
                           $"Notlar: {notlar}";

            await DisplayAlert("Ba�ar�l�", mesaj, "Tamam");
        }
    }
}
