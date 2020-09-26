namespace PunchClock.Service.Domain.Entities
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentCnpj { get; set; }
        public int AddressId { get; set; }
    }
}
