namespace TriajeBinarioApp.Clases;                  // Espacio de nombres (estilo de una sola línea)

public class Paciente                               // Entidad: datos de un paciente
{
    public string Nombre { get; set; }              // Nombre completo
    public string Cedula { get; set; }              // Documento de identidad
    public string Sintoma { get; set; }             // Motivo de consulta
    public int PuntajeRiesgo { get; set; }          // Gravedad de 1 a 100; ordena el árbol

    public Paciente(string nombre, string cedula, string sintoma, int puntajeRiesgo)   // Constructor
    {
        Nombre = nombre;                            // Guarda el nombre
        Cedula = cedula;                            // Guarda la cédula
        Sintoma = sintoma;                          // Guarda el síntoma
        PuntajeRiesgo = puntajeRiesgo;              // Guarda el riesgo
    }

    public override string ToString() =>            // Cómo se muestra al imprimirlo
        $"[Riesgo: {PuntajeRiesgo}] {Nombre} (CC: {Cedula}) - Síntoma: {Sintoma}";   // Ej: [Riesgo: 50] Carlos (CC: 123) - Síntoma: Fiebre
}