using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject FadeInObj;
    public GameObject FadeOutObj;
    public GameObject Pause;
    bool EscPressed;
    public KeyCode Esc;

    // Start is called before the first frame update
    void Start()
    {
        EscPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(Esc))
        {
            if (!EscPressed)
            {
                Pause.SetActive(true);
                EscPressed = true;
                Time.timeScale = 0;
            }
            else
            {
                Pause.SetActive(false);
                EscPressed = false;
                Time.timeScale = 1;
            }
        }
        
    }
    public void FadeIn() {
        FadeInObj.SetActive(true);
    }
    public void FadeOut() {
        FadeOutObj.SetActive(true);
    }
}
