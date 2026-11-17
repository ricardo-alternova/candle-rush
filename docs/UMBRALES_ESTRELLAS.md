# Umbrales de estrellas — niveles 2 a 30

> **Valores estimados.** No provienen de partidas cronometradas en Unity, sino de un estimador analítico calibrado con el nivel 1. Conviene ajustarlos tras probarlos en juego.

## Método

1. **Lectura del mapa.** Cada nivel usa `Assets/Resources/<N>.csv`, donde cada celda es un color `r-g-b`. El color se traduce a entidad con `Assets/Resources/Common_Map.asset` (suelo, agujero, muro, bandera de inicio y de meta, vida extra, teletransportador, puerta, llave, cubo de hielo).
2. **Camino más corto.** Búsqueda en anchura (BFS) desde la bandera de inicio hasta la de meta, con pasos de una casilla en las cuatro direcciones, igual que `PlayerMovement`. No se puede pisar ninguna celda marcada como obstáculo (agujero, muro, puerta).
   - Aproximaciones: los teletransportadores se emparejan por orden de lectura y cruzarlos no cuesta pasos extra; una puerta se puede cruzar después de recoger cualquier llave; el deslizamiento sobre hielo no se modela. Los niveles 2 a 10 solo tienen suelo, inicio, meta y vidas extra, así que estas aproximaciones no influyen en ellos. Los niveles 11 a 20 tienen además un par de teletransportadores (en el juego se emparejan por color y todos son del mismo color, así que el emparejamiento es inequívoco); la espera de 0,5 s antes de poder volver a teletransportarse no se modela.
   - Niveles 21 a 30: los niveles 23, 24 y 25 tienen dos pares de teletransportadores de distinto color (el cian de `Common_Map` y `0.3137255-1-1`, que no está en `Common_Map`; el juego lo trata como teletransportador), y los niveles 28 y 30 usan solo este segundo color. Como en el juego, los teletransportadores se emparejan **por color** (`MapGenerator.PairPositions[color]`). Los niveles 26 a 30 tienen cubos de hielo, y el deslizamiento **sí** se modela: al entrar en una celda de hielo, el jugador avanza una casilla más en la misma dirección si no es un obstáculo (se encadena sobre hielo seguido), con medio paso de tiempo extra (`IceCube` → `SetNewFinalPosition`). Por eso la columna «Pasos» de esos niveles es un equivalente en tiempo y puede tener medios pasos. Con estos dos cambios los niveles 1 a 20 dan exactamente los mismos resultados.
3. **Calibración.** El nivel 1 (umbral de 3 estrellas actual: 17 s) corresponde a una partida limpia de unos 15,5 s, y su camino más corto mide 11 pasos. Factor: 15,5 / 11 ≈ **1,409 s por paso**. Tiempo estimado T = pasos × 1,409.
4. **Umbrales.** 3 estrellas = ⌈T × 1,10⌉ s; 2 estrellas = ⌈T × 1,50⌉ s. Se escriben en `maxTime3Stars` y `maxTime2Stars` de `Assets/GJam2020/Config/Level_N.asset`.

Todos los niveles del 2 al 20 tienen camino de inicio a meta; ninguno queda sin resolver. En los niveles 11, 12, 14 y 15 la meta solo se alcanza usando el teletransportador, y en el 13 el teletransportador acorta el camino de 17 a 13 pasos; en el 16 al 20 no cambia la longitud del camino.

Todos los niveles del 21 al 30 también tienen camino. **El nivel 25 solo se resuelve emparejando los teletransportadores por color:** con el emparejamiento antiguo por orden de lectura (que mezclaba los dos colores) la meta quedaba inalcanzable. En los niveles 26, 27 y 29 el hielo acorta el tiempo estimado (de 18 a 16, de 32 a 23 y de 22 a 20,5 pasos equivalentes).

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
| 11 | 14 | 19,73 | 22 | 30 |
| 12 | 10 | 14,09 | 16 | 22 |
| 13 | 13 | 18,32 | 21 | 28 |
| 14 | 14 | 19,73 | 22 | 30 |
| 15 | 14 | 19,73 | 22 | 30 |
| 16 | 12 | 16,91 | 19 | 26 |
| 17 | 14 | 19,73 | 22 | 30 |
| 18 | 15 | 21,14 | 24 | 32 |
| 19 | 15 | 21,14 | 24 | 32 |
| 20 | 17 | 23,95 | 27 | 36 |
| 21 | 17 | 23,95 | 27 | 36 |
| 22 | 13 | 18,32 | 21 | 28 |
| 23 | 13 | 18,32 | 21 | 28 |
| 24 | 16 | 22,55 | 25 | 34 |
| 25 | 16 | 22,55 | 25 | 34 |
| 26 | 16 | 22,55 | 25 | 34 |
| 27 | 23 | 32,41 | 36 | 49 |
| 28 | 18 | 25,36 | 28 | 39 |
| 29 | 20,5 | 28,89 | 32 | 44 |
| 30 | 21 | 29,59 | 33 | 45 |

Nota: el nivel 2 tiene la misma longitud de camino que el nivel 1 (11 pasos), pero su umbral de 3 estrellas sale 18 s y no 17 s, porque ⌈15,5 × 1,10⌉ = ⌈17,05⌉ = 18. El nivel 1 no se modificó.
