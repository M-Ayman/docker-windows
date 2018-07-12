using System.Collections.Generic;

namespace SignUp.Entities
{
    public class Viewer
    {
        public int ViewerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Interest> Interests {get ; set;}                
    }
}
