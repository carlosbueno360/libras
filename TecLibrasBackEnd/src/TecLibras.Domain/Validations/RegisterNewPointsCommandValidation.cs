using TecLibras.Domain.Commands;

namespace TecLibras.Domain.Validations
{
    public class RegisterNewPointsCommandValidation : PointsValidation<RegisterNewPointsCommand>
    {
        public RegisterNewPointsCommandValidation()
        {
            ValidateId();
        }
    }
}