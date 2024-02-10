using Data.Models;

namespace Data.Entities
{
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Regon { get; set; }
        public string Nip { get; set; }
        public AddressModel? Address { get; set; }
        public ISet<ProductEntity> Products { get; set; }

    }
}
