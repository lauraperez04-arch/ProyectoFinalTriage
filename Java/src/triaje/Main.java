package triaje;

import java.io.IOException;
import java.nio.file.Path;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner teclado = new Scanner(System.in, "UTF-8");
        ArbolBinarioTriaje arbolTriaje = new ArbolBinarioTriaje();
        arbolTriaje.insertar(new Paciente("Carlos Mendoza", "10984512", "Dolor torácico leve", 50));
        arbolTriaje.insertar(new Paciente("Ana Lucía Gómez", "52418963", "Esguince de tobillo", 25));
        arbolTriaje.insertar(new Paciente("Jorge Ramírez", "80147258", "Dificultad respiratoria", 80));
        arbolTriaje.insertar(new Paciente("María Fernanda Ruiz", "10203040", "Fiebre moderada", 15));
        arbolTriaje.insertar(new Paciente("Luis Eduardo Torres", "79456123", "Trauma craneoencefálico", 95));

        boolean continuar = true;
        while (continuar) {
            System.out.println("\n==============================================");
            System.out.println(" SISTEMA DE TRIAJE MÉDICO - ÁRBOL BINARIO ");
            System.out.println("==============================================");
            System.out.println("1. Registrar nuevo paciente en el árbol");
            System.out.println("2. Visualizar jerarquía del Árbol Binario");
            System.out.println("3. Listar pacientes ordenados (Recorrido InOrden)");
            System.out.println("4. Consultar paciente más crítico (Extremo Derecho)");
            System.out.println("5. Buscar paciente por puntaje de riesgo");
            System.out.println("6. Respaldar pacientes en un archivo TXT");
            System.out.println("7. Salir");
            System.out.print("Seleccione una opción: ");
            if (!teclado.hasNextLine()) break;
            String entrada = teclado.nextLine().trim();
            int opcion;
            try { opcion = Integer.parseInt(entrada); }
            catch (NumberFormatException e) {
                System.out.println("Debe ingresar una opción numérica.");
                continue;
            }
            System.out.println();
            switch (opcion) {
                case 1:
                    String nombre = leerTexto(teclado, "Nombre del paciente: ");
                    String cedula = leerTexto(teclado, "Cédula: ");
                    String sintoma = leerTexto(teclado, "Síntoma principal: ");
                    int riesgo = leerPuntaje(teclado, "Puntaje de riesgo (1 - 100): ");
                    arbolTriaje.insertar(new Paciente(nombre, cedula, sintoma, riesgo));
                    System.out.println("Paciente insertado correctamente en la estructura.");
                    break;
                case 2:
                    System.out.println("--- ESTRUCTURA JERÁRQUICA DE NODOS ---");
                    arbolTriaje.imprimirEstructura();
                    break;
                case 3:
                    System.out.println("--- LISTADO ORDENADO POR GRAVEDAD (INORDEN) ---");
                    arbolTriaje.mostrarInOrden();
                    break;
                case 4:
                    Paciente critico = arbolTriaje.obtenerMasCritico();
                    System.out.println(critico == null ? "No hay pacientes registrados." : "ALERTA MÁXIMA: " + critico);
                    break;
                case 5:
                    int buscar = leerPuntaje(teclado, "Ingrese el puntaje de riesgo a buscar (1 - 100): ");
                    Paciente encontrado = arbolTriaje.buscarPorRiesgo(buscar);
                    System.out.println(encontrado == null ? "No existe un paciente con ese puntaje exacto." : "Resultado encontrado: " + encontrado);
                    break;
                case 6:
                    try {
                        Path ruta = arbolTriaje.respaldarEnTxt(Path.of("Respaldos", "pacientes_triaje.txt"));
                        System.out.println("Respaldo TXT creado correctamente: " + ruta);
                    } catch (IOException e) {
                        System.out.println("No se pudo escribir el respaldo: " + e.getMessage());
                    }
                    break;
                case 7:
                    continuar = false;
                    System.out.println("Hasta luego.");
                    break;
                default:
                    System.out.println("Opción no válida. Seleccione entre 1 y 7.");
            }
        }
    }

    private static String leerTexto(Scanner teclado, String mensaje) {
        while (true) {
            System.out.print(mensaje);
            String valor = teclado.nextLine().trim();
            if (!valor.isEmpty()) return valor;
            System.out.println("El campo no puede quedar vacío.");
        }
    }

    private static int leerPuntaje(Scanner teclado, String mensaje) {
        while (true) {
            System.out.print(mensaje);
            try {
                int numero = Integer.parseInt(teclado.nextLine().trim());
                if (numero >= 1 && numero <= 100) return numero;
            } catch (NumberFormatException e) { /* Reintentar */ }
            System.out.println("Ingrese un número entero entre 1 y 100.");
        }
    }
}
