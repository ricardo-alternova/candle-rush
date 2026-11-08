# Candle Rush

Juego de Alternova hecho en Unity 2019.2.11f1. Este documento describe la rama `beta-test` en `3cc0257` y se escribió el 2026-11-08 leyendo los archivos del repositorio, sin abrir Unity ni compilar.

## Qué es

Candle Rush (`productName: CandleRush`, `companyName: Alternova` en `ProjectSettings/ProjectSettings.asset`) es un puzzle 3D de un solo jugador sobre una cuadrícula. El personaje es una vela de cera, "WaxBoy" (`Assets/GJam2020/Models/WaxBoy.fbx`, `Assets/GJam2020/Prefabs/Avatar/WaxBoy.prefab`), que avanza una casilla por paso hasta la bandera de meta y se derrite a medida que camina. El nombre de la carpeta de código (`Assets/GJam2020/`), el espacio de nombres `GGJ2020` y el README anterior (`# GameJam2020`) sugieren que nació en una game jam de 2020; es una deducción por los nombres, no algo que el repositorio documente.

## Cómo se juega

Mecánicas tal como están en el código:

- Cada paso derrite una parte del cuerpo: `AvatarGeneralManager.StartMovement` llama a `BodyDestruction.DestroyBodyPart` (`Assets/GJam2020/Scripts/Avatar/AvatarGeneralManager.cs`, `Assets/GJam2020/Scripts/Avatar/BodyDestruction.cs`). El HUD muestra las partes restantes con `CanvasData.SetNumberOfPieces` (`Assets/GJam2020/Scripts/Level/UI/CanvasData.cs`).
- Sin partes y sin haber ganado, la partida termina: `BodyDestruction.CheckIfGameOver` → `AvatarGeneralManager.Dead()` → menú de game over.
- Las piezas de cera devuelven pasos: `PieceReconstruct` (`Assets/GJam2020/Scripts/Level/PieceReconstruct.cs`, campo `PieceValue`) → `AvatarGeneralManager.CapturePiece` → `BodyDestruction.ReconstructBodyPart`.
- "Step back" deshace el último movimiento y devuelve el paso, mediante una pila de comandos (`Assets/GJam2020/Scripts/Core/Command.cs`, `Assets/GJam2020/Scripts/Core/CommandsManager.cs`).
- Las llaves abren las puertas con el mismo `linkIndex` (`Assets/GJam2020/Scripts/Level/Key.cs`, `Assets/GJam2020/Scripts/Level/Door.cs`).
- Los teletransportadores van en parejas del mismo color (`Assets/GJam2020/Scripts/Level/Teleporter.cs`, `MapGenerator.GetPairPosition` en `Assets/GJam2020/Scripts/ImagesData/MapGenerator.cs`).
- El hielo hace deslizar al jugador (`Assets/GJam2020/Scripts/Level/IceCube.cs`).
- Llegar a la bandera de meta llama a `LevelManager.Win()` (`Assets/GJam2020/Scripts/Core/LevelManager.cs`), que calcula de 1 a 3 estrellas y abre el menú de victoria.

Las casillas posibles son las del enum `MapEntity` (`Assets/GJam2020/Scripts/Level/MapGeneratorSettings.cs`): hole, ground, wall, endFlag, startFlag, extraLife, teleporter, door, key, iceCube. No hay enemigos, contador de vidas ni puntos; el temporizador existe en el código pero no corre (ver "Carencias conocidas").

Controles (`Assets/GJam2020/Scripts/Core/InputSystem.cs`, `Assets/GJam2020/Input/GJam2020.inputactions`): W/A/S/D, gamepad y deslizamiento táctil (EnhancedTouch). El eje vertical se puede invertir desde la pausa (`Assets/GJam2020/Scripts/Level/UI/PauseMenu.cs`, `GameManager.InvertYAxis`).

## Contenido

