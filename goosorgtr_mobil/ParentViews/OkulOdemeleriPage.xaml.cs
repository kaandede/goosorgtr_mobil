using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ParentViews;

public partial class OkulOdemeleriPage : ContentPage
{
    // Ödeme bilgilerini tutacak model
    public class OdemeBilgisi
    {
        public string TaksitAdi { get; set; }
        public string SonOdemeTarihi { get; set; }
        public decimal Tutar { get; set; }
        public bool OdendiMi { get; set; }
    }

    // Observable collection ile ödemeleri tutuyoruz
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
        // Örnek ödeme verileri
        Odemeler = new ObservableCollection<OdemeBilgisi>
        {
            new OdemeBilgisi
            {
                TaksitAdi = "Eylül Taksiti",
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
                TaksitAdi = "Kasým Taksiti",
                SonOdemeTarihi = "15.11.2023",
                Tutar = 2500,
                OdendiMi = false
            }
        };
    }

    // Ödeme butonuna týklandýðýnda çalýþacak metod
    private async void OdemeYap_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var odemeBilgisi = button?.BindingContext as OdemeBilgisi;

        if (odemeBilgisi != null)
        {
            bool answer = await DisplayAlert(
                "Ödeme Onayý",
                $"{odemeBilgisi.TaksitAdi} için {odemeBilgisi.Tutar:C2} ödeme yapmak istiyor musunuz?",
                "Evet",
                "Hayýr");

            if (answer)
            {
                try
                {
                    // Burada ödeme iþlemleri yapýlacak
                    // API çaðrýsý, veritabaný iþlemleri vb.
                    await OdemeIsleminiGerceklestir(odemeBilgisi);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Hata", "Ödeme iþlemi sýrasýnda bir hata oluþtu.", "Tamam");
                }
            }
        }
    }

    private async Task OdemeIsleminiGerceklestir(OdemeBilgisi odemeBilgisi)
    {
        // Burada gerçek ödeme iþlemleri yapýlacak
        await Task.Delay(1000); // Simüle edilmiþ iþlem süresi

        // Baþarýlý ödeme sonrasý
        odemeBilgisi.OdendiMi = true;
        await DisplayAlert("Baþarýlý", "Ödeme iþleminiz baþarýyla gerçekleþtirildi.", "Tamam");
    }

    // Öðrenci seçildiðinde çalýþacak metod
    private void OgrenciSecim_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker?.SelectedIndex != -1)
        {
            // Seçilen öðrenciye göre ödemeleri güncelle
            OdemeleriYukle();
        }
    }

    // Toplam borç hesaplama
    private decimal ToplamBorcHesapla()
    {
        return Odemeler?.Where(o => !o.OdendiMi).Sum(o => o.Tutar) ?? 0;
    }
}



