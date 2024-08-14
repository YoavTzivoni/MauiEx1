using MauiEx1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiEx1.ViewModels
{
	public class RegistrationViewModel : ViewModelBase
	{
		private string name;
		private string userName;
		private string address;
		private DateTime dateOfBirth;
		private string email;
		private string password;

		private User newUser;

		public RegistrationViewModel()
		{
			AddUserCommand = new Command(AddUser);
		}

		public ICommand AddUserCommand
		{
			get; private set;
		}

		private void AddUser()
		{
			string errorMsg = UserErrorMessage();

			if (errorMsg == string.Empty) 
			{
				User user = new User()
				{
					Name = name,
					UserName = userName,
					Address = address,
					Email = email,
					Password = password,
					DateOfBirth = dateOfBirth
				};
				Shell.Current.DisplayAlert("Add User", "Registered", "ok");
			}
			else { Shell.Current.DisplayAlert("Add User", errorMsg, "OK"); }
		}

		private string UserErrorMessage()
		{
			string msg = string.Empty;
			if (!IsNameValid) msg += "Name need to be more then 5 characters" + Environment.NewLine;
			if (!IsUserNameValid) msg += "User Name need to be more then 5 characters" + Environment.NewLine;
			if (!IsAddressValid) msg += "Address need to be more then 5 characters" + Environment.NewLine;
			if (!IsEmailValid) msg += "Email is not in thr correct format" + Environment.NewLine;
			if (!IsPasswordValid) msg += "Password need to be more then 5 characters and contains number and upper case" + Environment.NewLine;
			if (!IsDateOfBirthValid) msg += "Age Must be more then 18";
			return msg;
		}
		public string Name
		{
			get { return name; }
			set { if (value != name) name = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsNameValid)); OnPropertyChanged(nameof(NameValidationIcon)); OnPropertyChanged(nameof(NameValidationIconColor)); }
		}
		public bool IsNameValid
		{
			get
			{				
				return !string.IsNullOrEmpty(name);
			}
		}
		public string NameValidationIcon { get { return IsNameValid ? "\ue876" : "\ue645"; } }
		public string NameValidationIconColor { get { return IsNameValid ? "Green" : "Red"; } }

		public string UserName
		{
			get { return userName; }
			set { if (userName != value) userName = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsUserNameValid)); OnPropertyChanged(nameof(UserNameValidationIcon)); OnPropertyChanged(nameof(UserNameValidationIconColor)); }
		}
		public string UserNameValidationIcon { get { return IsUserNameValid ? "\ue876" : "\ue645"; } }
		public string UserNameValidationIconColor { get { return IsUserNameValid ? "Green" : "Red"; } }

		public bool IsUserNameValid
		{
			get
			{
				Regex regex = new Regex("^[a-z]*$");//start with letters and no spaces
				return (!string.IsNullOrEmpty(userName) && regex.IsMatch(userName));
			}
		}

		public string Address
		{
			get { return address; }
			set { if (address != value) address = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsAddressValid)); OnPropertyChanged(nameof(AddressValidationIcon)); OnPropertyChanged(nameof(AddressValidationIconColor)); }
		}
		public bool IsAddressValid { get { return !string.IsNullOrEmpty(address); } }
		public string AddressValidationIcon { get { return IsAddressValid ? "\ue876" : "\ue645"; } }
		public string AddressValidationIconColor { get { return IsAddressValid ? "Green" : "Red"; } }

		public string Email
		{
			get { return email; }
			set { if(email != value) email = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsEmailValid)); OnPropertyChanged(nameof(EmailValidationIcon)); OnPropertyChanged(nameof(EmailValidationIconColor)); }
		}

		public bool IsEmailValid
		{
			get
			{
				string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
				return !string.IsNullOrEmpty(email) &&  Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
			}
		}
		public string EmailValidationIcon { get { return IsEmailValid ? "\ue876" : "\ue645"; } }
		public string EmailValidationIconColor { get { return IsEmailValid ? "Green" : "Red"; } }

		public DateTime DateOfBirth
		{
			get { return dateOfBirth; }
			set { if (dateOfBirth != value) dateOfBirth = value; OnPropertyChanged(); OnPropertyChanged(nameof(Age)); OnPropertyChanged(nameof(IsDateOfBirthValid)); OnPropertyChanged(nameof(DateOfBirthValidationIcon)); OnPropertyChanged(nameof(DateOfBirthValidationIconColor)); }
		}
		public bool IsDateOfBirthValid { get { return Age > 18; } }
		public string DateOfBirthValidationIcon { get { return IsDateOfBirthValid ? "\ue876" : "\ue645"; } }
		public string DateOfBirthValidationIconColor { get { return IsDateOfBirthValid ? "Green" : "Red"; } }

		public string Password
		{
			get { return password; }
			set { if (password != value) password = value; OnPropertyChanged(); }
		}

		public bool IsPasswordValid
		{
			get
			{
				Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]+$");
				return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
			}
		}
		public string PasswordValidationIcon { get { return IsPasswordValid ? "\ue876" : "\ue645"; } }
		public string PasswordValidationIconColor { get { return IsPasswordValid ? "Green" : "Red"; } }

		public int Age
		{
			get
			{
				var today = DateTime.Today;

				var a = (today.Year * 100 + today.Month) * 100 + today.Day;
				var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

				return (a - b) / 10000;
			}
		}

	}
}
