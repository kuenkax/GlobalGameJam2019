using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    Vector3 posicionGeneracion;
    public GameObject prefabEnemigo;
    public float tamaño;
    Vector3 posicion;
    public float home;
    public float enemyTime;
    float ultima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= enemyTime + ultima)
        {
            Generar();
            ultima = Time.time;
        }
    }
    void Generar()
    {
        Posicion();
        Instantiate(prefabEnemigo, posicion, Quaternion.identity);
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
