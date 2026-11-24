# Análisis de requerimientos

## Contexto del problema

Una clínica de urgencias desea representar pacientes según puntajes de riesgo clínico entre 1 y 100. Con fines académicos se usa un árbol binario de búsqueda en memoria. Las aplicaciones de consola se construyen con clases: Paciente, NodoArbol, ArbolBinarioTriaje y el punto de entrada.

## Requerimientos funcionales

| Código | Requerimiento | Criterio de aceptación |
|---|---|---|
| RF-01 | Registrar pacientes | Al ingresar datos válidos, se inserta un nodo. |
| RF-02 | Respetar jerarquía BST | Menores a la izquierda y mayores o iguales a la derecha. |
| RF-03 | Visualizar árbol | Se imprime la jerarquía en consola. |
| RF-04 | Listar InOrden | Se listan los puntajes de menor a mayor. |
| RF-05 | Consultar riesgo máximo | Se devuelve el paciente del extremo derecho. |
| RF-06 | Buscar por puntaje | Se informa si existe un paciente con el puntaje solicitado. |
| RF-07 | Respaldar en TXT | Se genera un archivo de texto con la lista InOrden. |
| RF-08 | Terminar la ejecución | Una opción permite salir del menú. |
| RF-09 | Migrar a Java | Existe una versión Java con las mismas operaciones. |

## Requerimientos no funcionales (propuestos)

| Código | Requerimiento | Verificación |
|---|---|---|
| RNF-01 | Compatibilidad de desarrollo | Ejecutable en Windows con .NET SDK 10 y JDK 21. |
| RNF-02 | Separación de responsabilidades | Clases de entidad, nodo, árbol y ejecución. |
| RNF-03 | Manejo de entradas inválidas | El menú y el puntaje rechazan entradas incorrectas. |
| RNF-04 | Portabilidad del código | Código fuente Java y C# incluido en el repositorio. |
| RNF-05 | Codificación de salida | Los TXT se generan en UTF-8. |
| RNF-06 | Sin base de datos | Datos en memoria; respaldo TXT bajo demanda. |

## Reglas de dominio

- RD-01: El puntaje es un número entero entre 1 y 100.
- RD-02: El primer paciente insertado se convierte en raíz.
- RD-03: Si el nuevo puntaje es menor, se inserta en el subárbol izquierdo.
- RD-04: Si el nuevo puntaje es mayor **o igual**, se inserta en el subárbol derecho.
- RD-05: El recorrido InOrden devuelve los pacientes en orden ascendente de puntaje.
- RD-06: El nodo más a la derecha contiene uno de los puntajes máximos.
- RD-07: En la búsqueda de puntajes repetidos se retorna la primera coincidencia encontrada.

## Alcance y límites

Se trata de un prototipo académico; no se usan protocolos médicos, historiales clínicos reales, autenticación ni persistencia transaccional. El respaldo TXT no permite restauración automática. La categorización de riesgo no debe interpretarse como una recomendación sanitaria real.
