using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
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
