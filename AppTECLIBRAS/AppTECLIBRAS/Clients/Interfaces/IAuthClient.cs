using AppTECLIBRAS.ViewModels;
using Refit;
using System;
using System.Threading.Tasks;

namespace AppTECLIBRAS.Clients
{
    public interface IAuthClient
    {

        Task<string> RegisterUser(UserRegistration userRegistration);

    }

    public class RankViewModel
    {
   
        public int Points { get; set; }

  
        public Guid UserId { get; set; }


        public ApplicationUserViewModel User { get; set; }
    }

    public class ApplicationUserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

    }
}