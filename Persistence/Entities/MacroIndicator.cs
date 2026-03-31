using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class MacroIndicator
    {
        public int Id { get; set; }

        public required string Name { get; set; } = string.Empty; 

        public decimal Weight { get; set; }

        public bool IsHigherBetter { get; set; } = true;

        //Navigation

        public ICollection<CountryIndicator> CountryIndicators { get; set; } = new List<CountryIndicator>();
    }
}
