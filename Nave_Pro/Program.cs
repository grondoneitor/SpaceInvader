namespace Nave_Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();
             bool salir = false;    
             Defensora = new NaveDefensora();
             Invasora = new List<NaveInvasora>();
            ConsoleKeyInfo KeyInfo;
            InicianInvasoras();
            do
            {
                while (!Console.KeyAvailable && !salir)
                {
                    Moverinvasoras();
                }

      
                if (!salir) salir = MoverNave();
            } while (!salir);

         





        }
        public static List<NaveInvasora> Invasora { get; set;}
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
    

        public static void InicianInvasoras()
        {

            for (int y = 1; y < 7; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    NaveInvasora naveInvasora = new NaveInvasora();
                    naveInvasora.Y = y;
                    naveInvasora.X = x * 2;
                    Invasora.Add(naveInvasora);


                }

            }
        }

        public static void Moverinvasoras()
        {
            for (int i = 0; i < Invasora.Count(); i++)
            {
                Invasora[i].Mover();

            }
            Thread.Sleep(50);
        
        }

    }
}