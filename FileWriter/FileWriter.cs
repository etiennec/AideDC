using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aide_Dilicom3.FileWriter
{
    class FileWriter
    {
        public static void writeToFile(string data, string filePath)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
