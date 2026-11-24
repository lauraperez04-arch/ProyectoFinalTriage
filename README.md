# Proyecto final — Sistema de triaje médico con árbol binario

**Asignatura:** Estructuras de datos  
**Lenguajes:** C# (.NET 10) y Java (JDK 21)  
**Editor:** Visual Studio Code (Windows)

## Objetivo

Implementar un árbol binario de búsqueda (BST) para almacenar pacientes por puntaje de riesgo (1 a 100), utilizando programación orientada a objetos. Reproducir el mismo caso en C# y Java, y añadir un respaldo en archivo TXT.

> **Importante:** Es un ejercicio académico de estructuras de datos, no una herramienta apta para decidir prioridades médicas reales.

## Requisitos previos

- Windows 10/11.
- Visual Studio Code (extensiones C# Dev Kit y Extension Pack for Java).
- .NET SDK **10** (`dotnet --version`).
- JDK **21** (`java -version` y `javac -version`).

## Abrir el proyecto

1. Descomprime el ZIP en una carpeta local.
2. En VS Code usa **Archivo > Abrir carpeta** y selecciona `ProyectoFinalTriaje`.
3. Abre una nueva terminal: **Terminal > Nueva terminal**.

### Ejecutar C#

En la terminal PowerShell, desde la carpeta raíz:

```powershell
cd CSharp\TriajeBinarioApp
dotnet run
```

También puedes hacer doble clic en `CSharp\ejecutar-windows.bat`.

### Ejecutar Java

En la terminal PowerShell, desde la carpeta raíz:

```powershell
cd Java
mkdir out
javac -encoding UTF-8 -d out src\triaje\*.java
java -Dfile.encoding=UTF-8 -cp out triaje.Main
```

Si la carpeta `out` ya existe, no hace falta crearla de nuevo. También puedes hacer doble clic en `Java\ejecutar-windows.bat`.

### Ejecutar pruebas de Java

Desde la carpeta `Java`:

```powershell
javac -encoding UTF-8 -d out src\triaje\*.java
java -Dfile.encoding=UTF-8 -cp out triaje.PruebasArbol
```

O ejecuta `Java\probar-windows.bat`.

## Menú del sistema

1. Registrar nuevo paciente.
2. Visualizar jerarquía del árbol.
3. Listar pacientes con recorrido InOrden.
4. Consultar al paciente con mayor riesgo.
5. Buscar paciente por puntaje.
6. **Respaldar pacientes en un TXT** (opción añadida para la entrega).
7. Salir.

Las versiones C# y Java incluyen los cinco pacientes iniciales de la guía. El respaldo se guarda en `Respaldos\pacientes_triaje.txt`, dentro del directorio desde el cual se ejecuta cada aplicación. **No importa un respaldo al iniciar** y los datos añadidos durante una ejecución solo permanecen en memoria hasta cerrar la aplicación. El TXT sirve como reporte de respaldo, no como una base de datos persistente.

## Reglas de inserción

- El primer paciente es la raíz.
- Puntaje **menor** que el nodo: izquierda.
- Puntaje **mayor o igual**: derecha.
- InOrden: izquierda, raíz, derecha => puntajes no decrecientes.
- Paciente más crítico: nodo extremo derecho.
- Si existen pacientes con puntaje idéntico, la búsqueda retorna el primero encontrado en el camino de búsqueda y la opción de máximo retorna el del extremo derecho.
- Se valida que el puntaje esté entre 1 y 100.

## Complejidad

La inserción y búsqueda cuestan O(h), donde h es la altura del árbol: O(log n) **en árboles equilibrados** y O(n) en el peor caso de un BST no equilibrado. El recorrido InOrden cuesta O(n).

## Estructura

```text
ProyectoFinalTriaje/
├── CSharp/
│   ├── ejecutar-windows.bat
│   └── TriajeBinarioApp/
│       ├── Clases/
│       │   ├── Paciente.cs
│       │   ├── NodoArbol.cs
│       │   └── ArbolBinarioTriaje.cs
│       ├── Program.cs
│       └── TriajeBinarioApp.csproj
├── Java/
│   ├── src/triaje/
│   │   ├── Paciente.java
│   │   ├── NodoArbol.java
│   │   ├── ArbolBinarioTriaje.java
│   │   ├── Main.java
│   │   └── PruebasArbol.java
│   ├── ejecutar-windows.bat
│   └── probar-windows.bat
├── Documentacion/
│   ├── Requerimientos.md
│   ├── Backlog.md
│   └── GuionPresentacion.md
├── Pruebas/
│   └── CasosDePrueba.md
├── .vscode/extensions.json
└── README.md
```

## GitHub

El ZIP **no publica automáticamente** un repositorio ni crea tareas reales en GitHub. En `Documentacion/Backlog.md` tienes un backlog propuesto para convertir en Issues o tablero Project. Para publicar, crea un repositorio nuevo, sube estos archivos y organiza las tareas del backlog. Añade el enlace del repositorio a tu presentación.

## Entrega final

En la presentación explica: ecosistema .NET, funciones de las clases, reglas del BST, recorrido, búsqueda, máximo, nuevo respaldo TXT, equivalencia con Java, capturas de pruebas, GitHub y backlog. Incluye una demostración de cada programa.

**Nota:** El proyecto está preparado con código fuente editable. Se recomienda ejecutar y validar ambos programas en tu propio Windows antes de entregarlos.
