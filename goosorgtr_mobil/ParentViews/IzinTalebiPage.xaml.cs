using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ParentViews;

public partial class IzinTalebiPage : ContentPage
{
    // �zin talebi i�in model s�n�f�
    public class IzinTalebi
    {
        public string OgrenciAdi { get; set; }
        public string Sinif { get; set; }
        public string OgrenciNo { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string IzinTuru { get; set; }
        public string Aciklama { get; set; }
        public bool BelgeOnaylandi { get; set; }
    }

    // �rnek ��renci listesi
    private readonly List<(string Ad, string Sinif, string No)> ogrenciler = new()
    {
        ("Ahmet Y�lmaz", "10-A", "1234"),
        ("Ay�e Demir", "11-B", "1235"),
        ("Mehmet Kaya", "9-C", "1236")
    };

    public IzinTalebiPage()
    {
        InitializeComponent();
        OgrencileriYukle();
    }

    private void OgrencileriYukle()
    {
        foreach (var ogrenci in ogrenciler)
        {
            ogrenciPicker.Items.Add(ogrenci.Ad);
        }
    }

    private void OgrenciSecim_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ogrenciPicker.SelectedIndex != -1)
        {
            var seciliOgrenci = ogrenciler[ogrenciPicker.SelectedIndex];
            sinifLabel.Text = $"S�n�f: {seciliOgrenci.Sinif}";
            ogrenciNoLabel.Text = $"��renci No: {seciliOgrenci.No}";
        }
    }

    private void TarihSecim_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (bitisTarihi.Date < baslangicTarihi.Date)
        {
            DisplayAlert("Uyar�", "Biti� tarihi ba�lang�� tarihinden �nce olamaz!", "Tamam");
            bitisTarihi.Date = baslangicTarihi.Date;
        }
    }

    private async void IzinTalebiOlustur_Clicked(object sender, EventArgs e)
    {
        if (!FormKontrol())
        {
            await DisplayAlert("Uyar�", "L�tfen t�m zorunlu alanlar� doldurunuz!", "Tamam");
            return;
        }

        var izinTalebi = new IzinTalebi
        {
            OgrenciAdi = ogrenciPicker.SelectedItem?.ToString(),
            Sinif = ogrenciler[ogrenciPicker.SelectedIndex].Sinif,
            OgrenciNo = ogrenciler[ogrenciPicker.SelectedIndex].No,
            BaslangicTarihi = baslangicTarihi.Date,
            BitisTarihi = bitisTarihi.Date,
            IzinTuru = izinTuruPicker.SelectedItem?.ToString(),
            Aciklama = izinAciklamasi.Text,
            BelgeOnaylandi = belgeOnayCheckBox.IsChecked
        };

        bool onay = await DisplayAlert(
            "Onay",
            "�zin talebini g�ndermek istiyor musunuz?",
            "Evet",
            "Hay�r");

        if (onay)
        {
            try
            {
                await IzinTalebiGonder(izinTalebi);
                await DisplayAlert("Ba�ar�l�", "�zin talebiniz ba�ar�yla olu�turuldu.", "Tamam");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", "�zin talebi olu�turulurken bir hata olu�tu.", "Tamam");
            }
        }
    }

    private bool FormKontrol()
    {
        if (ogrenciPicker.SelectedIndex == -1) return false;
        if (izinTuruPicker.SelectedIndex == -1) return false;
        if (string.IsNullOrWhiteSpace(izinAciklamasi.Text)) return false;
        if (!belgeOnayCheckBox.IsChecked) return false;
        return true;
    }

    private async Task IzinTalebiGonder(IzinTalebi izinTalebi)
    {
        // Burada API'ye izin talebi g�nderilecek
        await Task.Delay(1000); // Sim�le edilmi� i�lem s�resi
    }

    private async void Vazgec_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}