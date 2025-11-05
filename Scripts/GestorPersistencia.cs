using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GestorPersistencia : MonoBehaviour
{
    //sistema de guardado básico en Unity
    public static GestorPersistencia instancia;
    public DataPersistencia data; //clase de datos serializable 
    string archivoDatos = "save.dat"; //nombre de mi archivo binario para guardar datos

    private void Awake()
    {
        //Singleton, instancia única
        //Garantiza que solo hata una instancia de GestorPersistencia en todo el juego
        if (instancia == null)
        {
            DontDestroyOnLoad(this.gameObject); //Evita que sea destruido al cambhiar de escena 
            instancia = this;
        }
        else if (instancia != this) //Si ya existe otra instancia, se destruye la nueva
            Destroy(this.gameObject);

        CargarDataPersistencia();
    }

    private void Update()
    {
        //Test rapido de guardado
        if (Input.GetKeyDown(KeyCode.G)) GuardarDataPersistencia();
    }

    public void GuardarDataPersistencia()
    {
        //Serialización binaria
        string filePath = Application.persistentDataPath + "/" + archivoDatos; //Ruta de guardado
        BinaryFormatter bf = new BinaryFormatter(); //Conversión de datos a binario
        FileStream file = File.Create(filePath); //Creamos un archivo save.dat
        bf.Serialize(file, data); //Guardamos la información serializada
        file.Close();//Cerramos el archivo para libearar recursos
    }

    public void CargarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath)) //Si existe el archivo save.dat los despaquetamos, cn Deserialize(file) y recuperamos los datos
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            DataPersistencia cargado = (DataPersistencia)bf.Deserialize(file);
            data = cargado;
            file.Close();
        }
    }
}

[System.Serializable] //Con está etiqueta le indicamos a unity (y al BinaryFormatter) puede convertirlo en bytes
public class DataPersistencia
{
    //Usamos esta clase como contenedor de todo lo que vamos a guardar
    public int Puntos = 0;
    public bool puertaAbierta = false;
    public Punto posicionJugador;
    public Punto posicionEnemigo;

    //Estructura de datos

    public DataPersistencia()
    {
        Puntos = 0;
        puertaAbierta = false;
    }
}

[System.Serializable]
public class Punto
{
    public float x;
    public float y;
    public float z;

    public Punto(Vector3 p)
    {
        x = p.x; y = p.y; z = p.z;
    }

    public Vector3 aVector()
    {
        return new Vector3(x, y, z);
    }
}
