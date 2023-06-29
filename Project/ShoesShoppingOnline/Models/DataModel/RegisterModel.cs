using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShoesShoppingOnline.Models.DataModel
{
    public class RegisterModel
    {
		[Required(ErrorMessage = "Please enter your email address")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email address")]
		[MaxLength(50)]
		[RegularExpression(@"^[^@]+@[^-][a-z0-9.-]+(\.(?!web$)[a-z]{2,4}|\.web\.[a-z]{2,4})$", ErrorMessage = "Please enter correct email")]


		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
		[RegularExpression(@"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]

		public string Password { get; set; }
		
		[RegularExpression(@"^[^!@#$%^&*0-9]{10,}$", ErrorMessage = "Invalid Address")]
		public string Address { get; set; }

		[RegularExpression(@"^[^!@#$%^&*0-9]{5,}$", ErrorMessage = "Invalid Name")]
		public string Name { get; set; }

		[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
		public string PhoneNumber { get; set; }
		
		[Required(ErrorMessage = "Password confirmation is required.")]
		[Compare("Password", ErrorMessage = "Password confirmation does not match.")]
		public string PasswordConfirmation { get; set; }


	}
}
