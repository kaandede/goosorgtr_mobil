using GoosClient.Models;
using GoosClient.Services;
using goosorgtr_mobil.ViewModels;
using System.Collections.ObjectModel;

public class ParentStudentHomeWorkViewModel : BaseViewModel
{
  

    public ObservableCollection<CourseModel> Courses { get; set; } = new ObservableCollection<CourseModel>();

    public ParentStudentHomeWorkViewModel()
    {
     
        Task.Run(LoadCoursesAsync);
    }

    private async Task LoadCoursesAsync()
    {
        try
        {

            var courseList = await UserService.GetOgrenciDersleriAsync(ogrenciId: 87); // Örnek ID
            Courses.Clear();

            foreach (var course in courseList)
            {
                Courses.Add(course);
            }
        }
        catch (Exception ex)
        {

            var d = ex;
        }
    }


  
}
