internal class Program
{
        public class ColaArregloString
        {
            private string[] array; // arreglo de almacenamiento
            private int frente;     // siguiente a salir
            private int final;      // donde insertar
            private int count;      // cantidad de elementos

            public ColaArregloString(int capacidad)
            {
                // Si pasan una capacidad inválida, ponemos 1 como mínimo
                if (capacidad < 1) capacidad = 1;

                array = new string[capacidad];
                frente = 0;
                final = 0;
                count = 0;
            }

            public int Capacidad() { return array.Length; }
            public int Tamano() { return count; }
            public bool Vacia() { return count == 0; }
            public bool Llena() { return count == array.Length; }

            // Enqueue (meter). Devuelve true si se pudo encolar.
            public bool Enqueue(string valor)
            {
                if (Llena())
                {
                    Console.WriteLine("No se puede encolar: la cola está llena.");
                    return false;
                }

                array[final] = valor;
                final = (final + 1) % array.Length; // avance circular
                count++;
                return true;
            }

            // Dequeue (sacar). Devuelve true si se pudo desencolar y coloca el resultado en 'valor'.
            public bool Dequeue(out string valor)
            {
                if (Vacia())
                {
                    Console.WriteLine("No se puede desencolar: la cola está vacía.");
                    valor = "";
                    return false;
                }

                valor = array[frente];
                array[frente] = ""; // limpiar
                frente = (frente + 1) % array.Length; // avance circular
                count--;
                return true;
            }

            // Peek (ver frente). Devuelve true si hay elemento y lo deja en 'valor' sin quitarlo.
            public bool Peek(out string valor)
            {
                if (Vacia())
                {
                    Console.WriteLine("No hay elementos: la cola está vacía.");
                    valor = "";
                    return false;
                }

                valor = array[frente];
                return true;
            }
        }

    static void Main(string[] args)
    {
        ColaArregloString cola = new ColaArregloString(3);

        // Encolar
        cola.Enqueue("A");
        cola.Enqueue("B");

        // Ver frente
        if (cola.Peek(out string primero))
            Console.WriteLine("Frente: " + primero); // A

        // Desencolar
        if (cola.Dequeue(out string salido1))
            Console.WriteLine("Salió: " + salido1); // A

        // Encolar más
        cola.Enqueue("C");
        cola.Enqueue("D"); // ahora está llena: B, C, D

        // Intento de encolar cuando está llena
        cola.Enqueue("E"); // mostrará mensaje de cola llena

        // Desencolar y ver frente nuevamente
        if (cola.Dequeue(out string salido2))
            Console.WriteLine("Salió: " + salido2); // B

        if (cola.Peek(out string ahoraFrente))
            Console.WriteLine("Frente: " + ahoraFrente); // C

        Console.WriteLine("Tamaño actual: " + cola.Tamano()); // 2 (C, D)
    }
}

