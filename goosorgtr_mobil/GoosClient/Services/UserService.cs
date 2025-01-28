using GoosClient.Models;
using goosorgtr_mobil.GoosClient.Models;
using goosorgtr_mobil.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace GoosClient.Services
{
    public static class UserService
    {
        public static string BaseUrl { get; set; } = $"https://okul.goos.org.tr";
        private static HttpClientHandler GetHttpClientHandler()
        {
            // EXCEPTION: Javax.Net.Ssl.SSLHandshakeException: 'java.security.cert.CertPathValidatorException:
            // Trust anchor for certification path not found.'
            // SOLUTION: 
            // ATTENTION: DO NOT USE IN PRODUCTION 

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };

            return httpClientHandler;
        }
        public static async Task<bool> RegisterUser(string userName, string password, string emailAdress)
        {
            var endpoint = "/api/account/register";
            var register = new RegisterModel() { UserName = userName, Password = password, EmailAddress = emailAdress };

            using (var client = new HttpClient(GetHttpClientHandler()))
            {

                var json = JsonConvert.SerializeObject(register);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseUrl + endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;

                }
                return true;
            }

        }
        public static async Task<bool> Login(string userName, string password)
        {
            //var tokenVarmi = Preferences.Get("token",string.Empty);
            //if (!string.IsNullOrEmpty(tokenVarmi))
            //{
            //   return true;//TOKEN VARSA DİREK GİRSİN
            //}

            var login = new LoginModel() { UserName = userName, Password = password };
            var endpoint = "/connect/token";

            using (var client = new HttpClient(GetHttpClientHandler()))
            {

                var data = $"grant_type={login.GrantType}&username={userName}&password={password}&client_id={login.ClientId}&scope={login.Scope}&client_secret={login.ClientSecret}";

                var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.PostAsync(BaseUrl + endpoint, content);


                if (!response.IsSuccessStatusCode)
                {
                    return false;

                }
                var jsonResult = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<Token>(jsonResult);

                if (token == null)
                {
                    return false;
                }
                else
                {
                    Preferences.Set("token", token.AccessToken);

                    //user id ile kullanıcı detaylarını çek



                    try
                    {
                        await GetUserInfo("P-Stephanie60.");
                    }
                    catch (Exception e)
                    {

                        var s = e;
                    }




                    return true;
                }

                //string filePath = "token.txt"; // Specify the file path
                //using (StreamWriter writer = new StreamWriter(filePath))
                //{
                //    writer.WriteLine(token.AccessToken); // Write a line of text
                //}





            }


        }



        public static async Task<List<StudentParentModel>> GetStudentsAsync(int parentId)
        {
            var endpoint = $"/api/app/student-parent/students?parentId={parentId}&useUserId=false";
            var token = Preferences.Get("token", string.Empty);

            if (string.IsNullOrEmpty(token))
            {
                //girişe yönlendir
                await Shell.Current.GoToAsync("Login");
            }

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var students = JsonConvert.DeserializeObject<List<StudentParentModel>>(response);

                return students;
            }

        }

        public static async Task<List<CourseModel>> GetCoursesAsync()
        {
            var endpoint = "/api/app/course";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<ListedResult<CourseModel>>(response).Items;

                return objeccs;
            }

        }

        public static async Task<List<SemesterModel>> GetSemestersAsync()
        {
            var endpoint = "/api/app/Semester";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<ListedResult<SemesterModel>>(response).Items;

                return objeccs;
            }

        }

        public static async Task<List<AttendanceModel>> GetAttendanceAsync(int studentId, int courseId = 0, int classId = 0)//değer verilmezse 0 olsun, etkilemez
        {
            var endpoint = $"/api/app/attendance?StudentId={studentId}&CourseId={courseId}&ClassId={classId}";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<ListedResult<AttendanceModel>>(response).Items;

                return objeccs;
            }
        }


        public static async Task<List<CourseScheduleModel>> GetDersProgramiAsync(string studentId)
        {

            var endpoint = $"/api/app/course-schedule/course-schedule-for-user?userIdstr={studentId}";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<List<CourseScheduleModel>>(response);

                return objeccs;
            }

        }

        public static async Task<List<DuyuruModel>> GetDuyurularAsync()
        {
            var endpoint = "/api/app/announcement";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<ListedResult<DuyuruModel>>(response).Items;

                return objeccs;
            }

        }
        public static async Task<List<ExamModel>> GetExamAsync()
        {
            var endpoint = "/api/app/exam";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                var response = await client.GetStringAsync(BaseUrl + endpoint);
                var objects = JsonConvert.DeserializeObject<ListedResult<ExamModel>>(response).Items;
                return objects;
            }
        }
        public static async Task<List<CourseModel>> GetOgrenciDersleriAsync(int ogrenciId)
        {
            var endpoint = $"/api/app/course?StudentId={ogrenciId}&MaxResultCount=100";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());

                var response = await client.GetStringAsync(BaseUrl + endpoint);

                var objeccs = JsonConvert.DeserializeObject<ListedResult<CourseModel>>(response).Items;

                return objeccs;
            }

        }

        public static async Task<List<GradeModel>> GetGradesAsync(int studentId, int courseId, double score, int examId)
        {
            var endpoint = $"/api/app/grade?StudentId={studentId}&CourseId={courseId}&Score={score}&ExamId={examId}";
            var token = Preferences.Get("token", string.Empty);

            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                var response = await client.GetStringAsync(BaseUrl + endpoint);
                var objects = JsonConvert.DeserializeObject<ListedResult<GradeModel>>(response).Items;
                return objects;
            }
        }




        public static async Task<bool> GetUserInfo(string userName)
        {
            var token = Preferences.Get("token", string.Empty);
            var endpoint = $"/api/app/identity-user-app-service-custom/find-by-username?userName={userName}";
            
            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                try 
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                    var response = await client.PostAsync(BaseUrl + endpoint, null);
                    var data = await response.Content.ReadAsStringAsync();
                    
                    // Debug için gelen veriyi kontrol et
                    System.Diagnostics.Debug.WriteLine($"API Response: {data}");
                    
                    var objects = JsonConvert.DeserializeObject<UserModel>(data);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"GetUserInfo Error: {ex}");
                    return false;
                }
            }
        }

        public class UserRequestDto
        {
            public string userName { get; set; }
        }

    }
}
