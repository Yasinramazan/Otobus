using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrol
{
     public static class tryCatch
    {
        public static int trycatch(Action a)
        {
            int bayrak = 0;
            try
            {
                a();
                bayrak = 1;
            }
            catch (Exception)
            {
                bayrak = -1;
                
            }
            return bayrak;

        }
        
    }
}
