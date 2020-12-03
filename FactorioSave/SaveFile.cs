using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioSave
{
    class SaveFile
    {
        public string path { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public override string ToString()
        {
            return this.name.ToString();
        }

    }
}
