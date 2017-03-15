using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class AddPhoto
    {
        nasthaEntities DB { get; set; }
        public AddPhoto()
        {
            DB = new nasthaEntities();
        }
        public void Create()
        {

        }
    }
}