using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantDetails
{
    class MerchantDetailsControllers
    {

        MerchantDetailsModel tModel;
        public MerchantDetailsControllers()
        {
            tModel = new MerchantDetailsModel();

        }
        public void Process()
        {
            // Get the list of PlaceID to be process MerchantDetails.
            if (tModel.GetMerchantList())
            {
                //for each place ID with no addresss place the merchant details query;
                tModel.GetPlaceDetails();
            }
        }
    }
}
