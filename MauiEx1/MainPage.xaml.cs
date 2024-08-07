//using Android.Util;
//using Java.Lang;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiEx1
{
	public partial class MainPage : ContentPage , INotifyPropertyChanged
	{
		private string[] images = { "https://www.w3schools.com/howto/img_nature_wide.jpg",
		"https://www.w3schools.com/howto/img_snow_wide.jpg",
		"https://www.w3schools.com/howto/img_lights_wide.jpg",
		"https://www.w3schools.com/howto/img_mountains_wide.jpg"};

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private int index = 0;
		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
			ShowImage();			
		}
		public int Index { get { return index; } set { index = value; OnParentChanged(); } }
		double sliderIndex = 0;
		public double SliderIndex { get { return sliderIndex; } set{ sliderIndex = value; Index = (int)sliderIndex; }}
		private void btnUp_Clicked(object sender, EventArgs e)
		{
			if (index == 0) index = 4;
			index--;
			ShowImage();
		}

		private void btnDown_Clicked(object sender, EventArgs e)
		{
			if (index == 3) index = -1;
			index++;
			ShowImage();
			
		}

		private async void ShowImage()
		{
			img.Source = images[index];
			//Title = index.ToString();
			await img.RotateTo(360, 1000);
			img.Rotation = 0;

		}

		private async void NavigateDynamic(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//DynamicPage");
        }

		private async void NavigateRegistration(object sender, EventArgs e)
		{
			//await Shell.Current.GoToAsync("//Registration");
			await Shell.Current.Navigation.PushAsync(new Pages.RegistrationPage());
		}

		private async void SendSmsClicked(object sender, EventArgs e)
		{
			bool status = await SmsPermission();
			if (!status) return;

			if (Sms.Default.IsComposeSupported || true)
			{
				string[] recipients = new[] { "052-8998875" };
				string text = "Hello, I'm interested in buying your vase.";

				var message = new SmsMessage(text, recipients);

				await Sms.Default.ComposeAsync(message);
				await DisplayAlert("SMS", "Sms send", "OK");
			}
		}

		private async Task<bool> SmsPermission()
		{
			var status = await Permissions.CheckStatusAsync<Permissions.Sms>();
			//Log.Debug("EX1", "1 " + status.ToString());
			await DisplayAlert("SMS", status.ToString(), "OK");
			if (status == PermissionStatus.Granted) return true;

			status = await Permissions.RequestAsync<Permissions.Sms>();
			if (status == PermissionStatus.Granted) { return true; }
			return false;
		}
	}

}
