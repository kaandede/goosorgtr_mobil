using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ParentViews;

public partial class OkulOdemeleriPage : ContentPage
{
    // �deme bilgilerini tutacak model
    public class OdemeBilgisi
    {
        public string TaksitAdi { get; set; }
        public string SonOdemeTarihi { get; set; }
        public decimal Tutar { get; set; }
        public bool OdendiMi { get; set; }
    }

    // Observable collection ile �demeleri tutuyoruz
    private ObservableCollection<OdemeBilgisi> _odemeler;
    public ObservableCollection<OdemeBilgisi> Odemeler
    {
        get => _odemeler;
        set
        {
            _odemeler = value;
            OnPropertyChanged(nameof(Odemeler));
        }
    }

    public OkulOdemeleriPage()
    {
        InitializeComponent();
        OdemeleriYukle();
        BindingContext = this;
    }

    private void OdemeleriYukle()
    {
        // �rnek �deme verileri
        Odemeler = new ObservableCollection<OdemeBilgisi>
        {
            new OdemeBilgisi
            {
                TaksitAdi = "Eyl�l Taksiti",
                SonOdemeTarihi = "15.09.2023",
                Tutar = 2500,
                OdendiMi = false
            },
            new OdemeBilgisi
            {
                TaksitAdi = "Ekim Taksiti",
                SonOdemeTarihi = "15.10.2023",
                Tutar = 2500,
                OdendiMi = false
            },
            new OdemeBilgisi
            {
                TaksitAdi = "Kas�m Taksiti",
                SonOdemeTarihi = "15.11.2023",
                Tutar = 2500,
                OdendiMi = false
            }
        };
    }

    // �deme butonuna t�kland���nda �al��acak metod
    private async void OdemeYap_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var odemeBilgisi = button?.BindingContext as OdemeBilgisi;

        if (odemeBilgisi != null)
        {
            bool answer = await DisplayAlert(
                "�deme Onay�",
                $"{odemeBilgisi.TaksitAdi} i�in {odemeBilgisi.Tutar:C2} �deme yapmak istiyor musunuz?",
                "Evet",
                "Hay�r");

            if (answer)
            {
                try
                {
                    // Burada �deme i�lemleri yap�lacak
                    // API �a�r�s�, veritaban� i�lemleri vb.
                    await OdemeIsleminiGerceklestir(odemeBilgisi);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Hata", "�deme i�lemi s�ras�nda bir hata olu�tu.", "Tamam");
                }
            }
        }
    }

    private async Task OdemeIsleminiGerceklestir(OdemeBilgisi odemeBilgisi)
    {
        // Burada ger�ek �deme i�lemleri yap�lacak
        await Task.Delay(1000); // Sim�le edilmi� i�lem s�resi

        // Ba�ar�l� �deme sonras�
        odemeBilgisi.OdendiMi = true;
        await DisplayAlert("Ba�ar�l�", "�deme i�leminiz ba�ar�yla ger�ekle�tirildi.", "Tamam");
    }

    // ��renci se�ildi�inde �al��acak metod
    private void OgrenciSecim_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker?.SelectedIndex != -1)
        {
            // Se�ilen ��renciye g�re �demeleri g�ncelle
            OdemeleriYukle();
        }
    }

    // Toplam bor� hesaplama
    private decimal ToplamBorcHesapla()
    {
        return Odemeler?.Where(o => !o.OdendiMi).Sum(o => o.Tutar) ?? 0;
    }
}



