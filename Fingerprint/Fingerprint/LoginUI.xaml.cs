using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
namespace Fingerprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
            salom();
            GetEmailAsync();
            if (name != "" && name != null)
            {
                login.IsEnabled = true;
                login.IsVisible = true;
                grid_firstpage.IsEnabled = false;
                grid_firstpage.IsVisible = false;
            }
            else
            {
                login.IsVisible = false;
                login.IsEnabled = false;
                grid_firstpage.IsVisible = true;
                grid_firstpage.IsEnabled = true;
            }
        }

        string name = "";
        public async void GetEmailAsync()
        {
            name = await Xamarin.Essentials.SecureStorage.GetAsync("ism");
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginWithKeyUI());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new sign());
        }

        private async void salom()
        {
            string porol = await Xamarin.Essentials.SecureStorage.GetAsync("dastur_paroli");
            label_assalom.Text = $"Assalomu Alaykum {await Xamarin.Essentials.SecureStorage.GetAsync("ism")} {await Xamarin.Essentials.SecureStorage.GetAsync("familiya")}";
            if(porol == "" || porol == null)
            {
                button_kalit.Text = "parolni o\'rnatish";
                Xamarin.Essentials.SecureStorage.Remove("parolni_eslash");
                await Xamarin.Essentials.SecureStorage.SetAsync("parolni_eslash", "ozgartirish");
            }
            else
            {
                button_kalit.Text = "kalit orqali urinib ko'rish";
            }
        }

        private void clicked_kalit(object sender, EventArgs e)
        {
            Navigation.PushAsync(new parol());
        }

        private async void Clicked_barmoq(object sender, EventArgs e)
        {
            var available = await
            CrossFingerprint.Current.IsAvailableAsync();
            if (!available)
            {
                await DisplayAlert("Xato", "barmoq izi skanerida muommo bor", "xop");
                button_muammo.IsVisible= true;
                return; 

            }
            
            var authresult = await CrossFingerprint.Current.AuthenticateAsync(new 
                AuthenticationRequestConfiguration("Marhamat", "biometrik ma'lumotlaringizni kiritishingiz mumkin"));
            if (await Xamarin.Essentials.SecureStorage.GetAsync("ism") == null || await Xamarin.Essentials.SecureStorage.GetAsync("familiya")==null)
            {
                await DisplayAlert("xatolik", "siz registratsiya qilinmagansiz", "xop");
            }
            else if (authresult.Authenticated) 
            {
                await DisplayAlert("Muvaffaqqiyatli",$"marhamat {await Xamarin.Essentials.SecureStorage.GetAsync("ism")} {await Xamarin.Essentials.SecureStorage.GetAsync("familiya")} kirishingiz mumkin", "xop");
            }
            else
            {
                await DisplayAlert("Xatolik", "Qaytadan urinib ko'ring", "xop");
            }
        }

        private async void Clicked_muammo(object sender, EventArgs e)
        {
            var picture = await CrossFingerprint.Current.GetAvailabilityAsync();
            await DisplayAlert("sizda quyidagicha muammo mavjud", picture.ToString() , "ok");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new sign());
        }

        private void Tapped_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginWithKeyUI());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
            Navigation.PopToRootAsync();
            Navigation.PushAsync(new LoginUI());
            var firstPage = Navigation.NavigationStack.FirstOrDefault();
            if (firstPage != null)
            {
                Navigation.RemovePage(firstPage);
            }
        }

        private async void Button_Capture(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FingerprintCapturePage());
        }
    }
}