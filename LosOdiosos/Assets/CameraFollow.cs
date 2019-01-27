using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 defaultOffset;
    private Camera camera;
    private Vector3 offsetForOffset;
    private float maxDistance;
    private float scaleFactor;
    public Transform lookAt;

    private bool smooth = true;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 10, -10);

    void Start()
    {
        defaultOffset = new Vector3(0, 10, -10);
        scaleFactor = 0.5f; //This is to make the camera not go all the way to the mouse cursor position, tweak it until it feels right.
        maxDistance = 3.0f; //This limits how far the camera can go from the player, tweak it until it feels right.
    }



    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            offsetForOffset = (hit.point - lookAt.position) * scaleFactor;
        }
        else
            offsetForOffset = Vector3.zero; // This makes it so that if the camera raycast doesn't hit, we go to directly over the player.
        if (offsetForOffset.magnitude > maxDistance)
        {
            offsetForOffset.Normalize(); // Make the vector3 have a magnitude of 1
            offsetForOffset = offsetForOffset * maxDistance;
        }
        offset = defaultOffset + offsetForOffset;

        Vector3 desiredPosition = lookAt.transform.position + offset;

        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}

