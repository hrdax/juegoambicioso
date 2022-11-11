// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;//For sleep

bienvenida();
menu();

void bienvenida()
{
    Console.WriteLine("*****************************************");
    Console.WriteLine("****Bienvenido(a) al juego ambicioso*****");
    Console.WriteLine("*****************************************");

    Thread.Sleep(1000);

    Console.WriteLine("");
}

void menu()
{
    int opcion;
    string entrada_de_datos;
    Console.WriteLine("****************Menú de opciones**********");
    Console.WriteLine("1.Nuevo juego");
    Console.WriteLine("2.Tutorial");
    Console.WriteLine("3.Salir");
    do
    {
        Console.Write("Ingrese una opción:");
        entrada_de_datos = Console.ReadLine();
        while (!Int32.TryParse(entrada_de_datos, out opcion))
        {
            Console.Write("Error, debe ser un numero, ingrese una opción:");
            entrada_de_datos = Console.ReadLine();
        }

    }while ((opcion < 1) || (opcion > 3));

    switch (opcion)
    {
        case 1:
            //Console.WriteLine("Nuevo Juego iniciado");
            nuevo_juego();
        break;
        case 2:
            Console.WriteLine("\nTutorial iniciado");
            tutorial();
        break;
        case 3:
            Console.WriteLine("Apagando...");
        break;
        default:
            Console.WriteLine("Opción incorrecta");
        break;
    }
}

void nuevo_juego()
{
    int njugadores;
    string entrada_de_datos;

    Console.WriteLine(" ");

    do
    {
        Console.Write("Indique la cantidad de jugadores (mínimo 2, máximo 3:");
        entrada_de_datos = Console.ReadLine();
        while (!Int32.TryParse(entrada_de_datos, out njugadores))
        {
            Console.Write("Error, debe ser un numero, indique la cantidad solicitada:");
            entrada_de_datos = Console.ReadLine();
        }

    } while ((njugadores < 2) || (njugadores > 4));

    switch(njugadores)
    {
        case 2:
            //Console.WriteLine("Juego de dos jugadores");
            juego_2_jugadores();
        break;
        case 3:
            Console.WriteLine("Juego de tres jugadores");
            juego_3_jugadores();
            break;
        case 4:
            Console.WriteLine("Juego de cuatro jugadores");
            //juego_4_jugadores;
            break;
    }
}

void tutorial()
{
    Console.WriteLine("\nEl juego es simple\n" +
                      "debes conseguir mas cantidad de puntos que el otro jugador\n" +
                      "Reglas: Si obtienes el valor 1 en el dado perderas tu turno y tus puntajes obtenidos en la ronda\n");
    menu();
}

void creditos()
{
    Console.WriteLine("\nDesarrollador: Pepe El Grillo\n" +
                      "Github: www.github.com/Pepeelgrillo\n");
    menu();
}

