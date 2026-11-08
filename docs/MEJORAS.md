# Mejoras propuestas para Candle Rush

Propuestas sobre la rama `beta-test` en `3cc0257`, cada una a partir de un hecho descrito en el `README.md` y comprobado en el repositorio. El tamaño es la única estimación de esfuerzo; el orden dentro de cada grupo no es una prioridad.

## Errores y código muerto

### Las estrellas siempre son 3

**Evidencia:** `Assets/GJam2020/Scripts/Core/LevelManager.cs:26` declara `timePlaying=0f` y `:49` lo pasa a `GetStarts` sin haberlo cambiado; `Assets/GJam2020/Scripts/Level/LevelSettings.cs:26` devuelve 3 si `time <= maxTime3Stars`.

**Cambio:** acumular el tiempo de juego del nivel en `LevelManager` (sin contar la pausa) y pasarlo a `GetStarts`.

**Por qué:** hoy la puntuación por estrellas no mide nada; con tiempo 0 cualquier umbral da 3 estrellas.

**Tamaño:** pequeño

### `MainMenu.LoadScene` ignora su argumento

**Evidencia:** `Assets/GJam2020/Scripts/MainMenu.cs` no usa `sceneName`; el botón Play le pasa `LevelsMenu` (`Assets/GJam2020/Scenes/MainMenu.unity:926`).

**Cambio:** quitar el parámetro (y el argumento del botón) o usarlo de verdad; borrar la línea comentada `SceneManager.LoadScene` y el `Start` vacío.

**Por qué:** quien lee el botón cree que abre `LevelsMenu`, una escena que ni está en el build.

**Tamaño:** pequeño

### `ReadMapFromCsv` lee archivos que no existen en un build

**Evidencia:** `Assets/GJam2020/Scripts/ImagesData/ReadMapFromCsv.cs:16` usa `File.ReadAllText` sobre `Assets/Resources/{0}.csv` y en `Start` lee siempre el mapa 24; solo lo usa `Assets/GJam2020/Scenes/MapTransform.unity`. `MapGenerator.GetColorFromCsv` (`Assets/GJam2020/Scripts/ImagesData/MapGenerator.cs:38`) ya hace lo mismo con `Resources.Load`.

**Cambio:** borrar `Assets/GJam2020/Scripts/ImagesData/ReadMapFromCsv.cs` y su componente en `Assets/GJam2020/Scenes/MapTransform.unity`, o moverlo a `Assets/GJam2020/Scripts/Editor/` si la herramienta lo necesita.

**Por qué:** es una copia del lector real que solo funciona en el editor y confunde sobre cuál es el que usa el juego.

**Tamaño:** pequeño

### Menús de pausa y game over duplicados

**Evidencia:** `Assets/GJam2020/Prefabs/UI/Menus/PauseMenu.prefab` y `Assets/GJam2020/Prefabs/UI/Menus/GameOverMenu.prefab` no aparecen en ninguna escena ni prefab; `Assets/GJam2020/Scenes/Gameplay.unity` usa `PauseMenu_2` y `GameOverMenu_2`.

**Cambio:** borrar los dos prefabs sin uso y, si se quiere, quitar el sufijo `_2` a los que quedan.

**Por qué:** dos versiones de cada menú invitan a corregir la equivocada.

**Tamaño:** pequeño

### Restos del toggle de invertir eje

**Evidencia:** `a8b586e` solo desactiva el objeto en `Assets/GJam2020/Scenes/Gameplay.unity`; `Assets/GJam2020/Prefabs/UI/Menus/PauseMenu_2.prefab:769` sigue teniendo `InvertVertical`, y `Assets/GJam2020/Scripts/Core/GameManager.cs:60` sigue leyendo la clave `yAxis`, que `Assets/GJam2020/Scripts/Core/InputSystem.cs:216` aplica al movimiento vertical.

**Cambio:** decidir entre dos opciones: quitar el objeto, `PauseMenu.invertYAxis`, `GameManager.InvertYAxis` y la clave `yAxis`; o volver a mostrar la opción (localizada) en la pausa.

