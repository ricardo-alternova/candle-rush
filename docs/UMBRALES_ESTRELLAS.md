# Umbrales de estrellas — niveles 2 a 50

> **Valores estimados.** No provienen de partidas cronometradas en Unity, sino de un estimador analítico calibrado con el nivel 1. Conviene ajustarlos tras probarlos en juego.

## Método

1. **Lectura del mapa.** Cada nivel usa `Assets/Resources/<N>.csv`, donde cada celda es un color `r-g-b`. El color se traduce a entidad con `Assets/Resources/Common_Map.asset` (suelo, agujero, muro, bandera de inicio y de meta, vida extra, teletransportador, puerta, llave, cubo de hielo).
2. **Camino más corto.** Búsqueda en anchura (BFS) desde la bandera de inicio hasta la de meta, con pasos de una casilla en las cuatro direcciones, igual que `PlayerMovement`. No se puede pisar ninguna celda marcada como obstáculo (agujero, muro, puerta).
   - Aproximaciones generales (los puntos siguientes las precisan por rango): los teletransportadores se emparejan por color, como en el juego; una puerta se puede cruzar en cuanto se tiene la llave, sin modelar la animación de la llave hasta la cerradura (ver «Animación de la llave»); el deslizamiento sobre hielo se modela desde el nivel 26. Los niveles 2 a 10 solo tienen suelo, inicio, meta y vidas extra, así que estas aproximaciones no influyen en ellos. Los niveles 11 a 20 tienen además un par de teletransportadores (en el juego se emparejan por color y todos son del mismo color, así que el emparejamiento es inequívoco). Como en el juego (`Teleporter.OnTriggerEnter` → `PlayerMovement.UpdateMovementPosition`), el paso que entra en el teletransportador termina una casilla más allá de su pareja, en la dirección de entrada; ese paso cuenta como uno solo. Los 0,5 s de `AvatarPosition.Teleporter()` son solo el tiempo antes de poder volver a teletransportarse, no una pausa, así que no suman tiempo a un camino que lo cruza una vez y no se modelan.
   - Niveles 21 a 30: los niveles 23, 24 y 25 tienen dos pares de teletransportadores de distinto color (el cian de `Common_Map` y `0.3137255-1-1`, que no está en `Common_Map`; el juego lo trata como teletransportador), y los niveles 28 y 30 usan solo este segundo color. Como en el juego, los teletransportadores se emparejan **por color** (`MapGenerator.PairPositions[color]`). Los niveles 26 a 30 tienen cubos de hielo, y el deslizamiento **sí** se modela: al entrar en una celda de hielo, el jugador avanza una casilla más en la misma dirección si no es un obstáculo (se encadena sobre hielo seguido), con medio paso de tiempo extra (`IceCube` → `SetNewFinalPosition`). Por eso la columna «Pasos» de esos niveles es un equivalente en tiempo y puede tener medios pasos. Con estos dos cambios los niveles 1 a 20 dan exactamente los mismos resultados. Estos niveles también usan la regla de la casilla de salida del punto siguiente; sin ella, los niveles 21, 23, 24, 25, 28, 29 y 30 tenían umbrales más holgados de lo previsto (el 23, con 13 pasos en lugar de 11).
   - Salida del teletransportador (todos los niveles con teletransportador, 11 a 50): al cruzar un teletransportador el jugador **no queda sobre el teletransportador de salida, sino una casilla más allá**, en la dirección en que entró y dentro del mismo paso (`Teleporter` → `PlayerMovement.UpdateMovementPosition`: posición final = par + dirección). Si esa casilla es un obstáculo o queda fuera del mapa, el estimador no usa ese cruce. Si esa casilla es hielo, el deslizamiento se aplica desde ahí. Los niveles 11 a 20 y 21 a 30 ya están recalculados con esta regla, igual que 31 a 50. Siguen sin modelarse la espera de 0,5 s antes de volver a teletransportarse y el impulso de salida más allá de esa casilla.
   - Niveles 41 a 50: los niveles 41 a 47 tienen una puerta y una llave (una sola de cada, así que «cualquier llave abre la puerta» coincide con el juego), los niveles 45 a 50 tienen hielo y todos menos el 48 tienen un par de teletransportadores cian. En el juego la puerta no se abre al recoger la llave, sino cuando el jugador con la llave llega a 1,5 unidades de la puerta; entonces la llave vuela hasta la cerradura (`Key.OpenCorroutine`, 0,02 unidades por fotograma) y solo al terminar la puerta deja de ser obstáculo (`Door.Open` → `RemoveObstacle`). **Esa espera no se modela**: el estimador deja cruzar la puerta en cuanto se tiene la llave. En este rango solo afecta a los niveles 44, 45 y 46, los únicos en que la meta exige pasar la puerta (ver el punto siguiente).
   - Animación de la llave (niveles 37, 38, 40, 44, 45 y 46): en estos niveles la meta exige cruzar la puerta, y la animación de la llave hasta la cerradura no se modela, así que el tiempo real mínimo es algo mayor que el estimado y el umbral de 3 estrellas queda más justo. En el 37, el 38 y el 40 el margen efectivo de 3 estrellas queda en torno al 5 % en lugar del 10 %: justo, pero alcanzable. En el 44, el 45 y el 46 la espera estimada (unos 1,5 s a 60 fps y hasta unos 3 s a 30 fps) cabe dentro del margen; el 45 es el más justo (3,59 s de margen) y es el primero que conviene probar en juego en el dispositivo objetivo. Si una partida limpia no llega a 3 estrellas, se puede sumar alrededor de 1 a 2 s por puerta obligatoria.
