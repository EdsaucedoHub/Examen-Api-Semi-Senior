using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using WebAPIExamenEP.Models;

namespace WebAPIExamenEP.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountByCardNumberAsync(string cardNumber)
        {
            // Busca una cuenta en la base de datos cuyo número de tarjeta coincida con el número proporcionado.
            return await _context.Accounts.SingleOrDefaultAsync(a => a.CardNumber == cardNumber);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        //public async Task CreateTransactionAsync(Transaction transaction)
        //{
        //    await _context.Transactions.AddAsync(transaction);
        //    await _context.SaveChangesAsync();
        //}
        public async Task CreateTransactionAsync(Transaction transaction)
        {

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }



    }
}
