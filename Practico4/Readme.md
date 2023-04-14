# Práctico 3

## Objetivos

Poner en práctica los conocimientos de:

* Cámara
* User Interface 
* Persistencia básica y pasaje de datos entre escenas

--- 

## Ejercicios

Comenzar los ejercicios en un nuevo proyecto llamado `Practico4`. Los ejercicios Bonus son opcionales para que cada uno haga luego de la clase.

### Ejercicio 1

> En nuestro juego survival, nuestro personaje se mueve en un bosque. Hacer una escena con árboles y un personaje con movimiento, similar al [Ejercicio2](../Practico3/Readme.md#ejercicio-2) del práctico 3, y agregarle a la cámara una lógica que se ubique donde está el personaje.

1. Crear estructura con escena para ejercicio 1.
2. Crear prefab para el Personaje agregarle un `SpriteRenderer` y crear un `Sprite` con el menu de `Create/2D/Sprites/` de tipo hexágono. Configurar al personaje para tener el hexágono.
3. Instanciar en escena el personaje.
4. Agregarle una lógica de movimiento al personaje como hicimos en el [Ejercicio2](../Practico3/Readme.md#ejercicio-2) del práctico anterior.

```csharp
public class Control : MonoBehaviour
{
    [SerializeField]
    private Movimiento movimiento;
   	 
    private void Update()
    {
        movimiento.direccion.x = Input.GetAxis("Horizontal");
        movimiento.direccion.y = Input.GetAxis("Vertical");
    }
}
```

```csharp
public class Movimiento : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
   	 
    [NonSerialized]
    public Vector3 direccion;

    void FixedUpdate()
    {
        transform.position += direccion * speed * Time.deltaTime;
    }
}
```

5. Ejecutar.
6. Agregar a la cámara un script con un field público de tipo `Transform` que se llame `target` y referenciar en editor al transform del personaje. Agregar una lógica que copie la posición del transform referenciado en el transform de la cámara.

```csharp
public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform target;
   	 
    private void Update()
    {
        var position = transform.position;
        position.x = target.transform.position.x;
        position.y = target.transform.position.y;
        transform.position = position;
    }
}
```

* ¿Por qué copiamos solamente las coordenadas x e y en vez de directamente la posición?

7. Ejecutar

* ¿Que pasa que ahora no se mueve el personaje? 

8. Vamos a agregar decoraciones. Agregar un nuevo prefab llamado `Arbol` con un `SpriteRenderer`, crear un Sprite de tipo Diamante con el menu de Create, y asignarselo al `SpriteRenderer`. Rotar el transform 90 grados en el eje z para que quede apuntando para arriba. Colorear de verde e instanciar en la escena muchos árboles a gusto. 
9. Ejecutar

### Ejercicio 2

> En el bosque hay monedas tiradas y el personaje deberá agarrarlas y el jugador podrá ver en pantalla cuantas monedas tiene.

1. Crear una nueva estructura para Ejercicio 2, vamos a reusar `Control`, `Movimiento` y `Follower` del Ejercicio 1 y el prefab de árbol.  Vamos a crear un nuevo prefab de personaje igual al del Ejercicio 1.
2. Vamos a crear un nuevo prefab llamado `Moneda` que tiene un `SpriteRenderer` con un Sprite de tipo circulo, creado con el menu `Create/2d/Sprites`, asignarle el sprite y colorearlo de amarillo. Instanciar monedas en escena a gusto.
3. Crear un nuevo `Canvas` con el menu `GameObject/UI/Canvas` y configurar ScaleWithScreenSize al CanvasScaler, con resolucion 1280x720. 
4. Agregarle un objeto de tipo `Text` usando el menu `GameObject/UI/Text` y ubicarlo centrado arriba. Este objeto mostrará luego las monedas que tiene el personaje.
5. Crear un nuevo script llamado `CircleBounds` y agregarlo en ambos prefabs (moneda y personaje), el cual tiene la lógica de detección de colisión de tipo Circlulo/Circulo. Configurar la moneda con radio de 0.25 y el personaje 0.5

```csharp
public class CircleBounds : MonoBehaviour
{
    [SerializeField]
    private float radius;

    public bool InContact(CircleBounds b)
    {
        var r = radius + b.radius;
       	 
        var distX = transform.position.x - b.transform.position.x;
        var distY = transform.position.y - b.transform.position.y;

        if (Mathf.Abs(distX) > r)
            return false;

        if (Mathf.Abs(distY) > r)
            return false;

        var distanceSqr = (distX * distX) + (distY * distY);
        return distanceSqr < r * r;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
```

6. Crear un script `Personaje` y agregarle al prefab de `Personaje`, que tenga una referencia pública a un `Text` de UI, configurarlo en el inspector como referencia al Text que creamos previamente, y agregarle un campo privado de tipo int llamado `monedas`, y agregarle un callback llamado `OnContactWithMoneda` que recibe un parámetro de tipo `Moneda`.

```csharp
public class Personaje : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [NonSerialized]
    public int monedas;

    public void UpdateMonedas(int monedas)
    {
        this.monedas = monedas;
        text.text = $"Monedas: {monedas}";
    }

    public void OnContactWithMoneda(Moneda moneda)
    {
        GameObject.Destroy(moneda.gameObject);
        UpdateMonedas(monedas + 1);
    }
}
```

7. Crear un script `Moneda` y agregarlo al prefab de `Moneda`, asignarle un campo de tipo `CircleBounds` y configurar la referencia en el prefab de `Moneda`. Agregar una lógica en el `FixedUpdate` para detectar colision con el player y en ese caso enviar un broadcast message al `GameObject` del personaje con el nombre del callback que dijimos anteriormente.

```csharp
public class Moneda : MonoBehaviour
{
    [SerializeField]
    private CircleBounds bounds;
   	 
    private void FixedUpdate()
    {
        var playerObject = GameObject.FindWithTag("Player");
        var circleBounds = playerObject.GetComponent<CircleBounds>();

        if (bounds.InContact(circleBounds))
        {
            playerObject.BroadcastMessage("OnContactWithMoneda", this);
        }
    }
}
```

8. Ejecutar

### Ejercicio 3a

> Vamos a agregar persistencia para que el jugador pueda continuar su partida donde la dejó y agarrar cada vez más monedas.

1. Crear nueva estructura y escena para Ejercicio3 a partir de la escena de Ejercicio2.
2. Crear un nuevo script `Persistidor` y agregarlo a la instancia de personaje en la escena. Este script va a responder al mismo callback de agarrar una moneda y utilizar los `PlayerPrefs` para salvar las monedas de personaje. Aparte, en el `Awake` va a leer de `PlayerPrefs` y asignarle la monedas guardadas a personaje.

```csharp
public class Persistidor : MonoBehaviour
{
    [SerializeField]
    private Personaje personaje;

    private void Awake()
    {
        var monedasGuardadas = PlayerPrefs.GetInt("Ejercicio3.Monedas", 0);
        personaje.UpdateMonedas(monedasGuardadas);
    }

    public void OnContactWithMoneda(Moneda moneda)
    {
        PlayerPrefs.SetInt("Ejercicio3.Monedas", personaje.monedas);
        PlayerPrefs.Save();
    }
}
```

3. Ejecutar varias veces agarrando monedas cada vez.

### Ejercicio 3b

> Cada partida consiste en que el jugador agarre todas las monedas de la escena, una vez logrado ese objetivo, el juego presenta una pantalla con el resultado de cantidad de monedas recolectadas y la opción de jugar un nuevo nivel.

1. Crear una nueva escena llamada Resultados
2. Crear un script llamado Juego que cuente la cantidad de monedas en escena, en caso de no haber ninguna más, carga la escena llamada Resultados. Para esto podemos usar `FindObjectsOfType<Moneda>()`. Crear un GameObject en la escena Ejercicio3 y agregarle el script.

```csharp
public class Juego : MonoBehaviour
{
    private int monedasJuego;
   	 
    private void Awake()
    {
        Resultados.monedasRecolectadas = 0;
        monedasJuego = FindObjectsOfType<Moneda>().Length;
    }

    private void Update()
    {
        var monedas = FindObjectsOfType<Moneda>();

        if (monedas.Length == 0)
        {
            Resultados.monedasRecolectadas = monedasJuego;
            SceneManager.LoadScene("Resultados");
        }
    }
}
```

3. En la escena Resultados, crear un GameObject llamado Resultados y agregarle un script llamado Resultados.
4. Crear una UI que muestre la cantidad de monedas recolectadas en la partida y la cantidad de monedas totales. Además, tiene un botón de `Next` y un boton de `Exit`. Con el botón de `Next` el juego vuelve a cargar la escena Ejercicio3 para jugar de nuevo. En caso de tocar el botón `Exit` el juego sale.

```csharp
public class Resultados : MonoBehaviour
{
    public static int monedasRecolectadas;

    [SerializeField]
    private Text textTotales;
    [SerializeField]
    private Text textRecolectadas;
   	 
    private void Awake()
    {
        var monedasTotales = PlayerPrefs.GetInt("Ejercicio3.Monedas", 0);
       	 
        textTotales.text = $"Totales: {monedasTotales}";
        textRecolectadas.text = $"Recolectadas: {monedasRecolectadas}";
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Ejercicio3");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
```

5. Ejecutar
6. Configurar como primera escena de la build Resultados y luego crear una build windows y ejecutar.

---

## Bonus tracks

### Ejercicio 1.1

Agregarle a la cámara un movimiento, con velocidad, y modificar el script para que la cámara se mueva hacia la posición del personaje a lo largo del tiempo, no de manera instantánea.

### Ejercicio 3b.1

El juego consiste ahora en recolectar todas las monedas en menos de un tiempo determinado. Agregar una cuenta regresiva y mostrarla en la UI, en caso de que el jugador no logra recolectar todas las monedas antes de ese tiempo, el juego muestra los resultados con un GAME OVER y no se persisten las monedas totales. En caso de recolectar todo en tiempo y forma, el juego muestra la ventana de resultados con un VICTORY y persiste los datos de monedas. 

### Ejercicio 3b.2

Al resultado del Ejercicio anterior, modificar el script Juego para que cree en el Awake Monedas aleatorias (cantidad y ubicación) usando el prefab Moneda.
