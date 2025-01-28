using CommunityToolkit.Mvvm.Input;
using GoosClient.Models;
using GoosClient.Services;
using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ViewModels;

public partial class CourseScheduleViewModel : BaseViewModel
{



    public ObservableCollection<DaySchedule> Days { get; set; } = new();

    public CourseScheduleViewModel()
    {

       
    }

    [RelayCommand]
    public async Task DersProgramiDoldur()
    {

        if (IsLoading) return;
        try
        {
            IsLoading = true;
            var ogrenciId = Preferences.Get("seciliOgrenciUserId", string.Empty);
            var program = await UserService.GetDersProgramiAsync(ogrenciId);
            var dayliste = new List<DaySchedule>();

            foreach (var gun in program.OrderBy(p => p.DaysOfWeek).ThenBy(p=>p.StartTime).GroupBy(p => p.DaysOfWeek))
            {
                var lessonliste = new List<Lesson>();//her güne resetlenecek
                foreach (var ders in program.Where(p => p.DaysOfWeek == gun.Key))
                {
                    lessonliste.Add(new Lesson()
                    {
                        Name = ders.CourseCode,
                        Time = ders.StartTime + " - " + ders.EndTime
                    });
                }

                dayliste.Add(new DaySchedule()
                {
                    DayName = ((DaysOfWeek)gun.Key).ToString(),
                    Lessons = lessonliste
                });

            }   
            Days.Clear();
            foreach (var item in dayliste)
            {
                Days.Add(item);
            }

            //Days = new ObservableCollection<DaySchedule>(dayliste);
            //OnPropertyChanged(nameof(Days));
        }
        catch (Exception ex)
        {
  
            await Shell.Current.DisplayAlert("Hata", "Sistemde bir hata oluştu", "Tamam");
        }
        finally
        {
            IsLoading = false;
        }

   

    }
}

public class DaySchedule
{
    public string DayName { get; set; }
    public List<Lesson> Lessons { get; set; }
}

public class Lesson
{
    public string Name { get; set; }
    public string Time { get; set; }
}

