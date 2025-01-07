using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Devices.Sensors;
using DevExpress.XtraSpellChecker.Parser;
using Microsoft.Maui.Controls.Maps;


namespace goosorgtr_mobil.ParentViews
{
    public partial class ParentStudentLocation : ContentPage
    {
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

            var position = new Location(39.89783152118657, 32.686864328835384);
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.1)));

            var pin = new Pin
            {
                Address = "MEV Koleji",
                Location = position,
                Type = PinType.Place,
                Label = "Öðrenci Þuan Okulda"
            };

            GoogleMap.Pins.Add(pin);
        }
       
    }
}
