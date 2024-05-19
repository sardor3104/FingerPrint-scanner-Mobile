using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace Fingerprint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sign : ContentPage
    {
        public sign()
        {
            InitializeComponent();
            parolun();
        }
        string esla = "";
        private async void parolun()
        {
            esla = await Xamarin.Essentials.SecureStorage.GetAsync("parolni_eslash");
            if (esla == "parol_uchun")
            {
                label_head.Text = "parol uchun " + label_head.Text;
                Xamarin.Essentials.SecureStorage.Remove("parolni_eslash");
                entry_email.Text = await Xamarin.Essentials.SecureStorage.GetAsync("email");
                entry_email.IsEnabled = false;
            }
            else
            {
                label_head.Text = @"Marhamat ma'lumotlaringizni kiriting";
                entry_email.IsEnabled=true;
            }
        }
        string parol="";
        Random rnd = new Random();
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
            label_soat.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private async void loginconfirm(object sender, EventArgs e)
        {
           if (entry_kalit.Text == parol)
           {
                await DisplayAlert("muvaffaqqiyatli", "bir martalik parol tasdiqlandi", "ok");
                if (esla == "parol_uchun")
                {
                Xamarin.Essentials.SecureStorage.Remove("parolni_eslash");
                await Xamarin.Essentials.SecureStorage.SetAsync("parolni_eslash", "ozgartirish");
                    await Navigation.PushAsync(new parol());         
                }
                else if(await Xamarin.Essentials.SecureStorage.GetAsync("parolni_eslash") != "parol_uchun")
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("email", entry_email.Text);
                    await Navigation.PushAsync(new sign_up());
                }
            }
            else if (entry_kalit.Text == null || entry_kalit.Text.Length < 8 || entry_kalit.Text.Length > 20)
            {
                label_error.Text = "parolni to\'g\'ri to'ldiring";
                label_error_plus.Text = "parol kamida 8ta ko\'pi bilan 20ta raqamdan iborat bo'lishi kerak";
                label_error.TextColor = Color.Red;
                buttonOK.Text = "Qayta urinish";
                buttonOK.TextColor = Color.Blue;
            }
            else
            {
                label_error.Text = "qaytadan urinib ko'ring";
                label_error.TextColor = Color.Red;
                buttonOK.Text = "tekshirish";
                buttonOK.TextColor = Color.Red;
                await DisplayAlert("Xatolik", "Ma'lumot topilmadi", "Xop");
            }
        }

        private void Clicked_xabar(object sender, EventArgs e)
        {
            if (entry_email.Text != null)
            {
                try {
                    parol = "";
                    string fromMail = "sabduhoshimov538@gmail.com";
                    string fromPaswd = "eakbfvoniqfnigku";
                    for (int j = 0; j < 4; j++)
                    {
                        parol += rnd.Next(10, 99);
                    }
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(fromMail);
                    message.Subject = "Fingerprint ilovasi";
                    message.To.Add(new MailAddress(entry_email.Text));
                    message.Body = $"<html><body>Bir martalik parol: {parol}</body></html>";
                    message.IsBodyHtml = true;
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPaswd),
                        EnableSsl = true,
                    };
                    smtpClient.Send(message);
                    entry_kalit.IsEnabled = true;
                }
                catch
                {
                    DisplayAlert("xatolik", "gmail adress tog'ri kiritilganligiga ishonch hosil qiling", "xop");
                    entry_kalit.IsEnabled = false;
                }
            }
            else
            {
                entry_kalit.IsEnabled = false;
                DisplayAlert("xatolik","email to'ldirilmagan","xop");
            }
        }
    }
}