using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expancion : MonoBehaviour
{
    private bool BOM;
    private Rigidbody rb;
    public GameObject ColorObj;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BOM = false;
    }

    void Update()
    {
        if (BOM)
        {
            Color color = new Color(r: 255, g: 0.5f, b:255);
            ColorObj.GetComponent<Renderer>().material.color = color;

            rb.transform.localScale = new Vector3(rb.transform.localScale.x + 0.1f * Time.deltaTime, rb.transform.localScale.y + 0.1f * Time.deltaTime, rb.transform.localScale.z + 0.1f * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Rini"))
        {
            BOM = true;
        }
    }
}
