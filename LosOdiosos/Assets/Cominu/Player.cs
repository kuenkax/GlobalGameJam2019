using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rbody;
    public Vector3 mov_dir; // movement direction
    public float mov_force = 100;


    private void OnEnable() {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update() {
    }


    private void FixedUpdate() {
        var old_mov_dir = mov_dir;
        mov_dir.x = Input.GetAxis("Horizontal");
        mov_dir.z = Input.GetAxis("Vertical");
        /*
        var dot = Vector3.Dot( old_mov_dir, mov_dir );
        if ( dot < 0.5) {
            rbody.velocity = Vector3.zero; // change of direction: stop it!
        }*/

        rbody.AddForce( mov_dir * mov_force );
    }
}


