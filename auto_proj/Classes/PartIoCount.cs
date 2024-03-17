using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_proj.Classes
{
    class PartIoCount
    {
        string _partName = string.Empty;
        private PlcIoCount[] arr = new PlcIoCount[10];

        public PartIoCount(string partName)
        {
            _partName = partName;   
            
            for(int i = 0; i< 10; i++)
            {
                arr[i] = new PlcIoCount(i);
            }
            
        }

        public string PART_NAME
        {
            get => this._partName;
        }

        public PlcIoCount this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public override string ToString()
        {
            return $"part : {PART_NAME}, plc cout : {arr.Length}";
        }
    }
}
