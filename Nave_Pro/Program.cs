namespace Nave_Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool salir = false;    
            Defensora = new NaveDefensora();
            Invasora = new List<NaveInvasora>();
            Proyectil = new List<NaveProtectil>();

            ConsoleKeyInfo KeyInfo;
            InicianInvasoras();
            do
            {
                while (!Console.KeyAvailable && !salir)
                {
                    Moverinvasoras();

                    for (int i = 0; i < Proyectil.Count(); i++)
                    {
                        Proyectil[i].Mover();
                        DestruirProyectil(i);
                        DestruirInvasora();
                    }

                }

      
                if (!salir) salir = MoverNave();
            } while (!salir);

         





        }

        public static List<NaveProtectil> Proyectil { get; set; }

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
                case ConsoleKey.Spacebar:
                    if (!ExisteProyectil(Defensora.X))
                    {
                         NaveProtectil proyectil = new NaveProtectil();
                        proyectil.X = Defensora.X;
                        proyectil.Y = Defensora.Y -1;
                        Proyectil.Add(proyectil);

                    }
                    break;
            
            }
          return salir;
        }  
    
        public static bool ExisteProyectil(int x)
        {
            bool existe = false;

            foreach (NaveProtectil item in Proyectil)
            {
                if (item.X == x) existe = true;
            }
            return existe;
        }


        public static void DestruirProyectil(int i)
        {
            if (Proyectil[i].Y ==0)
            {
                Proyectil[i].Clear();
                Proyectil.Remove(Proyectil[i]);
            }

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


        public static void DestruirInvasora()
        {
            for (int j = 0; j < Proyectil.Count(); j++)
            {
               NaveProtectil proyectil = Proyectil[j];
                Explotar explotar = new Explotar();
                for (int i = 0; i < Invasora.Count(); i++)
                {
                    bool colision = proyectil.X == Invasora[i].X && proyectil.Y == Invasora[i].Y && !proyectil.EsRojo; 
                    if (colision)
                    {
                        proyectil.EsRojo = true;
                        explotar.Explosion(Invasora[i].X, Invasora[i].Y);
                        Invasora[i].Clear();
                        Invasora.Remove(Invasora[i]);

                    }


                }

            }
        }

    }
}