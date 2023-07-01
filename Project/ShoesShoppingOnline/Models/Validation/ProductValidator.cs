using FluentValidation;
using ShoesShoppingOnline.Models.DataModel;
using System;
namespace ShoesShoppingOnline.Models.Validation
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product Name is required");
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
            RuleFor(p => p.BrandId)
                .NotEmpty().WithMessage("Brand ID is required");
            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Image path is required");
        }
    }
}
