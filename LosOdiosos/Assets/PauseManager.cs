using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject Pause, GameOver;
    bool EscPressed;
    public KeyCode Esc;
    private bool muerto;
    private Scene sceneActual;

    // Start is called before the first frame update
    void Start()
    {
        muerto = false;
        Scene sceneActual = SceneManager.GetActiveScene();
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

        if (muerto == true && Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneActual.buildIndex);
        }
        
    }

    public void ChangeScene() {
        
        if (sceneActual.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        

    }

    public void GameOverUI() {
        GameOver.SetActive(true);
        muerto = true;

    }
}
