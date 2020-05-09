﻿using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using FluentValidation;

namespace DelMazo.PointRecord.Service.Web.Validators.v1.PointRecord
{
    public class PunchClockValidator : AbstractValidator<PunchClockRequest>
    {
        public PunchClockValidator()
        {
            RuleFor(p => p.Document).NotNull().NotEmpty().Length(11, 11).OverridePropertyName("cpf");
        }
    }
}
