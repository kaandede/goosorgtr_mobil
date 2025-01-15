using GoosClient.InputModels;
using GoosClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
            //    return true;//TOKEN VARSA DİREK GİRSİN
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
                    return true;
                }

                //string filePath = "token.txt"; // Specify the file path
                //using (StreamWriter writer = new StreamWriter(filePath))
                //{
                //    writer.WriteLine(token.AccessToken); // Write a line of text
                //}
          

       


            }


        }
        public static async Task<List<StudentModel>> GetStudentsAsync()
        {
            var endpoint = "/api/app/student";
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

                var students = JsonConvert.DeserializeObject<ListedResult<StudentModel>>(response).Items;

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

        public static async Task<List<AttendanceModel>> GetAttendanceAsync(AttendanceGetListInput input)
        {
            var endpoint = "/api/app/Attendance";
            var token = Preferences.Get("token", string.Empty);



            using (var client = new HttpClient(GetHttpClientHandler()))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());


                string json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseUrl + endpoint, content);
                var responseData = await response.Content.ReadAsStringAsync();

                var objeccs = JsonConvert.DeserializeObject<ListedResult<AttendanceModel>>(responseData).Items;

                return objeccs;
            }

        }


        public static async Task<List<CourseScheduleModel>> GetDersProgramiAsync(string studentId= "cecab47b-f8b3-c4ca-a7b0-3a145cb90213")
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

                var objeccs = JsonConvert.DeserializeObject<ListedResult<ExamModel>>(response).Items;

                return objeccs;
            }

        }


    }


}
