using System;
using System.Timers;
using Timer = System.Threading.Timer;

namespace Nave_Pro
{
    internal class Program
    {
        // Timer para el lanzamiento de proyectiles de nave invasora
        //static Timer invasorTimer;
        static void Main(string[] args)
        {
             

            Console.CursorVisible = false;
            bool salir = false;
            Defensora = new NaveDefensora();
            Invasora = new List<NaveInvasora>();
            Proyectil = new List<NaveProtectil>();
            ProInvasora = new List<ProyectilInvasor>();
            ConsoleKeyInfo KeyInfo;
            InicianInvasoras();

            // Crear y configurar el temporizador
            //invasorTimer = new Timer(state => LanzamientoInvasoras(), null, 0, 1500);

            // Iniciar el temporizador
            //invasorTimer.Start();
        


            do
            {
                while (!Console.KeyAvailable && !salir)
                {
                    Moverinvasoras();
                    MostrarPuntaje();
                    LanzarProyectilInvasor();
                    LanzamientoInvasoras();

                    for (int i = 0; i < Proyectil.Count(); i++)
                    {
                        Proyectil[i].Mover();
                        DestruirProyectil(i);
                        DestruirInvasora();
                    }
                    if (Perdimos())
                    {
                        Console.SetCursorPosition(23, 14);
                        Console.WriteLine($"Perdiste. puntaje final {valor} ");
                        MostrarPuntaje();
                        break;
                    } else if (Ganamos())
                    {
                        Console.SetCursorPosition(23, 14);
                        Console.WriteLine($"Ganaste. puntaje final {valor} ");
                        MostrarPuntaje();
                        break;
                    }
                }
                if (!salir) salir = MoverNave();
            } while (!salir);

            //invasorTimer.Dispose();

        }



        public static Contador Contador { get; set; }
        public static List<NaveProtectil> Proyectil { get; set; }

        public static List<NaveInvasora> Invasora { get; set; }
        public static NaveDefensora Defensora { get; set; }
        public static List<ProyectilInvasor> ProInvasora { get; set; }

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
                        proyectil.Y = Defensora.Y - 1;
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
            if (Proyectil[i].Y == 0)
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
        public static bool Perdimos()
        {
            bool ss = false;
            for (int i = 0; i < Invasora.Count(); i++)
            {
                bool llega = Invasora[i].Y == Defensora.Y;
                if (llega)
                {
                    ss = true;
                }
            }
            return ss;
        }
        public static bool Ganamos()
        {
            bool tt = false;
            bool cantidad = Invasora.Count == 0;
            if (cantidad)
            {
                tt = true;
            }
            return tt;
        }
        public static int valor;
        public static void MostrarPuntaje()
        {
            int contador = 0;
            int cantInvasoras = 180;

            for (int i = 0; i < Invasora.Count(); i++)
            {
                contador = cantInvasoras - Invasora.Count();
                int puntajeFinal = contador * 20;
                Contador contat = new Contador(puntajeFinal);
                contat.Imprimir();
                valor = puntajeFinal;
            }

        }

        public static bool DisparosDeInvasora(int x)
        {
            bool vemos = false;
            foreach (ProyectilInvasor item in ProInvasora)
            {
                if (item.X == x) vemos = true;
            }
            return vemos;

        }
        static void LanzarProyectilInvasor()
        {
            Random rnd = new Random();

            int ramdomNumber = 0;

            //for (int i = 0; i < Invasora.Count(); i++)
            //{
            ramdomNumber = rnd.Next(Invasora.Count);

            if (!DisparosDeInvasora(Invasora[ramdomNumber].X))
            {
                ProyectilInvasor proInvasora = new ProyectilInvasor();
                proInvasora.X = Invasora[ramdomNumber].X;
                proInvasora.Y = Invasora[ramdomNumber].Y + 1; // Mover el proyectil un paso hacia abajo
                ProInvasora.Add(proInvasora);

            }

        }

         private static void LanzamientoInvasoras()
        {
            foreach (ProyectilInvasor item in ProInvasora)
            {
                item.Mover(); // Ejecutar el método Mover de cada proyectil invasor
            }
            

        }


    }




}   

