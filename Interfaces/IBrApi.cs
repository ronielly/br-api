using BrApi.Dtos;
using BrApi.Models;

namespace BrApi.Interfaces
{
    public interface IBrApi
    {
        Task<Response<List<BankModel>>> GetAllBanks();
        Task<Response<BankModel>> GetBankByCode(string code);
    }
}