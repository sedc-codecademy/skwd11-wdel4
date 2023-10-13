using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.User
{
    public class RegisterUserViewModel
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Confirm password")]
        public string ConfirmationPassword { get; set; }
        public int RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
