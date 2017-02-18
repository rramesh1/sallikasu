using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using nastha.Models;
using Newtonsoft.Json;

namespace TextSearchRequest
{
    class TextSearchController
    {
        private TextSearchModel tModel; 
        public TextSearchController()
        {
            tModel = new TextSearchModel();     
        }
        public void process(String Locality, String City, String PostalCode)
        {
            tModel.process(Locality, City, PostalCode);
        }
        
    }
}
