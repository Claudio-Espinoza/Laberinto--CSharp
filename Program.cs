using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class Program
    {
        private static int x = 0, y = 0, opcion, contadorRetorno = 0, botonRetorno = 0;
        private static int validador = 0;

        private static Stack dimensionX = new Stack();
        private static Stack dimensionY = new Stack();

        private static string[,] laberinto ={
            {"1", "1", "1", "1", "E", "1", "1", "1", "1", "1" },
            {"1", "0", "0", "1", "0", "1", "0", "0", "0", "1" },
            {"1", "0", "0", "1", "0", "0", "0", "1", "0", "1" },
            {"1", "1", "0", "1", "0", "1", "1", "1", "0", "1" },
            {"1", "1", "0", "1", "0", "0", "1", "1", "0", "1" },
            {"1", "0", "0", "1", "0", "0", "0", "0", "0", "1" },
            {"1", "0", "1", "1", "0", "1", "0", "1", "1", "1" },
            {"1", "0", "0", "1", "1", "1", "0", "0", "0", "1" },
            {"1", "0", "0", "0", "0", "0", "0", "1", "0", "1" },
            {"1", "1", "1", "1", "1", "1", "X", "1", "1", "1" }};
        private static string[,] laberinto2 ={
            {"X", "1", "1", "E", "1", "1", "X", "1", "1", "1" },
            {"1", "0", "1", "0", "0", "0", "1", "0", "0", "1" },
            {"1", "0", "0", "0", "1", "0", "0", "0", "0", "1" },
            {"1", "0", "1", "0", "1", "0", "1", "0", "1", "X" },
            {"1", "0", "0", "0", "0", "0", "1", "0", "0", "1" },
            {"1", "0", "1", "1", "0", "0", "1", "0", "1", "1" },
            {"1", "0", "0", "1", "1", "0", "1", "0", "1", "X" },
            {"1", "0", "1", "0", "0", "0", "1", "0", "0", "1" },
            {"1", "0", "0", "1", "1", "0", "1", "0", "0", "1" },
            {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }};

        static void Main(string[] args)
        {

            bool validadorInterno = true;
            do
            {
                try
                {
                    Console.WriteLine("Bienvenido\nElija un laberinto");
                    Console.WriteLine("Laberinto N°1");
                    MostrarLaberinto(laberinto);
                    Console.WriteLine("Laberinto N°2");
                    MostrarLaberinto(laberinto2);

                    Console.WriteLine("Laberinto N°1 : 1");
                    Console.WriteLine("Laberinto N°2 : 2");
                    Console.Write("Eleccion: ");
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion != 1 && opcion != 2)
                    {
                        validadorInterno = false;
                        Console.WriteLine("\n||-----Ese valor no es valido-----||\n");
                    }

                }
                catch (Exception e)
                {
                    validadorInterno = false;
                    Console.WriteLine("\n||-----Ese valor no es valido-----||\n");
                }

                //-|Laberinto 1|------------------------------------------------------------------------------------------------------------------------------------//
                if (opcion == 1)
                {
                    BuscarIncio(laberinto);
                    MostrarLaberinto(laberinto);
                    while (validador == 0)
                    {
                        Movimiento(laberinto);
                        if (laberinto[x, y] != "E" && laberinto[x, y] != "X" && laberinto[x, y] != "1")
                        {
                            if (laberinto[x + 1, y] == "0" && laberinto[x, y + 1] == "0" || laberinto[x - 1, y] == "0" && laberinto[x, y - 1] == "0")
                            {
                                dimensionX.Push(x);
                                dimensionY.Push(y);
                            }
                        }
                        MostrarLaberinto(laberinto);
                    }
                    Console.WriteLine("Fin");
                }
                //-|Laberinto 1|------------------------------------------------------------------------------------------------------------------------------------//
                else if (opcion == 2)
                {
                    BuscarIncio(laberinto2);
                    MostrarLaberinto(laberinto2);
                    while (validador == 0)
                    {
                        Movimiento(laberinto2);
                        if (laberinto2[x, y] != "E" && laberinto2[x, y] != "X" && laberinto2[x, y] != "1")
                        {
                            if (laberinto2[x + 1, y] == "0" && laberinto2[x, y + 1] == "0" || laberinto2[x - 1, y] == "0" && laberinto2[x, y - 1] == "0" || laberinto2[x - 1, y] == "0" && laberinto2[x + 1, y] == "0" || laberinto2[x, y-1] == "0" && laberinto2[x , y+1] == "0")
                            {
                                dimensionX.Push(x);
                                dimensionY.Push(y);
                            }
                        }

                        MostrarLaberinto(laberinto2);
                    }
                    Console.WriteLine("Fin");
                }
            } while (validadorInterno != true);
        }

        //-|Movimiento de las piezas|---------------------------------------------------------------------------------------------------------------------------------//
        public static void Movimiento(String[,] laberinto)
        {
            bool validadorInterno = true;
            do
            {
                try
                {
                        Console.Write("\nOpcion del jugador: \nArriba    : 1\nIzquierda : 2\nDerecha   : 3\nAbajo     : 4\nRetorno     : 0\nEleccion: ");
                        int opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            try
                            {
                                x = dimensionX.Pop();
                                y = dimensionY.Pop();
                               
                                Console.WriteLine("{0}{1}", x, y);
                                LimpiarTablero(laberinto);
                                laberinto[x, y] = "R";

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("|---Accion invalida---|");
                            }
                            break;


                        case 1:
                            try
                            {
                                if (laberinto[x - 1, y] == "1")
                                {
                                    Console.WriteLine("\n||---Esa es una pared. ¡No se puede avanzar!---||\n");
                                    break;
                                }
                                else if (laberinto[x - 1, y] == "X")
                                {
                                    Console.WriteLine("\n||---Has ganado. Fin del juego---||\n");
                                    validador = 1;
                                    break;
                                }

                                laberinto[x - 1, y] = "*";
                                x = x - 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n||---Ese es un vacio. ¡No se puede avanzar!---||\n");
                                break;
                            }
                            break;

                        case 2:
                            try
                            {
                                if (laberinto[x, y - 1] == "1")
                                {
                                    Console.WriteLine("||---Esa es una pared. ¡No se puede avanzar!---||");
                                    break;
                                }
                                else if (laberinto[x, y - 1] == "X")
                                {

                                    Console.WriteLine("\n||---Has ganado. Fin del juego---||\n");
                                    validador = 1;
                                    break;
                                }
                                laberinto[x, y - 1] = "*";
                                y = y - 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n||---Ese es un vacio. ¡No se puede avanzar!---||\n");
                                break;
                            }
                            break;

                        case 3:
                            try
                            {
                                if (laberinto[x, y + 1] == "1")
                                {
                                    Console.WriteLine("||---Esa es una pared. ¡No se puede avanzar!---||");

                                    break;
                                }
                                else if (laberinto[x, y + 1] == "X")
                                {

                                    Console.WriteLine("\n||---Has ganado. Fin del juego---||\n");
                                    validador = 1;
                                    break;
                                }

                                laberinto[x, y + 1] = "*";
                                y = y + 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n||---Ese es un vacio. ¡No se puede avanzar!---||\n");
                                break;
                            }
                            break;

                        case 4:
                            try
                            {
                                if (laberinto[x + 1, y] == "1")
                                {
                                    Console.WriteLine("\n||---Ese es un vacio. ¡No se puede avanzar!---||\n");
                                    break;
                                }
                                else if (laberinto[x + 1, y] == "X")
                                {
                                    validador = 1;
                                    Console.WriteLine("\n||---Has ganado. Fin del juego---||\n");
                                    break;
                                }


                                laberinto[x + 1, y] = "*";
                                x = x + 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n||---Ese es un vacio. ¡No se puede avanzar!---||\n");
                                break;
                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    validadorInterno = false;
                    Console.WriteLine("\n||-----Ese valor no es valido-----||\n");
                }
            } while (validadorInterno != true);
        }

        //-|Funciones de utilidad|------------------------------------------------------------------------------------------------------------------------------------//
        public static void BuscarIncio(String[,] laberinto)
        {
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (laberinto[i, j] == "E")
                    {
                        x = i;
                        y = j;
                    }
                }
            }
        }
        //-|Tablero|--------------------------------------------------------------------------------------------------------------------------------------------------//
        public static void MostrarLaberinto(String[,] laberinto)
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    Console.Write($"|{laberinto[i, j]}| ");
                }
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------");
            }
        }
        public static void LimpiarTablero(String[,] laberinto)
        {
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (laberinto[i, j] == "*")
                    {
                        laberinto[i, j] = "0";
                    }
                }
            }
        }
    }
}
