using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy1 : MonoBehaviour
{
    GameObject player;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    public float minimumDistance = 1f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Keep a note of the time the movement started.
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = new Vector3(player.transform.position.x - minimumDistance
            , player.transform.position.y, player.transform.position.z - minimumDistance);
        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, nextPos);
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        Vector3 newPos = Vector3.Lerp(transform.position, nextPos, fracJourney);
        if (minimumDistance < journeyLength)
        {
            transform.position = newPos;
        }
    }
}
