using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave_Pro
{
    internal class ProyectilInvasor : NaveAutomatico
    {

        public override char Caracter { get { return 'v'; } }

        public override void Mover()
        {
            if (this.Y < Console.BufferHeight - 1) // Verifica que no haya llegado al borde inferior
            {
                this.Y++;
            }
        }




    }

}

