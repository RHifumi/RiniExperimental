using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rini_MoverPj : MonoBehaviour
{
    //Test de Movimiento para CharacterController
    //No usamos fisica real, gravedad o colisiones fisicas del motor en unity, si no que la simulamos a mano
    //Podemos tener control total  de la velocidad y rotación
    private float horizontalMove;
    private float verticalMove;

    public float VelocidadRini = 1;

    //Utlizamos Cinemachine
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    private Vector3 moveRini;

    public float gravity = 30f;

    public float velocidadCaidaRini;
    public float velocidadSaltoRini;

    private Vector3 RiniInput;

    CharacterController CC;

    private bool Rampita = false;
    private Vector3 hitNormal;
    public float velocidadSlideRini;
    public float slopeForceDown;

    Animator animator;

    void Start()
    {
        CC = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SalirPausa();

        Movimiento();

        camDirection();

        moveRini = RiniInput.x * camRight + RiniInput.z * camForward;

        moveRini = moveRini * VelocidadRini;

        CC.transform.LookAt(CC.transform.position + moveRini);

        Gravedad();

        Saltitos();

        //Movimiento
        CC.Move(moveRini * Time.deltaTime);
    }

    void Movimiento()
    {
        //Recibimos inputs direccionales
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        //Evitamos que el personaje aumente su velocidad en sentido diagonal
        RiniInput = new Vector3(horizontalMove, 0, verticalMove);

        RiniInput = Vector3.ClampMagnitude(RiniInput, 1);

        animator.SetFloat("PlayerWalkVelocity", RiniInput.magnitude * VelocidadRini);

    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        //Diraccion ajustada
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void Gravedad()
    {
        //Simulación de gravedad por la que se ve afectada
        if (CC.isGrounded)
        {
            velocidadCaidaRini = -gravity * Time.deltaTime;
            moveRini.y = velocidadCaidaRini;
        }
        else
        {
            velocidadCaidaRini -= gravity * Time.deltaTime;
            moveRini.y = velocidadCaidaRini;

            animator.SetFloat("PlayerVerticalVelocity", CC.velocity.y);
        }

        animator.SetBool("isGrounded", CC.isGrounded);

        SlideDown();

    }

    public void Saltitos()
    {
        if (CC.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocidadCaidaRini = velocidadSaltoRini;
            moveRini.y = velocidadCaidaRini;

            animator.SetTrigger("PLayerJump");
        }

    }

    public void SlideDown()
    {
        //simula deslizamiento en rampas inclinadas
        Rampita = Vector3.Angle(Vector3.up, hitNormal) >= CC.slopeLimit;

        if (Rampita)
        {
            moveRini.x += (hitNormal.x * (1f - hitNormal.y)) * velocidadSlideRini;
            moveRini.z += (hitNormal.z * (1f - hitNormal.y)) * velocidadSlideRini;

            moveRini.y += slopeForceDown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;

    }

    private void SalirPausa()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
