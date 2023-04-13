# Práctico 3

## Objetivos

Poner en práctica los conocimientos de:

* Controles (keyboard y mouse)
* Detección de colisiones
* Física

--- 
## Ejercicios

Comenzar los ejercicios en un nuevo proyecto llamado `Practico3`. Los ejercicios Bonus son opcionales para que cada uno haga luego de la clase.

--- 
### Ejercicio 1

Vamos a crear dos elementos y vamos a detectar cuando el mouse está por arriba para seleccionarlos como si fuera un juego de estrategia o una carta de un juego como el Heartstone, con nuestro sistema de colisiones para ir elaborando para el obligatorio.

1. Crear una escena llamada `Ejercicio1` dentro de una carpeta llamada igual.
2. Crear un nuevo prefab llamado `Personaje` dentro de esa carpeta.
3. Agregarle un componente `SpriteRenderer` al prefab. Crear un `Sprite` con el menu `Create/2D/Sprites/Square`, nombrarlo Personaje y configurarlo al SpriteRenderer del prefab.
4. Crear 2 instancias de ese prefab en la escena.
5. Agregar un script llamado `RectBounds` que tenga dos campos `width` y `height` de tipo `float` configurables e implementar el método OnDrawGizmos para mostrar los bounds. Agregar al prefab y configurarlo en tamaño (1, 1).

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

6. Modificar las instancias en escena, moverlas ubicaciones a gusto y configurarles tamaños distintos modificando el transform scale. ¿Cómo se comporta el debug de los bounds?
7. Agregar un nuevo script llamado `Selection` que tenga el siguiente código:

```csharp
[SerializeField]
private RectBounds bounds;

[SerializeField]
private SpriteRenderer spriteRenderer;

[SerializeField]
private Color highlightedColor, selectedColor;

[NonSerialized]
public bool selected;

public void Update()
{
  if (bounds == null)
    return;
    
  var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

  var mouseInsideBounds = bounds.Collides(mousePosition);

  if (Input.GetMouseButtonDown(0))
    selected = mouseInsideBounds;

  if (selected)
    spriteRenderer.color = selectedColor;
  else
    spriteRenderer.color = mouseInsideBounds ? highlightedColor : Color.white;
}
```

8. Implementar el método `RectBounds.Collides()` como sigue:

```csharp
public bool Collides(Vector2 point)
{
  var p = transform.position;
    
  var xmin = p.x - size.x * 0.5f;
  var xmax = p.x + size.x * 0.5f;
  var ymin = p.y - size.y * 0.5f;
  var ymax = p.y + size.y * 0.5f;

  if (point.x < xmin)
    return false;
    
  if (point.x > xmax)
    return false;
    
  if (point.y < ymin)
    return false;
   
  if (point.y > ymax)
    return false;
    
  return true;
}
```

9. Ejecutar la escena, mover el mouse por arriba de cada personaje y probar seleccionarlo con el click.