void juego_2_jugadores()
{
    Console.WriteLine("");

    Console.WriteLine("Jugador 1 Ready");
    Thread.Sleep(1000);
    Console.WriteLine("Jugador 2 Ready");
    Thread.Sleep(1000);

    int i;

    int ronda;

    int[] puntuacion_jugador1 = new int[10];

    int[] puntuacion_jugador2 = new int[10];

    string[] etiqueta_columnas = new string[10];
    etiqueta_columnas[0] = "A|";
    etiqueta_columnas[1] = "M|";
    etiqueta_columnas[2] = "B|";
    etiqueta_columnas[3] = "I|";
    etiqueta_columnas[4] = "C|";
    etiqueta_columnas[5] = "I|";
    etiqueta_columnas[6] = "O|";
    etiqueta_columnas[7] = "S|";
    etiqueta_columnas[8] = "O|";

    string[] jugadores = new string[2];

    jugadores[0] = "Jugador 1|";
    jugadores[1] = "Jugador 2|";

    ronda = 1;

    int puntuacion_jugador1_anterior = 0;
    int puntuacion_jugador2_anterior = 0;

    while (ronda < 10)
    {
        Console.WriteLine(" ");
        Console.WriteLine("*************************");
        Console.Write("**** Ronda " + ronda);
        Console.WriteLine("****");
        Console.WriteLine("*************************");

        Thread.Sleep(1000);

        //Turno jugador 1
        puntuacion_jugador1[ronda - 1] = turno_jugador(1) + puntuacion_jugador1_anterior;

        puntuacion_jugador1_anterior = puntuacion_jugador1[ronda - 1];

        //Ahora mostramos la puntuación del jugador 1...

        Console.WriteLine(" ");
        Console.WriteLine("*********************");
        Console.WriteLine("*****Resultados******");
        Console.WriteLine("*********************");

        for (i = 0; i < ronda; i++)
        {
            if (i == 0)
            {
                Console.Write("           ");
            }
            Console.Write(" " + etiqueta_columnas[i]);
        }

        Console.WriteLine(" ");

        for (i = 0; i <= ronda - 1; i++)
        {
            if (i == 0)
            {
                Console.Write(" " + jugadores[i]);
            }
            Console.Write(" " + puntuacion_jugador1[i]);
        }

        Thread.Sleep(1000);

        Console.WriteLine(" ");

        //Turno Jugador 2
        puntuacion_jugador2[ronda - 1] = turno_jugador(2) + puntuacion_jugador2_anterior;

        puntuacion_jugador2_anterior = puntuacion_jugador2[ronda - 1];

        //Ahora mostramos la puntuación del jugador 2

        Console.WriteLine(" ");
        Console.WriteLine("*********************************");
        Console.WriteLine("****Puntuaciones Acumulativas****");
        Console.WriteLine("*********************************");

        for (i = 0; i < ronda; i++)
        {
            if (i == 0)
            {
                Console.Write("           ");
            }
            Console.Write(" " + etiqueta_columnas[i]);
        }

        Console.WriteLine(" ");

        for (i = 0; i <= ronda - 1; i++)
        {
            if (i == 0)
            {
                Console.Write(" " + jugadores[0]);
            }
            Console.Write(" " + puntuacion_jugador1[i]);
        }


        Console.WriteLine(" ");

        for (i = 0; i <= ronda - 1; i++)
        {
            if (i == 0)
            {
                Console.Write(" " + jugadores[1]);
            }
            Console.Write(" " + puntuacion_jugador2[i]);
        }

        Thread.Sleep(1000);

        Console.WriteLine(" ");

        ronda++;
    }

        //Resultados finales del juego

        int puntuacionFinal_jugador1 = puntuacion_jugador1[8];
        int puntuacionFinal_jugador2 = puntuacion_jugador2[8];

        Thread.Sleep(1000);

        Console.WriteLine(" ");
        if (puntuacionFinal_jugador1 > puntuacionFinal_jugador2)
        {
            Console.WriteLine("El jugador 1 ha ganado!!! Gracias por jugar >:)");
        }
        else
            Console.WriteLine("El jugador 2 ha ganado!!! Gracias por jugar >:)");
    }

    void juego_3_jugadores()
    {
        Console.WriteLine("");

        Console.WriteLine("Jugador 1 Ready");
        Thread.Sleep(1000);
        Console.WriteLine("Jugador 2 Ready");
        Thread.Sleep(1000);
        Console.WriteLine("Jugador 3 Ready");
        Thread.Sleep(1000);

        int i;

        int ronda;

        int[] puntuacion_jugador1 = new int[10];

        int[] puntuacion_jugador2 = new int[10];

        int[] puntuacion_jugador3 = new int[10];

        string[] etiqueta_columnas = new string[10];
        etiqueta_columnas[0] = "A|";
        etiqueta_columnas[1] = "M|";
        etiqueta_columnas[2] = "B|";
        etiqueta_columnas[3] = "I|";
        etiqueta_columnas[4] = "C|";
        etiqueta_columnas[5] = "I|";
        etiqueta_columnas[6] = "O|";
        etiqueta_columnas[7] = "S|";
        etiqueta_columnas[8] = "O|";

        string[] jugadores = new string[3];

        jugadores[0] = "Jugador 1|";
        jugadores[1] = "Jugador 2|";
        jugadores[2] = "Jugador 3|";

        ronda = 1;

        int puntuacion_jugador1_anterior = 0;
        int puntuacion_jugador2_anterior = 0;
        int puntuacion_jugador3_anterior = 0;

        while (ronda < 10)
        {
            Console.WriteLine(" ");
            Console.WriteLine("*************************");
            Console.Write("**** Ronda " + ronda);
            Console.WriteLine("****");
            Console.WriteLine("*************************");

            Thread.Sleep(1000);

            //Turno jugador 1
            puntuacion_jugador1[ronda - 1] = turno_jugador(1) + puntuacion_jugador1_anterior;

            puntuacion_jugador1_anterior = puntuacion_jugador1[ronda - 1];

            //Ahora mostramos la puntuación del jugador 1...

            Console.WriteLine(" ");
            Console.WriteLine("*********************");
            Console.WriteLine("*****Resultados******");
            Console.WriteLine("*********************");

            for (i = 0; i < ronda; i++)
            {
                if (i == 0)
                {
                    Console.Write("           ");
                }
                Console.Write(" " + etiqueta_columnas[i]);
            }

            Console.WriteLine(" ");

            for (i = 0; i <= ronda - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(" " + jugadores[i]);
                }
                Console.Write(" " + puntuacion_jugador1[i]);
            }

            Thread.Sleep(1000);

            Console.WriteLine(" ");

            //Turno jugador 2
            puntuacion_jugador2[ronda - 1] = turno_jugador(2) + puntuacion_jugador2_anterior;

            puntuacion_jugador2_anterior = puntuacion_jugador2[ronda - 1];

            //Ahora mostramos la puntuación del jugador 1...

            Console.WriteLine(" ");
            Console.WriteLine("*********************");
            Console.WriteLine("*****Resultados******");
            Console.WriteLine("*********************");

            for (i = 0; i < ronda; i++)
            {
                if (i == 0)
                {
                    Console.Write("           ");
                }
                Console.Write(" " + etiqueta_columnas[i]);
            }

            Console.WriteLine(" ");

            for (i = 0; i <= ronda - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(" " + jugadores[1]);
                }
                Console.Write(" " + puntuacion_jugador2[i]);
            }

            Thread.Sleep(1000);

            Console.WriteLine(" ");

            //Turno Jugador 3
            puntuacion_jugador3[ronda - 1] = turno_jugador(3) + puntuacion_jugador3_anterior;

            puntuacion_jugador3_anterior = puntuacion_jugador3[ronda - 1];

            //Ahora mostramos la puntuación del jugador 2

            Console.WriteLine(" ");
            Console.WriteLine("*********************************");
            Console.WriteLine("****Puntuaciones Acumulativas****");
            Console.WriteLine("*********************************");

            for (i = 0; i < ronda; i++)
            {
                if (i == 0)
                {
                    Console.Write("           ");
                }
                Console.Write(" " + etiqueta_columnas[i]);
            }

            Console.WriteLine(" ");

            for (i = 0; i <= ronda - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(" " + jugadores[0]);
                }
                Console.Write(" " + puntuacion_jugador1[i]);
            }


            Console.WriteLine(" ");

            for (i = 0; i <= ronda - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(" " + jugadores[1]);
                }
                Console.Write(" " + puntuacion_jugador2[i]);
            }

            Console.WriteLine(" ");

            for (i = 0; i <= ronda - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(" " + jugadores[2]);
                }
                Console.Write(" " + puntuacion_jugador3[i]);
            }

            Thread.Sleep(1000);

            Console.WriteLine(" ");

            ronda++;
        }

        //Resultados finales del juego

        int puntuacionFinal_jugador1 = puntuacion_jugador1[8];
        int puntuacionFinal_jugador2 = puntuacion_jugador2[8];
        int puntuacionFinal_jugador3 = puntuacion_jugador3[8];

        Thread.Sleep(1000);

        Console.WriteLine(" ");
        if (puntuacionFinal_jugador1 > puntuacionFinal_jugador2 && puntuacionFinal_jugador1 > puntuacionFinal_jugador3)
        {
            Console.WriteLine("El jugador 1 ha ganado!!! Gracias por jugar >:)");
        }
        else if (puntuacionFinal_jugador2 > puntuacionFinal_jugador1 && puntuacionFinal_jugador2 > puntuacionFinal_jugador3)
        {
            Console.WriteLine("El jugador 2 ha ganado!!! Gracias por jugar >:)");
        }
        else
            Console.WriteLine("El jugador 3 ha ganado!!! Gracias por jugar >:)");

    }

    int turno_jugador(int njugador)
    {
        int puntos = 0;
        bool lanzar;
        int opcion;
        Random dado = new Random();
        int lanzada;

        string entrada_de_datos;

        do
        {
            Console.WriteLine(" ");
            Console.Write("Jugador " + njugador);
            Console.WriteLine(", desea lanzar el dado?");
            Console.WriteLine("1.Si");
            Console.WriteLine("2.No");
            Console.WriteLine(" ");

            do
            {
                Console.Write("Elija opción: ");
                entrada_de_datos = Console.ReadLine();
                while (!Int32.TryParse(entrada_de_datos, out opcion))
                {
                    Console.Write("Error, debe ser un numero, elija opción:");
                    entrada_de_datos = Console.ReadLine();
                }

            } while ((opcion < 1) || (opcion > 2));

            if (opcion == 1)
            {
                //Lanza el jugador
                Console.WriteLine(" ");
                Console.WriteLine("Lanza el jugador " + njugador);
                Console.WriteLine("....esperando el dado....");
                lanzada = dado.Next(1, 7);
                Thread.Sleep(2000);
                Console.WriteLine(" ");
                Console.WriteLine("Resultado del dado: " + lanzada);

                if (lanzada == 1)
                {
                    lanzar = false;
                    puntos = 0;
                }
                else
                {
                    lanzar = true;
                    puntos = puntos + lanzada;
                }
                Console.WriteLine(" ");
                Console.WriteLine(" Puntos obtenidos en el turno: " + puntos);
                Thread.Sleep(2000);
            }
            else
            {
                lanzar = false;
            }
        } while (lanzar == true);
        return (puntos);
    }