using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_V2
{
    class BckSp : IBckSp
    {

        public string UsuńZnak(string znak)
        {
            if(znak.Length>0)
                 znak =  znak.Remove(znak.Length - 1, 1);
            return znak;
        }
    }
}
