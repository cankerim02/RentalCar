using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.FileHelper.Constants
{
    public static class FilePath
    {
        public static string Full(string path, string root = FileType.root /*string fileType = FileType.images*/)
        {
            // Üç dizeyi bir yol halinde birleştirir.Dört adet overloading bulunur.- Path.Combine(string path1,string path2, string path3)
            // Directory.GetCurrentDirectory() uygulamanın geçerli çalışma dizinini döndürür.
            return Path.Combine(Directory.GetCurrentDirectory(), root, /*fileType*/ path);
        }
    }
}
