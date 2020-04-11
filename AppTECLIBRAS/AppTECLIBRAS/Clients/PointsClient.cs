using AppTECLIBRAS.Properties;
using AppTECLIBRAS.ViewModels;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTECLIBRAS.Clients
{
    public class PointsClientApi : IPointsClientApi
    {
        protected readonly RestClient _client;

        public PointsClientApi()
        {
            _client = new RestClient(Resources.PointsClientUrl);
        }

        public async Task<List<PointsViewModel>> GetPointsByUserId(Guid userId)
        {
            var request = new RestRequest($"points/{userId}", DataFormat.Json);

            var retorno = await _client.GetAsync<ResponseApi<List<PointsViewModel>>>(request);

            return retorno.data;
        }

        public async Task<List<RankViewModel>> GetPointsRank()
        {
            var request = new RestRequest($"rank", DataFormat.Json);

            var retorno = await _client.GetAsync<ResponseApi<List<RankViewModel>>>(request);

            return retorno.data;
        }

    }
}
