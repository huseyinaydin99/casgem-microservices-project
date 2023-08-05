using System.ComponentModel.DataAnnotations;

namespace Casgem_MicroServices.IdentityServer.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
    }
}
