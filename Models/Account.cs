namespace WebAPIExamenEP.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string PIN { get; set; } = string.Empty; 
        public decimal Balance { get; set; }
    }

}
