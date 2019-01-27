using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
static public EnemiesGenerator i;
    Vector3 posicionGeneracion;
    public List<GameObject> prefabsEnemigo;
    public float tamaño;
    Vector3 posicion;
    public float home;
    public float enemyTime;
    float ultima;
    public GameObject enemyContainer;
    public bool running;
    // Start is called before the first frame update
    void Start()
    {
    i = this;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= enemyTime + ultima)
        {
            if(running){
                Generar();
           
            }
            ultima = Time.time;
        }
    }

    public float start_y = 2;

    void Generar()
    {
        Posicion();
        posicion.y += start_y;
        int eType = Random.Range(0, prefabsEnemigo.Count - 1);
        Instantiate(prefabsEnemigo[eType], posicion, Quaternion.identity,enemyContainer.transform);
    }
    void Posicion()
    {
        float d;
        do
        {
            posicion = new Vector3(Random.Range(-tamaño / 2, tamaño / 2), 1, Random.Range(-tamaño / 2, tamaño / 2));
            d = Vector3.Distance(Vector3.zero, posicion);
        }
        while ( d >= tamaño / 2 * 0.9f || d <= home );
    }
}
