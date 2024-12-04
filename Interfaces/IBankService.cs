using BrApi.Dtos;

namespace BrApi.Interfaces
{
    public interface IBankService
    {
        Task<Response<List<BankDto>>> GetAllBanks();
        Task<Response<BankDto>> GetBankByCode(string code);
    }
}