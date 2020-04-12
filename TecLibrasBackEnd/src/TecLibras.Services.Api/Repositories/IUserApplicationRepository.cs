using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Repositories
{
    public interface IUserApplicationRepository
    {
        ApplicationUser GetByUserName(string userName);
    }
}