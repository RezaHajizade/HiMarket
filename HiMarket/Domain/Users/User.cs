using Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    [Auditable]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
