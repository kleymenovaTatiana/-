namespace WebApplication2.Contracts.staff
{
    public class CreatestaffRequest
    {
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Namee { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthdate { get; set; }
    }
}
