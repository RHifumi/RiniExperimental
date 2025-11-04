using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara_Rini : MonoBehaviour
{
//Vector 2 para guardar la posición del cursor
    Vector2 mouseMirar;
    Vector2 suavidadV;
//Ajuste para una sensibilidad y suavizado en el recorrido de la cámara
    private float sensibilidad = 2.5f;
    private float suavizado = 0.3f;

    GameObject Player_Rini;

    void Start()
    {
//La cámara está asignada a la protagonista
        Player_Rini = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        SalirPausa();

        Movimiento();

    }

    private void SalirPausa()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }

    private void Movimiento()
    {
//1.Obtengo las coordenadas del cursor, ej (0.5) y (0.2)
        var MouseDirecction = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
//2. Consigo un movmiento más fluido y más controlado, con Sacle multiplcamos por la sensibilidad (0.5)(0.2) * 6 =  (3)(1.2) 
        MouseDirecction = Vector2.Scale(MouseDirecction, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

//3.Calculo los valores de dirección en x y con una sensibilidad Math.f.Lerp (3)(1.2) / Suavidad como 2 = (1.5)(0.6)
        suavidadV.x = Mathf.Lerp(suavidadV.x, MouseDirecction.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, MouseDirecction.y, 1f / suavizado);
//4.Acumula la rotación general, sumaría 1.5° +(derecha) y 0.6° +(Arriba)
        mouseMirar += suavidadV;
//5.Limito la vista en y hacía arriba y abajo
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -10, 15);
//6.Transformo la rotación en ° en rotaicón real 
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
//7.El personaje gira junto la cámara
        Player_Rini.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, Player_Rini.transform.up);

    }
}
