using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Document).NotNull().NotEmpty().WithMessage("O numero de documento deve ser informado");
            RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("A senha deve ser informada");
        }
    }
}
