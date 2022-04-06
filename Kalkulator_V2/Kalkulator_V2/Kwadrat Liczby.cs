using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_V2
{
    class Kwadrat_Liczby : Potęgi
    {
               
        public Kwadrat_Liczby(double podstawa)
        {
            this.podstawa = podstawa;
            Kwadrat();
        }

        double podstawa;
        public double kwadrat { get; set; }

        private void Kwadrat()
        {
            Potęgi wynik = new Potęgi();
            kwadrat = wynik.Potęga(podstawa, 2);
        }       
    }
}
