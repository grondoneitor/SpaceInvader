using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave_Pro
{
    internal class NaveInvasora : NaveAutomatico
    {
        public NaveInvasora() 
        {
            this.X = 0;
            this.Y = 0;
        }

        public override char Caracter { get { return 'M'; }  }

        public override void Mover()
        {
            if (this.X==0 && this.Direccion == Direccion.Izquierda)
            {
                this.Direccion =Direccion.Derecha;
                Y++;
            }else if (this.X == 78 && this.Direccion == Direccion.Derecha)
            {
                this.Direccion = Direccion.Izquierda;
                Y++;
             
            }

            if (this.Direccion == Direccion.Derecha)
            {
                X++;
            }
            else X--;

        }


        public Direccion Direccion { get; set; }    
    }
}
