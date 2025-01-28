namespace goosorgtr_mobil.ParentViews;

public partial class YardimDestek : ContentPage
{
	public YardimDestek()
	{
		InitializeComponent();
	}
    private async void OnSendClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(subjectEntry.Text) || string.IsNullOrWhiteSpace(messageEditor.Text))
        {
            await DisplayAlert("Uyarı", "Lütfen konu ve mesaj alanlarını doldurun.", "Tamam");
            return;
        }

        // Burada gerçek uygulamada mesajı sunucuya gönderme işlemi yapılır
        await DisplayAlert("Başarılı", "Mesajınız başarıyla gönderildi. En kısa sürede size dönüş yapılacaktır.", "Tamam");

        // Form alanlarını temizle
       subjectEntry.Text = string.Empty;
       messageEditor.Text = string.Empty;
    }
}