using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookCamera : MonoBehaviour
{
    public Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = this.transform.position - m_Camera.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, m_Camera.transform.rotation * Vector3.up);
        
    }

    void RotationEngine() {
        Vector3 cameraVector = Camera.main.transform.position - transform.position;
        float newYangle = Mathf.Atan2(cameraVector.z, cameraVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -1 * newYangle, 0);

    }
}
