using FluentValidation;
using ShoesShoppingOnline.Models.DataModel;
using System;

public class RegisterValidator : AbstractValidator<RegisterModel>
{
	public RegisterValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Please enter your email address")
			.EmailAddress().WithMessage("Please enter a valid email address");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.Matches(@"^(?=.*[!@#$%^&*(),.?\""':{}|<>])(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,}$")
			.WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");

		RuleFor(x => x.Address)
			.Matches(@"^[^!@#$%^&*0-9]{10,}$").WithMessage("Invalid Address: Should not contain special characters, should not start with a number, and must have at least 10 characters.");

		RuleFor(x => x.Name)
			.Matches(@"^[^!@#$%^&*0-9]{5,}$").WithMessage("Invalid Name: Should not contain special characters, should not start with a number, and must have at least 5 characters.");

		RuleFor(x => x.PhoneNumber)
			.Matches(@"^\d{10}$").WithMessage("Invalid phone number: Should be a 10-digit number.");

		RuleFor(x => x.PasswordConfirmation)
			.NotEmpty().WithMessage("Password confirmation is required.")
			.Equal(x => x.Password).WithMessage("Password confirmation does not match.");
	}

}
