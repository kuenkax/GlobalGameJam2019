using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rbody;
    public Vector3 mov_dir; // movement direction
    public float mov_force = 100;
    public SpriteRenderer sr;
    public Transform wpn_rotator;
    
    public SpriteRenderer sr_wpn;

    private void OnEnable() {
        rbody = GetComponent<Rigidbody>();
    }

    public float r = 100f;
    public float r2;

    private void Update() {
        // flip the character if aiming left/right
        sr.flipX = PlayerCamera.I.aim.transform.position.x < rbody.position.x;

        var dir = ( PlayerCamera.I.aim.position - rbody.position ).normalized;
        r = Vector3.Angle( dir, Vector3.right );
        r2 = Vector3.Angle( dir, Vector3.forward );
        if ( r2 < 90f ) {
            r = -r;
        }


        wpn_rotator.localRotation = Quaternion.Euler( 0, r, 0 );

        while ( r > 360f ) r -= 360f;
        while ( r < 0f   ) r += 360f;

        sr_wpn.flipX = !( r < 90f || r > 270 );
    }


    private void FixedUpdate() {
        var old_mov_dir = mov_dir;
        mov_dir.x = Input.GetAxis("Horizontal");
        mov_dir.z = Input.GetAxis("Vertical");
        rbody.AddForce( mov_dir * mov_force );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 100);
        }
    }
}


