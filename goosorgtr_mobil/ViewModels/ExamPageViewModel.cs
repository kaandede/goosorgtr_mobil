using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoosClient.Services;
using GoosClient.Models;
using goosorgtr_mobil.GoosClient.Models;

namespace goosorgtr_mobil.ViewModels
{
    public partial class ExamPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<ExamModel> exams = new();

        [ObservableProperty]
        private int selectedStudentId;

        public IAsyncRelayCommand RefreshCommand { get; }
        public IAsyncRelayCommand LoadStudentExamsCommand { get; }

        public ExamPageViewModel()
        {
            Title = "Sınavlar";
   
            RefreshCommand = new AsyncRelayCommand(LoadExams);
            LoadStudentExamsCommand = new AsyncRelayCommand(LoadStudentExams);
        }

        public async Task LoadStudentExams()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
 
                
                var examList = await UserService.GetExamAsync();
                
                Exams.Clear();
                
                if (examList != null && examList.Any())
                {
                    foreach (var exam in examList)
                    {
                        
                        Exams.Add(exam);
                    }
                   
                }
                else
                {
                    
                    await Shell.Current.DisplayAlert("Bilgi", "Bu öğrenci için sınav bulunamadı.", "Tamam");
                }
            }
            catch (Exception ex)
            {
               
                await Shell.Current.DisplayAlert("Hata", $"Sınavlar yüklenirken hata oluştu: {ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        private async Task LoadExams()
        {
            try
            {
                IsBusy = true;
                var examList = await UserService.GetExamAsync();
                Exams.Clear();
                foreach (var exam in examList)
                {
                    Exams.Add(exam);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", "Sınavlar yüklenirken hata oluştu: " + ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}