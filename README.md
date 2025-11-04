# RiniExperimental
Demo técnica desarrolada en Unity 2019.4.12f1, testeo basico de interacciones en unity, recreación de movimiento con Charactercontroler y Cinemamachine para movimintos y una cámara dinamica.
--
## Scrpits Principales
-`Rini:MoverPj.cs` -> Sistema de movimiento 3D con CharacterController, control relativo a cámara con cinemachine, deslizamiento en rampas verticales, animaciones integradas (Idle, Salto, Ataque, Defensa), simulación de salto y gravedad.

$$ Objetivos
-`RiniInput = new Vector3(horizontalMove, 0, verticalMove);` y `RiniInput = Vector3.ClampMagnitude(RiniInput, 1);` -> Movmiento direccional y evitamos que el personaje aumente su velocidad en sentido diagonal.


-`animator.SetFloat("PlayerWalkVelocity", RiniInput.magnitude * VelocidadRini);` -> Manejo de animaciones con componente Animtor. Controlamos cuando el personaje se mueve para cambiar de una animación estatica a una de desplazarse. 


-` velocidadCaidaRini = -gravity * Time.deltaTime;` -> Simulación de caída con una contante de gravedad, también podemos gestionar animaciones de caída.


-`Rampita = Vector3.Angle(Vector3.up, hitNormal) >= CC.slopeLimit;` -> Para la simulación de caída por ramparas, primero determinamos si el piso sobre el que estamos está más inclinado, y tiene una inclinacion mayor a la pendiende maxima determinada. Con está función calculamos el ángulo entre dos vectores en grados para obtener que tan inclinada está la superficie respecto al suelo.

