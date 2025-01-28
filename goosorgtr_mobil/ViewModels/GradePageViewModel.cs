using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoosClient.Services;
using GoosClient.Models;
using goosorgtr_mobil.Models;
using goosorgtr_mobil.GoosClient.Models;

namespace goosorgtr_mobil.ViewModels
{
    public partial class GradePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<GradeModel> grades = new();

        [ObservableProperty]
        private int selectedStudentId;

        public IAsyncRelayCommand RefreshCommand { get; }
        public IAsyncRelayCommand<int> LoadStudentGradesCommand { get; }

        public GradePageViewModel()
        {
            Title = "Notlar";

         
            RefreshCommand = new AsyncRelayCommand(LoadGrades);
            LoadStudentGradesCommand = new AsyncRelayCommand<int>(LoadStudentGrades);
        }

        public async Task LoadStudentGrades(int studentId)
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                System.Diagnostics.Debug.WriteLine($"Loading grades for student: {studentId}");
                
                var gradeList = await UserService.GetGradesAsync(studentId, 0, 0, 0);
                
                Grades.Clear();
                
                if (gradeList != null && gradeList.Any())
                {
                    foreach (var grade in gradeList)
                    {
                         Grades.Add(grade);
                    }
                    System.Diagnostics.Debug.WriteLine($"Loaded {gradeList.Count} grades");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No grades found for student");
                    await Shell.Current.DisplayAlert("Bilgi", "Bu öğrenci için not bulunamadı.", "Tamam");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Grade loading error: {ex}");
                await Shell.Current.DisplayAlert("Hata", $"Notlar yüklenirken hata oluştu: {ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        public async Task LoadGrades()
        {
            try
            {
                IsBusy = true;
                var gradeList = await UserService.GetGradesAsync(selectedStudentId, 0, 0, 0);
                Grades.Clear();
                foreach (var grade in gradeList)
                {
                    Grades.Add(grade);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", "Notlar yüklenirken hata oluştu: " + ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}