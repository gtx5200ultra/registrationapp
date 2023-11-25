namespace registrationapp.DTO
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int CountryRegionId { get; set; }
    }

    public class CreatedUserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
    }
}