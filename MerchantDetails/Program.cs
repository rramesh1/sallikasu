using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            MerchantDetailsControllers tController = new MerchantDetailsControllers();

            if ( tController != null)
            {
                tController.Process();
            }

        }
    }
}
