using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_14_06_dict_or_queue
{
    internal class Visitor
    {
        public string Name { get; set; }
        // TODO bool reserved ?
        // date ?


        public Visitor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
