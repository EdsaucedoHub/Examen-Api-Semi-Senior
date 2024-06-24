using WebAPIExamenEP.Data;
using WebAPIExamenEP.Models;
using WebAPIExamenEP.DTOs;

namespace WebAPIExamenEP.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> ChangePINAsync(ChangePinDto dto)
        {
            var account = await _repository.GetAccountByCardNumberAsync(dto.CardNumber);
            if (account == null || account.PIN != dto.OldPIN)
            {
                return "Número de tarjeta o PIN no válido";
            }

            account.PIN = dto.NewPIN;
            await _repository.UpdateAccountAsync(account);
            return "PIN cambiado correctamente";
        }
        public async Task<decimal?> CheckBalanceAsync(string cardNumber, string pin)
        {
            var account = await _repository.GetAccountByCardNumberAsync(cardNumber);
            if (account == null || account.PIN != pin)
            {
                return null;
            }

            return account.Balance;
        }
        public async Task<string> DepositAmountAsync(DepositDto dto)
        {
            var account = await _repository.GetAccountByCardNumberAsync(dto.CardNumber);
            if (account == null)
            {
                return "numero de tarjeta invalido";
            }

            account.Balance += dto.Amount;
            await _repository.UpdateAccountAsync(account);

            var transaction = new Transaction
            {
                AccountId = account.AccountId,
                Amount = dto.Amount,
                TransactionDate = DateTime.Now,
                TransactionType = "Deposit"
            };
            await _repository.CreateTransactionAsync(transaction);

            return "Depósito exitosa";
        }
        public async Task<string> WithdrawAmountAsync(WithdrawDto dto)
        {
            var account = await _repository.GetAccountByCardNumberAsync(dto.CardNumber);
            if (account == null || account.PIN != dto.PIN)
            {
                return "Número de tarjeta o PIN no válido";
            }

            if (account.Balance < dto.Amount)
            {
                return "Fondos insuficientes";
            }

            account.Balance -= dto.Amount;
            await _repository.UpdateAccountAsync(account);

            var transaction = new Transaction
            {
                AccountId = account.AccountId,
                Amount = dto.Amount,
                TransactionDate = DateTime.Now,
                TransactionType = "Withdraw"
            };
            await _repository.CreateTransactionAsync(transaction);

            return "Retiro exitoso";
        }

    }
}
