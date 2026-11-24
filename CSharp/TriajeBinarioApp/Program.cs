using System.Text;
using TriajeBinarioApp.Clases;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
var arbolTriaje = new ArbolBinarioTriaje();

// Los mismos cinco datos de ejemplo de la guía del profesor.
arbolTriaje.Insertar(new Paciente("Carlos Mendoza", "10984512", "Dolor torácico leve", 50));
arbolTriaje.Insertar(new Paciente("Ana Lucía Gómez", "52418963", "Esguince de tobillo", 25));
arbolTriaje.Insertar(new Paciente("Jorge Ramírez", "80147258", "Dificultad respiratoria", 80));
arbolTriaje.Insertar(new Paciente("María Fernanda Ruiz", "10203040", "Fiebre moderada", 15));
arbolTriaje.Insertar(new Paciente("Luis Eduardo Torres", "79456123", "Trauma craneoencefálico", 95));

int opcion;
do
{
    Console.WriteLine("\n==============================================");
    Console.WriteLine(" SISTEMA DE TRIAJE MÉDICO - ÁRBOL BINARIO ");
    Console.WriteLine("==============================================");
    Console.WriteLine("1. Registrar nuevo paciente en el árbol");
    Console.WriteLine("2. Visualizar jerarquía del Árbol Binario");
    Console.WriteLine("3. Listar pacientes ordenados (Recorrido InOrden)");
    Console.WriteLine("4. Consultar paciente más crítico (Extremo Derecho)");
    Console.WriteLine("5. Buscar paciente por puntaje de riesgo");
    Console.WriteLine("6. Respaldar pacientes en un archivo TXT");
    Console.WriteLine("7. Salir");
    Console.Write("Seleccione una opción: ");
    var entrada = Console.ReadLine();
    if (entrada is null) break;
    if (!int.TryParse(entrada, out opcion))
    {
        Console.WriteLine("Debe ingresar una opción numérica.");
        continue;
    }
    Console.WriteLine();
    switch (opcion)
    {
        case 1:
            var nombre = LeerTexto("Nombre del paciente: ");
            var cedula = LeerTexto("Cédula: ");
            var sintoma = LeerTexto("Síntoma principal: ");
            var riesgo = LeerPuntaje("Puntaje de riesgo (1 - 100): ");
            arbolTriaje.Insertar(new Paciente(nombre, cedula, sintoma, riesgo));
            Console.WriteLine("Paciente insertado correctamente en la estructura.");
            break;
        case 2:
            Console.WriteLine("--- ESTRUCTURA JERÁRQUICA DE NODOS ---");
            arbolTriaje.ImprimirEstructura();
            break;
        case 3:
            Console.WriteLine("--- LISTADO ORDENADO POR GRAVEDAD (INORDEN) ---");
            arbolTriaje.MostrarInOrden();
            break;
        case 4:
            var critico = arbolTriaje.ObtenerMasCritico();
            Console.WriteLine(critico is not null ? $"ALERTA MÁXIMA: {critico}" : "No hay pacientes registrados.");
            break;
        case 5:
            var buscar = LeerPuntaje("Ingrese el puntaje de riesgo a buscar (1 - 100): ");
            var encontrado = arbolTriaje.BuscarPorRiesgo(buscar);
            Console.WriteLine(encontrado is not null ? $"Resultado encontrado: {encontrado}" : "No existe un paciente con ese puntaje exacto.");
            break;
        case 6:
            try
            {
                var ruta = arbolTriaje.RespaldarEnTxt(Path.Combine("Respaldos", "pacientes_triaje.txt"));
                Console.WriteLine($"Respaldo TXT creado correctamente: {ruta}");
            }
            catch (IOException error)
            {
                Console.WriteLine($"No se pudo escribir el respaldo: {error.Message}");
            }
            catch (UnauthorizedAccessException error)
            {
                Console.WriteLine($"Sin permisos para guardar: {error.Message}");
            }
            break;
        case 7:
            Console.WriteLine("Hasta luego.");
            break;
        default:
            Console.WriteLine("Opción no válida. Seleccione entre 1 y 7.");
            break;
    }
} while (opcion != 7);

static string LeerTexto(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        var valor = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(valor)) return valor;
        Console.WriteLine("El campo no puede quedar vacío.");
    }
}

static int LeerPuntaje(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out var valor) && valor is >= 1 and <= 100) return valor;
        Console.WriteLine("Ingrese un número entero entre 1 y 100.");
    }
}
