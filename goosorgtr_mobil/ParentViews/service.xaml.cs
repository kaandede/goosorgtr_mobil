using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ParentViews
{
    public partial class Service : ContentPage
    {
        public ParentViewModel _parentViewModel;
        private readonly RouteDrawingService _routeService;
        public List<Pin> Pins { get; set; } = new List<Pin>();
        public Service()
        {
            InitializeComponent();
            _parentViewModel = new ParentViewModel();
            BindingContext = _parentViewModel; 
            _routeService = new RouteDrawingService("AIzaSyBM9bP45ttREkinQxrnaXijot6bZKLjCn0");
        }



        protected override async void OnAppearing()
        {

            base.OnAppearing();

            //var mevkolej = new Location(39.89783152118657, 32.686864328835384);
            //GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(mevkolej, Distance.FromKilometers(2)));

            //Pins.Add(new Pin
            //{
            //    Address = "MEV Koleji",
            //    Location = mevkolej,
            //    Type = PinType.Place,
            //    Label = "Öðrenci Þuan Okulda"
            //});

            // GoogleMap.Pins.Clear();
            // GoogleMap.ItemsSource = Pins;


            //var ployline1 = new Polyline
            //{
            //    StrokeColor = Colors.Yellow,
            //    StrokeWidth = 15,
            //    Geopath =
            //    {
            //        new Location(39.89783152118657, 32.686864328835384),
            //        new Location(39.8975372596863, 32.67921761534151)
            //    }
            //};

            //GoogleMap.MapElements.Add(ployline1);

            //var ployline2 = new Polyline
            //{
            //    StrokeColor = Colors.Blue,
            //    StrokeWidth = 15,
            //    Geopath =
            //    {
            //        new Location(39.94587982707268, 32.62854408833028),
            //        new Location(39.8975372596863, 32.67921761534151)
            //    }
            //};

            //GoogleMap.MapElements.Add(ployline2);


            await _routeService.DrawRouteOnMap(
            GoogleMap,
            new Location(39.89783152118657, 32.686864328835384),
            new Location(39.8975372596863, 32.67921761534151),
            Colors.Yellow);

            await _routeService.DrawRouteOnMap(
                GoogleMap,
                new Location(39.94587982707268, 32.62854408833028),
                new Location(39.8975372596863, 32.67921761534151),
                Colors.Blue);

        }
    }
}