using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timeDuration;
    float timer;
    Quaternion end;
    float velocidad;
    public GameObject container;
    public Animator house;
    public GameObject player;
    public GameObject weapon;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //regla de 3
        velocidad = (30 * 11.832f) / timeDuration;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= timeDuration)
        {
            timer += Time.deltaTime;
            transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
            StartCoroutine(EndRound());
        }
    }

    private IEnumerator EndRound()
    {
        //Deshabilitar jugador
        player.GetComponent<Player>().enabled = false;
        weapon.SetActive(false);
        yield return new WaitWhile(() => MovePlayerToPos() > 0.5f);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        house.SetBool("appear", true);
        player.GetComponent<Player>().ChangeWeapon();
        yield return new WaitWhile(() => Input.anyKeyDown == false);
        house.SetBool("appear",false);
        weapon.SetActive(true);
        player.GetComponent<Player>().enabled = true;
        timer = 0;
    }

    private float MovePlayerToPos()
    {
        Vector3 dir = (new Vector3(0f, 1.5f, 0f) - player.transform.position).normalized * speed;
        player.GetComponent<Rigidbody>().AddForce(dir);
        return Vector3.Distance(new Vector3(0f, 1.5f, 0f), player.transform.position);
    }

}
