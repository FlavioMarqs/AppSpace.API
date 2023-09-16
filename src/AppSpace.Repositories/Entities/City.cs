using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population {  get; set; }
    }
}
