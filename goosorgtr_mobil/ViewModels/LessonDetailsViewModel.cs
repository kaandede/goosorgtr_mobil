using System.Collections.ObjectModel;
using System.Windows.Input;
using GoosClient.Models;
using GoosClient.Services;

namespace goosorgtr_mobil.ViewModels
{
    public class LessonDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<CourseModel> _courses;
        private bool _isRefreshing;

        public ObservableCollection<CourseModel> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        // Yeni Komutlar
        public ICommand RefreshCoursesCommand { get; }
        public ICommand CourseSelectedCommand { get; }
        public ICommand NavigateToExamsCommand { get; }
        public ICommand NavigateToGradesCommand { get; }
        public ICommand NavigateToReportCardCommand { get; }

        public LessonDetailsViewModel()
        {
            Courses = new ObservableCollection<CourseModel>();

            RefreshCoursesCommand = new Command(async () => await LoadCoursesAsync());
            CourseSelectedCommand = new Command<CourseModel>(OnCourseSelected);

            // Yeni komutlar tanımlandı
            NavigateToExamsCommand = new Command(async () => await NavigateToPage("ExamsPage"));
            NavigateToGradesCommand = new Command(async () => await NavigateToPage("GradesPage"));
            NavigateToReportCardCommand = new Command(async () => await NavigateToPage("ReportCardPage"));

            LoadCoursesAsync();
        }

        private async Task LoadCoursesAsync()
        {
            if (IsRefreshing) return;

            IsRefreshing = true;
            try
            {
                var seciliOgrenciId = Preferences.Get("seciliOgrenciId", string.Empty);
                if (string.IsNullOrEmpty(seciliOgrenciId))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Hata",
                        "Öğrenci seçimi yapılmamış",
                        "Tamam"
                    );
                    return;
                }

                var courses = await UserService.GetOgrenciDersleriAsync(seciliOgrenciId);

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
                // Shell ile sayfa geçişi
                await Shell.Current.GoToAsync($"//{pageName}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }
    }
}
