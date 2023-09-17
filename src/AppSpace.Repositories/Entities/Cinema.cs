using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class Cinema
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime OpenSince { get; set; }

        public City City { get; set; }
    }
}
