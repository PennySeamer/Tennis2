using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis2.Models
{
    public class member
    {
        public int Id { get; set; }
        public string MemberName { get; set; }

        [DataType(DataType.EmailAddress)]
        public object EmailAddress;
    }
}
