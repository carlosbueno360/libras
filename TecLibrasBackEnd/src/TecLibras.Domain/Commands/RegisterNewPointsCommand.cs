using System;
using TecLibras.Domain.Validations;

namespace TecLibras.Domain.Commands
{
    public class RegisterNewPointsCommand : PointsCommand
    {
        public RegisterNewPointsCommand(Guid id, int points)
        {
            Id = id;
            Points = points;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPointsCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}