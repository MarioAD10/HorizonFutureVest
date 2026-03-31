using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class ReturnRateConfig
    {
        public int Id { get; set; }
        public decimal MinRate { get; set; }
        public decimal MaxRate { get; set; }
    }
}
