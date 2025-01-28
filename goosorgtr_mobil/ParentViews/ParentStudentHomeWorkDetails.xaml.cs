using goosorgtr_mobil.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace goosorgtr_mobil.ParentViews;

public partial class ParentStudentHomeWorkDetails : ContentPage
{
    private readonly LessonDetailsViewModel _viewModel;

    public ParentStudentHomeWorkDetails()
    {
        InitializeComponent();
        _viewModel = new LessonDetailsViewModel();
        BindingContext = _viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var selectedStudentId = Preferences.Get("SelectedStudentId", 0);
        var parameters = new Dictionary<string, object>
        {
            { "StudentId", selectedStudentId }
        };
        await Shell.Current.GoToAsync($"ExamsPage", parameters);
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            var selectedStudentId = Preferences.Get("SelectedStudentId", 0);
            System.Diagnostics.Debug.WriteLine($"Navigating to GradesPage with StudentId: {selectedStudentId}");
            
            var parameters = new Dictionary<string, object>
            {
                { "StudentId", selectedStudentId }
            };
            await Shell.Current.GoToAsync($"GradesPage", parameters);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex}");
            await Shell.Current.DisplayAlert("Hata", "Sayfa yüklenirken bir hata oluştu.", "Tamam");
        }
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        var selectedStudentId = Preferences.Get("SelectedStudentId", 0);
        var parameters = new Dictionary<string, object>
        {
            { "StudentId", selectedStudentId }
        };
        await Shell.Current.GoToAsync($"ReportCardPage", parameters);
    }
}
