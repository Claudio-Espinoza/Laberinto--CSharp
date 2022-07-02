using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class Stack
    {
        private Nodo ancla;
        private Nodo trabajo;

        public Stack()
        {
            //Instanciamos el ancla
            ancla = new Nodo();

            //COmo es un stack vacia, su siguiente nivel es null
            ancla.Siguiente = null;
        }

        //-|Push|-----------------------------------------------------------------------------------------------------------------------------------------------------//
        //Se pondra en la parte superior de la pila, entre mas reciente, mas arriba de la pila estara y sera el primero en ser sacado
        public void Push(int dato)
        {
            Nodo temp = new Nodo();
            temp.Dato = dato;

            temp.Siguiente = ancla.Siguiente;

            ancla.Siguiente = temp;
        }

        //-|Pop|------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Saca el primer valor del stack, el que esta arriba en ese momento segun el funcionamiento de la pila
        //Y lo elimina dek stack
        public int Pop()
        {

            int valor = 0;

            //Llevamos a cabo el trabajo solo si hay elementos en el stack
            if (ancla.Siguiente != null)
            {
                //Obtenemos el dato correspondiente
                trabajo = ancla.Siguiente;
                valor = trabajo.Dato;


                //Lo sacamos del stack
                ancla.Siguiente = trabajo.Siguiente;
                trabajo.Siguiente = null;

            }
            return valor;
        }

        //-|Peek|-----------------------------------------------------------------------------------------------------------------------------------------------------//
        //Hace lo mismo que el (Pop) pero este no elimina el valor
        public int Peek()
        {
            //Esta version no contiene codigo de seguridad
            //Colocar una excepcion cuandos e intente hacer un pop a un stack vacia

            int valor = 0;

            //Llevamos a cabo el trabajo solo si hay elemntos en el stack
            if (ancla.Siguiente != null)
            {
                //Obtenemos el dato correspondiente
                trabajo = ancla.Siguiente;
                valor = trabajo.Dato;
            }
            return valor;
        }

        //-|Transversa|-----------------------------------------------------------------------------------------------------------------------------------------------//
        public void Transversa()
        {
            //Trabajo al inicio
            trabajo = ancla;

            //Recorremos hasta encontrar el final
            while (trabajo.Siguiente != null)
            {
                //Avanzamos trabajo
                trabajo = trabajo.Siguiente;

                //Obtenemos el dato y lo mostramos
                int d = trabajo.Dato;

                Console.WriteLine("|-[{0}]-|\n", d);
            }
        } //Se ha hecho con el fin de utilidad pero se que no pertenece a las estructuras de datos
    }
}
