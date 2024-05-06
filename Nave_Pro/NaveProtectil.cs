using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave_Pro
{
    internal class NaveProtectil:NaveAutomatico
    {

        public override char Caracter { get { return '|'; } }

        public override void Mover()
        {
                this.Y--;
         
        }

    }
}
