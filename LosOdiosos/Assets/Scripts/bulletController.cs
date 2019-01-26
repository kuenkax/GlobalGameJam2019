using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float velocity;
    public int damage;
    public float lifeTime;
    public float pushForce;

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

        //Debug.DrawRay(transform.position,transform.forward * 10, Color.yellow );
    }

    public float push_force = 3;

    private void OnCollisionEnter(Collision collision ) {
        Debug.LogFormat("OnCollisionEnter");

        if ( collision.transform.tag == "Enemy" ) {
            var dir = collision.GetContact(0).point - transform.position;
            dir.Normalize();
            collision.gameObject.GetComponent<Rigidbody>().AddForce( dir * push_force );
            collision.gameObject.GetComponent<Health>().SetDamage(damage);
            Destroy(gameObject); // self destruct
        }
    }
}
