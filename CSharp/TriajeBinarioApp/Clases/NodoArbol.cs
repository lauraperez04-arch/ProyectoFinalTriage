namespace TriajeBinarioApp.Clases;                  // Espacio de nombres (estilo de una sola línea)

public class NodoArbol                              // Nodo: una "cajita" del árbol
{
    public Paciente Datos { get; set; }             // Paciente guardado en el nodo
    public NodoArbol? Izquierdo { get; set; }       // Hijo izquierdo (menor riesgo); null si no hay
    public NodoArbol? Derecho { get; set; }         // Hijo derecho (mayor o igual riesgo); null si no hay

    public NodoArbol(Paciente paciente)             // Constructor: recibe el paciente a guardar
    {
        Datos = paciente;                           // Guarda el paciente en el nodo
    }                                               // Izquierdo y Derecho quedan null por defecto
}