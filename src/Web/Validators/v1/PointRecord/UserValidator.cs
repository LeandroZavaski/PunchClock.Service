using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().OverridePropertyName("nome");
            RuleFor(r => r.BirthDate).NotNull().NotEmpty().OverridePropertyName("dataNascimento");
            RuleFor(r => r.Phone).NotNull().NotEmpty().OverridePropertyName("telefone");
            RuleFor(r => r.Gender).NotNull().NotEmpty().OverridePropertyName("sexo");
            RuleFor(r => r.DocumentCpf).NotNull().NotEmpty().Length(11, 11).OverridePropertyName("cpf");
            RuleFor(r => r.DocumentRg).NotNull().NotEmpty().Length(8, 8).OverridePropertyName("rg");
            RuleFor(r => r.DocumentPis).NotNull().NotEmpty().Length(11, 11).OverridePropertyName("pis");
            RuleFor(r => r.Email).NotNull().NotEmpty().OverridePropertyName("email");
            RuleFor(r => r.StartDate).NotNull().NotEmpty().OverridePropertyName("dataContratacao");
            RuleFor(r => r.Active).NotNull().NotEmpty().OverridePropertyName("ativo");
        }
    }
}
