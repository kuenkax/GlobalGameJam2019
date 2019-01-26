using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float velocity;
    public int damage;
    public float lifeTime;

    public bool MiniGun;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the bullet
        //transform.Translate( transform.forward * velocity * Time.deltaTime );
        var p = transform.position;
        p += transform.forward * velocity * Time.deltaTime;
        transform.position = p;

        Debug.DrawRay(transform.position,transform.forward * 10, Color.yellow );  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //other.gameObject.health.(Funcion)(damage);
        }
    }
}
