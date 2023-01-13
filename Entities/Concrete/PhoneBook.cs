
using Core.Entities;

namespace Entities.Concrete
{
    public class PhoneBook : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public ICollection<ContactInformation> contactInformations { get; }
    }
}
