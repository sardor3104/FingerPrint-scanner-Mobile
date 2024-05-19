using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fingerprint
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class parol : ContentPage
	{
		public parol ()
		{
			InitializeComponent ();
            mumkinmi();
		}
        private async void mumkinmi()
        {
            string qiymatim = await Xamarin.Essentials.SecureStorage.GetAsync("parolni_eslash");
            if(qiymatim == "ozgartirish")
            {
                label_unutdingmi.IsVisible = false;
            }
            else
            {
                label_unutdingmi.IsVisible=true;
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            label_parol.Text += "1";
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            label_parol.Text += 2;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            label_parol.Text += 3;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            label_parol.Text += 4;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            label_parol.Text += 5;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            label_parol.Text += 6;
            label_parol.Text= label_parol.Text.Substring(1);
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            label_parol.Text += 7;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            label_parol.Text += 8;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            label_parol.Text += 9;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private async void Button_Clicked_9(object sender, EventArgs e)
        {
            if (label_parol.Text.Contains('*'))
            {
                await DisplayAlert("Xatolik", "Parol 4ta raqamdan iborat", "Xop");
            }
            else
            {
                string ok = await Xamarin.Essentials.SecureStorage.GetAsync("parolni_eslash");
                if (ok == "ozgartirish")
                {
                    Xamarin.Essentials.SecureStorage.Remove("dastur_paroli");
                    await Xamarin.Essentials.SecureStorage.SetAsync("dastur_paroli",label_parol.Text);
                    Xamarin.Essentials.SecureStorage.Remove("parolni_eslash");
                    await DisplayAlert("muvaffaqqiyatli", "tabriklaymiz parol o\'rnatildi","xop");
                    await Navigation.PopAsync();
                }
                else if (ok != "ozgartirish")
                {
                    if(await Xamarin.Essentials.SecureStorage.GetAsync("dastur_paroli") == label_parol.Text)
                    {
                        await DisplayAlert("Tasdiqlandi",$"Marhamat {await Xamarin.Essentials.SecureStorage.GetAsync("ism")} {await Xamarin.Essentials.SecureStorage.GetAsync("familiya")}","xop");
                    }
                    else
                    {
                        await DisplayAlert("xatolik", "parol mos kelmadi", "xop");
                    }
                }
            }
        }

        private void Button_Clicked_10(object sender, EventArgs e)
        {
            label_parol.Text += 0;
            label_parol.Text=label_parol.Text.Substring(1);
        }

        private void Button_Clicked_11(object sender, EventArgs e)
        {

            label_parol.Text = label_parol.Text.Substring(0, label_parol.Text.Length - 1);
            label_parol.Text = "*"+ label_parol.Text;
        }

        private void Button_Clicked_12(object sender, EventArgs e)
        {
            label_parol.Text = "****";
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.SetAsync("parolni_eslash","parol_uchun");
            Navigation.PushAsync(new sign());
        }
    }
}