**Por qué:** un jugador que activó la opción antes de `a8b586e` sigue con el eje invertido y ya no puede cambiarlo.

**Tamaño:** pequeño

### Bloque `HandleInput` comentado

**Evidencia:** `Assets/GJam2020/Scripts/Core/InputSystem.cs:253–292`.

**Cambio:** borrar el bloque; el historial de git lo conserva.

**Por qué:** cuarenta líneas comentadas que hay que saltar al leer `InputSystem`.

**Tamaño:** pequeño

### `OptionsMenu.EnableSound` no tiene efecto

**Evidencia:** `Assets/GJam2020/Scripts/Level/UI/OptionsMenu.cs:32` alterna `_soundEnable`, que nada más lee.

**Cambio:** borrar el método y el campo, o conectarlo a `SoundManager` si el botón debe silenciar.

**Por qué:** un control que no hace nada.

**Tamaño:** pequeño

### Escenas y datos sin uso

**Evidencia:** `ProjectSettings/EditorBuildSettings.asset` solo incluye MainMenu y Gameplay; `Assets/GJam2020/Scenes/LevelsMenu.unity`, `Assets/GJam2020/Scenes/IntersectionScene.unity` y `Assets/GJam2020/Scenes/TestMapGenerator.unity` quedan fuera, y `Assets/GJam2020/Config/TestDoor.asset` no está referenciado por ningún asset.

**Cambio:** borrar las tres escenas y `Assets/GJam2020/Config/TestDoor.asset`. `Assets/GJam2020/Scenes/MapTransform.unity` se conserva porque es la herramienta PNG → CSV.

**Por qué:** menos sitios donde buscar al retomar el proyecto.

**Tamaño:** pequeño

## Jugabilidad y contenido

### Textos sin traducir y idioma sin guardar

**Evidencia:** "Home" en `Assets/GJam2020/Prefabs/UI/Menus/WinMenu.prefab:79` y `Assets/GJam2020/Prefabs/UI/Menus/GameOverMenu_2.prefab:1399`; "Options" en `Assets/GJam2020/Prefabs/UI/Menus/OptionsMenu.prefab:387`; "Recuperaste un paso" en `Assets/GJam2020/Prefabs/UI/Menus/Tutorial_Keyboard.prefab`, `Assets/GJam2020/Prefabs/UI/Menus/Tutorial_touch.prefab` y `Assets/GJam2020/Prefabs/UI/Menus/TutorialJoystick.prefab`; `Assets/GJam2020/Scenes/MainMenu.unity` no usa Lean Localization; `SaveLanguage: 0` en `Assets/GJam2020/Scenes/Gameplay.unity:1841`.

**Cambio:** pasar esos textos a frases de Lean en inglés, español y francés, localizar MainMenu y activar `SaveLanguage`.

**Por qué:** un jugador en francés ve hoy botones en inglés y una frase del tutorial en español.

**Tamaño:** mediano

### Umbrales de estrellas para los niveles 2 a 50

**Evidencia:** solo `Assets/GJam2020/Config/Level_1.asset` tiene umbrales (`maxTime3Stars: 17`, `maxTime2Stars: 25`); los otros 49 tienen `maxTime3Stars: 0`.

**Cambio:** una vez corregido `timePlaying`, jugar cada nivel y fijar sus dos umbrales.

**Por qué:** sin umbrales, arreglar el tiempo deja cualquier nivel a partir del 2 en 1 estrella.

**Tamaño:** mediano

### Qué pasa después del nivel 50

**Evidencia:** `Assets/GJam2020/Config/Level_50.asset` tiene `nextLevel: {fileID: 0}` y `WinMenu.NextLevel` (`Assets/GJam2020/Scripts/Level/UI/WinMenu.cs:21–22`) vuelve entonces a MainMenu.

**Cambio:** mostrar un cierre al terminar el último nivel (mensaje y total de estrellas) en lugar de volver al menú sin más.

**Por qué:** hoy el final del juego no se distingue de salir al menú.

**Tamaño:** pequeño

### Reconciliar los diseños PNG con los CSV

