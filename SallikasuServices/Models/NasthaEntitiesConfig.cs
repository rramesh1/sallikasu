using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    // need this for the runtime. the auto generated class gets overwritten every time.
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class nasthaEntities : DbContext
    {
    }
}