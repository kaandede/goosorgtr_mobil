using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using IMap = Microsoft.Maui.Maps.IMap;

public class RouteDrawingService
{
    private const string GoogleDirectionsApiUrl = "https://maps.googleapis.com/maps/api/directions/json";
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public RouteDrawingService(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task DrawRouteOnMap(IMap GoogleMap, Location origin, Location destination, Color routeColor)
    {
        try
        {
            var points = await GetRoutePath(origin, destination);
            if (points != null && points.Any())
            {
                var polyline = new Polyline
                {
                    StrokeColor = routeColor,
                    StrokeWidth = 15,
                };

                foreach (var point in points)
                {
                    polyline.Geopath.Add(point);
                }

                GoogleMap.Elements.Add(polyline);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error drawing route: {ex.Message}");
            // Hata yönetimini burada yapabilirsiniz
        }
    }

    private async Task<List<Location>> GetRoutePath(Location origin, Location destination)
    {
        var requestUrl = $"{GoogleDirectionsApiUrl}?origin={origin.Latitude},{origin.Longitude}" +
                        $"&destination={destination.Latitude},{destination.Longitude}" +
                        $"&key={_apiKey}&mode=driving";

        var response = await _httpClient.GetStringAsync(requestUrl);
        var routeData = JsonSerializer.Deserialize<GoogleDirectionsResponse>(response);

        if (routeData?.Status != "OK" || routeData.Routes.Count == 0)
        {
            return null;
        }

        return DecodePolylinePoints(routeData.Routes[0].Overview_polyline.Points);
    }

    private List<Location> DecodePolylinePoints(string encodedPoints)
    {
        var poly = new List<Location>();
        int index = 0, len = encodedPoints.Length;
        int lat = 0, lng = 0;

        while (index < len)
        {
            int shift = 0, result = 0;
            int b;
            do
            {
                b = encodedPoints[index++] - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);
            int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lat += dlat;

            shift = 0;
            result = 0;
            do
            {
                b = encodedPoints[index++] - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);
            int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lng += dlng;

            var p = new Location(lat * 1e-5, lng * 1e-5);
            poly.Add(p);
        }

        return poly;
    }
}

// Google Directions API Response sınıfları
public class GoogleDirectionsResponse
{
    public string Status { get; set; }
    public List<Route> Routes { get; set; }
}

public class Route
{
    public Overview_Polyline Overview_polyline { get; set; }
}

public class Overview_Polyline
{
    public string Points { get; set; }
}