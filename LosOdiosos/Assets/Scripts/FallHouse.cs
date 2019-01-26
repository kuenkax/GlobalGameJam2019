using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHouse : MonoBehaviour
{
    public GameObject Casa;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void CaerCasa() {
        Vector3 posicionGenerar = new Vector3(0, 10, 0);
        Instantiate(Casa, posicionGenerar, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
