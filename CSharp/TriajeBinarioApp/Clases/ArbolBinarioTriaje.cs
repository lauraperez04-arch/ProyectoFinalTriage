using System;                                   // Console, DateTime, excepciones
using System.Collections.Generic;               // List e IEnumerable
using System.IO;                                // Path, Directory, File
using System.Text;                              // UTF8Encoding

namespace TriajeBinarioApp.Clases
{
    public class ArbolBinarioTriaje
    {
        public NodoArbol? Raiz { get; private set; }    // Primer nodo; solo la clase la modifica

        public ArbolBinarioTriaje()                     // Constructor
        {
            Raiz = null;                                // Árbol nuevo = vacío
        }

        public void Insertar(Paciente nuevoPaciente)    // Registra un paciente
        {
            ArgumentNullException.ThrowIfNull(nuevoPaciente);   // Error si es null

            if (nuevoPaciente.PuntajeRiesgo < 1 || nuevoPaciente.PuntajeRiesgo > 100)   // Fuera de rango
            {
                throw new ArgumentOutOfRangeException(nameof(nuevoPaciente), "El riesgo debe estar entre 1 y 100.");   // Rechaza
            }

            Raiz = InsertarRecursivo(Raiz, nuevoPaciente);      // Inserta y actualiza la raíz
        }

        private NodoArbol InsertarRecursivo(NodoArbol? actual, Paciente paciente)
        {
            if (actual == null)                         // Llegó a un hueco
            {
                return new NodoArbol(paciente);         // Crea el nodo aquí
            }

            if (paciente.PuntajeRiesgo < actual.Datos.PuntajeRiesgo)    // ¿Menor riesgo?
            {
                actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, paciente);   // Baja por la izquierda
            }
            else                                        // Mayor o igual
            {
                actual.Derecho = InsertarRecursivo(actual.Derecho, paciente);       // Baja por la derecha
            }

            return actual;                              // Conserva los enlaces
        }

        public void MostrarInOrden()                    // Imprime de menor a mayor riesgo
        {
            if (Raiz == null)                           // Árbol vacío
            {
                Console.WriteLine("El árbol se encuentra vacío.");   // Avisa
                return;                                 // Termina
            }
            RecorrerInOrden(Raiz);                      // Inicia el recorrido
        }

        private void RecorrerInOrden(NodoArbol? nodo)
        {
            if (nodo == null) return;                   // Nada que mostrar

            RecorrerInOrden(nodo.Izquierdo);            // 1) Lado izquierdo
            Console.WriteLine(nodo.Datos.ToString());   // 2) Nodo actual
            RecorrerInOrden(nodo.Derecho);              // 3) Lado derecho
        }

        public Paciente? BuscarPorRiesgo(int puntaje)   // Busca por puntaje exacto
        {
            return BuscarRecursivo(Raiz, puntaje);      // Empieza en la raíz
        }

        private Paciente? BuscarRecursivo(NodoArbol? actual, int puntaje)
        {
            if (actual == null) return null;            // No existe
            if (actual.Datos.PuntajeRiesgo == puntaje) return actual.Datos;     // Encontrado

            if (puntaje < actual.Datos.PuntajeRiesgo)   // ¿Buscado es menor?
                return BuscarRecursivo(actual.Izquierdo, puntaje);   // Busca a la izquierda
            else
                return BuscarRecursivo(actual.Derecho, puntaje);     // Busca a la derecha
        }

        public Paciente? ObtenerMasCritico()            // Paciente de mayor riesgo
        {
            if (Raiz == null) return null;              // Sin pacientes

            NodoArbol actual = Raiz;                    // Parte de la raíz
            while (actual.Derecho != null)              // Mientras haya nodo a la derecha
            {
                actual = actual.Derecho;                // Baja por la derecha
            }
            return actual.Datos;                        // El del extremo derecho
        }

        public void ImprimirEstructura()                // Dibuja el árbol
        {
            if (Raiz == null)                           // Árbol vacío
            {
                Console.WriteLine("El árbol está vacío.");   // Avisa
                return;                                 // Termina
            }
            ImprimirNodo(Raiz, "", true, "RAÍZ");       // Dibuja desde la raíz
        }

        private void ImprimirNodo(NodoArbol? nodo, string sangria, bool esUltimo, string rama)
        {
            if (nodo == null) return;                   // Nada que dibujar

            Console.Write(sangria);                     // Espacios de alineación
            Console.Write(esUltimo ? "└── " : "├── ");  // Conector según posición
            Console.WriteLine($"[{rama}] {nodo.Datos.Nombre} (Riesgo: {nodo.Datos.PuntajeRiesgo})");   // Datos del nodo

            sangria += esUltimo ? "    " : "│   ";      // Sangría para los hijos

            if (nodo.Izquierdo != null || nodo.Derecho != null)     // ¿Tiene hijos?
            {
                if (nodo.Izquierdo != null)             // Hijo izquierdo
                    ImprimirNodo(nodo.Izquierdo, sangria, nodo.Derecho == null, "IZQ <");   // Es último si no hay derecho

                if (nodo.Derecho != null)               // Hijo derecho
                    ImprimirNodo(nodo.Derecho, sangria, true, "DER >=");    // Siempre es último
            }
        }

        public IEnumerable<Paciente> ObtenerInOrden()   // Pacientes ordenados en una lista
        {
            List<Paciente> lista = new List<Paciente>();    // Lista vacía
            RecorrerInOrdenLista(Raiz, lista);          // La llena en InOrden
            return lista;                               // La devuelve
        }

        private void RecorrerInOrdenLista(NodoArbol? nodo, List<Paciente> lista)
        {
            if (nodo == null) return;                   // Nada que agregar

            RecorrerInOrdenLista(nodo.Izquierdo, lista);    // Izquierda
            lista.Add(nodo.Datos);                      // Nodo actual
            RecorrerInOrdenLista(nodo.Derecho, lista);  // Derecha
        }

        public string RespaldarEnTxt(string rutaArchivo)    // Guarda el respaldo en TXT
        {
            string rutaCompleta = Path.GetFullPath(rutaArchivo);        // Ruta absoluta
            string? carpeta = Path.GetDirectoryName(rutaCompleta);      // Solo la carpeta

            if (!string.IsNullOrEmpty(carpeta))         // Si hay carpeta
            {
                Directory.CreateDirectory(carpeta);     // La crea si no existe
            }

            List<string> lineas = new List<string>      // Líneas del archivo
            {
                "SISTEMA DE TRIAJE MÉDICO - RESPALDO TXT",                  // Título
                $"Fecha de respaldo: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",   // Fecha y hora
                "Pacientes ordenados por riesgo (InOrden)",                 // Subtítulo
                new string('-', 55)                                         // Separador
            };

            foreach (Paciente p in ObtenerInOrden())    // Recorre los pacientes ordenados
            {
                lineas.Add(p.ToString());               // Agrega una línea por paciente
            }

            if (Raiz == null)                           // Árbol vacío
            {
                lineas.Add("Sin pacientes registrados.");   // Lo indica en el archivo
            }

            File.WriteAllLines(rutaCompleta, lineas, new UTF8Encoding(false));  // Escribe en UTF-8 sin BOM
            return rutaCompleta;                        // Devuelve dónde quedó
        }
    }
}