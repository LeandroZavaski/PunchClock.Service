using FluentValidation;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;

namespace PunchClock.Service.Web.Validators.v1.PointRecord
{
    public class AuthValidator : AbstractValidator<AuthRequest>
    {
        public AuthValidator()
        {
            RuleFor(p => p.Document).NotNull().NotEmpty();
            RuleFor(p => p.Password).NotNull().NotEmpty();
        }
    }
}
