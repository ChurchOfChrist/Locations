using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            
        }
        public ContactViewModel(Contact entity)
        {
            FullName = entity.FullName;
            PhoneNumber = entity.PhoneNumber;
            Email = entity.Email;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact ToEntity()
        {
            return new Contact
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                Email = Email,
            };
        }
    }
}