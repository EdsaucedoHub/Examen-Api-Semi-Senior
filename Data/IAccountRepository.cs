using System.Security.Principal;
using WebAPIExamenEP.Models;

namespace WebAPIExamenEP.Data
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByCardNumberAsync(string cardNumber);
        Task UpdateAccountAsync(Account account);
        Task CreateTransactionAsync(Transaction transaction);


    }
}
