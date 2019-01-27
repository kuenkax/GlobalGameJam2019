using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool finished;
    public AudioClip[] music;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
        var clip = music[Random.Range(0, music.Length)];
        var asrc = GetComponent<AudioSource>();
        asrc.clip = clip;
        asrc.Play();

        //regla de 3
        velocidad = (30 * 11.832f) / timeDuration;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeDuration - timer <= 10)
        {
//            camara.GetComponent<CameraAnimations>().Alejar();
        }
        if (timer <= timeDuration)
        {
            timer += Time.deltaTime;
            transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
        }
        else
        {
            if(!finished){
                finished = true;
                transform.rotation = Quaternion.identity;
                foreach (Transform child in container.transform)
                {
                    Destroy(child.gameObject);
                }
                StartCoroutine(EndRound());
            }
            
        }
    }

    public CameraShake camShake;
    public AudioClip casaClip;
    public Text nRounds;

    private IEnumerator EndRound()
    {
        //Deshabilitar jugador
        player.GetComponent<Player>().enabled = false;
        weapon.SetActive(false);
        camShake.shaking = false;
        EnemiesGenerator.i.running = false;
        yield return new WaitWhile(() => MovePlayerToPos() > 0.5f);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        house.SetBool("appear", true);
        player.GetComponent<Health>().health = 100;
        player.GetComponent<Player>().updatehealth();
        var asrc = GetComponent<AudioSource>();
        asrc.Stop();
        asrc.clip = casaClip;
        asrc.Play();

        var rounds = int.Parse( nRounds.text );
        nRounds.text = ( rounds + 1 ).ToString();

        player.GetComponent<Player>().ChangeWeapon();
        yield return new WaitWhile(() => Input.anyKeyDown == false);
        house.SetBool("appear",false);

        var clip = music[Random.Range(0, music.Length)];
        asrc.clip = clip;
        asrc.Play();

        weapon.SetActive(true);
        player.GetComponent<Player>().enabled = true;
        timer = 0;
        finished = false;
        EnemiesGenerator.i.running = true;
    }

    private float MovePlayerToPos()
    {
        Vector3 dir = (new Vector3(0f, 2f, 0f) - player.transform.position).normalized * speed;
        player.GetComponent<Rigidbody>().AddForce(dir);
        return Vector3.Distance(new Vector3(0f, 2f, 0f), player.transform.position);
    }

}
