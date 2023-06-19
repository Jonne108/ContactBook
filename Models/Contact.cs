namespace ContactBook.Models
{
    public class Contact
    {
        private static int _lastId = 0;

        public int Id { get; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Contact()
        {
            _lastId++;
            Id = _lastId;
            Name = string.Empty;
            PhoneNumber = string.Empty;
            EmailAddress = string.Empty;
        }
    }
}