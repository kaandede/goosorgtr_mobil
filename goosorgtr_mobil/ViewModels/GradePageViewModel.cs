using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoosClient.Services;
using goosorgtr_mobil.Models;

namespace goosorgtr_mobil.ViewModels
{
    public partial class GradePageViewModel : BaseViewModel
    {
        private ObservableCollection<GradeModel> _grades;
        public ObservableCollection<GradeModel> Grades
        {
            get => _grades;
            set => SetProperty(ref _grades, value);
        }

        [ObservableProperty]
        private int selectedStudentId;

        public IAsyncRelayCommand RefreshCommand { get; }
        public IAsyncRelayCommand<int> LoadStudentGradesCommand { get; }

        public GradePageViewModel()
        {
            Title = "Notlar";
            Grades = new ObservableCollection<GradeModel>();
            RefreshCommand = new AsyncRelayCommand(LoadGrades);
            LoadStudentGradesCommand = new AsyncRelayCommand<int>(LoadStudentGrades);
        }

        public async Task LoadGrades()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var gradeList = await UserService.GetGradesAsync(199, 0, 0, 0);
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

        public async Task LoadStudentGrades(int studentId)
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                selectedStudentId = studentId;
                var gradeList = await UserService.GetGradesAsync(studentId, 0, 0, 0);
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