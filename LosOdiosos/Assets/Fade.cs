using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    private GameObject FadeObj;
    private void Start()
    {
        ;
    }
    public void FadeIn()
    {
        this.gameObject.SetActive(true);
    }
    public void FadeOut()
    {
        Destroy(this.gameObject);
    }
}
