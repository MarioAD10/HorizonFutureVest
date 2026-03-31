using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        public required string IsoCode {  get; set; } = string.Empty;
        
        // Navigation

        public ICollection<CountryIndicator> Indicators { get; set; } = new List<CountryIndicator>();
    }
}
