using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmotion : MonoBehaviour
{
    public float slowTime;
    public float scale;
    float time;
    float ultima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stop(slowTime,scale);

        }
    }
    public void Stop(float tiempo,float escala)
    {
        if (isStop) return;
       
        ultima = Time.realtimeSinceStartup;
        StartCoroutine(StopTime(tiempo,escala));
    }
    bool isStop;

    public IEnumerator StopTime(float tiempo, float escala)
    {
        
     
        print(time);
        isStop = true;
        while(isStop && Time.realtimeSinceStartup - ultima <= tiempo)
        {
           
                Time.timeScale = escala;
               
            
            yield return null;
        }
        
        Time.timeScale = 1;
        isStop = false;
    }
}
