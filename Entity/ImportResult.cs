using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ImportResult
    {
        public int Processed { get; set; }
        public int Inserted { get; set; }
        public int Failed { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
