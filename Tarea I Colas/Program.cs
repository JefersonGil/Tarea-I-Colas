using System;

namespace Tarea_I_Colas
{
    class Program
    {
        static void Main(string[] args)
        {
            //pequena interfas para probar el funcionamiento
            Cola MiCola = new Cola();
        Inicio:
            Console.WriteLine("1 para leer cola, 2 para agregar a cola, 3 para eliminar primer elemento de la cola");
            int Opcion = int.Parse(Console.ReadLine());
            if (Opcion == 1)
            {
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();
            }
            else if (Opcion == 2)
            {
                Console.WriteLine("Escriba su elemento: ");
                string Elemento = Console.ReadLine();
                Console.WriteLine("Escriba su prioridad: ");
                int Prioridad = int.Parse(Console.ReadLine());
                MiCola.InsertarElementos(Prioridad, Elemento);
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();
            }
            else if (Opcion == 3)
            {
                MiCola.ExtraerElementos();
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }
            goto Inicio;
        }
    }
    class Cola
    {
        public class Nodo //Clase nodo
        {
            public int Prioridad; //Nivel de importancia en la cola
            public string Informacion; //identifica un elemento en la cola
            public Nodo Siguiente; //Conoce su siguiente nodo en la cola
        }

        private Nodo InicioCola, FinCola; //Donde empieza la cola y donde acaba

        public Cola() //Constructor de la clase cola
        {
            InicioCola = null;
            FinCola = null;
        }

        public bool ColaVacia() //Comprueba si hay elementos en la cola
        {
            if (InicioCola == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertarElementos(int Prioridad, string Elemento) //Insertar a una cola
        {
            Nodo unNodo = new Nodo(); 
            unNodo.Prioridad = Prioridad; //Prioridad del elemento en la cola
            unNodo.Informacion = Elemento;
            unNodo.Siguiente = null;

            if (ColaVacia())
            {
                InicioCola = unNodo;
                FinCola = unNodo;
            }
            else 
            {
                Nodo Aux = InicioCola; //Este nodo sirve de apollo para comparar la prioridad del nuevo elemento con los existentes en caso de existir alguno
                if (InicioCola.Prioridad > Prioridad)
                {
                    unNodo.Siguiente = InicioCola;
                    InicioCola = unNodo;
                }
                else
                {
                    while (Aux.Siguiente != null && Aux.Siguiente.Prioridad < Prioridad)
                    {
                        Aux = Aux.Siguiente;
                    }
                    unNodo.Siguiente = Aux.Siguiente;
                    Aux.Siguiente = unNodo;
                }
            }
        }
        public void ExtraerElementos() //Eliminar de una cola, elimina el elemento de menos prioridad
        {
            if (!ColaVacia()) 
            {
                string PrimerElemento = InicioCola.Informacion; 
                if (InicioCola == FinCola) 
                {
                    InicioCola = null;
                    FinCola = null;
                }
                else
                {
                    InicioCola = InicioCola.Siguiente;
                }
            }
        }
        public void LeerLista() //Metodo para leer la cola
        {
            Nodo miCola = InicioCola;
            Console.WriteLine("Elementos de la cola");
            while (miCola != null)
            {
                Console.WriteLine(miCola.Informacion);
                miCola = miCola.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
