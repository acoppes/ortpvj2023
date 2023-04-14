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

### Ejercicio 2

Vamos a implementar un personaje controlable con teclado, con las teclas WASD o flechas y vamos a detectar cuando entra y sale de un área de juego.

1. Crear una estructura de directorios para el Ejercicio2 con su escena también.
2. Copiar el prefab del ejercicio1 o bien crear uno nuevo configurado similar.
3. Crear dos nuevos scripts, uno llamado Movimiento con un campo speed de tipo float configurable en editor y otro campo llamado dirección de tipo Vector3 publico pero no mostrable en editor, y agregarle una lógica en el FixedUpdate que mueva al personaje en base a la dirección y la velocidad.

```csharp
public class Movimiento : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
   	 
    [NonSerialized]
    public Vector3 direction;

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
```

4. Y el otro script llamado ControlTeclado, que en base al uso de ejes de input cambie la direccion de movimiento de la clase Movimiento.

```csharp
public class ControlTeclado : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxis = "Horizontal";
   	 
    [SerializeField]
    private string verticalAxis = "Vertical";

    [SerializeField]
    private Movimiento movimiento;
   	 
    void Update()
    {
        movimiento.direction.x = Input.GetAxis(horizontalAxis);
        movimiento.direction.y = Input.GetAxis(verticalAxis);
    }
}
```

5. Agregar ambos scripts al prefab nuevo de Ejercicio2 y configurarle una velocidad, ejecutar. Probar modificar distintos valores como el Gravity, Sensitivity y Dead de los ejes en el Input Manager para ver como se comporta.
6. Crear un nuevo prefab llamado Trampa que solo tenga SpriteRenderer y RectBounds.
7. Crear y agregar un nuevo script llamado Trampa que al detectar al personaje en colisión (rect vs rect) se coloree en rojo sin opacidad, y cuando no lo detecte se quede con mitad de opacidad. Etiquetar al personaje con la etiqueta Player.

```csharp
public class Trampa : MonoBehaviour
{
    [SerializeField]
    private RectBounds bounds;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color playerDetectedColor, noPlayerColor;
   	 
    private void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var playerBounds = player.GetComponent<RectBounds>();

        var collideWithPlayer = bounds.Collides(playerBounds);

        spriteRenderer.color = collideWithPlayer ? playerDetectedColor : noPlayerColor;
    }
}
```

8. Implementar la detección de rectángulo con rectángulo en el RectBounds. Primero crear una estructura nueva llamada Bounds, auxiliar y luego implementar el método sobrecargado en RectBounds.

```csharp
public struct Bounds
{
    public float xmin, xmax, ymin, ymax;

    public Bounds(float a, float b, float c, float d)
    {
        xmin = a;
        xmax = b;
        ymin = c;
        ymax = d;
    }
}

public Bounds GetBounds()
{
     var p = transform.position;
     return new Bounds(
         p.x - size.x * 0.5f,
         p.x + size.x * 0.5f,
         p.y - size.y * 0.5f,
         p.y + size.y * 0.5f);
}

public bool Collides(RectBounds rect)
{
     var bounds = GetBounds();
     var rectBounds = rect.GetBounds();

     if (bounds.xmax < rectBounds.xmin)
         return false;
   	 
     if (bounds.xmin > rectBounds.xmax)
         return false;
       	 
     if (bounds.ymax < rectBounds.ymin)
         return false;
   	 
     if (bounds.ymin > rectBounds.ymax)
         return false;

     return true;
}
```

9. Instanciar una o varias trampas en escena, distribuirlas y modificarles el tamaño usando la escala. Ejecutar y probar moverse dentro y fuera de cada trampa.

### Ejercicio 3a

Queremos hacer un juego de carreras ahora, vamos a agregar controles nuevos, opcionales, que permitan rotar la dirección con AD y avanzar y retroceder con WS como si fuera un vehículo.

1. Crear estructura para Ejercicio3.
2. Crear un nuevo prefab de Personaje, similar al de Ejercicio2 pero sin el ControlTeclado ni el Movimiento.
3. Crear dos nuevos scripts, ControlAuto y MovimientoAuto y agregarlos al prefab.
4. Agregar a MovimientoAuto una lógica que rote el ángulo al cual apunta dado un valor de rotacion y que avance o retroceda dado un valor de forward. También vamos a hacer que se modifique el ángulo del transform para que se vea visualmente hacia donde estamos apuntando.

