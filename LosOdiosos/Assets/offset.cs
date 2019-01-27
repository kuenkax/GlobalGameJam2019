using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offset : MonoBehaviour
{

    public Renderer myRenderer;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRenderer.material.mainTextureOffset = new Vector2 (Time.time * velocidad, 0);
    }
}