- **Niveles:** 50 ScriptableObjects `Assets/GJam2020/Config/Level_1.asset` a `Assets/GJam2020/Config/Level_50.asset`, encadenados por `nextLevel` del 1 al 50 (clase `Assets/GJam2020/Scripts/Level/LevelSettings.cs`). `Assets/GJam2020/Config/TestDoor.asset` (number 25, siguiente Level_1) queda fuera de la cadena.
- **Mapas:** 50 CSV, `Assets/Resources/1.csv` a `Assets/Resources/50.csv`. Cada celda es un color en texto "r-g-b" que `MapGenerator` convierte en un prefab según `Assets/Resources/Common_Map.asset`.
- **Diseños fuente:** 50 PNG numerados en `Assets/GJam2020/LevelDesigns/`, más `Assets/GJam2020/LevelDesigns/Deprecated/` y `Assets/GJam2020/LevelDesigns/Other/`. No se comprobó que coincidan con los CSV.
- **Aspecto:** 5 juegos de materiales y cielo (`Assets/GJam2020/Config/ConfigMaterials/`), uno al azar en cada carga de escena (`GameManager.SetRandomSkyMat`).
- **Idiomas:** inglés (por defecto), español y francés con Lean Localization (`Assets/Lean/Localization/`); las frases están dentro de `Assets/GJam2020/Scenes/Gameplay.unity`.
- **Mundos:** solo existen como páginas de 6 niveles en el selector (`Assets/WorldsNavigation.cs`); no son contenido aparte.
- **Paquetes de terceros** (carpetas en `Assets/`): `Assets/Blue Cartoon UI/`, `Assets/Demigiant/` (DOTween), `Assets/Epic Toon FX/`, `Assets/Lean/`, `Assets/Minimalist Free v2.4.2/`, `Assets/TextMesh Pro/`, `Assets/Samples/Input System/1.0.0-preview.5/`.
- **Fuentes y audio propios del juego:** `Assets/GJam2020/Fonts/Candy Beans.otf`, `Assets/GJam2020/Fonts/CFBandofBrothersPERSONAL-Re.ttf`, efectos en `Assets/GJam2020/Sounds/` y `Assets/GJam2020/Sounds/Fx/` (archivos `ES_*.wav`), música en `Assets/GJam2020/Sounds/Music/`.

## Escenas y flujo

Escenas en `Assets/GJam2020/Scenes/`; el build (`ProjectSettings/EditorBuildSettings.asset`) incluye solo dos:

| Escena | En el build | Uso |
| --- | --- | --- |
| `Assets/GJam2020/Scenes/MainMenu.unity` | sí | Logo y botón Play |
| `Assets/GJam2020/Scenes/Gameplay.unity` | sí | Todos los niveles, HUD, pausa, game over, victoria, selector de niveles |
| `Assets/GJam2020/Scenes/LevelsMenu.unity` | no | Selector de niveles antiguo |
| `Assets/GJam2020/Scenes/IntersectionScene.unity` | no | Escena de transición sin uso |
| `Assets/GJam2020/Scenes/MapTransform.unity` | no | Herramienta de editor PNG → CSV |
| `Assets/GJam2020/Scenes/TestMapGenerator.unity` | no | Prueba del generador |

Flujo:

1. MainMenu: Play llama a `MainMenu.LoadScene` (`Assets/GJam2020/Scripts/MainMenu.cs`), que espera 0,4 s y llama a `GameManager.ChargeOrReload()` (`Assets/GJam2020/Scripts/Core/GameManager.cs`), que carga Gameplay en el nivel guardado.
2. Gameplay se recarga para cada nivel; `MapGenerator` construye el mapa en `Start` a partir del CSV del nivel.
3. Victoria: `WinMenu.NextLevel` (`Assets/GJam2020/Scripts/Level/UI/WinMenu.cs`) → `GameManager.NewLevelComplete` guarda y carga el siguiente nivel.
4. Derrota: `GameOverMenu.Restore` (`Assets/GJam2020/Scripts/Level/UI/GameOverMenu.cs`) rebobina todos los movimientos (`CommandsManager.StartRewindCommands`) y reinicia; `GoHome` vuelve a MainMenu.
5. El selector de niveles se abre desde la pausa o el game over (`OpenLevels`) con `Assets/GJam2020/Prefabs/WorldsMenu.prefab` y `Assets/WorldsNavigation.cs`.

`GameManager` vive entre escenas (`DontDestroyOnLoad`).

## Mapa del código

112 archivos C# en `Assets/`; el código propio son unas 7.400 líneas, de las que unas 2.400 son clases de input generadas (`Assets/GJam2020/Scripts/Core/Input/PlayerInputActions.cs`, `Assets/GJam2020/Scripts/Core/Input/UiInput.cs`).

