using System;
using TecLibras.Domain.Commands;
using FluentValidation;

namespace TecLibras.Domain.Validations
{
    public abstract class PointsValidation<T> : AbstractValidator<T> where T : PointsCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}