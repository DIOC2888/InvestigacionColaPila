using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificacionParentesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Verificador de Paréntesis Balanceados (usa una PILA)\n");
            Console.WriteLine("Escribe una expresión (ej.: (2+3)*(4+(5-1))) o 'salir' para terminar.");
            Console.WriteLine("-----------------------------------------------------------------------");

            while (true)
            {
                Console.Write("Expresión: ");
                string input = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada no válida. Intenta de nuevo.");
                    continue;
                }

                if (input.Equals("salir", StringComparison.OrdinalIgnoreCase))
                    break;

                bool balanceada = EstaBalanceada(input);

                Console.WriteLine("-----------------------------------------------------------------------");
                if (balanceada)
                {
                    Console.WriteLine("La expresión está BALANCEADA.");
                }
                else
                {
                    Console.WriteLine("a expresión NO está balanceADA.");
                }
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            // Pausa opcional:
            // Console.WriteLine("Presione una tecla para salir...");
            // Console.ReadKey();
        }

        // Recorre la cadena y usa una pila para '(' y ')'
        static bool EstaBalanceada(string expr)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expr)
            {
                if (c == '(')
                {
                    pila.Push(c); // apilar cuando vemos '('
                }
                else if (c == ')')
                {
                    // si no hay nada que desapilar, está desbalanceada
                    if (pila.Count == 0) return false;
                    pila.Pop(); // desapilar un '(' correspondiente
                }
                // Si aparecen otros caracteres, se ignoran (solo verificamos paréntesis)
            }

            // Al final, si la pila está vacía, está balanceada
            return pila.Count == 0;

        }
    }
}
