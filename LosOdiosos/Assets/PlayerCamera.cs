using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PlayerCamera : MonoBehaviour {
    public static PlayerCamera I;

    public Transform target;
    public Transform cam;
    public Camera _cam;
    public Transform aim;
    public LayerMask mask;


    [Range(0.1f, 20f)]
    public float pos_lerp_speed = 1f;

    private void OnEnable() {
        I = this;
        _cam = GetComponentInChildren<Camera>();
    }

    RaycastHit[] hits = new RaycastHit[32];

    void Update() {
        var pos = transform.position;
        transform.position = Vector3.Lerp( pos, target.position, pos_lerp_speed * Time.deltaTime );;

        //cam.LookAt( target );

        var mouse_pos = Input.mousePosition;
        var ray = _cam.ScreenPointToRay(mouse_pos);
        //Debug.DrawRay( ray.origin, ray.direction * 100f, Color.red, 0.1f );

        var closest = Vector3.zero;
        var min_dist = Mathf.Infinity;
        var n_hits = Physics.RaycastNonAlloc( ray, hits, 100f, mask );
        for ( var i = 0; i < n_hits; i++) {
            if ( hits[i].distance < min_dist ) {
                min_dist = hits[i].distance;
                closest = hits[i].point;
            }
        }
        //Debug.DrawRay( closest, Vector3.up, Color.green, 0.1f );
        aim.position = closest;
    }

}