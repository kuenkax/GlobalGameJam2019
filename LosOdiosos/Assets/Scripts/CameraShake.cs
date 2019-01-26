using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float radio;
    Vector3 posicionInicial;
    public float velocidad;
    Vector3 posicion;
 
    public float tiempo;
    
    void Start()
    {
        posicionInicial = transform.localPosition;
        posicion = posicionInicial;
    }


    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tiempoPasado = 0;
            StartCoroutine(Shake(tiempo));
        }
    }*/


    public bool shaking;

    public void ShakeIt() {
        if ( shaking ) return;

        StartCoroutine(Shake());
    }


    public IEnumerator Shake()
    {
        shaking = true;
        while (shaking)
        {
            if (Mathf.Round(transform.localPosition.x) == Mathf.Round(posicion.x) && Mathf.Round(transform.localPosition.z) == Mathf.Round(posicion.z))
            {
                posicion = new Vector3(Random.Range(posicionInicial.x - radio, posicionInicial.x + radio), transform.localPosition.y,
                        (Random.Range(posicionInicial.z - radio, posicionInicial.z + radio)));

                //print(posicion);
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicion, velocidad);            

            yield return null;
        }

        shaking = false;
        transform.localPosition = posicionInicial;
    }
}



