namespace DotNetProjectClient.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public SecretDTO Secret { get; set; }
    }
}