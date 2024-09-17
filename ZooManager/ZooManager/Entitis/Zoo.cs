using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Entitis
{
    internal class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public int PartNumber { get; set; }
        public List<Part>parts { get; set; }
    }
}
