using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Hybrid_Prototype.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<User> Users { get; set; }
    }
}
