using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarEspada : MonoBehaviour
{
  //Uso basico de un Animator relacionado con la acción de atacar.
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Atacar();
    }

    private void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            animator.SetTrigger("Atacar");
        }
    }
}
