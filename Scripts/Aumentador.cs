using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aumentador : MonoBehaviour
{
    int _Puntos;

    void Start()
    {
        _Puntos = GestorPersistencia.instancia.data.Puntos;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otro)
    {
        if (otro.tag == "Espada")
        {
            _Puntos += 1;
            GestorPersistencia.instancia.data.Puntos = _Puntos;

            GestorPersistencia.instancia.GuardarDataPersistencia();
        }
    }
}
