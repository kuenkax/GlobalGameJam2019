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
    // Start is called before the first frame update
    void Start()
    {
       
        posicionInicial = transform.position;
        posicion = posicionInicial;
       
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tiempoPasado = 0;
            StartCoroutine(Shake(tiempo));
        }
    }

     float tiempoPasado = 0;

    public IEnumerator Shake(float time)
    {
        while (true)
        {
            tiempoPasado += Time.deltaTime;
            if(tiempoPasado >= time)
            {
                transform.position = posicionInicial;

                break;

            }
                if (Mathf.Round(transform.position.x) == Mathf.Round(posicion.x) && Mathf.Round(transform.position.z) == Mathf.Round(posicion.z))
                {
                    posicion = new Vector3(Random.Range(posicionInicial.x - radio, posicionInicial.x + radio), transform.position.y
            , (Random.Range(posicionInicial.z - radio, posicionInicial.z + radio)));
                    print(posicion);
                }
                transform.position = Vector3.MoveTowards(transform.position, posicion, velocidad);
            

            yield return null; 
        }




    }
    }



