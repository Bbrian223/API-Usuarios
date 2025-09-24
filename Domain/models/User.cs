using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Document { get; set; }
        public string telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public int zip { get; set; }
    }
}
