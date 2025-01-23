using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GoosClient.Models;
using GoosClient.Services;
using goosorgtr_mobil.ViewModels;

public class ParentStudentHomeWorkViewModel : BaseViewModel
{
  

    public ObservableCollection<CourseModel> Courses { get; set; } = new ObservableCollection<CourseModel>();

    public ParentStudentHomeWorkViewModel()
    {
     
        Task.Run(LoadCoursesAsync);
    }

    private async Task LoadCoursesAsync()
    {
        var courseList = await GetStudentCoursesAsync(); // Örnek ID
        Courses.Clear();

        foreach (var course in courseList)
        {
            Courses.Add(course);
        }
    }

    private async Task<IEnumerable<CourseModel>> GetStudentCoursesAsync()
    {
        return await UserService.GetOgrenciDersleriAsync(ogrenciId: 87);
    }
  
}
