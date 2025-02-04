using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Model
{
    public class EmployeeModel
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public int? AddressId { get; set; }

        public AddressModel Address { get; set; }
    }
}
