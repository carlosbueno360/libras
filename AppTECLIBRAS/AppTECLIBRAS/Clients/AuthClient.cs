using AppTECLIBRAS.Properties;
using AppTECLIBRAS.ViewModels;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTECLIBRAS.Clients
{
    public class AuthClient : IAuthClient
    {
        protected readonly RestClient _client;

        public AuthClient()
        {
            _client = new RestClient(Resources.PointsClientUrl);
        }



        public async Task<LoggedinReponse> RegisterUser(UserRegistration userRegistration)
        {
            var request = new RestRequest($"/api/Account/register", DataFormat.Json);
            request.AddJsonBody(userRegistration);
            var retorno = await _client.PostAsync<ResponseApi<LoggedinReponse>>(request);

            return retorno.data;
        }

        public async Task<LoggedinReponse> Login(UserLogin userLogin)
        {
            var request = new RestRequest($"/api/Account/login", DataFormat.Json);
            request.AddJsonBody(userLogin);
            var retorno = await _client.PostAsync<ResponseApi<LoggedinReponse>>(request);

            return retorno.data;
        }
    }
}
