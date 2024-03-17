using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace auto_proj.Classes
{
    public class Sheet
    {
        private _Worksheet _xlWorksheet = null;
        private Range _xlRange = null;
        private string _sheetName = null;

        public Sheet(_Worksheet xlWorksheet)
        {
            this._xlWorksheet = xlWorksheet;
            this._xlRange = this._xlWorksheet.UsedRange;
            this._sheetName = this._xlWorksheet.Name;
        }

        public _Worksheet XlWorksheet
        {
            get => _xlWorksheet;
        }

        public Range XlRange
        {
            get => _xlRange;
        }

        public string SheetName
        {
            get => _sheetName;
        }

        public void Close()
        {  
            Marshal.ReleaseComObject(this._xlWorksheet);
            Marshal.ReleaseComObject(this._xlRange);
        }
    }
}
