using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace auto_proj.Classes
{
    public class BinaryFile
    {
        static public byte[] GetBinaryFromFile(string fileName)
        {
            byte[] bytes; 
            
            try            
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            return bytes;

           
        }

        static public bool MakeFileFromBinary(byte[] bytes, string name)
        {
            try
            {
                File.WriteAllBytes(name, bytes);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return File.Exists(name);
        }

        
    }
}
