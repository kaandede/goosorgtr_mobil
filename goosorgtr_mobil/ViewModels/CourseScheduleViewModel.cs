using GoosClient.Models;
using GoosClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace goosorgtr_mobil.ViewModels;

public class CourseScheduleViewModel : INotifyPropertyChanged
{
    


    public ObservableCollection<DaySchedule> Days { get; set; }

    public CourseScheduleViewModel()
    {

        //DersProgramiDoldur();

        // Örnek veri
        //Days = new ObservableCollection<DaySchedule>
        //{
        //    new DaySchedule
        //    {
        //        DayName = "Pazartesi",
        //        Lessons = new List<Lesson>
        //        {
        //            new Lesson { Name = "Matematik", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "Türkçe", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Fen Bilgisi", Time = "11:30 - 12:30" },
        //             new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" },
        //             new Lesson { Name = "Matematik", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "Türkçe", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Fen Bilgisi", Time = "11:30 - 12:30" },
        //             new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
        //        }
        //    },
        //    new DaySchedule
        //    {
        //        DayName = "Salı",
        //        Lessons = new List<Lesson>
        //        {
        //            new Lesson { Name = "Sosyal Bilgiler", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "İngilizce", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Müzik", Time = "11:30 - 12:30" },
        //            new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
        //        }
        //    },
        //    new DaySchedule
        //    {
        //        DayName = "Çarşamba",
        //        Lessons = new List<Lesson>
        //        {
        //            new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
        //              new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
        //        }
        //    },
        //    new DaySchedule
        //    {
        //        DayName = "Perşembe",

        //        Lessons = new List<Lesson>
        //        {
        //            new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
        //              new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
        //        }
        //    },
        //    new DaySchedule
        //    {
        //        DayName = "Cuma",
        //        Lessons = new List<Lesson>
        //        {
        //            new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
        //            new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
        //            new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
        //              new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
        //            new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
        //            new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
        //        }
        //    }
        //};
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public async void DersProgramiDoldur()
    {
        var program = await UserService.GetDersProgramiAsync();
        var dayliste = new List<DaySchedule>();

        foreach (var gun in program.OrderBy(p=>p.DaysOfWeek).GroupBy(p => p.DaysOfWeek))
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
        Days = new ObservableCollection<DaySchedule>(dayliste);
        OnPropertyChanged(nameof(Days));

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

