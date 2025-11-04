using UnityEngine;
using UnityEngine.UI;

public class ControlVida : MonoBehaviour
{
    //Barra de vida con un Canvas WorldSpace, pido una imagen y texto para modificarlo.
    public Text TextoVida;

    public Image ImagenVida;

    //Cabeza representa el objeto al que voy a cambiarle el color
    private int VidaMax;
    public float VidaActual = 0;
    public GameObject Cabeza;

    private Rigidbody rb;

    void Start()
    {
        //Vida aleatoria entre 2 y 10, un color y proporciones distintas para cada instancia.
        VidaMax = UnityEngine.Random.Range(2, 10);
        VidaActual = VidaMax;

        Color color = new Color(r: UnityEngine.Random.Range(0f, 1f), g: UnityEngine.Random.Range(0f, 1f), b: UnityEngine.Random.Range(0f, 1f));
        Cabeza.GetComponent<Renderer>().material.color = color;

        rb = GetComponent<Rigidbody>();
        rb.transform.localScale = new Vector3(rb.transform.localScale.x * UnityEngine.Random.Range(0.5f, 2f), rb.transform.localScale.y * UnityEngine.Random.Range(0.5f, 2f), rb.transform.localScale.z * UnityEngine.Random.Range(0.5f, 2f));
    }

    void Update()
    {
        ControlVidaEnemigo();

    }

    public void ControlVidaEnemigo()
    {
        //Texto en canvas indicando la vida actual.
        TextoVida.text = VidaActual.ToString() + "/" + VidaMax.ToString();
        ImagenVida.fillAmount = VidaActual / VidaMax;

        if (VidaActual <= 0)
        {
            VidaActual = 0;
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider otro)
    {
        //Deteccion de golpes de Espada.
        if (otro.CompareTag("Espada"))
        {
            VidaActual -= 1;
        }
    }
}
