using FluentValidation;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Domain.Enums;
using PunchClock.Service.Web.Helpers;
using System;
using System.Collections.Generic;

namespace PunchClock.Service.Web.Validators.v1.PointRecord
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            var types = new List<string> { "CPF", "RG", "PIS" };

            RuleFor(r => r.Type).NotNull().NotEmpty().WithMessage("é obrigatório").Must(x => types.Contains(x)).WithMessage("Please only use: " + String.Join(",", types));

            RuleFor(r => r.Number).NotNull().NotEmpty().WithMessage("cpf é obrigatório")
                .When(w => w.Type.Equals(DocumentType.Cpf) && ValidateDocuments.IsValidCpf(w.Number)).WithMessage("cpf inválido").Length(10, 11).WithMessage("cpf deve possuir 11 char");

            RuleFor(r => r.Number).NotNull().NotEmpty().WithMessage("pis é obrigatório")
                .When(w => w.Type.Equals(DocumentType.Pis) && ValidateDocuments.IsValidPis(w.Number)).WithMessage("pis inválido").Length(8, 11).WithMessage("pis deve possuir 10 char");

            RuleFor(r => r.Number).NotNull().NotEmpty().WithMessage("rg é obrigatório")
                .When(w => w.Type.Equals(DocumentType.Rg)).Length(7, 10).WithMessage("rg deve possuir entre 8 a 10 char");

        }
    }
}
