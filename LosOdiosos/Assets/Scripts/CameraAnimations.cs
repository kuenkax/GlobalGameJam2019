using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    Vector3 posicionNormal;
    public Transform posicionFinal;
    public float tiempo;
    bool inicio;
    bool final;
    public GameObject casa;
    // Start is called before the first frame update
    void Start()
    {
        inicio = true;
        posicionNormal = transform.position;
        transform.position = posicionFinal.position;
    }

    // Update is called once per frame
    void Update()
    {
      if(casa.GetComponent<Animator>().GetBool("appear") == true)
        {
            ActivarAnimacion(posicionNormal, posicionFinal.position);
        }
        if (inicio)
        {
            ActivarAnimacion(posicionFinal.position, posicionNormal);
        }
        
       
    }
    void ActivarAnimacion(Vector3 start, Vector3 end)
    {
        if (inicio)
        {
            transform.parent.GetComponent<PlayerCamera>().enabled = false;
            print("camara");
            transform.position = Vector3.Lerp(start, end, tiempo);
            if (Vector3.Distance(transform.position, end) <= 1)
            {
                transform.parent.GetComponent<PlayerCamera>().enabled = true;
                inicio = false;

                transform.position = posicionNormal;
            }

        }
    }
}
