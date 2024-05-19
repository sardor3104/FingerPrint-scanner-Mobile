using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
namespace Fingerprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithKeyUI : ContentPage
    {
        public LoginWithKeyUI()
        {
                InitializeComponent();
        }

        bool isvisble = false;

        private void SuffixIconTapped(object sender, System.EventArgs e)
        {
            ozgarish();
            entry_kalit.IsPassword = isvisble;
            if (isvisble)
                glaza.Source = "closed.png";
            else
                glaza.Source = "opened.png";
            isvisble = !isvisble;
        }
        private void ozgarish()
        {
            label_soat.Text =  DateTime.Now.ToString("hh:mm tt");
        }
    

        // Q
        static async Task SendGetRequest(string requestUrl,string xatolik)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    xatolik = e.Message;
                }
            }
        }
        private async void loginconfirm(object sender, EventArgs e)
        {
            if (entry_email.Text ==null || entry_email.Text.Length <3)
            {
                
                label_error.Text = "emailni to\'g\'ri to\'ldiring" ;
                label_error_plus.Text = "email kamida 3ta belgidan iborat bo'lishi kerak";
                label_error.TextColor = Color.Red;
                buttonOK.Text = "Qayta urinish";
                buttonOK.TextColor = Color.Blue;
            }
            else if (entry_kalit.Text == null || entry_kalit.Text.Length < 8 || entry_kalit.Text.Length>20)
            {
                label_error.Text = "parolni to\'g\'ri to'ldiring";
                label_error_plus.Text = "parol kamida 8ta ko\'pi bilan 20ta belgidan iborat bo'lishi kerak";
                label_error.TextColor = Color.Red;
                buttonOK.Text = "Qayta urinish";
                buttonOK.TextColor = Color.Blue;
            }
            else
            {
                label_error.Text = "Talablar bajarildi";
                label_error.TextColor = Color.Green;
                buttonOK.Text = "Done";
                buttonOK.TextColor = Color.Green;
                string myhost = "192.168.1.3";
                // /docs uchun GET so'rovini yuborish
                await SendGetRequest($"http://{myhost}:8000/docs",xatolik : label_error.Text);

                // /openapi.json uchun GET so'rovini yuborish
                await SendGetRequest($"http://{myhost}:8000/openapi.json", xatolik: label_error.Text);
                // Foydalanuvchi ma'lumotlarini yuborish uchun POST so'rovini yuborish
                string holat = await PostLoginAsync($"http://{myhost}:8000/login",entry_email.Text,entry_kalit.Text);
                if(holat == "NotFound")
                {
                     await DisplayAlert("qayta urinib ko\'ring", "Ma\'lumotlar xato kiritildi", "xop");
                }
                //entry_email.Text = null;
                //entry_kalit.Text = null;
                else
                {
                    string url = $"http://{myhost}:8000/my-profile";
                    string ism = await GetFirstNameAsync(url, holat);
                    string familiya = await GetLastNameAsync(url, holat);
                    if(await Xamarin.Essentials.SecureStorage.GetAsync("ism") != null)
                    {
                        Xamarin.Essentials.SecureStorage.Remove("ism");
                        Xamarin.Essentials.SecureStorage.Remove("familiya");
                    }
                    await Xamarin.Essentials.SecureStorage.SetAsync("ism", ism);
                    await Xamarin.Essentials.SecureStorage.SetAsync("familiya",familiya);
                    //davomi bor
                    await DisplayAlert("Muvaffaqqiyatli", $"{ism} {familiya} autentifikatsiyadan o\'tdingiz", "Xop");
                    await Navigation.PushAsync(new LoginUI());
                    var firstPage = Navigation.NavigationStack.FirstOrDefault();
                    while (firstPage != null)
                    {
                        firstPage = Navigation.NavigationStack.FirstOrDefault();
                        Navigation.RemovePage(firstPage);
                    }
                }
            }
         }

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
        public static async Task<string> PostLoginAsync(string loginUrl,string Email,string Password)
        {
            var loginData = new
            {
                email = Email,
                password = Password
            };

            var json = JsonConvert.SerializeObject(loginData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(loginUrl, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(responseContent);
                        string accessToken = tokenResponse.Value<string>("access_token");
                        return accessToken; // Token'ni qaytarish
                    }
                    else
                    {
                        return "NotFound";
                    }
                }
                catch (HttpRequestException e)
                {
                    return "NotFound";
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FingerprintCapturePage());
        }
    }

    public class UserProfile
    {
        [JsonProperty("user_info")]
        public UserInfo UserInfo { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        // Add other properties as needed
    
}
}