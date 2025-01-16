using System.Collections.ObjectModel;
using System.Windows.Input;
using GoosClient.Services;
using goosorgtr_mobil.GoosClient.Models;
using goosorgtr_mobil.ParentViews;

namespace goosorgtr_mobil.ViewModels
{
    public class LessonDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<LessonModel> _lessons;
        private bool _isRefreshing;

        public ObservableCollection<LessonModel> Lessons
        {
            get => _lessons;
            set => SetProperty(ref _lessons, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ICommand DersleriDoldurCommand { get; }
        public ICommand ItemTappedCommand { get; }

        public LessonDetailsViewModel()
        {
            Lessons = new ObservableCollection<LessonModel>();
            DersleriDoldurCommand = new Command(async () => await DersleriDoldur());
            ItemTappedCommand = new Command<LessonModel>(async (item) => await OnItemTapped(item));
        }

        public async Task DersleriDoldur()
        {
            IsRefreshing = true;
            try
            {
                var lessons = await GetLessonsFromAPI();
                Lessons.Clear();
                foreach (var lesson in lessons)
                {
                    Lessons.Add(lesson);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Hata", ex.Message, "Tamam");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task OnItemTapped(LessonModel lesson)
        {
            if (lesson == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new DersDetay2());
        }

        private async Task<List<LessonModel>> GetLessonsFromAPI()
        {

            var seciliOgrenciId = Preferences.Get("seciliOgrenciId", string.Empty);

            if (!string.IsNullOrEmpty(seciliOgrenciId))
            {
                var program = await UserService.GetDersProgramiAsync(seciliOgrenciId);


                return new List<LessonModel>
                {
                    new LessonModel
                {
                    LessonName = "Matematik",
                    TeacherName = "Ayşe Yılmaz",
                    LessonDays = "Pazartesi - Çarşamba",
                    LessonIcon = "calculator.png",
                    LessonColor = "#EEF2FF",
                    ButtonColor = "#4F46E5"
                },
                    new LessonModel
                {
                    LessonName = "Fizik",
                    TeacherName = "Mehmet Demir",
                    LessonDays = "Salı - Perşembe",
                    LessonIcon = "atom.png",
                    LessonColor = "#FEF3C7",
                    ButtonColor = "#D97706"
                }
                };
            }
            else
            {
                return new List<LessonModel>();
            }

        }
    }
}