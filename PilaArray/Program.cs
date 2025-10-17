using System;

namespace PilaBasica
{
    public class PilaArregloInt
    {
        // Qué necesitas:
        // - Un arreglo para guardar los datos
        private int[] array;

        // - Un índice tope (empieza en -1 cuando está vacía)
        private int tope;

        public PilaArregloInt(int capacidad)
        {
            if (capacidad < 1) capacidad = 1; // mínimo 1
            array = new int[capacidad];
            tope = -1; // pila vacía
        }

        public int Capacidad() { return array.Length; }
        public int Tamano()    { return tope + 1; } // cantidad de elementos
        public bool Vacia()    { return tope == -1; }
        public bool Llena()    { return tope == array.Length - 1; }

        // Push (meter): si no está llena, tope = tope + 1 y array[tope] = valor
        public bool Push(int valor)
        {
            if (Llena())
            {
                Console.WriteLine("No se puede hacer el push, la pila está llena.");
                return false;
            }
            tope ++;
            array[tope] = valor;
            return true;
        }

        // Pop (sacar): si no está vacía, lee array[tope], luego tope = tope - 1
        public bool Pop(out int valor)
        {
            if (Vacia())
            {
                Console.WriteLine("No se puede hacer Pop: la pila está vacía.");
                valor = 0;
                return false;
            }
            valor = array[tope];
            array[tope] = 0;
            tope --;
            return true;
        }

        // Peek (ver tope): devuelve array[tope] sin cambiar tope
        public bool Peek(out int valor)
        {
            if (Vacia())
            {
                Console.WriteLine("No se puede hacer Peek: la pila está vacía.");
                valor = 0;
                return false;
            }
            valor = array[tope];
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            // Ejemplo:
            // Inicio: tope = -1 (arreglo vacío)
            PilaArregloInt pila = new PilaArregloInt(3);

            // Push 5 → tope = 0, array[0] = 5
            pila.Push(5);

            // Push 7 → tope = 1, array[1] = 7
            pila.Push(7);

            // Peek → devuelve 7
            if (pila.Peek(out int arriba)) Console.WriteLine("Peek: " + arriba); // 7

            // Pop → saca 7 y tope = 0
            if (pila.Pop(out int salido)) Console.WriteLine("Pop: " + salido); // 7

            // Peek ahora → 5
            if (pila.Peek(out arriba)) Console.WriteLine("Peek: " + arriba); // 5
        }
    }
}
