using FluentValidation;
using PunchClock.Service.Domain.Enums;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using PunchClock.Service.Web.Helpers;

namespace PunchClock.Service.Web.Validators.v1.PointRecord
{
    public class VacationValidator : AbstractValidator<VacationRequest>
    {
        public VacationValidator()
        {
            RuleFor(r => r.Registration).NotNull().NotEmpty().WithMessage("matricula é obrigatório").OverridePropertyName("matricula");
            RuleFor(r => r.Name).NotNull().NotEmpty().WithMessage("nome é obrigatório").OverridePropertyName("nome");
            RuleFor(r => r.Document.Number).NotNull().NotEmpty().WithMessage("cpf é obrigatório")
                .When(w => w.Document.Type.Equals(DocumentType.Cpf) && ValidateDocuments.IsValidCpf(w.Document.Number)).WithMessage("cpf inválido").Length(10, 11).WithMessage("cpf deve possuir 11 char");
            RuleFor(r => r.StartDate).NotNull().NotEmpty().WithMessage("inicio é obrigatório").OverridePropertyName("inicioFerias");
            RuleFor(r => r.EndDate).NotNull().NotEmpty().WithMessage("termino é obrigatório").OverridePropertyName("terminoFerias");
        }
    }
}
