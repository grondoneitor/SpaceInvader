using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave_Pro
{
    internal class Contador
    {

        public Contador(int contador)
        {
            this.Conta = contador;
            this.X = 78;
            this.Y = 0;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Conta { get; set; }   

        public void Imprimir()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write($"Puntaje: {Conta}");
        }


    }
}
