using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
namespace Fingerprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerprintCapturePage : ContentPage
    {

        public FingerprintCapturePage()
        {
            InitializeComponent();
        }

        private async void CaptureButton_Clicked(object sender, EventArgs e)
        {
            initial();
            // Barmoq izini olish funksiyasini chaqirish
        }
        static async Task <string> UploadFingerprintAsync(string filePath)
        {
            // So'rovni yuborish uchun HttpClient yaratish
            using (var client = new HttpClient())
            {
                // Multipart/form-data tarkibini yaratish
                using (var content = new MultipartFormDataContent("----WebKitFormBoundaryP3gBfN9h2jDBRbyu"))
                {
                    // Rasm faylini o'qish va uni tarkibga qo'shish
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/bmp");
                    content.Add(fileContent, "fingerprint_image", "9__M_Left_little_finger_Obl.BMP");

                    // Qo'shimcha headerlarni sozlash
                    // client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Not-A.Brand\";v=\"99\", \"Chromium\";v=\"124\"");
                    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                    //client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.6367.155 Safari/537.36");
                    //client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
                    //  client.DefaultRequestHeaders.Referrer = new Uri("http://192.168.1.3:8000/docs");

                    // POST so'rovini yuborish
                    var response = await client.PostAsync("http://192.168.1.3:8000/login-fingerprint", content);

                    if (response.IsSuccessStatusCode)
                    {
                                    // Javob tarkibini o'qish va token'ni qaytarish
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JObject.Parse(responseContent);
                    string accessToken = tokenResponse.Value<string>("access_token");
                    return accessToken;
                    }
                    else
                    {
                        return "Fayl yuklashda xatolik: " + response.StatusCode;
                    }
                }
            }
        }
        private string myhost = "192.168.1.3";
        private string token = null;

        private async void initial()
        {
            // /docs va /openapi.json uchun GET so'rovlarini yuborish
            await SendGetRequest($"http://{myhost}:8000/docs");
            await SendGetRequest($"http://{myhost}:8000/openapi.json");
           
            // Fayl tanlash va yuklash
            var fileResult = await FilePicker.PickAsync();
            if (fileResult != null)
            {
                token = await UploadFingerprintAsync(fileResult.FullPath);
            }
            if (token == null)
            {
                await DisplayAlert("tokenda muammo", "sda", "asd");
            }
            else {
                string url = $"http://{myhost}:8000/my-profile";
                string ism = await GetFirstNameAsync(url, token);
                string familiya = await GetLastNameAsync(url, token);
                string Epochta = await GetEmailAsync(url, token);
                string parols = await GetPasswordAsync(url, token);
                if (await Xamarin.Essentials.SecureStorage.GetAsync("ism") != null)
                {
                    Xamarin.Essentials.SecureStorage.RemoveAll();
                }
                await Xamarin.Essentials.SecureStorage.SetAsync("ism", ism);
                await Xamarin.Essentials.SecureStorage.SetAsync("familiya", familiya);
                await Xamarin.Essentials.SecureStorage.SetAsync("email", Epochta);
                await Xamarin.Essentials.SecureStorage.SetAsync("parol",parols);
                await DisplayAlert("Marhamat kirishingiz mumkin",$"{ism} {familiya}", "ok");
                await Navigation.PushAsync(new LoginUI());
                var firstPage = Navigation.NavigationStack.FirstOrDefault();
                while (firstPage != null)
                {
                    firstPage = Navigation.NavigationStack.FirstOrDefault();
                    Navigation.RemovePage(firstPage);
                }
            } }

        static async Task SendGetRequest(string requestUrl)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nXato: ");
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static async Task<string> PostLoginAsync(string loginUrl, string imagePath)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Rasm faylini o'qish va uni HTTP so'roviga qo'shish
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/bmp");
                content.Add(imageContent, "fingerprint_image", Path.GetFileName(imagePath));

                try
                {
                    // So'rovni yuborish
                    var response = await client.PostAsync(loginUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Javob tarkibini o'qish va token'ni qaytarish
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(responseContent);
                        string accessToken = tokenResponse.Value<string>("access_token");
                        return accessToken;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"So'rovda xato: {e.Message}");
                    return null;
                }
            }
        }

        static async Task<string> UploadFingerprint(string filePath)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/bmp");
                content.Add(fileContent, "fingerprint_image", Path.GetFileName(filePath));

                HttpResponseMessage response = await client.PostAsync("http://192.168.1.3:8000/login-fingerprint", content);
                if (response.IsSuccessStatusCode)
                {

                   return response.Content.ToString();
                }
                else
                {
                   return "Fayl yuklashda xatolik: " + response.StatusCode;
                }
            }
        }
        public static async Task<string> GetFirstNameAsync(string url, string token)
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseBody);
                    return profile.UserInfo.FirstName.ToString();
                    // Other properties can be accessed in a similar way
                }
                catch (HttpRequestException e)
                {
                    return "tizimda xatolik";
                }
            }
        }
        public static async Task<string> GetEmailAsync(string url, string token)
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseBody);
                    return profile.UserInfo.Email.ToString();
                    // Other properties can be accessed in a similar way
                }
                catch (HttpRequestException e)
                {
                    return "tizimda xatolik";
                }
            }
        }
        public static async Task<string> GetPasswordAsync(string url, string token)
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseBody);
                    return profile.UserInfo.Email.ToString() ;
                    // Other properties can be accessed in a similar way
                }
                catch (HttpRequestException e)
                {
                    return "tizimda xatolik";
                }
            }
        }
        public static async Task<string> GetLastNameAsync(string url, string token)
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseBody);
                    return profile.UserInfo.LastName.ToString();
                    // Other properties can be accessed in a similar way
                }
                catch (HttpRequestException e)
                {
                    return "tizimda xatolik";
                }
            }
        }

    }
}
