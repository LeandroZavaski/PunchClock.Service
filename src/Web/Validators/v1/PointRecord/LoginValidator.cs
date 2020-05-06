using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Document).NotNull().NotEmpty().MaximumLength(11); ;
            RuleFor(p => p.Password).NotNull().NotEmpty();
        }
    }
}
