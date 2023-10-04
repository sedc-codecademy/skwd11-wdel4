using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Shared.Exceptions.User
{
    public class UserNotFoundExcpetion : Exception
    {
        public UserNotFoundExcpetion(string message) : base(message)
        {
                
        }
    }
}
