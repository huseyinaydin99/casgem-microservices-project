using Microsoft.AspNetCore.Identity;

namespace Casgem_MicroServices.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    //Bu sınıf AppUser'e karşılık geliyor.
    public class ApplicationUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}