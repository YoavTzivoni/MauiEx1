//using Bumptech.Glide.Load.Resource.Gif;

namespace MauiEx1;

public partial class DynamicPage : ContentPage
{
	private string[] images = { "https://www.w3schools.com/howto/img_nature_wide.jpg",
		"https://www.w3schools.com/howto/img_snow_wide.jpg",
		"https://www.w3schools.com/howto/img_lights_wide.jpg",
		"https://www.w3schools.com/howto/img_mountains_wide.jpg"};
	private int index = 0;
	private Image img;

	public DynamicPage()
	{
		InitializeComponent();
		LoadControls();
		ShowImage();
	}

	private void LoadControls()
	{
		Content = new VerticalStackLayout()
		{
			Children =
			{
				new Button()
				{
					FontFamily = "MaterialSymbolsRounded",
					FontSize = 35.0,
					HorizontalOptions = LayoutOptions.Center,
					Text = IconFont.Arrow_upward
				},
				new Image()
				{
					Margin = 10,
					HeightRequest = 150,
					Source="dotnet_bot.png"
				},
				new Button()
				{
					FontFamily = "MaterialSymbolsRounded",					
					FontSize = 35.0,
					HorizontalOptions = LayoutOptions.Center,
					Text = IconFont.Arrow_downward
				},

				new Button()
				{
					FontFamily = "MaterialSymbolsRounded",
					FontSize = 35.0,
					HorizontalOptions = LayoutOptions.Center,
					Text = "Back",
					Margin= 10
				}
			}
		};
		
		VerticalStackLayout v  =  Content as VerticalStackLayout;
		Button btnUp = (Button)v.Children[0];
		img = (Image)v.Children[1];
		Button btnDown = (Button)v.Children[2];
		btnUp.Clicked += (s, e) =>
		{
			if (index == 0) index = 4;
			index--;
			ShowImage();
		};
		btnDown.Clicked += (s, e) =>
		{
			if (index == 3) index = -1;
			index++;
			ShowImage();
		};
		Button btnBack = (Button)v.Children[3];
		btnBack.Clicked += (s, e) =>
		{
			btnBack.Text = "..";
			Shell.Current.GoToAsync("..");
		};
	}

	private async void ShowImage()
	{
		img.Source = images[index];
		Title = index.ToString();
		await img.RotateTo(360, 2000);
		img.Rotation = 0;

	}
}