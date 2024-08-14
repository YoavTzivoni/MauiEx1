using MauiEx1.Models;
using MauiEx1.ViewModels;

namespace MauiEx1.Pages;

public partial class RegistrationPage : ContentPage
{
	private User user = new User();
	public RegistrationPage()
	{
		InitializeComponent();
		LoadUser();
		BindingContext = new RegistrationViewModel();
	}

	public User User { get { return user; } }

	private bool SaveUser()
	{
		if (user.UserErrorMessage() == string.Empty)
		{
			Preferences.Set(nameof(user.Name), user.Name);
			Preferences.Set(nameof(user.UserName), user.UserName);
			Preferences.Set(nameof(user.Address), user.Address);
			Preferences.Set(nameof(user.Password), user.Password);
			Preferences.Set(nameof(user.DateOfBirth), user.DateOfBirth);
			Preferences.Set(nameof(user.Email), user.Email);
			return true;
		}

		DisplayAlert("Registration", user.UserErrorMessage(), "OK");
		return false;
	}

	private void LoadUser()
	{
		if (Preferences.ContainsKey(nameof(user.Name)))
		{
			user.Name = Preferences.Get(nameof(user.Name), string.Empty);
			user.UserName = Preferences.Get(nameof(user.UserName), string.Empty);
			user.Address = Preferences.Get(nameof(user.Address), string.Empty);
			user.Password = Preferences.Get(nameof(user.Password), string.Empty);
			user.DateOfBirth = Preferences.Get(nameof(user.DateOfBirth), DateTime.Now);
			user.Email = Preferences.Get(nameof(user.Email), string.Empty);
		}

	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		if (SaveUser())
			Shell.Current.GoToAsync("..");
	}
}


