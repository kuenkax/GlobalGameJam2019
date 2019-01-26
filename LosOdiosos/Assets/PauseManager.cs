using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Animator Fade;
    public GameObject Pause;
    bool EscPressed;
    public KeyCode Esc;
    public int SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Fade").GetComponent<Animator>();
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
        Fade.SetTrigger("FadeIn");
    }
    public void FadeOut() {
        Fade.SetTrigger("FadeOut");
    }

    public void ChangeScene() {
        Scene sceneLoaded = SceneManager.GetActiveScene();
        if (sceneLoaded.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        

    }
}
