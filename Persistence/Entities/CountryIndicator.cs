using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class CountryIndicator
    {
        public int Id { get; set; }

        //Relacion con Country
        public int CountryId { get; set; }

        public Country Country { get; set; } = null!;

        //Relacion con Macro

        public int MacroIndicatorId { get; set; }
        public MacroIndicator MacroIndicator { get; set; } = null!;


        public int year { get; set; }
        public decimal value { get; set; }
    }
}
