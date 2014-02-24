using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aide_Dilicom3.Utils
{
    class FileUtils
    {
        public static String getFolderPathFromFilePath(String FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return "";
            }
            
            FileInfo fi = new FileInfo(FilePath);

            return fi.Directory.FullName;
        }

        public static String getFileNameFromFilePath(String FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return "";
            }

            FileInfo fi = new FileInfo(FilePath);

            return fi.Name;
        }
    }
}
