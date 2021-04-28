namespace FinancialControl.API.DTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }

        public string TaxNumber { get; set; }

        public string Occupation { get; set; }

        public byte[] Photograph { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
