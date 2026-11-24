# Plan de pruebas manuales (C# y Java)

Realiza cada caso en ambos lenguajes y guarda una captura cuando corresponda.

| Caso | Acción | Resultado esperado |
|---|---|---|
| CP-01 | Seleccionar 2 con datos iniciales | Raíz 50; rama izquierda 25→15 y derecha 80→95. |
| CP-02 | Seleccionar 3 | Puntajes 15, 25, 50, 80, 95. |
| CP-03 | Seleccionar 4 | Paciente Luis Eduardo Torres, riesgo 95. |
| CP-04 | Seleccionar 5 y buscar 25 | Encuentra Ana Lucía Gómez. |
| CP-05 | Seleccionar 5 y buscar 99 | No existe coincidencia. |
| CP-06 | Seleccionar 1 e ingresar un paciente con riesgo 50 | Se inserta en la rama derecha al comparar con la raíz 50. |
| CP-07 | Seleccionar 1 e ingresar riesgo 101, luego 60 | Rechaza 101 y acepta 60. |
| CP-08 | Seleccionar 6 | Crea `Respaldos/pacientes_triaje.txt` en UTF-8. |
| CP-09 | Abrir TXT y verificar líneas | Aparecen todos los pacientes ordenados por puntaje. |
| CP-10 | Seleccionar 7 | Termina la ejecución. |
| CP-11 | Escribir texto en el menú | Muestra error sin cerrarse. |

## Prueba automatizada disponible

`Java/src/triaje/PruebasArbol.java` contiene verificaciones de árbol vacío, cantidad, InOrden, búsqueda, máximo, rango y TXT. Ejecutar `Java/probar-windows.bat`.

## Evidencias

- Captura 1: versión .NET con menú.
- Captura 2: versión .NET con jerarquía.
- Captura 3: versión .NET con respaldo TXT.
- Captura 4: versión Java con menú.
- Captura 5: versión Java con listado y búsqueda.
- Captura 6: consola de pruebas Java.
- Captura 7: repositorio y tablero real en GitHub.

**Estado:** Los casos de esta tabla están pendientes de validación manual en Windows; no marques pruebas como aprobadas hasta ejecutarlas.
