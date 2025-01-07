using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;


namespace goosorgtr_mobil.ParentViews
{
    public partial class ParentStudentLocation : ContentPage
    {
       public List<Pin> Pins { get; set; } = new List<Pin>();

        public ParentStudentLocation()
        {
            InitializeComponent();
                        //var position = new Location(39.89783152118657, 32.686864328835384); 
            //GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.1)));
        }

        protected async override void OnAppearing()
        {
            await Navigation.PopToRootAsync(false);
            base.OnAppearing();

           


            var zaferkolej = new Location(39.8975372596863, 32.67921761534151);
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(zaferkolej, Distance.FromKilometers(0.1)));

            Pins.Add(new Pin
            {
                Address = "Zafer Koleji",
                Location = zaferkolej,
                Type = PinType.Place,
                Label = "Öðrenci Þuan Okulda"
            });

            var mevkolej = new Location(39.89783152118657, 32.686864328835384);
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(mevkolej, Distance.FromKilometers(0.1)));

            Pins.Add(new Pin
            {
                Address = "MEV Koleji",
                Location = mevkolej,
                Type = PinType.Place,
                Label = "Öðrenci Þuan Okulda"
            });
            //var pin = new Pin
            //{
            //    Address = "MEV Koleji",
            //    Location = position,
            //    Type = PinType.Place,
            //    Label = "Öðrenci Þuan Okulda"
            //};

            GoogleMap.Pins.Clear(); 
            GoogleMap.ItemsSource = Pins;
        }
       
    }
}
