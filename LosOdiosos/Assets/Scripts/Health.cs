using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    public System.Action OnDeath;


    public void SetDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            if ( OnDeath != null ) OnDeath();
            else Destroy(gameObject);
        }
    }
}
