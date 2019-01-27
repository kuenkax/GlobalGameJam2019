using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookCamera : MonoBehaviour
{
    void Update()
    {
        var targetVector = this.transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, Camera.main.transform.rotation * Vector3.up);
    }
}
