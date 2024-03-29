﻿using FluentValidation;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;

namespace PunchClock.Service.Web.Validators.v1.PointRecord
{
    public class AuthResetValidator : AbstractValidator<AuthResetRequest>
    {
        public AuthResetValidator()
        {
            RuleFor(p => p.Password).NotNull().NotEmpty();
            RuleFor(p => p.ConfirmedPassword).NotNull().NotEmpty();
            RuleFor(p => p.Password).Equal(p => p.ConfirmedPassword).WithMessage("As senhas devem ser iguais");
        }
    }
}
