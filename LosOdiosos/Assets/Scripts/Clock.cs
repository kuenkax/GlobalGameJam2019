using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timeDuration;
    Quaternion end;
    float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        //regla de 3
        velocidad = (30 * 12) / timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < timeDuration)
        {
            transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
        }
    }
}
