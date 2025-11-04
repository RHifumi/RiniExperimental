# RiniExperimental
Demo técnica desarrolada en Unity 2019.4.12f1, testeo basico de interacciones en unity, recreación de movimiento con Charactercontroler y Cinemamachine para movimintos y una cámara dinamica.
--
## Scripts Principales
-`Rini:MoverPj.cs` -> Sistema de movimiento 3D con CharacterController, control relativo a cámara con cinemachine, deslizamiento en rampas verticales, animaciones integradas (Idle, Salto, Ataque, Defensa), simulación de salto y gravedad.


-`ControlVida.cs` -> Gestor de vida, con un Canvas WorldSpace personalizado para cada objeto, además de instanciarle la vida, color y propociones a los enemigos.


-`MovimientoCamara_Rini.cs` -> Gestor de cámara, con rotación, aplicada con sensibilidad y suavizada.

## Objetivos
-`RiniInput = new Vector3(horizontalMove, 0, verticalMove);` y `RiniInput = Vector3.ClampMagnitude(RiniInput, 1);` -> Movmiento direccional y evitamos que el personaje aumente su velocidad en sentido diagonal.


-`animator.SetFloat("PlayerWalkVelocity", RiniInput.magnitude * VelocidadRini);` -> Manejo de animaciones con componente Animtor. Controlamos cuando el personaje se mueve para cambiar de una animación estatica a una de desplazarse. 


-` velocidadCaidaRini = -gravity * Time.deltaTime;` -> Simulación de caída con una contante de gravedad, también podemos gestionar animaciones de caída.


-`Rampita = Vector3.Angle(Vector3.up, hitNormal) >= CC.slopeLimit;` -> Para la simulación de caída por ramparas, primero determinamos si el piso sobre el que estamos está más inclinado, y tiene una inclinacion mayor a la pendiende maxima determinada. Con está función calculamos el ángulo entre dos vectores en grados para obtener que tan inclinada está la superficie respecto al suelo.


-`ImagenVida.fillAmount = VidaActual / VidaMax;` -> Permite desde un Canvas, controlar una barra de vida estilo juego clasico, diviendo mi vida actual en la vida maxima establecida.


-`rb.transform.localScale = new Vector3(rb.transform.localScale.x + 0.1f * Time.deltaTime, rb.transform.localScale.y + 0.1f * Time.deltaTime, rb.transform.localScale.z + 0.1f * Time.deltaTime);` -> Efecto de crecimiento por frame, disponible en `Expancion.cs`.


-`Player_Rini.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, Player_Rini.transform.up);` -> Resultado de, obtener las coordenadas del cursor, ver su movimiento, multiplicarlo por la sensibilidad, dividirlo en base a la suavidad, convertir los grados en rotción y hacer rotar al objeto en base a ello.
