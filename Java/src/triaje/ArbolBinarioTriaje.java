package triaje;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

public class ArbolBinarioTriaje {
    private NodoArbol raiz;

    public void insertar(Paciente paciente) {
        if (paciente == null) throw new IllegalArgumentException("Paciente obligatorio");
        if (paciente.getPuntajeRiesgo() < 1 || paciente.getPuntajeRiesgo() > 100)
            throw new IllegalArgumentException("El riesgo debe estar entre 1 y 100");
        raiz = insertarRecursivo(raiz, paciente);
    }

    private NodoArbol insertarRecursivo(NodoArbol actual, Paciente paciente) {
        if (actual == null) return new NodoArbol(paciente);
        if (paciente.getPuntajeRiesgo() < actual.datos.getPuntajeRiesgo())
            actual.izquierdo = insertarRecursivo(actual.izquierdo, paciente);
        else actual.derecho = insertarRecursivo(actual.derecho, paciente);
        return actual;
    }

    public List<Paciente> obtenerInOrden() {
        List<Paciente> lista = new ArrayList<>();
        recorrerInOrden(raiz, lista);
        return lista;
    }

    private void recorrerInOrden(NodoArbol actual, List<Paciente> lista) {
        if (actual == null) return;
        recorrerInOrden(actual.izquierdo, lista);
        lista.add(actual.datos);
        recorrerInOrden(actual.derecho, lista);
    }

    public void mostrarInOrden() {
        if (raiz == null) {
            System.out.println("El árbol se encuentra vacío.");
            return;
        }
        for (Paciente p : obtenerInOrden()) System.out.println(p);
    }

    public Paciente buscarPorRiesgo(int puntaje) {
        NodoArbol actual = raiz;
        while (actual != null) {
            if (actual.datos.getPuntajeRiesgo() == puntaje) return actual.datos;
            actual = puntaje < actual.datos.getPuntajeRiesgo() ? actual.izquierdo : actual.derecho;
        }
        return null;
    }

    public Paciente obtenerMasCritico() {
        if (raiz == null) return null;
        NodoArbol actual = raiz;
        while (actual.derecho != null) actual = actual.derecho;
        return actual.datos;
    }

    public void imprimirEstructura() {
        if (raiz == null) {
            System.out.println("El árbol está vacío.");
            return;
        }
        imprimirNodo(raiz, "", true, "RAÍZ");
    }

    private void imprimirNodo(NodoArbol nodo, String sangria, boolean esUltimo, String rama) {
        if (nodo == null) return;
        System.out.print(sangria);
        System.out.print(esUltimo ? "└── " : "├── ");
        System.out.println("[" + rama + "] " + nodo.datos.getNombre() + " (Riesgo: " + nodo.datos.getPuntajeRiesgo() + ")");
        sangria += esUltimo ? "    " : "│   ";
        if (nodo.izquierdo != null) imprimirNodo(nodo.izquierdo, sangria, nodo.derecho == null, "IZQ <");
        if (nodo.derecho != null) imprimirNodo(nodo.derecho, sangria, true, "DER >=");
    }

    public Path respaldarEnTxt(Path ruta) throws IOException {
        Path absoluta = ruta.toAbsolutePath().normalize();
        if (absoluta.getParent() != null) Files.createDirectories(absoluta.getParent());
        List<String> lineas = new ArrayList<>();
        lineas.add("SISTEMA DE TRIAJE MÉDICO - RESPALDO TXT");
        lineas.add("Fecha de respaldo: " + LocalDateTime.now().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")));
        lineas.add("Pacientes ordenados por riesgo (InOrden)");
        lineas.add("-------------------------------------------------------");
        for (Paciente p : obtenerInOrden()) lineas.add(p.toString());
        if (raiz == null) lineas.add("Sin pacientes registrados.");
        Files.write(absoluta, lineas, StandardCharsets.UTF_8);
        return absoluta;
    }
}