using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Domain.Enitites
{
    public class Role : BaseEntity
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
