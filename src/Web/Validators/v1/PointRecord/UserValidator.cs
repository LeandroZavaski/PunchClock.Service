using FluentValidation;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using System;
using System.Collections.Generic;

namespace PunchClock.Service.Web.Validators.v1.PointRecord
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            var conditions = new List<string> { "Matutino", "Vespertino", "Noturno", "Administrativo" };

            RuleFor(r => r.Name).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("nome");
            RuleFor(r => r.BirthDate).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("dataNascimento");
            RuleFor(r => r.Phone).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("telefone");
            RuleFor(r => r.Gender).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("sexo");
            RuleForEach(x => x.Documents).SetValidator(new DocumentValidator());
            RuleFor(r => r.Email).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("email");
            RuleFor(r => r.StartDate).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("dataContratacao");
            RuleFor(r => r.Active).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("ativo");
            RuleFor(r => r.Address).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("endereco");
            RuleFor(r => r.Shift).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("funcao");
            RuleFor(r => r.Shift).NotNull().NotEmpty().WithMessage("é obrigatório").Must(x => conditions.Contains(x)).WithMessage("Please only use: " + String.Join(",", conditions)).OverridePropertyName("turno");
        }
    }
}
