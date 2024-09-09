using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        // NewGuid() Methoduyla guid struct'ının yeni bir nesnesini oluşturulur.
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
            // Guid g = Guid.NewGuid();
            // g.ToString();  bu şekilde de kullanabilirdik.
        }
    }
}
