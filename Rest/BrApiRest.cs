using System.Dynamic;
using System.Text.Json;
using BrApi.Dtos;
using BrApi.Interfaces;
using BrApi.Models;

namespace BrApi.Rest
{
    public class BrApiRest : IBrApi
    {
        public async Task<Response<List<BankModel>>> GetAllBanks()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://brasilapi.com.br/api/banks/v1");

            var response = new Response<List<BankModel>>();
            using (var client = new HttpClient())
            {
                var responseBrApi = await client.SendAsync(request);
                var contentResponse = await responseBrApi.Content.ReadAsStringAsync();
                var banks = JsonSerializer.Deserialize<List<BankModel>>(contentResponse);

                if(responseBrApi.IsSuccessStatusCode)
                {
                    response.HttpStatusCode = responseBrApi.StatusCode;
                    response.Data = banks;
                }
                else
                {
                    response.HttpStatusCode = responseBrApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }
            return response;
        }

        public async Task<Response<BankModel>> GetBankByCode(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{code}");

            var response = new Response<BankModel>();
            
            using(var client = new HttpClient()){
                var responseBrApi = await client.SendAsync(request);
                var contentResponse = await responseBrApi.Content.ReadAsStringAsync();
                var bank = JsonSerializer.Deserialize<BankModel>(contentResponse);

                if(responseBrApi.IsSuccessStatusCode){
                    response.HttpStatusCode = responseBrApi.StatusCode;
                    response.Data = bank;
                }
                else{
                    response.HttpStatusCode = responseBrApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }
            return response;
        }
    }
}