using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaImpresion

{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> colaDoc = new Queue<string>();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Bienvenido al sistema de cola de impresión.\n");
            Console.WriteLine("-----------------------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("Ingrese el nombre del documento (o 'salir' para terminar):");
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
                else if(input.ToLower() == "salir")
                {
                    break;
                }
                else
                {
                    colaDoc.Enqueue(input);
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"{colaDoc.Count} Documentos en la cola:");
            foreach (var doc in colaDoc)
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Imprimiendo el primer documento en cola...");
            if (colaDoc.Count > 0)
            {
                string docImpreso = colaDoc.Dequeue();
                Console.WriteLine($"Documento '{docImpreso}' impreso y removido de la cola.");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($"{colaDoc.Count} Documentos restantes en la cola:");
                foreach (var doc in colaDoc)
                {
                    Console.WriteLine(doc);
                    
                }
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay documentos en la cola para imprimir.");
            }
        }
    }
}
