using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E48_DecimalAHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Programa que convierte número Decimal positivo a Hexadecimal\nIngrese número Decimal:");
                
                if (Int32.TryParse(Console.ReadLine(), out int numero) && numero >0)
                    Console.WriteLine("Resultado {0}", ConvertirDecimalAHexadecimal(numero));
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error no se puede convertir...");
                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);
            } while (!salir);
        }
        public static string ConvertirDecimalAHexadecimal(int numero)
        {
            if (numero >= 0 && numero <= 9)
                return numero.ToString();

            StringBuilder resultado = new StringBuilder();
            int cociente = numero, residuo;
            List<int> cosientes = new List<int>();

            while ( cociente != 0 )
            {
                residuo = cociente % 16;
                cociente /= 16;
                cosientes.Add(residuo);                
            }

            cosientes.Reverse();
            foreach (char v in cosientes)
                resultado.Append(ObtenerEquivalenteEnBase16(v));

            return resultado.ToString();
        }
        public static char? ObtenerEquivalenteEnBase16( int numero)
        {
            if (numero >= 0 && numero <= 9)
                return char.Parse(numero.ToString());
            else
            {
                switch (numero)
                {
                    case 10:
                        return 'A';
                    case 11:
                        return 'B';
                    case 12:
                        return 'C';
                    case 13:
                        return 'D';
                    case 14:
                        return 'E';
                    case 15:
                        return 'F';
                }
            }

            return null;
        }
    }
}
