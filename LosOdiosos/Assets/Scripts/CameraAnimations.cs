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
    bool appeared;
    bool changed;
    
   
    // Start is called before the first frame update
    void Start()
    {
        inicio = true;
        posicionNormal = transform.position;
        transform.position = posicionFinal.position;
    }

    // Update is called once per frame
    public void Alejar()
    {
        appeared = true;
        final = true;
    }
    void Update()
    {
       
      if( appeared )
        {
            ActivarAnimacion(posicionNormal , posicionFinal.position);
           
        }
        if (inicio)
        {
            ActivarAnimacion(posicionFinal.position, posicionNormal);
            final = true;
        }
        
       
    }
    void ActivarAnimacion(Vector3 start, Vector3 end)
    {
        
            transform.parent.GetComponent<PlayerCamera>().enabled = false;

            transform.position = Vector3.Lerp(transform.position, end, tiempo);
            if (Vector3.Distance(transform.position, end) <= 1)
            {

            if(casa.GetComponent<Animator>().GetBool("appear") == true)
            {
                transform.position = posicionNormal;
            }
            if (final)
            {
                transform.parent.GetComponent<PlayerCamera>().enabled = true;
                
            }
            inicio = false;
           
              
            }

        
    }
}
