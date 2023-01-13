using Core.Entities;

namespace Entities.DTOs
{
    public class PhoneBookDto : IDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
    }
}
