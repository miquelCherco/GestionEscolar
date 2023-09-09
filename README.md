# GestionEscolar
Gestion Escolar

Al iniciar el proyecto GestioEscolar, solo hay que ir directamente al postman.
Con las exportaciones ya tendrá ejemplos para hacer la pruebas de entrada de datos.

Se ha realizado con la versió 6.0


Peticiones:

 EndPoint 1 (InicializarDatos): Se ha hecho una petición de tipo POST, ya que en un caso real estaríamos guardado los datos.
  
- EndPoint 2 (EntrarRespuestas): Se ha hecho una petición de tipo POST, ya que estamos añadiendo datos nuevos.

- EndPoint 3 (DevuelveNota): Se ha hecho una petición de tipo GET, ya que lo que estamos haciendo es una cosulta de datos.
 
- EndPoint 4 (ModificarPonderacion): Se ha hecho una petición de tipo PATCH porque estamos modificando una parte de los valores del las ponderaciones.


Decisiones importantes del proyecto:

- Se ha creado una carpeta Model donde se han generado todas las entidades.

- También tenemos la carpeta donde encontraremos los controllers que son las classes para gestionar las solicitudes http.

- Luego podemos encontrar la carpeta services que es donde hay todos los eventos principales para llevar a cabo lo que pide el proyecto.

- Al no tener persistencia de datos, se han generado varias clases de repositorio, que cuando necesitamos calcular u obtener algún dato que no sea por entrada de datos allí hay.

- También se ha generado una carpeta DTO, allí encontraremos clases para la entrada o salida de datos para el postman.

- La carpeta de Exception, es donde encontraremos todas la excepciones que utilizamos para poder controlar los posibles errores.

- Se ha creado varis servicios, ya que no todos tratan lo mismo y por tener más ordenado el código.

- Para generar los test se ha generado un nuevo proyecto con Xunit, para ejecutar los test des del Visual Studio en el menu de Prueva -> Ejecutar todas las pruebas


Decisiones del ejercicio:

- Al ser un poco libre, se han tomado algunas decisiones como se ha entendido.
- Se entiende que una actividad tiene un tipo específico y un tipo de competencia.
- Cada tipo contiene sus porcentajes.
- En el caso de la calificación de las preguntas, se ha hecho que cada pregunta tenga la misma puntuación. En el caso de tener 5 preguntas en toda la actividad, se entiende que cada una vale 2 puntos.
- En el caso que el alumno puede repetir las actividades, se ha añadido una clase donde aparece la actividad y el número de repeticiones, que incrementaría en el caso de ir añadiendo respuestas o nuevas actividades.