```csharp
public class MovimientoAuto : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 1.0f;

    [SerializeField]
    private float backwardSpeed = 0.25f;

    [SerializeField]
    private float rotateSpeed = 180;

    [NonSerialized]
    public float rotate;
   	 
    [NonSerialized]
    public float forward;

    [SerializeField]
    private float angle = 0;
   	 
    private void FixedUpdate()
    {
        angle += rotate * rotateSpeed * Time.deltaTime;

        var speed = forward > 0 ? forward * forwardSpeed : forward * backwardSpeed;
        var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
       	 
        transform.position += direction * speed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * 1.0f);
    }
}
```

5. Agregar a ControlAuto una lógica que al apretar AD modifique el valor de rotate para indicar un giro y con WS ir hacia adelante o hacia atrás. No usamos los ejes porque no queremos la aceleración de los controles virtuales.

```csharp
public class ControlAuto : MonoBehaviour
{
    [SerializeField]
    private MovimientoAuto movimiento;
   	 
    void Update()
    {
        movimiento.rotate = 0;
        movimiento.forward = 0;

        if (Input.GetKey(KeyCode.A))
        {
            movimiento.rotate += 1;
        }
       	 
        if (Input.GetKey(KeyCode.D))
        {
            movimiento.rotate += -1;
        }
       	 
        if (Input.GetKey(KeyCode.W))
        {
            movimiento.forward += 1;
        }
       	 
        if (Input.GetKey(KeyCode.S))
        {
            movimiento.forward += -1;
        }
    }
}
```

6. Configurar datos a gusto en el prefab del personaje.
7. Instanciar el prefab y modificarle el local scale a (1, 0.5, 1) para que se vea más largo que alto.
8. Ejecutar para mover.
9. Etiquetar la instancia como Player y agregar trampas en la escena como hicimos en el Ejercicio 2. Ejecutar y probar.

> ¿Qué pasa si giramos sin estar avanzando? 

### Ejercicio 3b

Vamos a agregarle un movimiento de física simple al movimiento de vehículos con aceleración y desaceleración.

1. Agregar una variable de aceleración al MovimientoAuto y cambiar a modificar la velocidad en el tiempo en base a tener forward o no, de manera que si tengo apretado hacia adelante, la velocidad aumenta hasta tener una magnitud de forwardSpeed y si tengo apretado hacia atrás lo mismo pero hasta tener una magnitud de backwardSpeed.

```csharp
public class MovimientoAuto : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 1;
   	 
    [SerializeField]
    private float forwardSpeed = 1.0f;

    [SerializeField]
    private float backwardSpeed = 0.25f;

    [SerializeField]
    private float rotateSpeed;

    [NonSerialized]
    public float rotate;
   	 
    [NonSerialized]
    public float forward;

    [SerializeField]
    private float angle = 0;

    private Vector3 velocity;

    private void FixedUpdate()
    {
        var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

        if (forward > 0)
        {
            velocity += direction  * acceleration * Time.deltaTime;
           	 
            // Limitamos la velocidad máxima yendo hacia adelante
            if (velocity.sqrMagnitude > forwardSpeed * forwardSpeed)
            {
                velocity = velocity.normalized * forwardSpeed;
            }
           	 
        } else if (forward < 0)
        {
            velocity -= direction * acceleration * Time.deltaTime;
           	 
            // Limitamos la velocidad máxima retrocediendo
            if (velocity.sqrMagnitude > backwardSpeed * backwardSpeed)
            {
                velocity = velocity.normalized * backwardSpeed;
            }

            // Invertimos el angulo de rotacion al ir para atras
            rotate *= -1;
        }
        else
        {
            velocity = Vector3.zero;
        }
       	 
        angle += rotate * rotateSpeed * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
```

> ¿Porque “derrapa” el auto si estamos avanzando y giramos?

## Bonus tracks

### Ejercicio 1.1

Al presionar el botón derecho del mouse en la pantalla el personaje seleccionado se mueve, a lo largo del tiempo, desde donde está actualmente hasta la ubicación indicada a una velocidad constante.

### Ejercicio 1.2

Si mantengo el botón izquierdo presionado sobre un personaje y muevo el mouse, el personaje se mueve junto con el mouse estilo drag.

### Ejercicio 3b.1

Modificar MovimientoAuto de manera que el auto no pueda rotar a menos que tenga algo de velocidad, incluso podría ser gradual, mientras se mueve lento rota menos que cuando se mueve rápido, pero si está quieto no debería poder rotar.

### Ejercicio 3b.2

Agregar una lógica de desaceleración del auto cuando no se está presionando ni W ni S y el auto estaba en movimiento.
