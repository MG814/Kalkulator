using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_V2
{
    class Działania
    {
        
       double x1, x2;
        public Działania(double x1, double x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public double Operacja(string działanie)
        {
            double wynik=0;
            switch(działanie)
            {
                case "+":
                    {
                        wynik = x1 + x2;
                        break;
                    }
                case "-":
                    {
                        wynik = x1 - x2;
                        break;
                    }
                case "*":
                    {
                        wynik = x1 * x2;
                        break;
                    }
                case "/":
                    {
                        wynik = x1 / x2;
                        break;
                    }
            }
            return wynik;
        }
    }
}
