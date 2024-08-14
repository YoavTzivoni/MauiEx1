using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiEx1.Models
{
	public class User : ObservableObject
	{
		private bool IsEmailValid(string email)
		{
			string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

			return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
		}

		private string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { if (name != value) { name = value; OnPropertyChanged(); OnPropertyChanged(nameof(NameValidationIcon)); OnPropertyChanged(nameof(NameValidationIconColor)); OnPropertyChanged(nameof(IsNameValid)); } }
		}
		public bool IsNameValid { get { return name.Length > 5; } }
		public string NameValidationIcon { get { return IsNameValid ? "\ue876" : "\ue645"; } }
		public string NameValidationIconColor { get { return IsNameValid ? "Green" : "Red"; } }
		private string userName = string.Empty;

		public string UserName
		{
			get { return userName; }
			set { userName = value; OnPropertyChanged(); OnPropertyChanged(nameof(UserNameValidationIcon)); OnPropertyChanged(nameof(UserNameValidationIconColor)); OnPropertyChanged(nameof(IsUserNameValid)); }
		}
		public bool IsUserNameValid { get{ return userName.Length > 5; }}
		public string UserNameValidationIcon { get { return IsUserNameValid ? "\ue876" : "\ue645"; } }
		public string UserNameValidationIconColor { get { return IsUserNameValid ? "Green" : "Red"; } }

		private string address = string.Empty;

		public string Address
		{
			get { return address; }
			set { address = value; OnPropertyChanged(); OnPropertyChanged(nameof(AddressValidationIcon)); OnPropertyChanged(nameof(AddressValidationIconColor)); }
		}
		public bool IsAddressValid { get { return address.Length > 5; }}
		public string AddressValidationIcon { get { return IsAddressValid ? "\ue876" : "\ue645"; } }
		public string AddressValidationIconColor { get { return IsAddressValid ? "Green" : "Red"; } }

		private string email = string.Empty;

		public string Email
		{
			get { return email; }
			set { email = value; OnPropertyChanged(); OnPropertyChanged(nameof(EmailValidationIcon)); OnPropertyChanged(nameof(EmailValidationIconColor)); }
		}
		public string EmailValidationIcon { get { return IsEmailValid(email) ? "\ue876" : "\ue645"; } }
		public string EmailValidationIconColor { get { return IsEmailValid(email) ? "Green" : "Red"; } }

		private DateTime dateOfBirth;

		public DateTime DateOfBirth
		{
			get { return dateOfBirth; }
			set { dateOfBirth = value; OnPropertyChanged(); OnPropertyChanged(nameof(Age)); OnPropertyChanged(nameof(DateOfBirthValidationIcon)); OnPropertyChanged(DateOfBirthValidationIconColor); }
		}
		public bool IsDateOfBirthValid { get { return Age > 18; } }
		public string DateOfBirthValidationIcon { get { return IsDateOfBirthValid ? "\ue876" : "\ue645"; } }
		public string DateOfBirthValidationIconColor { get { return IsDateOfBirthValid ? "Green" : "Red"; } }

		private string password = string.Empty;

		public string Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(PasswordValidationIcon)); OnPropertyChanged(nameof(PasswordValidationIconColor)); }
		}
		public bool IsPasswordValid { get { return password.Length > 5 && password.Any(char.IsNumber) && password.Any(Char.IsUpper); } }
		public string PasswordValidationIcon { get { return IsPasswordValid ? IconFont.Done : IconFont.Priority_high; } }
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

		public string UserErrorMessage()
		{
			string msg = string.Empty;
			if (!IsNameValid) msg += "Name need to be more then 5 characters" + Environment.NewLine;
			if (!IsUserNameValid) msg += "User Name need to be more then 5 characters" + Environment.NewLine;
			if (!IsAddressValid) msg += "Address need to be more then 5 characters" + Environment.NewLine;
			if (!IsEmailValid(Email)) msg += "Email is not in thr correct format" + Environment.NewLine;
			if (!IsPasswordValid) msg += "Password need to be more then 5 characters and contains number and upper case" + Environment.NewLine;
			if (!IsDateOfBirthValid) msg += "Age Must be more then 18";
			return msg;
		}
	}
}
