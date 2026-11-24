package triaje;

import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

public class PruebasArbol {
    public static void main(String[] args) throws Exception {
        ArbolBinarioTriaje a = new ArbolBinarioTriaje();
        assertTrue(a.obtenerMasCritico() == null, "Árbol vacío");
        a.insertar(new Paciente("Raíz", "1", "ejemplo", 50));
        a.insertar(new Paciente("Menor", "2", "ejemplo", 25));
        a.insertar(new Paciente("Mayor", "3", "ejemplo", 80));
        a.insertar(new Paciente("Igual", "4", "ejemplo", 80));
        List<Paciente> orden = a.obtenerInOrden();
        assertTrue(orden.size() == 4, "Cantidad de pacientes");
        assertTrue(orden.get(0).getPuntajeRiesgo() == 25 && orden.get(1).getPuntajeRiesgo() == 50
            && orden.get(2).getPuntajeRiesgo() == 80 && orden.get(3).getPuntajeRiesgo() == 80, "InOrden");
        assertTrue(a.buscarPorRiesgo(25) != null, "Búsqueda existente");
        assertTrue(a.buscarPorRiesgo(99) == null, "Búsqueda inexistente");
        assertTrue(a.obtenerMasCritico().getPuntajeRiesgo() == 80, "Más crítico");
        boolean invalido = false;
        try { a.insertar(new Paciente("Inválido", "5", "ejemplo", 101)); }
        catch (IllegalArgumentException e) { invalido = true; }
        assertTrue(invalido, "Validación rango");
        Path respaldo = Files.createTempFile("triaje-prueba-", ".txt");
        try {
            a.respaldarEnTxt(respaldo);
            String texto = Files.readString(respaldo);
            assertTrue(texto.contains("Raíz") && texto.contains("Igual"), "Respaldo TXT");
        } finally { Files.deleteIfExists(respaldo); }
        System.out.println("OK: 8 verificaciones Java realizadas correctamente.");
    }

    private static void assertTrue(boolean condicion, String descripcion) {
        if (!condicion) throw new AssertionError("Falló: " + descripcion);
    }
}
