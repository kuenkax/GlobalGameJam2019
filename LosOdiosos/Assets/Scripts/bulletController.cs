using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float velocity;
    public float damage;
    public float lifeTime;

    public 


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        //Move the bullet
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