**Evidencia:** 50 PNG en `Assets/GJam2020/LevelDesigns/`, 22 en `Assets/GJam2020/LevelDesigns/Deprecated/` y 2 en `Assets/GJam2020/LevelDesigns/Other/`, frente a 50 CSV en `Assets/Resources/`; nada comprueba que coincidan.

**Cambio:** regenerar los CSV desde los PNG con `Assets/GJam2020/Scenes/MapTransform.unity`, comparar, y dejar una sola fuente de verdad; borrar `Assets/GJam2020/LevelDesigns/Deprecated/` si nada lo usa.

**Por qué:** hoy no se sabe si el PNG o el CSV es el diseño vigente de un nivel.

**Tamaño:** mediano

### Un formato de mapa validado

**Evidencia:** las celdas son texto "r-g-b" que `Assets/GJam2020/Scripts/ImagesData/MapGenerator.cs:60` lee con `float.Parse` sin cultura fija; 28 CSV tienen valores decimales como `0.3137255`, y un error de lectura solo deja un `Debug.Log` en el bloque `catch` del mismo método.

**Cambio:** usar identificadores de casilla en lugar de colores (o al menos `CultureInfo.InvariantCulture`) y validar cada mapa en una prueba de editor: tamaño, una salida, una meta, teletransportadores en pares, llaves con su puerta.

**Por qué:** el resultado de `float.Parse` depende de la cultura del dispositivo, y un mapa roto hoy se carga en silencio.

**Tamaño:** mediano

## Salud del proyecto

### Pruebas y CI

**Evidencia:** la única prueba es `Assets/GJam2020/Scripts/Editor/TestingPortals.cs`; el repositorio no tiene archivo de CI.

**Cambio:** añadir pruebas de editor para guardar y cargar `GameData`, `LevelSettings.GetStarts` y la cadena de 50 niveles (de `Level_1` a `Level_50`, sin ciclos), y un trabajo de CI que las ejecute en modo batch con la versión de Unity del proyecto.

**Por qué:** los errores de este documento (estrellas, mapas) habrían saltado con pruebas así.

**Tamaño:** mediano

### Licencias de fuentes y audio

**Evidencia:** `Assets/GJam2020/Fonts/CFBandofBrothersPERSONAL-Re.ttf`, `Assets/GJam2020/Fonts/Candy Beans.otf`, los efectos `ES_*.wav` de `Assets/GJam2020/Sounds/` y la música de `Assets/GJam2020/Sounds/Music/` no tienen licencia ni créditos en el repositorio.

**Cambio:** confirmar la licencia de cada recurso y registrarla en un archivo `CREDITS` o `THIRD_PARTY`; reemplazar lo que no pueda usarse comercialmente.

**Por qué:** el nombre de la fuente termina en "PERSONAL", lo que sugiere una licencia de uso personal; sin registro no se puede publicar con seguridad.

**Tamaño:** mediano

### Unificar `master` y `beta-test` y limpiar ramas

**Evidencia:** `beta-test` va 364 commits por delante de `origin/master`, que solo tiene `84fb701` (licencia MIT) que `beta-test` no tiene; `origin/dev` no aporta nada propio; hay 23 ramas `origin/feature/*` y otras tres sueltas.

**Cambio:** fusionar `beta-test` en `master` (trae la licencia y fija `master` como tronco), y borrar `origin/dev` y las ramas ya fusionadas tras revisar cada una.

**Por qué:** hoy la rama por defecto del remoto tiene la licencia pero no el juego.

**Tamaño:** pequeño

### Actualizar Unity y los paquetes

**Evidencia:** `ProjectSettings/ProjectVersion.txt` (2019.2.11f1); `Packages/manifest.json` con Input System 1.0.0, Cinemachine 2.6.0-preview.8 y Lightweight RP 6.9.2; `ProjectSettings/ProjectSettings.asset:780–781` deja activos el input nuevo y el antiguo.

**Cambio:** pasar a una versión LTS actual, Lightweight RP a URP, y Cinemachine e Input System a versiones estables, en una rama propia.

