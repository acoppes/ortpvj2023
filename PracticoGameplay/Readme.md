# Práctico: Gameplay (WORK IN PROGRESS)

## Objetivos

Poner en práctica los conocimientos de:

* Spawneo de elementos (enemigos)
* Herramientas básicas de IA para controlar personajes (enemigos)
  - Máquinas de estado
* Weapons & Bullets
* Curva de dificultad.
* Detección de colisiones con física y movimiento de cuerpos kinemáticos.
* Señales/eventos
* UI para representar datos de juego.

## Modalidad

Clase interactiva, si bien el docente va a llevar el práctico adelante, se espera que los alumnos propongan ideas de como implementar cada cosa.

--- 

Vamos a implementar un videojuego rpg de acción en perspectiva 2.5D.

## Ejercicios

Comenzar los ejercicios a partir del proyecto llamado `PracticoGameplay` del repositorio. 

### Ejercicio 1

Los arbustos del juego cada cierto tiempo spawnean un enemigo nuevo, que en principio sale y camina a un punto prefijado.

### Ejercicio 2

Ahora los enemigos se auto controlan realizando un loop que comienza con un desplazamiento a una ubicación random del nivel, luego descansa unos segundos y luego retoma el loop.

### Ejercicio 3

Ahora el enemigo slime crece a lo largo del tiempo hasta un máximo prefijado. Luego de un tiempo en el máximo tamaño, configurable, se divide en dos slimes de tamaño mínimo.

### Ejercicio 4

Nuestro personaje adquirió un arma y ahora puede disparar bullets con la barra espaciadora (o con el boton del mouse) en la dirección que está mirando. Cada bullet hace un daño de 1 al impactar en enemigos.

Los enemigos tienen 2 puntos de vida que incrementan hasta 4 según el tamaño que tienen. En caso de recibir un daño de una bullet y llegan a 0 puntos de vida, mueren.

### Ejercicio 5

El personaje tiene 5 puntos de vida, cada vez que un enemigo toca al personaje, el personaje pierde 1 punto de vida y se vuelve invulnerable durante 1 segundo, para poder escapar.

Ahora los enemigos deciden moverse hacie al jugador en caso de que el jugador esté dentro de una cierta área cercana.

### Ejercicio 6

Los enemigos sueltan unos pickups de puntaje al morir que el jugador debe recolectar y se representan en la UI. Además, ahora el arma del personaje tiene un máximo de balas que al ser gastadas el jugador deberá ir a recoger de unas cajas que aparecen cada tanto en lugares prefijados de la pantalla. 

Los spawners comienzan a spawnear enemigos cada vez más frecuentemente y cada vez más fuertes (más vida, más velocidad, más grandes).

## Bonus tracks

### Ejercicio 7

El personaje puede disparar libre ahora e incluso caminar para un lado pero disparar para el otro, o sea que el arma rota al rededor en la direccion hacia donde está el mouse y las balas salen en esa dirección al disparar.