using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_proj.Classes
{
    class PlcIoCount
    {
        int ai_count = 0;
        int ao_count = 0;
        int di_count = 0;
        int do_count = 0;
        int plcNum = 0;

        public PlcIoCount()
        {
        }

        public PlcIoCount(int plcNum)
        {   
            this.plcNum = plcNum;
        }

        public int AI_COUNT
        {
            get => this.ai_count;
            set => this.ai_count = value;
        }

        public int AO_COUNT
        {
            get => this.ao_count;
            set => this.ao_count = value;
        }

        public int DI_COUNT
        {
            get => this.di_count;
            set => this.di_count = value;                
        }

        public int DO_COUNT
        {
            get => this.do_count;
            set => this.do_count = value;
        }

        public int PLC_NAME
        {
            get => this.plcNum;            
        }

      

        public override string ToString()
        {
            return $"plc:{PLC_NAME}, AI:{AI_COUNT}, AO:{AO_COUNT}, DI:{DI_COUNT}, DO:{DO_COUNT}";
        }
    }
}
