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

    public GameObject Bullet;

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

        sr_wpn.flipY = !( r < 90f || r > 270 );

        var wpn_rot = Quaternion.Euler( 0f, 0f, -r );
        sr_wpn.transform.localRotation = wpn_rot;

        var time_between_shots = 0.1f; // TODO: put this in the weapon prefab

        var time_since_last_shot = Time.realtimeSinceStartup - last_shot_time;
        if ( time_since_last_shot > time_between_shots ) {
            if ( Input.GetMouseButton(0) ) {
                cam_shake.ShakeIt();
                last_shot_time = Time.realtimeSinceStartup;

                var aim_dir = Quaternion.Euler(0, r, 0 ) * Vector3.right;

                //Debug.DrawRay( sr_wpn.transform.position, aim_dir * 1, Color.cyan , 10f );
                var bullet = Instantiate( Bullet, sr_wpn.transform.position, Quaternion.identity );
                bullet.transform.LookAt( sr_wpn.transform.position + aim_dir );
            }
        }

        if ( Input.GetMouseButtonUp(0) ) {
            cam_shake.shaking = false;
        }
    }

    public CameraShake cam_shake;
    public float last_shot_time = 0;


    private void FixedUpdate() {
        var old_mov_dir = mov_dir;
        mov_dir.x = Input.GetAxis("Horizontal");
        mov_dir.z = Input.GetAxis("Vertical");
        if ( mov_dir.magnitude > 0.5 ) mov_dir.Normalize();
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