3. **Calibración.** El nivel 1 (umbral de 3 estrellas actual: 17 s) corresponde a una partida limpia de unos 15,5 s, y su camino más corto mide 11 pasos. Factor: 15,5 / 11 ≈ **1,409 s por paso**. Tiempo estimado T = pasos × 1,409.
4. **Umbrales.** 3 estrellas = ⌈T × 1,10⌉ s; 2 estrellas = ⌈T × 1,50⌉ s. Se escriben en `maxTime3Stars` y `maxTime2Stars` de `Assets/GJam2020/Config/Level_N.asset`.

Todos los niveles del 2 al 20 tienen camino de inicio a meta; ninguno queda sin resolver. En los niveles 11, 12, 14 y 15 la meta solo se alcanza usando el teletransportador, y en el 13 el teletransportador acorta el camino de 17 a 14 pasos; en el 16 al 20 no cambia la longitud del camino.

Todos los niveles del 21 al 30 también tienen camino. **El nivel 25 solo se resuelve emparejando los teletransportadores por color:** con el emparejamiento antiguo por orden de lectura (que mezclaba los dos colores) la meta quedaba inalcanzable. En los niveles 26 a 30 el hielo acorta el tiempo estimado (de 18 a 16, de 32 a 23, de 19 a 17, de 21 a 19,5 y de 24 a 20 pasos equivalentes). Con la regla de la casilla de salida, los niveles 21, 24, 25, 28, 29 y 30 bajan un paso y el 23 baja dos.

Todos los niveles del 31 al 40 tienen camino; ninguno queda sin resolver. Con la regla de la casilla de salida, los niveles 33, 34, 35 y 40 bajan un paso respecto a dejar al jugador sobre el teletransportador, y el nivel 36 sube uno.

Todos los niveles del 41 al 50 tienen camino; ninguno queda sin resolver. En los niveles 44, 45, 46 y 50 la meta solo se alcanza usando el teletransportador, y en los niveles 44, 45 y 46 solo abriendo la puerta. En los niveles 48, 49 y 50 el hielo **alarga** el camino (de 13 a 17, de 17 a 22 y de 15 a 27 pasos respecto a tratarlo como suelo), porque el deslizamiento obliga a rodear; en el 45 y el 46 lo acorta (de 25 a 23 y de 50 a 48). El nivel 46 es el más largo de la tabla (48 pasos).

## Tabla (estimado)

| Nivel | Pasos | Tiempo estimado (s) | 3 estrellas (s) | 2 estrellas (s) |
| --- | --- | --- | --- | --- |
| 2 | 11 | 15,5 | 18 | 24 |
| 3 | 13 | 18,32 | 21 | 28 |
| 4 | 13 | 18,32 | 21 | 28 |
| 5 | 13 | 18,32 | 21 | 28 |
| 6 | 16 | 22,55 | 25 | 34 |
| 7 | 12 | 16,91 | 19 | 26 |
| 8 | 15 | 21,14 | 24 | 32 |
| 9 | 15 | 21,14 | 24 | 32 |
| 10 | 20 | 28,18 | 32 | 43 |
| 11 | 13 | 18,32 | 21 | 28 |
| 12 | 11 | 15,5 | 18 | 24 |
| 13 | 14 | 19,73 | 22 | 30 |
| 14 | 13 | 18,32 | 21 | 28 |
| 15 | 13 | 18,32 | 21 | 28 |
| 16 | 12 | 16,91 | 19 | 26 |
| 17 | 14 | 19,73 | 22 | 30 |
| 18 | 15 | 21,14 | 24 | 32 |
| 19 | 15 | 21,14 | 24 | 32 |
| 20 | 17 | 23,95 | 27 | 36 |
| 21 | 16 | 22,55 | 25 | 34 |
| 22 | 13 | 18,32 | 21 | 28 |
| 23 | 11 | 15,5 | 18 | 24 |
| 24 | 15 | 21,14 | 24 | 32 |
| 25 | 15 | 21,14 | 24 | 32 |
| 26 | 16 | 22,55 | 25 | 34 |
| 27 | 23 | 32,41 | 36 | 49 |
| 28 | 17 | 23,95 | 27 | 36 |
| 29 | 19,5 | 27,48 | 31 | 42 |
| 30 | 20 | 28,18 | 32 | 43 |
| 31 | 21 | 29,59 | 33 | 45 |
| 32 | 29 | 40,86 | 45 | 62 |
| 33 | 17 | 23,95 | 27 | 36 |
| 34 | 19,5 | 27,48 | 31 | 42 |
| 35 | 20,5 | 28,89 | 32 | 44 |
| 36 | 17 | 23,95 | 27 | 36 |
| 37 | 22 | 31 | 35 | 47 |
| 38 | 25 | 35,23 | 39 | 53 |
| 39 | 20 | 28,18 | 32 | 43 |
| 40 | 21 | 29,59 | 33 | 45 |
| 41 | 18 | 25,36 | 28 | 39 |
| 42 | 16 | 22,55 | 25 | 34 |
| 43 | 13 | 18,32 | 21 | 28 |
| 44 | 28 | 39,45 | 44 | 60 |
| 45 | 23 | 32,41 | 36 | 49 |
| 46 | 48 | 67,64 | 75 | 102 |
| 47 | 18 | 25,36 | 28 | 39 |
| 48 | 17 | 23,95 | 27 | 36 |
| 49 | 22 | 31 | 35 | 47 |
| 50 | 27 | 38,05 | 42 | 58 |

Nota: el nivel 2 tiene la misma longitud de camino que el nivel 1 (11 pasos), pero su umbral de 3 estrellas sale 18 s y no 17 s, porque ⌈15,5 × 1,10⌉ = ⌈17,05⌉ = 18. El nivel 1 no se modificó.
