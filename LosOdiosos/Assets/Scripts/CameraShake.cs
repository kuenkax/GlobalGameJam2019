using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float radio;
    Vector3 posicionInicial;
    public float velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        Shake(60);
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 posicion;
    public void Shake(float time)
    {
        
       if (Time.time < time)
        {
        
            if(new vecto == posicion)
            {
                 posicion = new Vector3(Random.Range(posicionInicial.x - radio, posicionInicial.x + radio),
          (Random.Range(posicionInicial.x - radio, posicionInicial.x + radio)), transform.position.z);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, posicion, velocidad);
            }
        }
    }
}


