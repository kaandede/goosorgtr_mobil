using System.Collections.ObjectModel;
using System.Windows.Input;
using GoosClient.Services;
using goosorgtr_mobil.Models;


namespace goosorgtr_mobil.ViewModels
{
    public class ExamPageViewModel : BaseViewModel
    {
        private ObservableCollection<ExamModel> _exams;
        public ObservableCollection<ExamModel> Exams
        {
            get => _exams;
            set => SetProperty(ref _exams, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ICommand RefreshCommand { get; }

        public ExamPageViewModel()
        {
            Title = "Sınavlar";
            Exams = new ObservableCollection<ExamModel>();
            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
        }

        async Task ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            await LoadExams();
            IsRefreshing = false;
        }

        public async Task LoadExams()
        {
            if (IsBusy) return;

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
            }
        }
    }
}