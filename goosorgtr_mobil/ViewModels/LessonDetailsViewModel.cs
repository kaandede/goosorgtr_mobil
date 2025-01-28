using System.Collections.ObjectModel;
using System.Windows.Input;
using GoosClient.Models;
using GoosClient.Services;
using System.Collections.Generic;

namespace goosorgtr_mobil.ViewModels
{
    public partial class LessonDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<CourseModel> _courses;
   
        public ObservableCollection<CourseModel> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }

     

        // Yeni Komutlar
        public ICommand RefreshCoursesCommand { get; }
        public ICommand CourseSelectedCommand { get; }
        public ICommand NavigateToExamsCommand { get; }
        public ICommand NavigateToGradesCommand { get; }
        public ICommand NavigateToReportCardCommand { get; }

        public LessonDetailsViewModel()
        {
            Title = "Ders Detayları";
            Courses = new ObservableCollection<CourseModel>();

            RefreshCoursesCommand = new Command(async () => await LoadCoursesAsync());
            CourseSelectedCommand = new Command<CourseModel>(OnCourseSelected);

            // Yeni komutlar tanımlandı
            NavigateToExamsCommand = new Command(async () => await NavigateToExamsPage());
            NavigateToGradesCommand = new Command(async () => await NavigateToGradesPage());
            NavigateToReportCardCommand = new Command(async () => await NavigateToPage("ReportCardPage"));
           // LoadCoursesAsync().ConfigureAwait(true);


        }

        private async Task LoadCoursesAsync()
        {
            if (!IsRefreshing) return;

          
            try
            {
                var SelectedStudentId = Preferences.Get("SelectedStudentId", string.Empty);
                if (string.IsNullOrEmpty(SelectedStudentId))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Hata",
                        "Öğrenci seçimi yapılmamış",
                        "Tamam"
                    );
                    return;
                }

                var courses = await UserService.GetOgrenciDersleriAsync(int.Parse(SelectedStudentId));

                Courses.Clear();
                foreach (var course in courses)
                {
                    Courses.Add((CourseModel)course);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Hata",
                    $"Dersler yüklenirken hata oluştu: {ex.Message}",
                    "Tamam"
                );
            }
            finally
            {
                IsRefreshing = false;            
                IsLoading = false;
            }
        }

        private async void OnCourseSelected(CourseModel selectedCourse)
        {
            if (selectedCourse == null) return;

            try
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Ders Seçildi",
                    $"{selectedCourse.CourseName} dersi seçildi",
                    "Tamam"
                );

                // Ders detaylarına yönlendirme
                // await Shell.Current.GoToAsync($"//coursdetails?CourseId={selectedCourse.CourseId}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Hata",
                    $"Ders seçiminde hata: {ex.Message}",
                    "Tamam"
                );
            }
        }

        // Yeni: Sayfa geçişi için genel metot
        private async Task NavigateToPage(string pageName)
        {
            try
            {
                var selectedStudentId = Preferences.Get("SelectedStudentId", 0);
                if (selectedStudentId == 0)
                {
                    await Shell.Current.DisplayAlert("Hata", "Öğrenci seçilmemiş", "Tamam");
                    return;
                }

                var parameters = new Dictionary<string, object>
                {
                    { "StudentId", selectedStudentId }
                };
                await Shell.Current.GoToAsync($"{pageName}", parameters);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        private async Task NavigateToGradesPage()
        {
            try
            {
                var selectedStudentId = Preferences.Get("SelectedStudentId", string.Empty);
                if (selectedStudentId == string.Empty)
                {
                    await Shell.Current.DisplayAlert("Hata", "Öğrenci seçilmemiş", "Tamam");
                    return;
                }

                var parameters = new Dictionary<string, object>
                {
                    { "StudentId", selectedStudentId }
                };
                
                System.Diagnostics.Debug.WriteLine($"Navigating to GradesPage with StudentId: {selectedStudentId}");
                await Shell.Current.GoToAsync($"GradesPage", parameters);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex}");
                await Shell.Current.DisplayAlert("Hata", "Sayfa yüklenirken bir hata oluştu.", "Tamam");
            }
        }

        // Yeni ExamsPage navigasyon metodu
        private async Task NavigateToExamsPage()
        {
            try
            {
                var selectedStudentId = Preferences.Get("SelectedStudentId", string.Empty);
                if (selectedStudentId == string.Empty)
                {
                    await Shell.Current.DisplayAlert("Hata", "Öğrenci seçilmemiş", "Tamam");
                    return;
                }

                var parameters = new Dictionary<string, object>
                {
                    { "StudentId", selectedStudentId }
                };
                
                System.Diagnostics.Debug.WriteLine($"Navigating to ExamsPage with StudentId: {selectedStudentId}");
                await Shell.Current.GoToAsync($"ExamsPage", parameters);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex}");
                await Shell.Current.DisplayAlert("Hata", "Sayfa yüklenirken bir hata oluştu.", "Tamam");
            }
        }
    }
}