**Por qué:** el editor y un paquete preview fijan el proyecto en herramientas antiguas. Riesgo: dos sistemas de input a la vez, un paquete preview, cuatro plataformas con `#if` propios y ningún build comprobado aquí; hace falta probar en Android, iOS, tvOS y WebGL antes de darlo por bueno.

**Tamaño:** grande

### Paquetes y módulos que sobran

**Evidencia:** `Packages/manifest.json` incluye `com.unity.collab-proxy` 1.2.16 y 31 módulos `com.unity.modules.*`.

**Cambio:** quitar `collab-proxy` y los módulos que el juego no use (candidatos: `com.unity.modules.vehicles`, `com.unity.modules.terrain`, `com.unity.modules.vr`), comprobando antes que nada los referencia.

**Por qué:** menos dependencias que revisar en la actualización de Unity.

**Tamaño:** pequeño

### Datos guardados con versión

**Evidencia:** `GameManager.LoadGameData` (`Assets/GJam2020/Scripts/Core/GameManager.cs:215`) deserializa la clave `Gamedata` sin campo de versión y sin capturar errores.

**Cambio:** añadir un número de versión a `GameData`, una migración por versión y un valor por defecto si el XML no se puede leer.

**Por qué:** cualquier cambio en `GameData` o un valor corrupto deja al jugador sin poder cargar.

**Tamaño:** pequeño

### Escenas por nombre y cadenas de `#if`

**Evidencia:** `GameManager.MAIN_MENU_NAME` y `GAMEPLAY_NAME` son cadenas (`Assets/GJam2020/Scripts/Core/GameManager.cs:33` y `:35`); `Assets/GJam2020/Scripts/Core/InputSystem.cs` tiene ramas `UNITY_WEBGL`, `UNITY_IOS` y `UNITY_ANDROID`, y `Assets/GJam2020/Scripts/Core/Input/UIInputInjecter.cs` siete bloques `UNITY_TVOS`.

**Cambio:** convertir los nombres en constantes comprobadas contra la lista del build, y mover el input de cada plataforma a una implementación de `IInput` (`Assets/GJam2020/Scripts/Core/Input/IInput.cs`) elegida en un solo sitio.

**Por qué:** hoy un cambio de input para una plataforma obliga a leer y compilar mentalmente las otras tres.

**Tamaño:** mediano

### Errata en el nombre de una carpeta

**Evidencia:** `Assets/GJam2020/Scripts/EnvironmetMaterials/`.

**Cambio:** renombrarla a `EnvironmentMaterials` desde el editor (o moviendo también su `.meta`).

**Por qué:** se busca por el nombre correcto y no aparece.

**Tamaño:** pequeño

## Documentación

### Mantener al día el estado del README

**Evidencia:** la sección "Estado del proyecto" de `README.md` describe `3cc0257`.

**Cambio:** actualizar esa sección y "Carencias conocidas" con cada versión (`bundleVersion` en `ProjectSettings/ProjectSettings.asset`) y quitar de las carencias lo que se corrija.

**Por qué:** un README que describe otro commit vuelve a ser inútil.

**Tamaño:** pequeño

### Nota de build por plataforma

**Evidencia:** `ProjectSettings/ProjectSettings.asset` tiene ajustes de Android, iOS, tvOS y WebGL, y el archivo de firma de Android apunta a la carpeta Builds, que está en `.gitignore`; no hay instrucciones de build.

**Cambio:** cuando alguien haga un build real de una plataforma, escribir en `docs/` los pasos, la versión de herramientas usada y dónde se guarda la firma (sin incluirla).

**Por qué:** hoy nadie puede reproducir un build a partir del repositorio.

**Tamaño:** pequeño

### Registrar si el juego se publicó

**Evidencia:** `README.md` dice que el repositorio no contiene evidencia de publicación en ninguna tienda, aunque hay identificadores de Android e iOS en `ProjectSettings/ProjectSettings.asset`.

**Cambio:** que quien lo sepa anote en el README si el juego está o estuvo en alguna tienda y con qué versión.

**Por qué:** decide si una actualización debe respetar datos guardados y fichas de tienda existentes.

**Tamaño:** pequeño
