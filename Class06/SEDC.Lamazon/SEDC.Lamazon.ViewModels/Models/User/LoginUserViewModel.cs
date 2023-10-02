using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.User
{
    public class LoginUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}
