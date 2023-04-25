# Práctico 5

## Objetivos

Poner en práctica los conocimientos de:

* Como hacer ejecutables para cada plataforma
* Referencias a assets y como se incluyen en la build
* Flags de código condicional
* Application Runtime

--- 

## Ejercicios

Comenzar los ejercicios en un nuevo proyecto llamado `Practico5`. Los ejercicios Bonus son opcionales para que cada uno haga luego de la clase.

### Ejercicio 1

Crear un ejecutable para Windows que contenga 3 escenas: Splash, MainMenu y Juego. El ejecutable comienza en la escena Splash y cuando toco cualquier tecla pasa a la escena MainMenu y luego a Juego. Ponerle un texto o titulo a cada escena para identificarlas. El ejecutable se debe llamar `Super Scenes.exe`.

### Ejercicio 2

Sobre el resultado del ejercicio 1, con código condicional, hacer una build de la versión DEMO del juego, que solo tiene las escenas Splash y MainMenu y dice DEMO en una esquina en cada escena, y al tocar cualquier tecla pasa de Splash a MainMenu pero no a Juego. El ejecutable se debe llamar `Super Scenes - DEMO.exe`. Subir el ejecutable a Steam... (es broma!!)

### Ejercicio 3

Agregar un label en las escenas que diga el `Application.platform` en pantalla, en caso de ser Windows Standalone muestra ese label en verde, en caso de ser editor muestra en rojo y en caso de ser WebGL lo muestra en azul. Hacer una build windows y una webgl para validar colores.

## Referencias

* [Log files](https://docs.unity3d.com/Manual/LogFiles.html) - Donde guarda Unity los archivos de logs. 
* [Application.platform](https://docs.unity3d.com/ScriptReference/Application-platform.html) - Referencia de la API de Application de Unity.