| Carpeta | Contenido |
| --- | --- |
| `Assets/GJam2020/Scripts/Core/` | `GameManager`, `LevelManager`, `InputSystem`, comandos y deshacer, `PlayerPrefsMgr`, sonido (`SoundManager`, `SoundSlider`, `AudioToggle`) |
| `Assets/GJam2020/Scripts/Core/Input/` | Input táctil y de UI, inyección de input por plataforma, clases generadas |
| `Assets/GJam2020/Scripts/Core/Sounds/` | `SoundsMovementManager` |
| `Assets/GJam2020/Scripts/Avatar/` | Movimiento por casillas, derretido y reconstrucción, animación, cámara |
| `Assets/GJam2020/Scripts/Level/` | Objetos del mapa (puerta, llave, teletransportador, hielo, piezas), `LevelSettings`, `MapGeneratorSettings` |
| `Assets/GJam2020/Scripts/Level/UI/` | Menús de pausa, game over, victoria, opciones y HUD |
| `Assets/GJam2020/Scripts/Level/Tutorial/` | Tutorial con variantes teclado, gamepad y táctil |
| `Assets/GJam2020/Scripts/ImagesData/` | `MapGenerator`, `MapTransform` (PNG → CSV), `ReadMapFromCsv` |
| `Assets/GJam2020/Scripts/LevelMenu/` | Botones del selector de niveles |
| `Assets/GJam2020/Scripts/EnvironmetMaterials/` | Materiales aleatorios |
| `Assets/GJam2020/Scripts/Utilities/` | Utilidades de desarrollo: capturas, trucos por clics, menú de escenas del editor |
| `Assets/GJam2020/Scripts/Editor/` | La única prueba: `Assets/GJam2020/Scripts/Editor/TestingPortals.cs` |

Fuera de esa carpeta: `Assets/GJam2020/Scripts/MainMenu.cs` y otros tres scripts sueltos en `Assets/GJam2020/Scripts/`, y dos en la raíz de `Assets/`: `Assets/FocusDefect.cs` (mantiene el foco de la UI con gamepad y tvOS) y `Assets/WorldsNavigation.cs`.

## Datos guardados

Todo va en `PlayerPrefs`, sin versión de formato:

- `Gamedata`: XML de la clase `GameData` (`Assets/GJam2020/Scripts/Core/GameManager.cs`) con `levelsScore`, `lastLevelUnLock` y `currentLevel`.
- `yAxis`: "true"/"false", eje vertical invertido.
- `tutorial`: entero, si el tutorial ya se mostró (`Assets/GJam2020/Scripts/Level/Tutorial/TutorialController.cs` vía `PlayerPrefsMgr`).

## Plataformas y entrada

De `ProjectSettings/ProjectSettings.asset`:

- **Android:** `com.alternova.candlerush_pixtel`, version code 6, SDK mínimo 17, IL2CPP. El ajuste `AndroidKeystoreName` apunta a `'{inproject}: Builds/user.keystore'`; ese archivo no está en el repositorio (`Builds` está en `.gitignore`).
- **iOS:** `com.alternova.candlerush`, build 4, iOS 9.1 mínimo.
- **tvOS:** tvOS 9.0 mínimo, ramas `#if UNITY_TVOS` en `Assets/GJam2020/Scripts/Core/InputSystem.cs`, iconos en `10bee8d`.
- **WebGL:** ajustes `webGL*` y ramas `#if UNITY_WEBGL` en el código.
- Versión `bundleVersion: 0.37`; etiquetas git de `v0.2` a `v0.33` (17 en total).
- Unity Analytics activado (`ProjectSettings/UnityConnectSettings.asset`).

Entrada: están activos a la vez el Input System nuevo (`com.unity.inputsystem` 1.0.0) y el input manager antiguo (`enableNativePlatformBackendsForNewInputSystem: 1`, `disableOldInputManagerSupport: 0`), y el código usa ambos.

El repositorio no contiene evidencia de que el juego se haya publicado en ninguna tienda.

## Cómo abrir el proyecto

- Editor: Unity 2019.2.11f1 (`ProjectSettings/ProjectVersion.txt`).
- Paquetes (`Packages/manifest.json`): Input System 1.0.0, Cinemachine 2.6.0-preview.8, Lightweight RP 6.9.2, TextMesh Pro 2.0.1, Timeline 1.1.0, Test Framework 1.0.13. `ProjectSettings/GraphicsSettings.asset` no asigna pipeline personalizado aunque existe `Assets/GJam2020/LightweightRenderPipelineAsset.asset`.
- Escenas del build, en orden: `Assets/GJam2020/Scenes/MainMenu.unity` y `Assets/GJam2020/Scenes/Gameplay.unity`. Para jugar desde el editor, abrir MainMenu y pulsar Play.

Este procedimiento se leyó de los ajustes del proyecto; para este documento no se abrió Unity ni se compiló nada, así que no está comprobado que el proyecto abra o compile.

## Estado del proyecto

