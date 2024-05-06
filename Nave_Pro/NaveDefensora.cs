using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Nave_Pro
{
    internal class NaveDefensora : Nave
    {

public NaveDefensora()
{
            this.X = 34;// Math.Min(14, Console.BufferWidth - 1); // Ajusta X si es mayor que el ancho del búfer de la consola
            this.Y = 24; // Math.Min(34, Console.BufferHeight - 1); // Ajusta Y si es mayor que la altura del búfer de la consola
}




        //public string Carct { get; set;  }
        public override  char Caracter { get { return 'A'; } }


        public void MoverDerecha() 
        {
            this.X++;


        }
        public void MoverIzquierda()
        {
            this.X--;   
        }

    }
}
