using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    Vector3 posicionNormal;
    public Transform posicionFinal;
    public float tiempo;
    bool fin;
    // Start is called before the first frame update
    void Start()
    {
        posicionNormal = transform.position;
        transform.position = posicionFinal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fin)
        {
            transform.parent.GetComponent<PlayerCamera>().enabled = false;
            print("camara");
            transform.position = Vector3.Lerp(transform.position, posicionNormal, tiempo);
            if(Vector3.Distance(transform.position,posicionNormal) <= 1)
            {
                transform.parent.GetComponent<PlayerCamera>().enabled = true;
                fin = true;
                print(fin);
                transform.position = posicionNormal;
            }
            
        }
       
    }
}
