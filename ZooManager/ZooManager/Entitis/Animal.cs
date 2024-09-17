using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Entitis
{
    internal class Animal
    {
        public int Id { get; set; } 
        public int AnimalNumber { get; set; }
        public string Description { get; set; }
        public string AnimalType{ get; set; }
        public Part Part { get; set; }
        public int PartId {  get; set; }
    }
}
