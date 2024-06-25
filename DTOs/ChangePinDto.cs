namespace WebAPIExamenEP.DTOs
{
    public class ChangePinDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string OldPIN { get; set; } = string.Empty;
        public string NewPIN { get; set; } = string.Empty;

    }
}
