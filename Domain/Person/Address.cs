namespace Domain.Person
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
