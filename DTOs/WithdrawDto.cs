namespace WebAPIExamenEP.DTOs
{
    public class WithdrawDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string PIN { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}