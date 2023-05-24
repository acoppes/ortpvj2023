# Práctico: Gameplay (WORK IN PROGRESS)

## Objetivos

Poner en práctica los conocimientos de:

* Spawneo de elementos (enemigos)
* Herramientas básicas de IA para controlar personajes (enemigos)
  - Máquinas de estado
* Curva de dificultad.
* Detección de colisiones con física y movimiento de cuerpos kinemáticos.
* Señales/eventos
* UI para representar datos de juego.
* Weapons & Bullets

--- 

Vamos a implementar un videojuego rpg de acción en perspectiva 2.5D.

## Ejercicios

Comenzar los ejercicios a partir del proyecto llamado `PracticoGameplay` del repositorio. En este caso, todo el práctico se basa en un ejercicio solo.

### Ejercicio 1.1

Los arbustos del juego spawnean un enemigo nuevo cada cierto tiempo. El enemigo aparece y se desplaza a un punto random en la pantalla, indicado por el spawner.

### Ejercicio 1.2

Ahora los enemigos se auto controlan realizando un loop que comienza con un desplazamiento a una ubicación random del nivel, luego descansa unos segundos y luego retoma el loop.

### Ejercicio 1.3

Ahora el enemigo slime crece a lo largo del tiempo hasta un máximo prefijado. Luego de un tiempo en el máximo tamaño, configurable, se divide en dos slimes de tamaño mínimo.

### Ejercicio 1.4

Nuestro personaje adquirió un arma y ahora puede disparar bullets con la barra espaciadora (o con el boton del mouse) en la dirección que está mirando. Cada bullet hace un daño de 1 al impactar en enemigos.

Los enemigos tienen 2 puntos de vida que incrementan hasta 4 según el tamaño que tienen. En caso de recibir un daño de una bullet y llegan a 0 puntos de vida, mueren.

### Ejercicio 1.5

El personaje tiene 5 puntos de vida, cada vez que un enemigo toca al personaje, el personaje pierde 1 punto de vida y se vuelve invulnerable durante 1 segundo, para poder escapar.

Ahora los enemigos deciden moverse hacie al jugador en caso de que el jugador esté dentro de una cierta área cercana.

### Ejercicio 1.6

Los enemigos sueltan unos pickups de puntaje al morir que el jugador debe recolectar y se representan en la UI. Además, ahora el arma del personaje tiene un máximo de balas que al ser gastadas el jugador deberá ir a recoger de unas cajas que aparecen cada tanto en lugares prefijados de la pantalla. 

Los spawners comienzan a spawnear enemigos cada vez más frecuentemente y cada vez más fuertes (más vida, más velocidad, más grandes).

## Bonus tracks

### Track 1

El personaje puede disparar libre ahora e incluso caminar para un lado pero disparar para el otro, o sea que el arma rota al rededor en la direccion hacia donde está el mouse y las balas salen en esa dirección al disparar.

### Track 2

Agregar una cámara que siga al personaje libremente, con un pequeño delay. La cámara no debería irse de los limites del mundo y el personaje tampoco.

### Track 3

Al disparar la cámara tiene un pequeño shake y al impactar en enemigos tmb, de hecho al morir un enemigo la cámara tiene un shake más grande.

