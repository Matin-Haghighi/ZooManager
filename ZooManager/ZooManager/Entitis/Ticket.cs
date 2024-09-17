using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Entitis
{
    internal class Ticket
    {
        public int Id { get; set; } 
        public int Price { get; set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