- **Historia:** 375 commits entre 2020-02-01 y 2020-11-20. Autores con más commits, como aparecen en `git log`: Julio, Esteban Ramos, Julio Cesar, Alejandro Diaz, HaroldSati, SergioPenal7.
- **Últimos commits relevantes:**
  - `3cc0257` (2020-11-20) cambia la fuente a Candy Beans.
  - `d287379` (2020-11-19) ajusta la localización para seguir el idioma del dispositivo.
  - `c76df7f` (2020-11-11) recupera el input de tvOS.
  - `d446d5b` (2020-11-07) carga los mapas desde `Assets/Resources/`.
  - `74f93c6` (2020-11-06) añade francés.
  - `a8b586e` (2020-11-04) quita el toggle de invertir eje de `Assets/GJam2020/Scenes/Gameplay.unity`.
  - `e7c176a` (2020-11-04) cambia cómo se leen los mapas.
  - `aa5812e` (2020-10-28) controles por plataforma.
- **Ramas:** `beta-test` va 364 commits por delante de `origin/master`; `origin/master` tiene un commit que `beta-test` no tiene, `84fb701` (licencia MIT). `origin/dev` va 52 commits por detrás de `beta-test` y no aporta nada propio. Hay además 23 ramas `origin/feature/*`, `origin/features/door-mechanic`, `origin/ControlMappingTest` y `origin/tvios-settings`.

## Carencias conocidas

Hechos encontrados al leer el código, sin propuesta de solución:

- **Estrellas siempre 3:** `timePlaying` se declara en 0 y nunca cambia (`Assets/GJam2020/Scripts/Core/LevelManager.cs:26` y `:49`). Solo `Assets/GJam2020/Config/Level_1.asset` tiene umbrales (17 y 25 s); el resto tiene `maxTime3Stars: 0`, y `GetStarts(0)` devuelve 3 (`Assets/GJam2020/Scripts/Level/LevelSettings.cs:26`).
- **Argumento ignorado:** `MainMenu.LoadScene` no usa su parámetro; el botón le pasa `LevelsMenu` (`Assets/GJam2020/Scenes/MainMenu.unity:926`).
- **Lector inutilizable en build:** `Assets/GJam2020/Scripts/ImagesData/ReadMapFromCsv.cs` lee `Assets/Resources/24.csv` con `File.ReadAllText`, que no existe en un build; solo lo usa `Assets/GJam2020/Scenes/MapTransform.unity`.
- **Menús duplicados:** `Assets/GJam2020/Prefabs/UI/Menus/PauseMenu.prefab` y `Assets/GJam2020/Prefabs/UI/Menus/GameOverMenu.prefab` no se usan en ninguna escena; Gameplay usa sus copias `_2`. `Assets/GJam2020/Prefabs/UI/Menus/PauseMenu_2.prefab` sigue mostrando "Invert vertical joystick" después de `a8b586e`.
- **Textos sin traducir:** "Home" (`Assets/GJam2020/Prefabs/UI/Menus/WinMenu.prefab`, `Assets/GJam2020/Prefabs/UI/Menus/GameOverMenu_2.prefab`), "Options" (`Assets/GJam2020/Prefabs/UI/Menus/OptionsMenu.prefab`); "Recuperaste un paso" fijo en español en `Assets/GJam2020/Prefabs/UI/Menus/Tutorial_Keyboard.prefab`, `Assets/GJam2020/Prefabs/UI/Menus/Tutorial_touch.prefab` y `Assets/GJam2020/Prefabs/UI/Menus/TutorialJoystick.prefab`. MainMenu no tiene frases localizadas. `SaveLanguage: 0` en Gameplay: el idioma elegido no se guarda.
- **Licencias de recursos:** no hay archivo de licencia ni créditos para las fuentes ni para los efectos `ES_*.wav` y la música.
- **Pruebas:** una sola, `Assets/GJam2020/Scripts/Editor/TestingPortals.cs` (comprueba que los colores de teletransportador vayan en pares en los PNG); no hay configuración de CI.
- **Código muerto:** bloque `HandleInput` comentado en `Assets/GJam2020/Scripts/Core/InputSystem.cs:253–295`; `OptionsMenu.EnableSound` cambia un booleano que nada lee (`Assets/GJam2020/Scripts/Level/UI/OptionsMenu.cs:32`).
- **Escenas y datos sin uso:** cuatro escenas fuera del build (tabla de arriba) y `Assets/GJam2020/Config/TestDoor.asset`.
- **Errata en carpeta:** `Assets/GJam2020/Scripts/EnvironmetMaterials/`.

## Licencia

MIT, añadida en `master` con `84fb701` (2026-11-08); todavía no está en `beta-test`. Los paquetes y recursos de terceros conservan sus propias condiciones, que el repositorio no registra.

## Mejoras

Las mejoras propuestas a partir de este estado están en `docs/MEJORAS.md`.
