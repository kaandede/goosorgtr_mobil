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
                    Description = "�ehrin en b�y�k rock gruplar� bir araya geliyor. Muhte�em bir gece sizleri bekliyor. Biletler s�n�rl� say�da!"
                },
                new Event
                {
                    Title = "Teknoloji Zirvesi",
                    Date = DateTime.Now.AddDays(3),
                    ImageUrl = "teknoloji.jpg",
                    Description = "Yapay zeka, blockchain ve web3 teknolojilerinin konu�ulaca��, alan�nda uzman konu�mac�lar�n kat�laca�� dev zirve."
                },
                new Event
                {
                    Title = "Yoga Workshop",
                    Date = DateTime.Now.AddDays(5),
                    ImageUrl = "yoga.png",
                    Description = "Profesyonel e�itmenler e�li�inde nefes teknikleri ve meditasyon uygulamalar�. T�m seviyeler i�in uygundur."
                },
                new Event
                {
                    Title = "Film Festivali",
                    Date = DateTime.Now.AddDays(7),
                    ImageUrl = "film_festival.jpg",
                    Description = "�� g�n boyunca s�recek festivalde �d�ll� filmler ve y�netmenlerle s�yle�iler sizleri bekliyor."
                },
                new Event
                {
                    Title = "Gastronomi Festivali",
                    Date = DateTime.Now.AddDays(10),
                    ImageUrl = "food_festival.jpg",
                    Description = "�lkenin en iyi �efleri ve restoranlar� bir araya geliyor. Yemek workshoplar� ve tad�m etkinlikleri ile dolu bir g�n."
                },
                new Event
                {
                    Title = "�ocuk Tiyatrosu",
                    Date = DateTime.Now.AddDays(12),
                    ImageUrl = "children_theatre.jpg",
                    Description = "�ocuklar�n�z i�in e�lenceli ve e�itici bir tiyatro g�sterisi. 4-12 ya� aras� �ocuklar i�in uygundur."
                },
                new Event
                {
                    Title = "Sergi A��l���",
                    Date = DateTime.Now.AddDays(15),
                    ImageUrl = "art_exhibition.jpg",
                    Description = "Modern sanat eserlerinin sergilenece�i, sanat��larla tan��ma f�rsat� bulabilece�iniz �zel bir a��l�� gecesi."
                },
                new Event
                {
                    Title = "Spor Turnuvas�",
                    Date = DateTime.Now.AddDays(20),
                    ImageUrl = "sports_tournament.jpg",
                    Description = "Amat�r sporcular i�in d�zenlenen basketbol turnuvas�. Kat�l�m ve izleyici giri�i �cretsizdir."
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

        // Popup'� g�ster
        DetailPopup.IsVisible = true;

        // Animasyon ekle
        DetailPopup.TranslationY = 200;
        DetailPopup.FadeTo(1, 200);
        DetailPopup.TranslateTo(0, 0, 250, Easing.SpringOut);
    }

    private void OnCloseDetail(object sender, EventArgs e)
    {
        // Popup'� gizle
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
