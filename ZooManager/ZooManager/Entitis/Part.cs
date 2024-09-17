using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Entitis
{
    internal class Part
    {
        public int Id {  get; set; }
        public int Area {  get; set; }
        public Animal Animal { get; set; }
        public int AnimalCount { get; set; }
        public int TicketNumber { get; set; }
        public Ticket ticket { get; set; }
        public Zoo zoo { get; set; }
        public int ZooId { get; set; }  
    }
}
