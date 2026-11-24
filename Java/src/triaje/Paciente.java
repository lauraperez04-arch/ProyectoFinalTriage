package triaje;

public class Paciente {
    private final String nombre;
    private final String cedula;
    private final String sintoma;
    private final int puntajeRiesgo;

    public Paciente(String nombre, String cedula, String sintoma, int puntajeRiesgo) {
        this.nombre = nombre;
        this.cedula = cedula;
        this.sintoma = sintoma;
        this.puntajeRiesgo = puntajeRiesgo;
    }

    public String getNombre() { return nombre; }
    public int getPuntajeRiesgo() { return puntajeRiesgo; }

    @Override
    public String toString() {
        return "[Riesgo: " + puntajeRiesgo + "] " + nombre + " (CC: " + cedula + ") - Síntoma: " + sintoma;
    }
}
