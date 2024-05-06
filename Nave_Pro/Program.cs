namespace Nave_Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
             bool salir = false;    
             Defensora = new NaveDefensora();
            //Console.SetCursorPosition(Defensora.X, Defensora.Y);
            do
            {   

               if(!salir) salir = MoverNave();
            } while (!salir);

         





        }
        public static NaveDefensora Defensora { get; set; }
        static bool MoverNave() 
        {
            bool salir = false;
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    Defensora.MoverIzquierda();
                    break;
                case ConsoleKey.RightArrow:
                    Defensora.MoverDerecha();
                    break;
                case ConsoleKey.Escape:
                    salir = true;
                    break;
            }
          return salir;
        }  
    

    }
}