# Práctico 3

## Objetivos

Poner en práctica los conocimientos de:

* Controles (keyboard y mouse)
* Detección de colisiones
* Física

## Ejercicios

Comenzar los ejercicios en un nuevo proyecto llamado `Practico3`. Los ejercicios Bonus son opcionales para que cada uno haga luego de la clase.

### Ejercicio 1

Vamos a crear dos elementos y vamos a detectar cuando el mouse está por arriba para seleccionarlos como si fuera un juego de estrategia o una carta de un juego como el Heartstone, con nuestro sistema de colisiones para ir elaborando para el obligatorio.

1. Crear una escena llamada `Ejercicio1` dentro de una carpeta llamada igual.
2. Crear un nuevo prefab llamado `Personaje` dentro de esa carpeta.
3. Agregarle un componente `SpriteRenderer` al prefab. Crear un `Sprite` con el menu `Create/2D/Sprites/Square`, nombrarlo Personaje y configurarlo al SpriteRenderer del prefab.
4. Crear 2 instancias de ese prefab en la escena.
5. Agregar el siguiente script llamado `RectBounds`.

```csharp
[SerializeField]
private float width, height;

public Vector2 size => new Vector2(width * transform.localScale.x, height * transform.localScale.y);
    
public void OnDrawGizmos()
{
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(transform.position, size);
}
```
