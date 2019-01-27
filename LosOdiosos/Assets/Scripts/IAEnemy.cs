using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy : MonoBehaviour
{
    GameObject player;

    private static List<GameObject> allEnemies = new List<GameObject>();
    // Movement speed in units/sec.
    public float mov_force = 100;

    public float minimumDistance = 1f;

    public int EnemyID;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnEnable()
    {
        allEnemies.Add(gameObject);
    }

    private void OnDisable()
    {
        allEnemies.Remove(gameObject);
    }


    public float minDistToPlayer = 1f;



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextPos = Vector3.zero;
        float dis;
        int pos = allEnemies.IndexOf(gameObject) + 1;
        for(int i = pos; i < allEnemies.Count; i++)
        {
            //dis = transform.position - allEnemies[i].transform.position;
            dis = Vector3.Distance(transform.position, allEnemies[i].transform.position);
            if (dis <= minimumDistance)
            {
                nextPos += transform.position - allEnemies[i].transform.position;
            }
        }
        dis = Vector3.Distance(transform.position, player.transform.position);

        if (dis > minDistToPlayer)
        {
            if (EnemyID == 0)
            {
                nextPos -= transform.position - player.transform.position;
            }
            else if (EnemyID == 1)
            {
                nextPos -= transform.position - player.transform.position;
            }
            else if (EnemyID == 2)
            {
                nextPos -= transform.position - player.transform.position;
            }

            
        }
        GetComponent<Rigidbody>().AddForce(nextPos * mov_force);
    }
}
