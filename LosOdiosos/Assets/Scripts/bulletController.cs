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

        Debug.DrawRay(transform.position,transform.forward * 10, Color.yellow );  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Vector3 dir = other.GetContact(0).point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * pushForce);
            other.gameObject.GetComponent<Health>().SetDamage(damage);
            Destroy(gameObject);
        }
    }
}
