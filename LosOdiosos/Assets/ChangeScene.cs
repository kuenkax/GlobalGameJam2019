using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneDo()
    {
        Scene SceneActual= SceneManager.GetActiveScene();
        if (SceneActual.buildIndex == 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        // Start is called before the first frame update
    }
}
