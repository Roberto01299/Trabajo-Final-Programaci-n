using System;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            DatosPrestamos prestamos = new DatosPrestamos();

            string entrada = "";
            bool menu = true;

            
           

            while (menu)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" _______________________________________________");
                Console.WriteLine("|                                               |");
                Console.WriteLine("|Bienvenido al sistema calculadora de prestamos.|");
                Console.WriteLine("|_______________________________________________|");
                Console.WriteLine("|1-Introducir datos del prestamo.               |");
                Console.WriteLine("|_______________________________________________|");
                Console.WriteLine("|2-Generar tabla Amortizada.                    |");
                Console.WriteLine("|_______________________________________________|");
                Console.WriteLine("|3-Salir.                                       |");
                Console.WriteLine("|_______________________________________________|\n");

                Console.Write("Digite a cual opcion desea acceder: ");
                entrada = Console.ReadLine();

                switch (entrada)
                {


                    case "1":
                        Console.Clear();
                        prestamos.datos();
                        break;

                    case "2":
                        Console.Clear();
                        prestamos.tabla();
                        break;

                    case "3":
                        menu = false;
                        break;

                    default:
                        Console.Clear();
                        Console.Write("Ha introducido un valor invalido, presione cualquier tecla para regresar al menu principal.");
                        Console.ReadKey();
                        break;

                }

            }

        }
    }
}


class DatosPrestamos
{


    public double  Interes_pagado, Capital_pagado, monto_prestamo, interes_anual, cuotas;
    public int fila, meses, i;
    public string beneficiario;
    public void datos()
    {

        Console.Clear();
        Console.Write("Intruduzca el beneficiario: ");

        beneficiario = Console.ReadLine();

        Console.Write("Introduzca el monto del prestamo: ");

        monto_prestamo = Convert.ToDouble(Console.ReadLine());

        Console.Write("Introduzca la tasa de interes anual: ");

        interes_anual = Convert.ToDouble(Console.ReadLine());

        Console.Write("Introduzca el plazo en meses: ");

        meses = Convert.ToInt32(Console.ReadLine());





        //Pasando el interes a anual.
        interes_anual = ((interes_anual / 100) / 12);

        //Fórmula para calcular la cuota
        cuotas = (monto_prestamo * interes_anual) / (1 - Math.Pow((1 + interes_anual), (-meses)));


        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("Este sera su pago mensual: " + "{0:N2}",cuotas);
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("Para poder ver su tabla Amortizada dirijase al menu anterior y seleccione la opcion 2.");
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.Write("Presione una tecla para volver.");
        Console.ReadKey();
        Console.Clear();

    }


    public void tabla()
    {
        Console.Clear();
        Console.WriteLine("Beneficiario: " + beneficiario);
        fila = 1;
        Console.WriteLine();
        Console.WriteLine();
        Console.Write(" Numero de pago \t");
        Console.Write("Cuota \t\t");
        Console.Write("Intereses Pagados \t\t");
        Console.Write("Capital Pagado \t\t");
        Console.Write("Monto del prestamo \t");
        Console.WriteLine();
        Console.WriteLine();


        for (i = 0; i < meses; i++)
        {


            Console.Write("\t{0}\t\t", fila);


            Console.Write("{0:N2}", cuotas);


            Interes_pagado = interes_anual * monto_prestamo;
            Console.Write("\t\t" + "{0:N2}", Interes_pagado);


            Capital_pagado = cuotas - Interes_pagado;
            Console.Write("\t\t" + "{0:N2}", Capital_pagado);


            monto_prestamo = monto_prestamo - Capital_pagado;

            Console.Write("\t\t" + "{0:N2}", monto_prestamo);
            Console.Write("\n");
            
            fila = fila + 1;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

        }

        Console.WriteLine("\n");
        Console.Write("Presione una tecla para volver.");
        Console.ReadKey();
        Console.Clear();
    }
}

