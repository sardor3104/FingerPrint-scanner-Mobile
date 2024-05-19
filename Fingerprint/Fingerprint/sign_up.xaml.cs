using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;
using System.Net.Mail;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using System.IO;
namespace Fingerprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sign_up : ContentPage
    {
        public sign_up()
        {
            InitializeComponent();
            MailAddresses();
            GetEmailAsync();
        }
        static readonly HttpClient client = new HttpClient();
        static async Task SendGetRequest(string requestUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {

            }
        }
        static async Task<string> SendPostRequest(string requestUrl, string email, string firstname, string lastname, string password, string dob)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(email), "email");
            formData.Add(new StringContent(firstname), "first_name");
            formData.Add(new StringContent(lastname), "last_name");
            formData.Add(new StringContent(password), "password");
            formData.Add(new StringContent(dob), "date_of_birth");

            // Agar siz barmoq izi tasvirini yuborishni istasangiz, quyidagi qatorni qo'shing:
            // formData.Add(new ByteArrayContent(File.ReadAllBytes("path_to_your_file")), "fingerprint_image", "filename");

            try
            {
                HttpResponseMessage response = await client.PostAsync(requestUrl, formData);
                if (!response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return "error: " + responseBody;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                
            }
            catch (HttpRequestException e)
            {
                return "error: "+e.Message;
            }
        }

        public async void GetEmailAsync()
        {
            label_email.Text = $"email adresingiz: {await Xamarin.Essentials.SecureStorage.GetAsync("email")}";
        }
        string email = "";
        public async void MailAddresses()
        {
            email = $"{await Xamarin.Essentials.SecureStorage.GetAsync("email")}";
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entry_ism.Text == null || entry_ism.Text == "")
            {
                label_error.Text = "iltimos ismingizni kiriting";
            }
            else if (entry_familiya.Text == null || entry_familiya.Text == "")
            {
                label_error.Text = "iltimos familiyangizni kiriting";
            }
            else if (entry_parol.Text == null || entry_parol.Text.Length < 8 || entry_parol.Text.Length > 20)
            {
                label_error.Text = "parol kamida 8ta kopi bilan 20 ta bolishi kerak";
            }
            else
            {
                label_error.Text = @"Hammasi tog'ri kiritildi";
                label_error.TextColor = Color.Green;
                string myhost = "192.168.1.3";
                // /docs uchun GET so'rovini yuborish
                await SendGetRequest($"http://{myhost}:8000/docs");

                // /openapi.json uchun GET so'rovini yuborish
                await SendGetRequest($"http://{myhost}:8000/openapi.json");

                // Foydalanuvchi ma'lumotlarini yuborish uchun POST so'rovini yuborish
                string hol =  await SendPostRequest($"http://{myhost}:8000/register", email, entry_ism.Text, entry_familiya.Text, entry_parol.Text, dpick_tyil.ToString());
                //backend ulanish joyi
                if(hol.Substring(0,6)!="error:"){
                    await Xamarin.Essentials.SecureStorage.SetAsync("parol", entry_parol.Text);
                await Xamarin.Essentials.SecureStorage.SetAsync("tyil", dpick_tyil.Date.ToString());
                await Xamarin.Essentials.SecureStorage.SetAsync("ism", entry_ism.Text);
                await Xamarin.Essentials.SecureStorage.SetAsync("familiya", entry_familiya.Text);
                await Navigation.PushAsync(new LoginUI());
                var firstPage = Navigation.NavigationStack.FirstOrDefault();
                while (firstPage != null)
                {
                    firstPage = Navigation.NavigationStack.FirstOrDefault();
                    Navigation.RemovePage(firstPage);
                }
                 }
                else
                {
                    await DisplayAlert("Xatolik", hol, "xop");
                }
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (entry_ism.Text == null || entry_ism.Text == "")
            {
                label_error.Text = "iltimos ismingizni kiriting";
            }
            else if (entry_familiya.Text == null || entry_familiya.Text == "")
            {
                label_error.Text = "iltimos familiyangizni kiriting";
            }
            else if (entry_parol.Text == null || entry_parol.Text.Length < 8 || entry_parol.Text.Length > 20)
            {
                label_error.Text = "parol kamida 8ta kopi bilan 20 ta bolishi kerak";
            }
            else
            {
                var fileResult = await FilePicker.PickAsync();
                if (fileResult != null)
                {
                    var content = new MultipartFormDataContent();
                    var filePath = fileResult.FullPath;
                    var fileStream = await fileResult.OpenReadAsync();
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    content.Add(fileContent, "fingerprint_image", Path.GetFileName(filePath));

                    // Qo'shimcha ma'lumotlarni qo'shish
                    content.Add(new StringContent(email), "email");
                    content.Add(new StringContent(entry_ism.Text), "first_name");
                    content.Add(new StringContent(entry_familiya.Text), "last_name");
                    content.Add(new StringContent(entry_parol.Text), "password");
                    content.Add(new StringContent(dpick_tyil.ToString()), "date_of_birth");

                    using (var client = new HttpClient())
                    {
                        var response = await client.PostAsync("http://localhost:8000/register", content);
                        if (response.IsSuccessStatusCode)
                        {
                            await DisplayAlert("Success", "File sent successfully", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", $"Failed to send file: {response.StatusCode}", "OK");
                        }
                    }
                }
            }
        }
    }
}