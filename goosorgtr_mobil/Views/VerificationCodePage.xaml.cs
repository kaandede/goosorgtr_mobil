namespace goosorgtr_mobil.Views;

public partial class VerificationCodePage : ContentPage
{
    private Entry[] codeEntries;
    public VerificationCodePage()
	{
        InitializeComponent();
        codeEntries = new[] { code1, code2, code3, code4, code5, code6 };
        SetupCodeEntries();
    }
    private void SetupCodeEntries()
    {
        for (int i = 0; i < codeEntries.Length; i++)
        {
            var entry = codeEntries[i];
            entry.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.NewTextValue))
                {
                    int currentIndex = Array.IndexOf(codeEntries, s as Entry);
                    if (currentIndex < codeEntries.Length - 1)
                    {
                        codeEntries[currentIndex + 1].Focus();
                    }
                    else
                    {
                        // Tüm kodlar girildiðinde
                        VerifyCode();
                    }
                }
            };
        }
    }

    private async void VerifyCode()
    {
        string code = string.Join("", codeEntries.Select(e => e.Text));
        if (code.Length == 6)
        {
            // Kod doðrulama iþlemi burada yapýlacak
            await Navigation.PushAsync(new NewPasswordPage());
        }
    }
    
}