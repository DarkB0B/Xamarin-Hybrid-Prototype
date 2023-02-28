using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Hybrid_Prototype.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        public List<Party> MyParties;
    }
}
