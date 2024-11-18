using BrApi.Dtos;

namespace BrApi.Interfaces
{
    public interface IBankService
    {
        Task<Response<List<BankResponse>>> GetAllBanks();
        Task<Response<BankResponse>> GetBankByCode(string code);
    }
}