using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneDo(int SceneN)
    {
        SceneManager.LoadScene(SceneN);
        // Start is called before the first frame update
    }
}
