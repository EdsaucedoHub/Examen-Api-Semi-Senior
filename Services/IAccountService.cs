
using WebAPIExamenEP.DTOs;
namespace WebAPIExamenEP.Services
{
    public interface IAccountService
    {
        Task<string> ChangePINAsync(ChangePinDto dto);
        Task<decimal?> CheckBalanceAsync(string cardNumber, string pin);
        Task<string> DepositAmountAsync(DepositDto dto);
        Task<string> WithdrawAmountAsync(WithdrawDto dto);
    }
}
