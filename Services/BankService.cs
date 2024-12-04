using AutoMapper;
using BrApi.Dtos;
using BrApi.Interfaces;

namespace BrApi.Services
{
    public class BankService : IBankService
    {
        private readonly IMapper _mapper;
        private readonly IBrApi _brApi;

        public BankService(IMapper mapper, IBrApi brApi)
        {
            _mapper = mapper;
            _brApi = brApi;
        }

        public async Task<Response<List<BankDto>>> GetAllBanks()
        {
            var banks = await _brApi.GetAllBanks();
            return _mapper.Map<Response<List<BankDto>>>(banks);
        }

        public async Task<Response<BankDto>> GetBankByCode(string code)
        {
            var bank = await _brApi.GetBankByCode(code);
            return _mapper.Map<Response<BankDto>>(bank);
        }
    }
}