using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave_Pro
{
    internal abstract class Nave
    {
        public Nave() 
        {
   
        }
        public virtual int X
        {
            get
            {
                return _X;
                ;
            }
            set
            {
                if (value >= 0 && value < Console.BufferWidth -1 ) Clear();  _X = value; Write();
                ;
            }
        }
        public int _X { get; set; }

        public virtual int Y
        {
            get
            {
                return _Y;
                ;
            }
            set
            {
                if (value >= 0 && value < Console.BufferHeight ) Clear(); _Y = value; Write();
                ;
            }
        }
        public int _Y { get; set; }

        public abstract char Caracter { get; }
        public void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(' ');
        }

        public bool EsRojo { set; get; }

        public virtual void Write()
        {
            ConsoleColor color = Console.ForegroundColor;
            if (EsRojo) Console.ForegroundColor = ConsoleColor.Red;
             Console.SetCursorPosition(this.X,this.Y);
            Console.Write(this.Caracter);
            if (EsRojo) Console.ForegroundColor = color; //Restablece el color original
        }

    }
}
