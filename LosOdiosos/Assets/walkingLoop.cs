using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingLoop : MonoBehaviour
{

    public AudioClip Walk;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            AS.Play();

        }
        else
        {
            AS.Pause();
        }
    }
}
