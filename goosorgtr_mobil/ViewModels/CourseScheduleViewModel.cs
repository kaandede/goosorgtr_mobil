using System.Collections.ObjectModel;

namespace goosorgtr_mobil.ViewModels;

public class CourseScheduleViewModel
{
    public ObservableCollection<DaySchedule> Days { get; set; }

    public CourseScheduleViewModel()
    {
        // Örnek veri
        Days = new ObservableCollection<DaySchedule>
        {
            new DaySchedule
            {
                DayName = "Pazartesi",
                Lessons = new List<Lesson>
                {
                    new Lesson { Name = "Matematik", Time = "09:00 - 10:00" },
                    new Lesson { Name = "Türkçe", Time = "10:15 - 11:15" },
                    new Lesson { Name = "Fen Bilgisi", Time = "11:30 - 12:30" },
                     new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
                    new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
                    new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
                }
            },
            new DaySchedule
            {
                DayName = "Salı",
                Lessons = new List<Lesson>
                {
                    new Lesson { Name = "Sosyal Bilgiler", Time = "09:00 - 10:00" },
                    new Lesson { Name = "İngilizce", Time = "10:15 - 11:15" },
                    new Lesson { Name = "Müzik", Time = "11:30 - 12:30" },
                    new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
                    new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
                    new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
                }
            },
            new DaySchedule
            {
                DayName = "Çarşamba",
                Lessons = new List<Lesson>
                {
                    new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
                    new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
                    new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
                      new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
                    new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
                    new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
                }
            },
            new DaySchedule
            {
                DayName = "Perşembe",
              
                Lessons = new List<Lesson>
                {
                    new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
                    new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
                    new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
                      new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
                    new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
                    new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
                }
            },
            new DaySchedule
            {
                DayName = "Cuma",
                Lessons = new List<Lesson>
                {
                    new Lesson { Name = "Beden Eğitimi", Time = "09:00 - 10:00" },
                    new Lesson { Name = "Matematik", Time = "10:15 - 11:15" },
                    new Lesson { Name = "Resim", Time = "11:30 - 12:30" },
                      new Lesson { Name = "Müzik", Time = "12:45 - 13:45" },
                    new Lesson { Name = "Din Kültürü", Time = "14:00 - 15:00" },
                    new Lesson { Name = "Felsefe", Time = "15:15 - 16:15" }
                }
            }
        };
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

