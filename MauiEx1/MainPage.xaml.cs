namespace MauiEx1
{
	public partial class MainPage : ContentPage
	{
		private string[] images = { "https://www.w3schools.com/howto/img_nature_wide.jpg",
		"https://www.w3schools.com/howto/img_snow_wide.jpg",
		"https://www.w3schools.com/howto/img_lights_wide.jpg",
		"https://www.w3schools.com/howto/img_mountains_wide.jpg"};
		private int index = 0;
		public MainPage()
		{
			InitializeComponent();
			ShowImage();			
		}

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
			Title = index.ToString();
			await img.RotateTo(360, 2000);
			img.Rotation = 0;

		}

		private async void NavigateDynamic(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//DynamicPage");
        }
    }

}
