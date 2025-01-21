namespace goosorgtr_mobil.ParentViews;

public partial class EventPage : ContentPage
{
    private List<Event> events;

    public EventPage()
    {
        InitializeComponent();
        LoadEvents();
    }

    private void LoadEvents()
    {
        events = new List<Event>
            {
                new Event
                {
                    Title = "Rock Konseri",
                    Date = DateTime.Now.AddDays(1),
                    ImageUrl = "konser.jpg",
                    Description = "Þehrin en büyük rock gruplarý bir araya geliyor. Muhteþem bir gece sizleri bekliyor. Biletler sýnýrlý sayýda!"
                },
                new Event
                {
                    Title = "Teknoloji Zirvesi",
                    Date = DateTime.Now.AddDays(3),
                    ImageUrl = "teknoloji.jpg",
                    Description = "Yapay zeka, blockchain ve web3 teknolojilerinin konuþulacaðý, alanýnda uzman konuþmacýlarýn katýlacaðý dev zirve."
                },
                new Event
                {
                    Title = "Yoga Workshop",
                    Date = DateTime.Now.AddDays(5),
                    ImageUrl = "yoga.png",
                    Description = "Profesyonel eðitmenler eþliðinde nefes teknikleri ve meditasyon uygulamalarý. Tüm seviyeler için uygundur."
                },
                new Event
                {
                    Title = "Film Festivali",
                    Date = DateTime.Now.AddDays(7),
                    ImageUrl = "film_festival.jpg",
                    Description = "Üç gün boyunca sürecek festivalde ödüllü filmler ve yönetmenlerle söyleþiler sizleri bekliyor."
                },
                new Event
                {
                    Title = "Gastronomi Festivali",
                    Date = DateTime.Now.AddDays(10),
                    ImageUrl = "food_festival.jpg",
                    Description = "Ülkenin en iyi þefleri ve restoranlarý bir araya geliyor. Yemek workshoplarý ve tadým etkinlikleri ile dolu bir gün."
                },
                new Event
                {
                    Title = "Çocuk Tiyatrosu",
                    Date = DateTime.Now.AddDays(12),
                    ImageUrl = "children_theatre.jpg",
                    Description = "Çocuklarýnýz için eðlenceli ve eðitici bir tiyatro gösterisi. 4-12 yaþ arasý çocuklar için uygundur."
                },
                new Event
                {
                    Title = "Sergi Açýlýþý",
                    Date = DateTime.Now.AddDays(15),
                    ImageUrl = "art_exhibition.jpg",
                    Description = "Modern sanat eserlerinin sergileneceði, sanatçýlarla tanýþma fýrsatý bulabileceðiniz özel bir açýlýþ gecesi."
                },
                new Event
                {
                    Title = "Spor Turnuvasý",
                    Date = DateTime.Now.AddDays(20),
                    ImageUrl = "sports_tournament.jpg",
                    Description = "Amatör sporcular için düzenlenen basketbol turnuvasý. Katýlým ve izleyici giriþi ücretsizdir."
                }
            };

        EventsCollection.ItemsSource = events;
    }

    private void OnCardTapped(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Event selectedEvent)
        {
            ShowEventDetail(selectedEvent);
        }
    }

    private void ShowEventDetail(Event selectedEvent)
    {
        DetailTitle.Text = selectedEvent.Title;
        DetailDate.Text = selectedEvent.Date.ToString("d MMMM yyyy");
        DetailDescription.Text = selectedEvent.Description;

        // Popup'ý göster
        DetailPopup.IsVisible = true;

        // Animasyon ekle
        DetailPopup.TranslationY = 200;
        DetailPopup.FadeTo(1, 200);
        DetailPopup.TranslateTo(0, 0, 250, Easing.SpringOut);
    }

    private void OnCloseDetail(object sender, EventArgs e)
    {
        // Popup'ý gizle
        DetailPopup.FadeTo(0, 200);
        DetailPopup.TranslateTo(0, 200, 250, Easing.SpringIn)
            .ContinueWith((t) => MainThread.BeginInvokeOnMainThread(() =>
                DetailPopup.IsVisible = false));
    }

    private void OnEventSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Event selectedEvent)
        {
            ShowEventDetail(selectedEvent);
        }
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        FilterEvents();
    }

    private void OnFilterClicked(object sender, EventArgs e)
    {
        FilterEvents();
    }

    private void FilterEvents()
    {
        var filteredEvents = events.Where(e =>
            e.Date >= StartDatePicker.Date &&
            e.Date <= EndDatePicker.Date).ToList();

        EventsCollection.ItemsSource = filteredEvents;
    }
}

public class Event
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}  
