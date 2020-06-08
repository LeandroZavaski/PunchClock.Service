using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
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
            RuleFor(r => r.DocumentCpf).NotNull().NotEmpty().WithMessage("é obrigatório").Length(11, 11).OverridePropertyName("cpf");
            RuleFor(r => r.DocumentRg).NotNull().NotEmpty().WithMessage("é obrigatório").Length(8, 8).OverridePropertyName("rg");
            RuleFor(r => r.DocumentPis).NotNull().NotEmpty().WithMessage("é obrigatório").Length(11, 11).OverridePropertyName("pis");
            RuleFor(r => r.Email).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("email");
            RuleFor(r => r.StartDate).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("dataContratacao");
            RuleFor(r => r.Active).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("ativo");
            RuleFor(r => r.Address).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("endereco");
            RuleFor(r => r.Shift).NotNull().NotEmpty().WithMessage("é obrigatório").OverridePropertyName("funcao");
            RuleFor(r => r.Shift).NotNull().NotEmpty().WithMessage("é obrigatório").Must(x => conditions.Contains(x)).WithMessage("Please only use: " + String.Join(",", conditions)).OverridePropertyName("turno");
        }
    }
}
